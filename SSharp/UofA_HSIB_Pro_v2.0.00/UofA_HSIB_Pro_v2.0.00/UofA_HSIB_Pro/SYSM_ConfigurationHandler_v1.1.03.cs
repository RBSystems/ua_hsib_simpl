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
         * v1.0.03: Compacted code, made code more efficient
         * v1.1.00: Inbound configuration has changed, updated module accordingly
         *          Display configuration changed
         * v1.1.01: Matrix configuration changed          
         * v1.1.02: DSP configuration changed
         *          Marix configuration changed again - CMD -> CMD_IO
         * v1.1.03: Camera configuration changed          
         *          Relay configuration changed
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
        /// EXAMPLE: {MTRX_VSRC; guid=001: global_name=source_global1, local_name=source_local1, room_ass=01, local_id=3, function_id=2, filter_id=4, is_virtual=0, v_link=0,|}</param>
        public void ConfigureMatrixInput(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Input with {1}...", CLASSID, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                int guid = (int)args.Sig.Number % 700;
                string name = "";
                int number = -1;

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case ("GLOBAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("CMD_IO"):
                            {
                                number = Int32.Parse( ReturnNumbersOnly( value));
                                break;
                            }
                    }
                }
                #endregion

                controlSystem.mtrxSignals.AddInput(guid, number, name);
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Input with guid {1} named {2} with Evertz number {3}", CLASSID, (int)args.Sig.Number % 700, controlSystem.mtrxSignals.Inputs[(int)args.Sig.Number % 700].Name, controlSystem.mtrxSignals.Inputs[(int)args.Sig.Number % 700].SignalNumber); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "ACK"));
            }
            catch (Exception e)
            {
                if (debug) { CrestronConsole.PrintLine("{0} ### exception caught in : ConfigureMatrixInput(): {1}", CLASSID, e); }
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

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                int guid = (int)args.Sig.Number;
                string name = "";
                int number = -1;

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case ("GLOBAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("CMD_IO"):
                            {
                                number = Int32.Parse(ReturnNumbersOnly(value));
                                break;
                            }
                    }
                }
                #endregion

                controlSystem.mtrxSignals.AddOutput(guid, number, name);
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Output with guid {1} named {2} with Evertz number {3}", CLASSID, (int)args.Sig.Number, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].Name, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].SignalNumber); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "ACK"));
            }
            catch (Exception e)
            {
                if (debug) { CrestronConsole.PrintLine("{0} ### exception caught in : ConfigureMatrixOutput(): {1}", CLASSID, e); }
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

                int Guid = (int)args.Sig.Number % 50;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Camera {1} with {2}...", CLASSID, Guid, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                string name = "";
                string ip = "";

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case ("GLOBAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("IP"):
                            {
                                ip = value;
                                break;
                            }
                    }
                }
                #endregion

                controlSystem.CAMSony[Guid] = new CAM_Sony();
                controlSystem.CAMSony[Guid].Name = name;
                controlSystem.CAMSony[Guid].OnCommandToSend += new CAM_Sony.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.CAMSony[Guid].OnFeedbackUpdate += new CAM_Sony.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                controlSystem.camSonyClients[Guid] = new UDPServer(ip, CAM_Sony.IpPort, 5000);
                controlSystem.camSonyClients[Guid].ReceiveDataAsync(controlSystem.UDPServerReceiveCallback);
                controlSystem.camSonyClients[Guid].EnableUDPServer();
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Camera {1} named {2} with IP {3}", CLASSID, Guid, controlSystem.CAMSony[Guid].Name, controlSystem.camSonyClients[Guid].AddressToAcceptConnectionFrom); };

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

                // Update fire alarm preset client address too.
                //controlSystem.DSPIPAddress = args.Sig.StringValue.Split('|')[1];

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
        /// EXAMPLE: {DSP_POINTS; guid=001: global_name=myDSPPoint01,local_name=myDSPPoint01, room_ass=01, local_index=01, point_type=1|} </param>
        public void ConfigureDSPSignal(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring DSP Signal {1} with {2}...", CLASSID, args.Sig.Number, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                uint guid = args.Sig.Number;
                string name = "";
                string vol = "";
                string mute = "";

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case ("GLOBAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("CMD_VOL"):
                            {
                                vol = value;
                                break;
                            }
                        case ("CMD_MUTE"):
                            {
                                mute = value;
                                break;
                            }
                    }
                }
                #endregion

                controlSystem.DSPQSC.RegisterSignal(guid, name, vol, mute);

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
        /// EXAMPLE:  {DPLY;guid=01: global_name=myDPLY01,local_name=myDPLY01, ip=123.123.123.123, device_type=sony_lcd, room_ass=01, local_index=01|}
        /// EXAMPLE: Test Serial LG|COMPort1|LG
        /// See cse statements for displya types</param>
        public void ConfigureDisplay(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Display {1} with {2}...", CLASSID, args.Sig.Number, args.Sig.StringValue); }
                Display display = new Display();
                display.Guid = (int)args.Sig.Number;

                int portNumber = -1;
                
                ComPort.ComPortSpec comspec = new ComPort.ComPortSpec();

                string name = "";
                string ip = "";
                uint comPort = 0;

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];
//CrestronConsole.PrintLine("FLAG 5 - key: {0}, value: {1}", key, value);

                    switch (key.ToUpper())
                    {
                        case ("GLOBAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("IP"):
                            {
                                ip = value;
                                break;
                            }
                        case ("COM_PORT"):
                            {
                                comPort = UInt32.Parse(value);
                                break;
                            }
                        case ("DEVICE_TYPE"):
                            {
                                switch (value.ToUpper())        //device_type=[sony_lcd,sony_proj,lg_lcd,barco_lcd,Christie_lcd]
                                {
                                    case ("SONY_LCD"):
                                        {
                                            display.Controller = new DPLY_SonyLCD_LAN();
                                            portNumber = DPLY_SonyLCD_LAN.IpPort;
                                            break;
                                        }
                                    case ("SONY_PROJ"):
                                        {
                                            display.Controller = new DPLY_SonyProjector_LAN();
                                            portNumber = DPLY_SonyProjector_LAN.IpPort;
                                            break;
                                        }
                                    case ("LG_LCD"):
                                        {
                                            display.Controller = new DPLY_LGLCD();
                                            portNumber = ControlSystem.GLOBALCACHESERIALPORTIPPORT;
                                            break;
                                        }
                                    case ("BARCO_PROJ"):
                                        {
                                            display.Controller = new DPLY_BarcoProjector_LAN();
                                            portNumber = DPLY_BarcoProjector_LAN.IpPort;
                                            break;
                                        }
                                    case ("CHRISTIE_PROJ"):
                                        {
                                            display.Controller = new DPLY_ChristieProjector_LAN();
                                            portNumber = DPLY_ChristieProjector_LAN.IpPort;
                                            break;
                                        }
                                }
                                break;
                            }

                    }
                }
                #endregion

                display.Controller.Name = name;
                display.Controller.Guid = (int)args.Sig.Number;

                #region Set Communications
                if (comPort != 0)
                {
//CrestronConsole.PrintLine("FLAG 6B - comPort: {0}", comPort);
                    comspec = DPLY_LGLCD.GetComspec();
                    display.SerialPort = controlSystem.ComPorts[comPort];
                    display.SerialPort.SetComPortSpec(comspec);
                    display.SerialPort.SerialDataReceived += new ComPortDataReceivedEvent(controlSystem.SerialPort_SerialDataReceived);

                    controlSystem.DeviceForComPort.Add(display.SerialPort, display);
                }
                else if (ip != "" && portNumber != -1)
                {
//CrestronConsole.PrintLine("FLAG 6A - IP: {0} Port {1}", ip, portNumber);
                    display.Client = new TCPClient();
                    display.Client.AddressClientConnectedTo = ip;
                    display.Client.PortNumber = portNumber;
                    display.Client.SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);
                }

                #endregion

                #region Check if GUID exists. IF so remove it. Then add dislay to list.
                if (controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number) != -1)
                {
                    CrestronConsole.PrintLine("{0} *** Removing Display at index {1} from DisplayList, Type {2} with IP of {3}", CLASSID, controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number), controlSystem.DisplaysList[controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number)].Controller.ToString(), controlSystem.DisplaysList[controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number)].Client.AddressClientConnectedTo);
                    controlSystem.DisplaysList.RemoveAt(controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number));
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
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DplyCamEiscIndices, args.Sig.Number, "ACK"));
                #endregion

            }
            catch(Exception e)
            {
                if (debug) { CrestronConsole.PrintLine("{0} ### exception caught in : ConfigureDisplay(): {1}", CLASSID, e); }
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
                int Guid = (int)args.Sig.Number % 100;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Relays {1} and {2} with {3}...", CLASSID, Guid, Guid+1, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                string name = "";
                string ip = "";

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case ("GLOBAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("IP"):
                            {
                                ip = value;
                                break;
                            }
                    }
                }
                #endregion

                controlSystem.RLYGlobalCache[Guid] = new RLY_GlobalCache();
                controlSystem.RLYGlobalCache[Guid].Name = name;
                controlSystem.RLYGlobalCache[Guid].OnCommandToSend += new RLY_GlobalCache.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.RLYGlobalCache[Guid].OnFeedbackUpdate += new RLY_GlobalCache.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                controlSystem.RLYGlobalCacheClients[Guid] = new TCPClient(ip, RLY_GlobalCache.IpPort, 5000);
                controlSystem.RLYGlobalCacheClients[Guid].SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Relays {1} and {2} named {3} with IP {4}", CLASSID, Guid, Guid + 1, controlSystem.RLYGlobalCache[Guid].Name, controlSystem.RLYGlobalCacheClients[Guid].AddressClientConnectedTo); };
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        public void ConfigureImageProcessor(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                int id = (int)args.Sig.Number % 50;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Image processor {1} with {2}...", CLASSID, id, args.Sig.StringValue); }
                controlSystem.IMGPTvOne[id] = new IMGP_TVOne();
                controlSystem.IMGPTvOne[id].Name = args.Sig.StringValue.Split('|')[0];
                controlSystem.IMGPTvOne[id].OnCommandToSend += new IMGP_TVOne.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.IMGPTvOne[id].OnFeedbackUpdate += new IMGP_TVOne.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                controlSystem.IMGPTvOneClients[id] = new TCPClient(args.Sig.StringValue.Split('|')[1], IMGP_TVOne.IpPort, 5000);
                controlSystem.IMGPTvOneClients[id].SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Image processor {1} named {2} with IP {3}", CLASSID, id, controlSystem.IMGPTvOne[id].Name, controlSystem.IMGPTvOneClients[id].AddressClientConnectedTo); };
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
            }

        }

        public void ConfigureLight(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                int id = (int)args.Sig.Number % 10;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Lighting controller {1} with {2}...", CLASSID, id, args.Sig.StringValue); }
                controlSystem.LghtLutron[id] = new LGHT_Lutron();
                controlSystem.LghtLutron[id].Name = args.Sig.StringValue.Split('|')[0];
                controlSystem.LghtLutron[id].OnCommandToSend += new LGHT_Lutron.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.LghtLutron[id].OnFeedbackUpdate += new LGHT_Lutron.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                uint port = UInt32.Parse(ReturnNumbersOnly(args.Sig.StringValue.Split('|')[1]));
                controlSystem.ComPorts[port].SetComPortSpec(LGHT_Lutron.GetComspec());
                controlSystem.ComPorts[port].SerialDataReceived += new ComPortDataReceivedEvent(controlSystem.SerialPort_SerialDataReceived);

                controlSystem.DeviceForComPort.Add(controlSystem.ComPorts[port], controlSystem.LghtLutron[id]);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Image processor {1} named {2} on COM {3}", CLASSID, id, controlSystem.LghtLutron[id].Name, port); };
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        public void ConfigureLightID(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0) { return; }

                int RoomGuid = (int)args.Sig.Number % 50;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Lighting ID {1} with {2}...", CLASSID, RoomGuid, args.Sig.StringValue); }
                //ID|Name|Lutron Device GUID; guid of signal is index
                string RoomID = args.Sig.StringValue.Split('|')[0];
                string RoomName = args.Sig.StringValue.Split('|')[1];
                int Device = Int32.Parse( args.Sig.StringValue.Split('|')[2]);
                if (controlSystem.LghtLutron[Device] == null)
                {
                    controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
                    return;
                }
                controlSystem.LghtLutron[Device].SetRoomID(RoomGuid, RoomID, RoomName);
                controlSystem.LGHTDeviceForRoom.Add(RoomGuid, Device);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Lighting ID {1} named {2} with Lutron ID {3} on Lutron Device {4}", CLASSID, RoomGuid, controlSystem.LghtLutron[Device].RoomSignals[RoomGuid].Name, controlSystem.LghtLutron[Device].RoomSignals[RoomGuid].LutronID, Device); };
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "ACK"));
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
            }
        }


        /// <summary>
        /// Returns the all the numbers from a string
        /// </summary>
        /// <param name="s">The string to extract numbers from</param>
        /// <returns>All numbers from string as a string</returns>
        private string ReturnNumbersOnly(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string cleaned = new string(s.Where(char.IsDigit).ToArray());
            return cleaned;
        }

        /// <summary>
        /// Remove all the fluff from Ben's config, and return key-value pairs in a string array
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private string[] ReturnTidiedKeyValuePairs(SigEventArgs args)
        {
            try
            {
                string configuration = args.Sig.StringValue;
                configuration = configuration.Trim('{', '}', ' ');              // Removes leading and trailing curly brackets
                configuration = configuration.Split(':')[1];                    // Remove the header DPLY;guid=01:
                configuration = configuration.Trim(' ');                        // Remove leading and trailing spaces
                configuration = configuration.Replace(", ", ",");               // Remove spaces after commas
                string[] keyValues = configuration.Split(',');                  // break it down to individual key-value pairs delimited by ,

                return keyValues;
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0}: ### TCPClientReceiveCallback: Exception {1}", CLASSID, e);
                throw;
            }
        }
    }

    /// <summary>
    /// An arguments class to send information back through an EISC
    /// </summary>
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