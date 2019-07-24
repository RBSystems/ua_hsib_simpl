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
    public class SYSM_EISCHandler
    {
        public const string CLASSID = "EISC";

        //public const string PRO3IP1 = "10.156.27.100";
        public const string PRO3IP1 = "10.156.27.103";      // DEBUGGING

        public int[] MtrxEiscIds = { 0x81 };
        public int[] DspEiscIds = { 0x82 };
        public int[] DplyCamEiscIds = { 0x83 };
        public int[] IgmpRlyPartEiscIds = { 0x84 };

        public int[] MtrxEiscIndices = { 0 };
        public int[] DspEiscIndices = { 1 };
        public int[] DplyCamEiscIndices = { 2 };
        public int[] IgmpRlyPartEiscIndices = { 3 };

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
        private bool debug = true;

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
                parseMTRXSignal(args);
            }
            else if( DspEiscIds.Contains((int)currentDevice.ID) )
            {
                parseDSPSignal(args);
            }
            else if (DplyCamEiscIds.Contains((int)currentDevice.ID))
            {
                parseDPLYorCAMSignal(args);
            }
            //else if (Array.IndexOf(IgmpRlyPartEiscIds, currentDevice.ID) != -1)
            //{
            //    parseIMGPorPARTorRLYSignal(args);
            //}
        }

        private void parseMTRXSignal(SigEventArgs args)
        {
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
                    CrestronConsole.PrintLine("{0} parseEvertzSignal() - String {1} is empty; skipping", CLASSID, args.Sig.Number);
                }

            }
        }

        private void parseDSPSignal(SigEventArgs args)
        {
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
        }

        private void parseDPLYorCAMSignal(SigEventArgs args)
        {
            // check if signal is bool (digital) and true (high)
            if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == true)
            {
                #region Display commands
                // Display power toggle
                if (args.Sig.Number >= 1 && args.Sig.Number <= 199)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
                    controlSystem.DisplaysList[index].Controller.TogglePower();
                    //Thread t = new Thread(Test, null, Thread.eThreadStartOptions.Running);
                }
                // Display Power On
                else if (args.Sig.Number >= 201 && args.Sig.Number <= 399)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
                    controlSystem.DisplaysList[index].Controller.PowerOn();
                }
                // Display Power Off
                else if (args.Sig.Number >= 401 && args.Sig.Number <= 599)
                {
                    int index = controlSystem.DisplaysList.FindIndex(display => display.Guid == (int)args.Sig.Number % 200);
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
            }
        }

        //private void parseIMGPorPARTorRLYSignal(SigEventArgs args)
        //{
        //    // check if signal is bool (digital) and true (high)
        //    if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == true)
        //    {
        //        if (args.Sig.Number >= 101 && args.Sig.Number <= 199)
        //        {
        //            int number = (int)args.Sig.Number - 100;
        //            int unit = ((number - 1) / 2) + 1;
        //            int relay = ((number - 1) % 2) + 1;

        //            controlSystem.RLYGlobalcache[unit].SetRelay(relay);
        //        }
        //    }
        //    else if (args.Sig.Type == eSigType.Bool && args.Sig.BoolValue == false)
        //    {
        //        if (args.Sig.Number >= 101 && args.Sig.Number <= 199)
        //        {
        //            int number = (int)args.Sig.Number - 100;
        //            int unit = ((number - 1) / 2) + 1;
        //            int relay = ((number - 1) % 2) + 1;

        //            controlSystem.RLYGlobalcache[unit].ResetRelay(relay);
        //        }
        //    }
        //}

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
            else if (device.GetType() == typeof(CAM_Sony))
            {
                //
            }
            else if (device.GetType() == typeof(DSP_QSCCore))
            {
                DSPArgs args = (DSPArgs)value;
                foreach (int id in DspEiscIds)
                {
                    controlSystem.eiscs[id].UShortInput[args.Signal].UShortValue = args.CrestronRange;
                }
            }
            else if (device.GetType() == typeof(SYSM_ConfigurationHandler))
            {
                ConfigArgs args = (ConfigArgs)value;
                foreach (int index in args.EiscIndices)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1:X} >>> String {2} = {3}", CLASSID, index, args.SignalNumber, args.SignalValue); }
                    controlSystem.eiscs[index].StringInput[args.SignalNumber].StringValue = args.SignalValue;
                }
            }
            //else if (device.GetType() == typeof(RLY_GlobalCache))
            //{
            //    for (int x = 1; x < controlSystem.RLYGlobalcache.Length; x++)
            //    {
            //        if (device == controlSystem.RLYGlobalcache[x])
            //        {
            //            RLYArgs args = (RLYArgs)value;

            //            foreach (int id in IgmpRlyPartEiscIds)
            //            {
            //                int index = ((x - 1) * 2) + args.Relay;
            //                controlSystem.eiscs[id].BooleanInput[(uint)index].BoolValue = args.IsRelayClosed;
            //            }
            //            break;
            //        }
            //    }
            //} 
            //else if (device.GetType() == typeof(DPLY))
            //{
            //    for (int x = 1; x < controlSystem.DisplayList.Length; x++)
            //    {
            //        if (device == controlSystem.DisplayList[x])
            //        {
            //            DPLYArgs args = (DPLYArgs)value;
            //            switch (args.FeedbackType)
            //            {
            //                case (DPLY.FeedbackType.Power):
            //                    {
            //                        bool isPowered = false;
            //                        if (args.Power == DPLY.Power.On)
            //                        {
            //                            isPowered = true;
            //                        }

            //                        foreach (int id in DplyCamEiscIds)
            //                        {
            //                            controlSystem.eiscs[id].BooleanInput[(uint)(200 + x)].BoolValue = isPowered;
            //                            controlSystem.eiscs[id].BooleanInput[(uint)(400 + x)].BoolValue = !isPowered;
            //                        }
            //                        break;
            //                    }
            //            }
            //            break;
            //        }
            //    }
            //}
        }
    }
}