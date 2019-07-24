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
    /// Classhandles all the configuration requests from EISCs
    /// </summary>
    public class SYSM_ConfigurationHandler
    {
        /* Changelog:
         * v1.0.02: Added LG LCDs to ConfigureDisplay()
         * */

        public const string CLASSID = "CNFG";

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

        public SYSM_ConfigurationHandler(ControlSystem controlSystem)
        {
            this.controlSystem = controlSystem;
        }

        /// <summary>
        /// Configure the headend matrix
        /// </summary>
        /// <param name="args">
        /// SYNTAX: [name]|[IP]
        /// EXAMPLE: Evertz|10.156.25.10</param>
        public void ConfigureMatrix(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix with {1}...", CLASSID, args.Sig.StringValue); }
                controlSystem.MTRXEvertz = new MTRX_EvertzQuartz();
                controlSystem.MTRXEvertz.OnCommandToSend += new MTRX.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.MTRXEvertz.OnFeedbackUpdate += new MTRX.FeedbackUpdate(controlSystem.ModuleHasUpdate);
                controlSystem.MTRXEvertz.Name = args.Sig.StringValue.Split('|')[0];

                controlSystem.MTRXEvertzClient = new TCPClient(args.Sig.StringValue.Split('|')[1], MTRX_EvertzQuartz.IPPORT, 5000);
                controlSystem.MTRXEvertzClient.SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);
                //SocketErrorCodes err = controlSystem.MTRXEvertzClient.ConnectToServer();

                controlSystem.mtrxSignals = new MTRXSignals();
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix as {1} named {2} on IP {3}", CLASSID, controlSystem.MTRXEvertz.ToString(), controlSystem.MTRXEvertz.Name, controlSystem.MTRXEvertzClient.AddressClientConnectedTo); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        /// <summary>
        /// Configure an input on the matrix
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number % 700 is the GUID
        /// SYNTAX: [name]|[Evertz Input Number]
        /// EXAMPLE: room 123|24</param>
        public void ConfigureMatrixInput(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                int id = (int)args.Sig.Number % 700;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Input with {1}...", CLASSID, args.Sig.StringValue); }
                controlSystem.mtrxSignals.AddInput(id, Int32.Parse(args.Sig.StringValue.Split('|')[1]), args.Sig.StringValue.Split('|')[0]);
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Input with guid {1} named {2} with Evertz number {3}", CLASSID, id, controlSystem.mtrxSignals.Inputs[id].Name, controlSystem.mtrxSignals.Inputs[id].SignalNumber); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "NAK"));
            }   
        }

        /// <summary>
        /// Configure an output on the matrix
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number is the GUID
        /// SYNTAX: [name]|[Evertz Output Number]
        /// EXAMPLE: room 123|24</param>
        public void ConfigureMatrixOutput(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Output with {1}...", CLASSID, args.Sig.StringValue); }
                controlSystem.mtrxSignals.AddOutput((int)args.Sig.Number, Int32.Parse(args.Sig.StringValue.Split('|')[1]), args.Sig.StringValue.Split('|')[0]);
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Output with guid {1} named {2} with Evertz number {3}", CLASSID, args.Sig.Number, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].Name, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].SignalNumber); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "NAK"));
            } 
        }

        /// <summary>
        /// Configure a camera
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number % 50 is the GUID
        /// SYNTAX: [name]|[IP]
        /// EXAMPLE: Camera01|10.156.26.141</param>
        public void ConfigureCamera(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                int id = (int)args.Sig.Number % 50;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Camera {1} with {2}...", CLASSID, id, args.Sig.StringValue); }
                controlSystem.CAMSony[id] = new CAM_Sony();
                controlSystem.CAMSony[id].Name = args.Sig.StringValue.Split('|')[0];
                controlSystem.CAMSony[id].OnCommandToSend += new CAM_Sony.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.CAMSony[id].OnFeedbackUpdate += new CAM_Sony.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                controlSystem.camSonyClients[id] = new UDPServer(args.Sig.StringValue.Split('|')[1], CAM_Sony.IpPort, 5000);
                controlSystem.camSonyClients[id].ReceiveDataAsync(controlSystem.UDPServerReceiveCallback);
                SocketErrorCodes err =  controlSystem.camSonyClients[id].EnableUDPServer();
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Camera {1} named {2} with IP {3}", CLASSID, id, controlSystem.CAMSony[id].Name, controlSystem.camSonyClients[id].AddressToAcceptConnectionFrom); };

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "NAK"));
            } 
        }

        /// <summary>
        /// Configure the headend DSP
        /// </summary>
        /// <param name="args">
        /// SYNTAX: [name]|[IP]
        /// EXAMPLE: QSC Core|10.156.24.62</param>
        public void ConfigureDSP(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring DSP with {1}...", CLASSID, args.Sig.StringValue); }
                controlSystem.DSPQSC = new DSP_QSCCore();
                controlSystem.DSPQSC.OnCommandToSend += new DSP_QSCCore.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.DSPQSC.OnFeedbackUpdate += new DSP_QSCCore.FeedbackUpdate(controlSystem.ModuleHasUpdate);
                controlSystem.DSPQSC.Name = args.Sig.StringValue.Split('|')[0];

                controlSystem.DSPQSCClient = new TCPClient(args.Sig.StringValue.Split('|')[1], DSP_QSCCore.IPPORT, 5000);
                controlSystem.DSPQSCClient.SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured DSP as {1} named {2} on IP {3}", CLASSID, controlSystem.DSPQSC.ToString(), controlSystem.DSPQSC.Name, controlSystem.DSPQSCClient.AddressClientConnectedTo); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DspEiscIndices, args.Sig.Number, "  ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DspEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        /// <summary>
        /// Configure a control point in the DSP
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number is the GUID
        /// SYNTAX: [name]|[Volume named control]|[Mute named control]
        /// EXAMPLE: Room 04|R04_Wmic01_gain_volLevel|R04_Wmic01_gain_muteState </param>
        public void ConfigureDSPSignal(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring DSP Signal {1} with {2}...", CLASSID, args.Sig.Number, args.Sig.StringValue); }
                controlSystem.DSPQSC.RegisterSignal(args.Sig.Number, args.Sig.StringValue.Split('|')[0], args.Sig.StringValue.Split('|')[1], args.Sig.StringValue.Split('|')[2]);
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured DSP signal with index {1} as named {2} with volume named control {3} and mute named control {4}", CLASSID, args.Sig.Number, controlSystem.DSPQSC.dSPQSCSignal[args.Sig.Number].VolumeName, controlSystem.DSPQSC.dSPQSCSignal[args.Sig.Number].VolNamedControl, controlSystem.DSPQSC.dSPQSCSignal[args.Sig.Number].MuteNamedControl); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DspEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DspEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        /// <summary>
        /// Configure a display
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number is the GUID
        /// SYNTAX: [name]|[IP or COMPort number]|[display type]
        /// EXAMPLE: 5th 60p Sony|10.156.26.129|SONYLCD
        /// EXAMPLE: Test Serial LG|COMPort1|LG
        /// See cse statements for displya types</param>
        public void ConfigureDisplay(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Display {1} with {2}...", CLASSID, args.Sig.Number, args.Sig.StringValue); }
                // Format: Name|IP|Model
                Display display = new Display();
                display.Guid = (int)args.Sig.Number;

                int portNumber = -1;
                ComPort.ComPortSpec comspec = new ComPort.ComPortSpec();

                #region Get the display type. For LG, also get the comms type
                switch (args.Sig.StringValue.Split('|')[2].ToUpper())
                {
                    case ("BARCO"):
                        {
                            display.Controller = new DPLY_BarcoProjector_LAN();
                            portNumber = DPLY_BarcoProjector_LAN.IpPort;
                            break;
                        }
                    case ("CHRISTIE"):
                        {
                            display.Controller = new DPLY_ChristieProjector_LAN();
                            portNumber = DPLY_ChristieProjector_LAN.IpPort;
                            break;
                        }
                    case ("LG"):
                        {
                            display.Controller = new DPLY_LGLCD();

                            if (args.Sig.StringValue.Split('|')[1].ToUpper().Contains("COMPORT"))
                            {
                                portNumber = -2;
                                comspec = DPLY_LGLCD.GetComspec();
                            }
                            else
                            {
                                portNumber = ControlSystem.GLOBALCACHESERIALPORTIPPORT;
                            }
                            break;
                        }
                    case ("SONYPROJECTOR"):
                        {
                            display.Controller = new DPLY_SonyProjector_LAN();
                            portNumber = DPLY_SonyProjector_LAN.IpPort;
                            break;
                        }
                    case ("SONYLCD"):
                        {
                            display.Controller = new DPLY_SonyLCD_LAN();
                            portNumber = DPLY_SonyLCD_LAN.IpPort;
                            break;
                        }
                    case ("SONY232"):
                        {
                            display.Controller = new DPLY_SonyLCD_RS232C();
                            portNumber = -2;
                            break;
                        }
                    default:
                        {
                            if (debug) { CrestronConsole.PrintLine("{0} !!! Cannot match display type: {1}", CLASSID, args.Sig.StringValue.Split('|')[2].ToUpper()); }
                            controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "NAK"));
                            return;
                        }
                }
                #endregion

                if (display.Controller != null)
                {
                    display.Controller.Name = args.Sig.StringValue.Split('|')[0];

                    #region Set communications 
                    if (portNumber > 0 )           //Port number is not negative = TCP IP client
                    {
                        display.Client = new TCPClient();
                        display.Client.AddressClientConnectedTo = args.Sig.StringValue.Split('|')[1];
                        display.Client.PortNumber = portNumber;
                        display.Client.SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);
                    }
                    else if (portNumber == -2)      //Port number is -2 = TCP IP client
                    {
                        //uint port = UInt32.Parse(PWCConvert.ReturnNumbersOnly(args.Sig.StringValue.Split('|')[1]));
                        uint port = UInt32.Parse(ReturnNumbersOnly(args.Sig.StringValue.Split('|')[1]));
                        display.SerialPort = controlSystem.ComPorts[port];
                        display.SerialPort.SetComPortSpec(comspec);
                        display.SerialPort.SerialDataReceived += new ComPortDataReceivedEvent(controlSystem.SerialPort_SerialDataReceived);

                        controlSystem.DeviceForComPort.Add(display.SerialPort, display); 
                    }
                    #endregion

                    #region Check if GUID exists. IF so remove it. Then add dislay to list.
                    int index = controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number);
                    if (index != -1)
                    {
                        CrestronConsole.PrintLine("{0} *** Removing Display at index {1} from DisplayList, Type {2} with IP of {3}", CLASSID, index, controlSystem.DisplaysList[index].Controller.ToString(), controlSystem.DisplaysList[index].Client.AddressClientConnectedTo);
                        controlSystem.DisplaysList.RemoveAt(index);
                    }
                    controlSystem.DisplaysList.Add(display);
                    #endregion

                    // Register callbacks.
                    display.Controller.OnCommandToSend += new DPLY_SonyLCD_RS232C.CommandToSend(controlSystem.ModuleNeedsToSend);
                    display.Controller.OnFeedbackUpdate += new DPLY_SonyLCD_RS232C.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                    #region Update EISC with configuration sucessful
                    if (display.Client != null)
                    {
                        CrestronConsole.PrintLine("{0} *** Configured Display {1} as {2} named {3} on IP {4}", CLASSID, args.Sig.Number, display.Controller.ToString(), display.Controller.Name, display.Client.AddressClientConnectedTo);
                    }
                    else if (display.SerialPort != null)
                    {
                        CrestronConsole.PrintLine("{0} *** Configured Display {1} as {2} named {3} on COM {4}", CLASSID, args.Sig.Number, display.Controller.ToString(), display.Controller.Name, display.SerialPort.ID);
                    }
                    else
                    {
                        if (debug) { CrestronConsole.PrintLine("{0} !!! IMPOSSIBLE Didn't find client nor serial port", CLASSID); }
                        controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "NAK"));
                    }
                    controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "ACK"));
                    #endregion
                }
                else
                {
                    if (debug) { CrestronConsole.PrintLine("{0} !!! IMPOSSIBLE Cannot match display type: {1}", CLASSID, args.Sig.StringValue.Split('|')[2].ToUpper()); }
                    controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "NAK"));
                }
                
            }
            catch(Exception e)
            {
                if (debug) { CrestronConsole.PrintLine("{0} ### exception caugh in : ConfigureDisplay(): {1}", CLASSID, e); }
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void ConfigureRelay(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                //Format: Name|IP
                int id = (int)args.Sig.Number % 100;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Relays {1} and {2} with {3}...", CLASSID, id, id+1, args.Sig.StringValue); }
                controlSystem.RLYGlobalCache[id] = new RLY_GlobalCache();
                controlSystem.RLYGlobalCache[id].Name = args.Sig.StringValue.Split('|')[0];
                controlSystem.RLYGlobalCache[id].OnCommandToSend += new RLY_GlobalCache.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.RLYGlobalCache[id].OnFeedbackUpdate += new RLY_GlobalCache.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                controlSystem.RLYGlobalCacheClients[id] = new TCPClient(args.Sig.StringValue.Split('|')[1], RLY_GlobalCache.IpPort, 5000);
                controlSystem.RLYGlobalCacheClients[id].SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Relays {1} and {2} named {3} with IP {4}", CLASSID, id, id + 1, controlSystem.RLYGlobalCache[id].Name, controlSystem.RLYGlobalCacheClients[id].AddressClientConnectedTo); };

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        //public void ConfigureImageProcessor(SigEventArgs args)
        //{

        //}

        private string ReturnNumbersOnly(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string cleaned = new string(s.Where(char.IsDigit).ToArray());
            return cleaned;
        }
    }

    public class ConfigArgs
    {
        public int[] EiscIndices;
        public uint SignalNumber;
        public string SignalValue;

        public ConfigArgs(int[] EiscIndices, uint SignalNumber, string SignalValue)
        {
            this.EiscIndices = EiscIndices;
            this.SignalNumber = SignalNumber;
            this.SignalValue = SignalValue;
        }
    }
}