using System;
using Crestron.SimplSharp;                          	// For Basic SIMPL# Classes
using Crestron.SimplSharpPro;                       	// For Basic SIMPL#Pro classes
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading
using Crestron.SimplSharpPro.Diagnostics;		    	// For System Monitor Access
using Crestron.SimplSharpPro.DeviceSupport;         	// For Generic Device Support
using Crestron.SimplSharpPro.EthernetCommunication;
using PWCUtils;
using PWCSharpPro;
using System.Collections.Generic;
using Crestron.SimplSharpPro.UI;
using Crestron.SimplSharpPro.ThreeSeriesCards;
using Crestron.SimplSharpPro.GeneralIO;
using Crestron.SimplSharp.CrestronSockets;
using System.Globalization;
using System.Linq;

namespace UofA_HSIB_Pro
{
    /// <summary>
    /// Class handles data coming from and going to the EISCs. THis class is the "last stop" for all signals.
    /// </summary>
    public class SYSM_EISCHandler
    {
        /* Changelog:
         * v1.0.02: Adding threading
         * v1.0.03: Added DPLY feedback
         *          Added DSP feedback
         * v1.0.04: Fixed bug: Relay controllers after 1 were not mapping units correctly due to bad maths 
         * v1.0.05: BC Added camera control via analog signals
         * v1.0.06: Added analog display controls
         * */
        public const string CLASSID = "EISC";

        public const string PRO3IP1 = "10.156.27.100";
        //public const string PRO3IP1 = "192.168.1.105";      // DEBUGGING

        // The IPIDs for each EISC
        public int[] MtrxEiscIds = { 0x81 };
        public int[] DspEiscIds = { 0x82 };
        public int[] DplyCamEiscIds = { 0x83 };
        public int[] IgmpRlyPartLghtEiscIds = { 0x84 };

        // The indices of each EISC
        public int[] MtrxEiscIndices = { 0 };
        public int[] DspEiscIndices = { 1 };
        public int[] DplyCamEiscIndices = { 2 };
        public int[] IgmpRlyPartLghtEiscIndices = { 3 };

        public bool Debug
        {
            get
            {
                return debug;
            }
            set
            {
                debug = value;
            }
        }
        private bool debug = false;

        ControlSystem controlSystem;

        public SYSM_EISCHandler(ControlSystem controlSystem)
        {
            this.controlSystem = controlSystem;
        }

        /// <summary>
        /// Initialises, sets up, registers, and subscribes to the events for the EISCs
        /// </summary>
        public void RegisterEISCs()
        {
            controlSystem.eiscs = new ThreeSeriesTcpIpEthernetIntersystemCommunications[4];

            controlSystem.eiscs[0] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x81, PRO3IP1, controlSystem);
            controlSystem.eiscs[1] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x82, PRO3IP1, controlSystem);
            controlSystem.eiscs[2] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x83, PRO3IP1, controlSystem);
            controlSystem.eiscs[3] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x84, PRO3IP1, controlSystem);

            controlSystem.eiscs[0].Description = "Matrix Control";
            controlSystem.eiscs[1].Description = "DSP Control";
            controlSystem.eiscs[2].Description = "Display and Camera Control";
            controlSystem.eiscs[3].Description = "Relay, Lights, and Image Processor Control";

            foreach (ThreeSeriesTcpIpEthernetIntersystemCommunications eisc in controlSystem.eiscs)
            {
                eisc.Register();
                eisc.OnlineStatusChange += new OnlineStatusChangeEventHandler(controlSystem.ControlSystem_OnlineStatusChange);
                eisc.SigChange += new SigEventHandler(EISC_SigChange);
            }
        }

        /// <summary>
        /// Invoked when a change in an EISC is detected
        /// </summary>
        /// <param name="currentDevice"></param>
        /// <param name="args"></param>
        public void EISC_SigChange(BasicTriList currentDevice, SigEventArgs args)
        {
            if (debug)
            {
                if (args.Sig.Type == eSigType.String) { CrestronConsole.PrintLine("{0} {1:X} <<< {2} {3} = {4}", CLASSID, currentDevice.ID, args.Sig.Type, args.Sig.Number, args.Sig.StringValue); }
                else if (args.Sig.Type == eSigType.UShort) { CrestronConsole.PrintLine("{0} {1:X} <<< {2} {3} = {4}", CLASSID, currentDevice.ID, args.Sig.Type, args.Sig.Number, args.Sig.UShortValue); }
                else if (args.Sig.Type == eSigType.Bool) { CrestronConsole.PrintLine("{0} {1:X} <<< {2} {3} = {4}", CLASSID, currentDevice.ID, args.Sig.Type, args.Sig.Number, args.Sig.BoolValue); }
                else { CrestronConsole.PrintLine("{0} {1} <<< {2} {3}", CLASSID, currentDevice.ID, args.Sig.Type, args.Sig.Number); }
            }

            if( MtrxEiscIds.Contains((int)currentDevice.ID) )
            {
                new Thread(parseMTRXSignal, args, Thread.eThreadStartOptions.Running);
            }
            else if( DspEiscIds.Contains((int)currentDevice.ID) )
            {
                new Thread(parseDSPSignal, args, Thread.eThreadStartOptions.Running);
            }
            else if (DplyCamEiscIds.Contains((int)currentDevice.ID))
            {
                new Thread(parseDPLYorCAMSignal, args, Thread.eThreadStartOptions.Running);
            }
            else if (IgmpRlyPartLghtEiscIds.Contains((int)currentDevice.ID))
            {
                new Thread(parseIMGPorRLYorLGHTSignal, args, Thread.eThreadStartOptions.Running);
            }
        }

        /// <summary>
        /// Handles incoming signals from the matrix EISC
        /// </summary>
        /// <param name="_args"></param>
        /// <returns></returns>
        private object parseMTRXSignal(object _args)
        {
            SigEventArgs args = (SigEventArgs)_args;
            // Polling command. Index is output to poll. Check signal is true (pressed) and is boolean (digital)
            if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == true)
            {
                if (args.Sig.Number >= 1 && args.Sig.Number <= 699)
                {
                    uint Output = (uint)controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].SignalNumber;
                    controlSystem.MTRXEvertz.PollOutput(PWCSharpPro.MTRX.Signal.Video, Output);
                }
            }
            // Routing command. Index is output, value is input. Check signal is ushort (analog)
            else if (args.Sig.Type == eSigType.UShort)
            {
                if (args.Sig.Number >= 1 && args.Sig.Number <= 699)
                {
                    if (controlSystem.mtrxSignals != null)
                    {
                        int Output = controlSystem.mtrxSignals.GetOutputForGuid((int)args.Sig.Number);
                        int Input = controlSystem.mtrxSignals.GetInputForGuid((int)args.Sig.UShortValue);
                        if (debug) { CrestronConsole.PrintLine("{0} Queueing Out {1} In {2}", CLASSID, Output, Input); }

                        if (Output != -1 && Input != -1)
                        {
                            controlSystem.MTRXEvertz.SetInputForOutput(PWCSharpPro.MTRX.Signal.Video, (uint)Output, (uint)Input);
                        }
                        else
                        {
                            foreach(int x in MtrxEiscIndices)
                            {
                                controlSystem.eiscs[x].UShortInput[args.Sig.Number].UShortValue = 65535 ;
                            }
                        }
                    }
                }
            }
            else if (args.Sig.Type == eSigType.String)
            {
                if (args.Sig.StringValue.Length != 0)
                {
                    if (args.Sig.Number == 700)
                    {
                        controlSystem.ConfigurationHandler.ConfigureMatrix(args);
                    }
                    else if (args.Sig.Number >= 1 && args.Sig.Number <= 699)
                    {
                        controlSystem.ConfigurationHandler.ConfigureMatrixOutput(args);
                    }
                    else if (args.Sig.Number >= 701 && args.Sig.Number <= 1399)
                    {
                        controlSystem.ConfigurationHandler.ConfigureMatrixInput(args);
                    }
                }
                else
                {
                    //CrestronConsole.PrintLine("{0} parseEvertzSignal() - String {1} is empty; skipping", CLASSID, args.Sig.Number);
                }

            }

            return null;
        }

        /// <summary>
        /// Handles incoming signals from the DSP EISC
        /// </summary>
        /// <param name="_args"></param>
        /// <returns></returns>
        private object parseDSPSignal(object _args)
        {
            SigEventArgs args = (SigEventArgs)_args;
            // Set Volume command. Index is signal number, value is level. Check signal is ushort (analog)
            if (args.Sig.Type == eSigType.UShort)
            {
                if (args.Sig.Number >= 1 && args.Sig.Number <= 499)
                {
                    if (args.Sig.UShortValue < 32767) 
                    { 
                        controlSystem.DSPQSC.SetVolume(args.Sig.Number, (float)args.Sig.UShortValue); 
                    }
                    else
                    {
                        controlSystem.DSPQSC.SetVolume(args.Sig.Number, (float)((65536 - args.Sig.UShortValue) * -1));
                    }
                }
            }
            // Boolean (digital) values
            else if (args.Sig.Type == eSigType.Bool)
            {
                // Mute command. Mute on when value is true, mute off when value is false
                if (args.Sig.Number >= 1 && args.Sig.Number <= 499)
                {
                    if (args.Sig.BoolValue == true)
                    {
                        controlSystem.DSPQSC.MuteOn(args.Sig.Number);
                    }
                    else
                    {
                        controlSystem.DSPQSC.MuteOff(args.Sig.Number);
                    }
                }
                // Preset recall command
                else if (args.Sig.Number >= 501 && args.Sig.Number <= 599)
                {
                    controlSystem.DSPQSC.RecallPreset(args.Sig.Number - 500);
                }
                // Routing command
                else if (args.Sig.Number >= 1001 && args.Sig.Number <= 1499)
                {
                    int output = (int)args.Sig.Number % 1000;
                    controlSystem.DSPQSC.SetPoint(output, args.Sig.UShortValue);
                }
            }
            else if (args.Sig.Type == eSigType.String)
            {
                if (args.Sig.Number == 500)
                {
                    controlSystem.ConfigurationHandler.ConfigureDSP(args);
                }
                else if (args.Sig.Number >= 1 && args.Sig.Number <= 499)
                {
                    controlSystem.ConfigurationHandler.ConfigureDSPSignal(args);
                }
            }
            return null;
        }

        /// <summary>
        /// Handles incoming signals from the display and camera EISC
        /// </summary>
        /// <param name="_args"></param>
        /// <returns></returns>
        private object parseDPLYorCAMSignal(object _args)
        {
            SigEventArgs args = (SigEventArgs)_args;
            // 
            CAM_Sony thisCam = controlSystem.CAMSony[args.Sig.Number % 50];
            
            // check if signal is bool (digital) and true (high)
            if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == true)
            {
                #region Display commands
                // Display power toggle
                if (args.Sig.Number >= 1 && args.Sig.Number <= 199)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
                    controlSystem.DisplaysList[index].Controller.TogglePower();
                }
                // Display Power On
                else if (args.Sig.Number >= 201 && args.Sig.Number <= 399)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
                    //CrestronConsole.PrintLine("QUEUEING POWER ON FOR DISPLAY {0}", args.Sig.Number % 200);
                    controlSystem.DisplaysList[index].Controller.PowerOn();
                }
                // Display Power Off
                else if (args.Sig.Number >= 401 && args.Sig.Number <= 599)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
                    //CrestronConsole.PrintLine("QUEUEING POWER OFF FOR DISPLAY {0}", args.Sig.Number % 200);
                    controlSystem.DisplaysList[index].Controller.PowerOff();
                }
                // Display Input 1
                else if (args.Sig.Number >= 601 && args.Sig.Number <= 799)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
                    controlSystem.DisplaysList[index].Controller.SwitchtoInput(DPLY.Input.HDMI1);
                }
                #endregion

                #region Camera digital commands
                // Camera Up
                //else if (args.Sig.Number >= 1301 && args.Sig.Number <= 1349)
                if (args.Sig.Number >= 1301 && args.Sig.Number <= 1349)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveCamera(CAM.Move.Up);
                }
                // Camera down
                else if (args.Sig.Number >= 1351 && args.Sig.Number <= 1399)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveCamera(CAM.Move.Down);
                }
                // Camera left
                else if (args.Sig.Number >= 1401 && args.Sig.Number <= 1449)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveCamera(CAM.Move.Left);
                }
                // Camera right
                else if (args.Sig.Number >= 1451 && args.Sig.Number <= 1499)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveCamera(CAM.Move.Right);
                }
                // Camera zoom in
                else if (args.Sig.Number >= 1500 && args.Sig.Number <= 1549)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].ZoomCamera(CAM.Zoom.In);
                }
                // Camera zoom out
                else if (args.Sig.Number >= 1551 && args.Sig.Number <= 1599)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].ZoomCamera(CAM.Zoom.Out);
                }
                // Camera focus in
                else if (args.Sig.Number >= 1601 && args.Sig.Number <= 1649)
                {
                    
                }
                // Camera focus out
                else if (args.Sig.Number >= 1651 && args.Sig.Number <= 1699)
                {

                }
                // Camera stop
                else if (args.Sig.Number >= 1701 && args.Sig.Number <= 1749)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveCamera(CAM.Move.Stop);
                }
                #endregion
            }
            else if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == false)
            {
                //Camera PTZ is released - send stop
                if (args.Sig.Number >= 1301 && args.Sig.Number <= 1749)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveCamera(CAM.Move.Stop);
                }
            }
            else if (args.Sig.Type == eSigType.UShort)
            {
                #region Camera analog commands
                int thisVal = (int)args.Sig.UShortValue;

                // Camera Preset Recall
                if (args.Sig.Number >= 1301 && args.Sig.Number <= 1349)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].MoveToPreset((int)args.Sig.UShortValue);
                }
                // Camera Preset Save
                else if (args.Sig.Number >= 1351 && args.Sig.Number <= 1399)
                {
                    controlSystem.CAMSony[args.Sig.Number % 50].SavePreset((int)args.Sig.UShortValue);
                }
                // Camera folded control
                // 0 = Stop, 1 = Up, 2 = Down, 3 = Left, 4 = Right, 5 = Zoom In, 6 = Zoom Out, 7 = Focus Near, 8 = Focus Far, 9 = Power On, 10 = Power Off, 
                // 101-116 = Recall Preset [1-16], 201-216 = Store Preset [1-16]
                else if (args.Sig.Number >= 1401 && args.Sig.Number <= 1449)
                {
                    if (thisVal >= 0 && thisVal <= 99)
                    {
                        switch ((int)args.Sig.UShortValue)
                        {
                            case 0: thisCam.MoveCamera(CAM.Move.Stop);  break;
                            case 1: thisCam.MoveCamera(CAM.Move.Up);    break;
                            case 2: thisCam.MoveCamera(CAM.Move.Down);  break;
                            case 3: thisCam.MoveCamera(CAM.Move.Left);  break;
                            case 4: thisCam.MoveCamera(CAM.Move.Right); break;
                            case 5: thisCam.MoveCamera(CAM.Zoom.In);    break;
                            case 6: thisCam.MoveCamera(CAM.Zoom.Out);   break;
                            case 7: thisCam.PowerOn();                  break;
                            case 8: thisCam.PowerOff();                 break;
                        }
                    }
                    else if (thisVal > 100 && thisVal <= 199)
                    {
                        thisCam.MoveToPreset(thisVal);
                    }
                    else if (thisVal > 200 && thisVal <= 299)
                    {
                        thisCam.SavePreset(thisVal);
                    }
                }
                #endregion

                #region Display commands
                if (args.Sig.Number >= 1 && args.Sig.Number <= 199)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);

                    switch (args.Sig.UShortValue)
                    {
                        case(1):
                            {
                                controlSystem.DisplaysList[index].Controller.SwitchtoInput(DPLY.Input.HDMI1);
                                break;
                            }
                        case (2):
                            {
                                controlSystem.DisplaysList[index].Controller.SwitchtoInput(DPLY.Input.HDMI2);
                                break;
                            }
                        case (10):
                            {
                                controlSystem.DisplaysList[index].Controller.PowerOff();
                                break;
                            }
                        case (11):
                            {
                                controlSystem.DisplaysList[index].Controller.PowerOn();
                                break;
                            }
                        //case (99):
                        //    {
                        //        controlSystem.DisplaysList[index].Controller.SelfDestruct();
                        //        break;
                        //    }
                    }
                   
                }
                #endregion
            }
            else if (args.Sig.Type == eSigType.String)
            {
                // Configuration
                if (args.Sig.Number >= 1 && args.Sig.Number <= 199)
                {
                    controlSystem.ConfigurationHandler.ConfigureDisplay(args);
                }
                else if (args.Sig.Number >= 1301 && args.Sig.Number <= 1349)
                {
                    controlSystem.ConfigurationHandler.ConfigureCamera(args);
                }
                #region LG display specific: Control a single display in a daisy chain
                /* Summary
                 * args.Sig.Number % 200 is guid
                 * SYNTAX:  [LG display ID]|[command]
                 * EXAMPLE 1|On
                 * Valid command values: On, Off
                 * */
                else if (args.Sig.Number >= 201 && args.Sig.Number <= 399)
                {
                    try
                    {
                        int guid = (int)args.Sig.Number % 200;
                        int id = Int32.Parse(args.Sig.StringValue.Split('|')[0]);
                        string cmd = args.Sig.StringValue.Split('|')[1].ToUpper();

                        if (controlSystem.DisplaysList.First(disp => disp.Guid == guid).Controller.GetType() == typeof(DPLY_LGLCD))
                        {
                            DPLY_LGLCD display = (DPLY_LGLCD)controlSystem.DisplaysList.First(disp => disp.Guid == guid).Controller;
                            if (cmd == "ON")
                            {
                                display.PowerOn(id);
                                UpdateEISCSignal(this, new EISCArgs(args.Sig.Number, "ACK"));
                            }
                            else if (cmd == "OFF")
                            {
                                display.PowerOff(id);
                                UpdateEISCSignal(this, new EISCArgs(args.Sig.Number, "ACK"));
                            }
                        }
                    }
                    catch
                    {
                        UpdateEISCSignal(this, new EISCArgs(args.Sig.Number, "NAK"));
                    }
                }
                #endregion
            }
            return null;
        }

        /// <summary>
        /// Handles incoming signals from the image processor and relay EISC
        /// </summary>
        /// <param name="_args"></param>
        /// <returns></returns>
        private object parseIMGPorRLYorLGHTSignal(object _args)
        {
            SigEventArgs args = (SigEventArgs)_args;

            // check if signal is bool (digital) and true (high)
            if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == true)
            {
                if (args.Sig.Number >= 101 && args.Sig.Number <= 199)
                {
                    int number = (int)args.Sig.Number % 100;
                    int unit = number;
                    if (unit % 2 == 0)  { unit--; }
                    int relay = ((number - 1) % 2) + 1;
                    CrestronConsole.PrintLine("UNIT {0} RELAY {1}: TRUE", unit, relay);
                    controlSystem.RLYGlobalCache[unit].SetRelay(relay);
                }
                #region Lighting Control
                else if (args.Sig.Number >= 1001 && args.Sig.Number <= 1199)
                {
                    int roomNumber = (int)args.Sig.Number % 50;
                    int Scene = (int)(args.Sig.Number / 50) - 19;
                    int Device = controlSystem.LGHTDeviceForRoom[roomNumber];
                    controlSystem.LghtLutron[Device].RecallPreset(roomNumber, Scene);
                }
                else if (args.Sig.Number >= 1201 && args.Sig.Number <= 1249)
                {
                    int roomNumber = (int)args.Sig.Number % 50;
                    int Device = controlSystem.LGHTDeviceForRoom[roomNumber];
                    controlSystem.LghtLutron[Device].RecallPreset(roomNumber, 0);
                }
                #endregion
                
            }
            else if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == false)
            {
                if (args.Sig.Number >= 101 && args.Sig.Number <= 199)
                {
                    int number = (int)args.Sig.Number % 100;
                    //int unit = ((number - 1) / 2) + 1;
                    int unit = number;
                    if (unit % 2 == 0) { unit--; }
                    int relay = ((number - 1) % 2) + 1;

                    CrestronConsole.PrintLine("UNIT {0} RELAY {1}: FALSE", unit, relay);
                    controlSystem.RLYGlobalCache[unit].ResetRelay(relay);
                }
            }
            else if (args.Sig.Type == eSigType.String)
            {
                // Configuration
                if (args.Sig.Number >= 101 && args.Sig.Number <= 199)
                {
                    controlSystem.ConfigurationHandler.ConfigureRelay(args);
                }
                else if (args.Sig.Number >= 1001 && args.Sig.Number <= 1049)
                {
                    controlSystem.ConfigurationHandler.ConfigureLightID(args);
                }
                else if (args.Sig.Number >= 1101 && args.Sig.Number <= 1109)
                {
                    controlSystem.ConfigurationHandler.ConfigureLight(args);
                }
            }
            return null;
        }

        /// <summary>
        /// Upodates the relevant EISCs and their signals based the object type and index
        /// For example, MTRX index 10 will update [ushort / analog 10] with value for the MTRX EISCs
        /// </summary>
        /// <param name="device"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void UpdateEISCSignal(object device, object value)
        {
            if (debug) { CrestronConsole.PrintLine("{0} *** {1} wants to update EISC", CLASSID, device); }

            #region Matrix feedback
            if (device.GetType() == typeof(MTRX_EvertzQuartz))
            {
                MTRXArgs args = (MTRXArgs)value;
                foreach (int index in MtrxEiscIndices)
                {
                    int outputGuid = controlSystem.mtrxSignals.GetGuidForOutput((int)args.Ouput);
                    int inputGuid = controlSystem.mtrxSignals.GetGuidForInput((int)args.Input);

                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> Analog {2} = {3}", CLASSID, index, outputGuid, inputGuid); }
                    if (outputGuid != -1)
                    {
                        controlSystem.eiscs[index].UShortInput[(uint)outputGuid].UShortValue = (ushort)inputGuid;
                    }
                }
            }
            #endregion
            #region Camera Feedback
            else if (device.GetType() == typeof(CAM_Sony))
            {
                //
            }
            #endregion
            #region DSP feedback
            else if (device.GetType() == typeof(DSP_QSCCore))
            {
                DSPArgs args = (DSPArgs)value;

                switch (args.FeedbackType)
                {
                    case (DSP.FeedbackType.Volume):
                        {
                            foreach (int index in DspEiscIndices)
                            {
                                if (args.Volume < 0)
                                {
                                    controlSystem.eiscs[index].UShortInput[args.Signal].UShortValue = (ushort)(65536 + args.Volume);
                                }
                                else
                                {
                                    controlSystem.eiscs[index].UShortInput[args.Signal].UShortValue = (ushort)args.Volume;
                                }
                            }
                            break;
                        }
                    case (DSP.FeedbackType.Mute):
                        {
                            foreach (int index in DspEiscIndices)
                            {
                                controlSystem.eiscs[index].BooleanInput[args.Signal].BoolValue = args.IsMuted;
                            }
                            break;
                        }
                }
            }
            #endregion
            #region Config feedback
            else if (device.GetType() == typeof(SYSM_ConfigurationHandler))
            {
                ConfigArgs args = (ConfigArgs)value;
                foreach (int index in args.EiscIndices)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> String {2} = {3}", CLASSID, index, args.SignalNumber, args.SignalValue); }
                    controlSystem.eiscs[index].StringInput[args.SignalNumber].StringValue = args.SignalValue;
                }
            }
            #endregion
            #region Relay Feedback
            else if (device.GetType() == typeof(RLY_GlobalCache))
            {
                RLYArgs args = (RLYArgs)value;

                int unit = Array.IndexOf(controlSystem.RLYGlobalCache, (RLY_GlobalCache)device);
                uint join = (uint)(100 + ((unit - 1) * 2) + args.Relay);

                foreach (int index in IgmpRlyPartLghtEiscIndices)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> Bool {2} = {3}", CLASSID, unit, join, args.IsRelayClosed); }
                    controlSystem.eiscs[index].BooleanInput[join].BoolValue = args.IsRelayClosed;
                }
            }
            #endregion
            #region Display Feedback
            else if (device.GetType().IsSubclassOf(typeof(DPLY)))
            {
                DPLYArgs args = (DPLYArgs)value;

                Display display =  controlSystem.DisplaysList.Find(x => x.Controller == device);
                uint PowerOnJoin = (uint)display.Guid + 200;
                uint PowerOffJoin = (uint)display.Guid + 400;

                switch (args.FeedbackType)
                {
                    case(DPLY.FeedbackType.Power):
                        {
                            if (args.Power == DPLY.Power.On)
                            {
                                foreach (int index in DplyCamEiscIndices)
                                {
                                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> Bool {2} = {3}", CLASSID, index, PowerOnJoin, true); }
                                    controlSystem.eiscs[index].BooleanInput[PowerOnJoin].BoolValue = true;

                                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> Bool {2} = {3}", CLASSID, index, PowerOffJoin, false); }
                                    controlSystem.eiscs[index].BooleanInput[PowerOffJoin].BoolValue = false;
                                }
                            }
                            else if (args.Power == DPLY.Power.Off)
                            {
                                foreach (int index in DplyCamEiscIndices)
                                {
                                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> Bool {2} = {3}", CLASSID, index, PowerOnJoin, false); }
                                    controlSystem.eiscs[index].BooleanInput[PowerOnJoin].BoolValue = false;

                                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> Bool {2} = {3}", CLASSID, index, PowerOffJoin, true); }
                                    controlSystem.eiscs[index].BooleanInput[PowerOffJoin].BoolValue = true;
                                }
                            }
                            break;
                        }
                }
            }
            #endregion
            #region EISC Feedback - currently only for LG Displays
            else if(device.GetType() == typeof(SYSM_EISCHandler))
            {
                EISCArgs args = (EISCArgs)value;
                foreach (int index in DplyCamEiscIndices)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> String {2} = {3}", CLASSID, index, args.Number, args.StringValue); }
                    controlSystem.eiscs[index].StringInput[args.Number].StringValue = args.StringValue;
                }
            }
            #endregion
        }
    }

    public class EISCArgs
    {
        public uint Number;
        public string StringValue;

        public EISCArgs(uint Number, string StringValue)
        {
            this.Number = Number;
            this.StringValue = StringValue;
        }
    }
}
