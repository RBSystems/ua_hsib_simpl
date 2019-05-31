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
         * v1.1.04: Added Logger          
         * v1.0.05: Added escape in KVP when no = is found
         *          Fixed bug: Re-configuring DPLY would cause an error
         * v1.2.00: Adding pacer to class
         *          Storing historic SigEventArgs.Sig.StringValue for comparison and if args need to be actioned
         * v1.2.01: Pacer stops when list is empty.   
         * v1.2.02: Moved ConfigStrings to this main class, checking for identical strings in normal mode too.
         * */

        public const string CLASSID = "CNFG";
        public enum Method { ConfigureMatrix, ConfigureMatrixInput, ConfigureMatrixOutput, ConfigureCamera, ConfigureDSP, ConfigureDSPSignal, ConfigureDisplay, ConfigureRelay, ConfigureImageProcessor, ConfigureLight, ConfigureLightID };
        public string[,] ConfigStrings = new string[12, 3000];          // Mulitdimensional string array to hold config strings from PRO3 for comparision

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
        public ConfigPacer Pacer;

        

        public SYSM_ConfigurationHandler(ControlSystem controlSystem)
        {
            this.controlSystem = controlSystem;
            Pacer = new ConfigPacer(this, controlSystem);
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
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureMatrix, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureMatrix, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureMatrix, args.Sig.Number] = args.Sig.StringValue;

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
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Matrix as {1} named {2} on IP {3}", CLASSID, controlSystem.MTRXEvertz.ToString(), controlSystem.MTRXEvertz.Name, controlSystem.MTRXEvertzClient.AddressClientConnectedTo), CLASSID, false);                
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
        /// SYNTAX: global_name=[name], and cmd_io=[input number], Other comma-delimited pairs are ingored
        /// EXAMPLE: {MTRX_VSRC; guid=001: global_name=source_global1, local_name=source_local1, room_ass=01, cmd_io=123, local_id=3, function_id=2, filter_id=4, is_virtual=0, v_link=0,|}</param>
        public void ConfigureMatrixInput(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureMatrixInput, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureMatrixInput, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureMatrixInput, args.Sig.Number] = args.Sig.StringValue;

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Input with {1}...", CLASSID, args.Sig.StringValue); }


                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                int guid = (int)args.Sig.Number % 700;
                string name = "";
                int number = -1;

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    if (!KeyValue.Contains('=')) { continue; }

                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    //restronConsole.PrintLine("FLAG 1 - KEY {0} VALUE {1}", CLASSID, key, value);

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
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Matrix Input with guid {1} named {2} with Evertz number {3}", CLASSID, (int)args.Sig.Number % 700, controlSystem.mtrxSignals.Inputs[(int)args.Sig.Number % 700].Name, controlSystem.mtrxSignals.Inputs[(int)args.Sig.Number % 700].SignalNumber), CLASSID, false);
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
        /// SYNTAX: global_name=[name], and cmd_io=[output number], Other comma-delimited pairs are ingored
        /// EXAMPLE: {MTRX_VDST; guid=001: global_name=source_global1, local_name=source_local1, room_ass=01, cmd_io=123, local_id=3, function_id=2, filter_id=4, is_virtual=0, v_link=0,|}</param>
        public void ConfigureMatrixOutput(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureMatrixOutput, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureMatrixOutput, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureMatrixOutput, args.Sig.Number] = args.Sig.StringValue;

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Output with {1}...", CLASSID, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                int guid = (int)args.Sig.Number;
                string name = "";
                int number = -1;

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    if (!KeyValue.Contains('=')) { continue; }

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
                controlSystem.MTRXEvertz.StartPolling();
                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Output with guid {1} named {2} with Evertz number {3}", CLASSID, (int)args.Sig.Number, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].Name, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].SignalNumber); }

                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.MtrxEiscIndices, args.Sig.Number, "ACK"));
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Matrix Output with guid {1} named {2} with Evertz number {3}", CLASSID, (int)args.Sig.Number, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].Name, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].SignalNumber), CLASSID, false);
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
        /// SYNTAX: global_name=[name], and ip=[IP address], Other comma-delimited pairs are ingored
        /// EXAMPLE: {MTRX_VDST; guid=001: global_name=source_global1, local_name=source_local1, room_ass=01, ip=123.123.123.123, local_id=3, function_id=2, filter_id=4, is_virtual=0, v_link=0,|}</param>
        public void ConfigureCamera(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureCamera, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureCamera, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureCamera, args.Sig.Number] = args.Sig.StringValue;

                int Guid = (int)args.Sig.Number % 50;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Camera {1} with {2}...", CLASSID, Guid, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                string name = "";
                string ip = "";

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    if (!KeyValue.Contains('=')) { continue; }

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
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Camera {1} named {2} with IP {3}", CLASSID, Guid, controlSystem.CAMSony[Guid].Name, controlSystem.camSonyClients[Guid].AddressToAcceptConnectionFrom), CLASSID, false);
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
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureDSP, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureDSP, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureDSP, args.Sig.Number] = args.Sig.StringValue;

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
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured DSP as {1} named {2} on IP {3}", CLASSID, controlSystem.DSPQSC.ToString(), controlSystem.DSPQSC.Name, controlSystem.DSPQSCClient.AddressClientConnectedTo), CLASSID, false);
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
        /// SYNTAX: global_name=[name], cmd_vol=[volume named handle], and cmd_mute=[mute named handle], .Other comma-delimited pairs are ingored
        /// EXAMPLE: {DSP_POINTS; guid=001: global_name=myDSPPoint01,local_name=myDSPPoint01, room_ass=01, local_index=01, point_type=1, cmd_vol=R04_Wmic01_gain_volLevel, cmd_mute=R04_Wmic01_gain_muteState}</param>
        public void ConfigureDSPSignal(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureDSPSignal, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureDSPSignal, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureDSPSignal, args.Sig.Number] = args.Sig.StringValue;

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring DSP Signal {1} with {2}...", CLASSID, args.Sig.Number, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                uint guid = args.Sig.Number;
                string name = "";
                string vol = "";
                string mute = "";
                int pointType = 0;
                string rte = "";
                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    if (!KeyValue.Contains('=')) { continue; }

                    string key = KeyValue.Split('=')[0];
                    string value = KeyValue.Split('=')[1];

                    switch (key.ToUpper())
                    {
                        case ("LOCAL_NAME"):
                            {
                                name = value;
                                break;
                            }
                        case ("NAMED_CONTROL_GAIN"):
                            {
                                vol = value;
                                mute = value.Replace("_volLevel", "_muteState");
                                break;
                            }
                        case ("TAG_GAIN"):
                            {
                                vol = value;
                                mute = value.Replace("_volLevel", "_muteState");
                                break;
                            }
                        case ("NAMED_CONTROL_MUTE"):
                            {
                                mute = value;
                                break;
                            }
                        case ("TAG_MUTE"):
                            {
                                mute = value;
                                break;
                            }
                        case ("NAMED_CONTROL_RTE"):
                            {
                                rte = value;
                                break;
                            }
                        case ("TAG_RTE"):
                            {
                                rte = value;
                                break;
                            }
                        case ("POINT_TYPE"):
                            {
                                pointType = Convert.ToInt32(value);
                                break;
                            }
                    }
                }
                #endregion

                controlSystem.DSPQSC.RegisterSignal(guid, name, vol, mute, rte, pointType);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured DSP signal with index {1} as named {2} with volume named control {3} and mute named control {4}", CLASSID, args.Sig.Number, controlSystem.DSPQSC.dSPQSCSignals[args.Sig.Number].VolumeName, controlSystem.DSPQSC.dSPQSCSignals[args.Sig.Number].VolNamedControl, controlSystem.DSPQSC.dSPQSCSignals[args.Sig.Number].MuteNamedControl); }
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.DspEiscIndices, args.Sig.Number, "ACK"));
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured DSP signal with index {1} as named {2} with volume named control {3} and mute named control {4}", CLASSID, args.Sig.Number, controlSystem.DSPQSC.dSPQSCSignals[args.Sig.Number].VolumeName, controlSystem.DSPQSC.dSPQSCSignals[args.Sig.Number].VolNamedControl, controlSystem.DSPQSC.dSPQSCSignals[args.Sig.Number].MuteNamedControl), CLASSID, false);
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
        /// SYNTAX: global_name=[name], ip=[IP address], com_port=[COM port on this CP3], and device_type=[Display type], .Other comma-delimited pairs are ingored
        /// EXAMPLE: {DPLY;guid=01: global_name=myDPLY01,local_name=myDPLY01, ip=123.123.123.123, device_type=sony_lcd, room_ass=01, local_index=01|}
        /// EXAMPLE: {DPLY;guid=01: global_name=myDPLY01,local_name=myDPLY01, ip=123.123.123.123, device_type=lg_lcd, com_port=1, room_ass=01, local_index=01|}
        /// Display type valid values: SONY_LCD, SONY_PROJ, LG_LCD, BARCO_PROJ, CHRISTIE_PROJ</param>
        public void ConfigureDisplay(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureDisplay, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureDisplay, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureDisplay, args.Sig.Number] = args.Sig.StringValue;

                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Display {1} with {2}...", CLASSID, args.Sig.Number, args.Sig.StringValue); }
                Display display = new Display();
                display.Guid = (int)args.Sig.Number;

                int portNumber = -1;

                string name = "";
                string ip = "";
                uint comPort = 0;

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    if (!KeyValue.Contains('=')) { continue; }

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
                    display.SerialPort = controlSystem.ComPorts[comPort];
                    display.SerialPort.SetComPortSpec(DPLY_LGLCD.GetComspec());
                    display.SerialPort.SerialDataReceived += new ComPortDataReceivedEvent(controlSystem.SerialPort_SerialDataReceived);

                    if (controlSystem.DeviceForComPort.ContainsKey(display.SerialPort))
                    {
                        CrestronConsole.PrintLine("{0} *** Removing device association for COM port {1}", CLASSID, display.SerialPort.ID);
                        controlSystem.DeviceForComPort.Remove(display.SerialPort);
                    }

                    controlSystem.DeviceForComPort.Add(display.SerialPort, display);
                }
                else if (ip != "" && portNumber != -1)
                {
                    display.Client = new TCPClient();
                    display.Client.AddressClientConnectedTo = ip;
                    display.Client.PortNumber = portNumber;
                    display.Client.SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);
                }

                #endregion

                #region Check if GUID exists. IF so remove it. Then add dislay to list.
                if (controlSystem.DisplaysList.FindIndex(x => x.Guid == display.Guid) != -1)
                {
                    CrestronConsole.PrintLine("{0} *** Removing Display at index {1} from DisplayList, Type {2} with IP of {3}", CLASSID, controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number), controlSystem.DisplaysList[controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number)].Controller.ToString(), controlSystem.DisplaysList[controlSystem.DisplaysList.FindIndex(x => x.Guid == args.Sig.Number)].Client.AddressClientConnectedTo);
                    controlSystem.DisplaysList.RemoveAt(controlSystem.DisplaysList.FindIndex(x => x.Guid == display.Guid));
                }
                controlSystem.DisplaysList.Add(display);
                #endregion

                // Register callbacks.
                display.Controller.OnCommandToSend += new DPLY.CommandToSend(controlSystem.ModuleNeedsToSend);
                display.Controller.OnFeedbackUpdate += new DPLY.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                #region Update EISC with configuration sucessful
                if (display.Client != null)
                {
                    CrestronConsole.PrintLine("{0} *** Configured Display {1} as {2} named {3} on IP {4}", CLASSID, args.Sig.Number, display.Controller.ToString(), display.Controller.Name, display.Client.AddressClientConnectedTo);
                    controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Display {1} as {2} named {3} on IP {4}", CLASSID, args.Sig.Number, display.Controller.ToString(), display.Controller.Name, display.Client.AddressClientConnectedTo), CLASSID, false);
                }
                else if (display.SerialPort != null)
                {
                    CrestronConsole.PrintLine("{0} *** Configured Display {1} as {2} named {3} on COM {4}", CLASSID, args.Sig.Number, display.Controller.ToString(), display.Controller.Name, display.SerialPort.ID);
                    controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Display {1} as {2} named {3} on COM {4}", CLASSID, args.Sig.Number, display.Controller.ToString(), display.Controller.Name, display.SerialPort.ID), CLASSID, false);
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
        /// Configure a pair of relays. Use odd index to configure it and the next relay e.g. configure relay 11 to control relays 11 and 12.
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number % 100 is the GUID
        /// SYNTAX: global_name=[name], and ip=[IP address], Other comma-delimited pairs are ingored
        /// EXAMPLE: {MTRX_VDST; guid=001: global_name=source_global1, local_name=source_local1, room_ass=01, ip=123.123.123.123, local_id=3, function_id=2, filter_id=4, is_virtual=0, v_link=0,|}</param>
        public void ConfigureRelay(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureRelay, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureRelay, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureRelay, args.Sig.Number] = args.Sig.StringValue;

                //Format: Name|IP
                int Guid = (int)args.Sig.Number % 100;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Relays {1} and {2} with {3}...", CLASSID, Guid, Guid+1, args.Sig.StringValue); }

                string[] keyValues = ReturnTidiedKeyValuePairs(args);

                string name = "";
                string ip = "";

                #region Check each KVP for relevant data. Immediately set up device type when found
                foreach (string KeyValue in keyValues)
                {
                    if (!KeyValue.Contains('=')) { continue; }

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
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Relays {1} and {2} named {3} with IP {4}", CLASSID, Guid, Guid + 1, controlSystem.RLYGlobalCache[Guid].Name, controlSystem.RLYGlobalCacheClients[Guid].AddressClientConnectedTo), CLASSID, false);
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
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureImageProcessor, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureImageProcessor, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureImageProcessor, args.Sig.Number] = args.Sig.StringValue;

                int id = (int)args.Sig.Number % 100;
                if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Image processor {1} with {2}...", CLASSID, id, args.Sig.StringValue); }
                controlSystem.IMGPTvOne[id] = new IMGP_TVOne();
                controlSystem.IMGPTvOne[id].Name = args.Sig.StringValue.Split('|')[0];
                controlSystem.IMGPTvOne[id].OnCommandToSend += new IMGP_TVOne.CommandToSend(controlSystem.ModuleNeedsToSend);
                controlSystem.IMGPTvOne[id].OnFeedbackUpdate += new IMGP_TVOne.FeedbackUpdate(controlSystem.ModuleHasUpdate);

                controlSystem.IMGPTvOneClients[id] = new TCPClient(args.Sig.StringValue.Split('|')[1], IMGP_TVOne.IpPort, 5000);
                controlSystem.IMGPTvOneClients[id].SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Image processor {1} named {2} with IP {3}", CLASSID, id, controlSystem.IMGPTvOne[id].Name, controlSystem.IMGPTvOneClients[id].AddressClientConnectedTo); };
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "ACK"));
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Image processor {1} named {2} with IP {3}", CLASSID, id, controlSystem.IMGPTvOne[id].Name, controlSystem.IMGPTvOneClients[id].AddressClientConnectedTo), CLASSID, false);
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
            }

        }

        /// <summary>
        /// Configure the headend lighting controller
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number % 10 is the GUID
        /// SYNTAX: [name]|[COM port]
        /// EXAMPLE: 3rd floor lighting controller|COM1</param>
        public void ConfigureLight(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureLight, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureLight, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureLight, args.Sig.Number] = args.Sig.StringValue;

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
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Image processor {1} named {2} on COM {3}", CLASSID, id, controlSystem.LghtLutron[id].Name, port), CLASSID, false);
            }
            catch
            {
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "NAK"));
            }
        }

        /// <summary>
        /// Configure lighting for a room
        /// </summary>
        /// <param name="args">
        /// args.Sig.Number % 50 is the GUID
        /// SYNTAX: [name]|[Lutron ID]|[Lighting unit]
        /// EXAMPLE: Room 333|AABBCC|3</param>
        public void ConfigureLightID(SigEventArgs args)
        {
            try
            {
                if (args.Sig.StringValue.Length == 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                    return;
                }
                if (ConfigStrings[(int)Method.ConfigureLightID, args.Sig.Number] == args.Sig.StringValue)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, (int)Method.ConfigureLightID, args.Sig.Number, args.Sig.StringValue); }
                    return;
                }
                ConfigStrings[(int)Method.ConfigureLightID, args.Sig.Number] = args.Sig.StringValue;

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

                if (controlSystem.LGHTDeviceForRoom.ContainsKey(RoomGuid))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** Removing existing Lighting ID  at {1}", CLASSID, RoomGuid); }
                    controlSystem.LGHTDeviceForRoom.Remove(RoomGuid);
                }

                controlSystem.LGHTDeviceForRoom.Add(RoomGuid, Device);

                if (debug) { CrestronConsole.PrintLine("{0} *** Configured Lighting ID {1} named {2} with Lutron ID {3} on Lutron Device {4}", CLASSID, RoomGuid, controlSystem.LghtLutron[Device].RoomSignals[RoomGuid].Name, controlSystem.LghtLutron[Device].RoomSignals[RoomGuid].LutronID, Device); };
                controlSystem.eiscHandler.UpdateEISCSignal(this, new ConfigArgs(controlSystem.eiscHandler.IgmpRlyPartLghtEiscIndices, args.Sig.Number, "ACK"));
                controlSystem.Logger.LogEntry(string.Format("{0} *** Configured Lighting ID {1} named {2} with Lutron ID {3} on Lutron Device {4}", CLASSID, RoomGuid, controlSystem.LghtLutron[Device].RoomSignals[RoomGuid].Name, controlSystem.LghtLutron[Device].RoomSignals[RoomGuid].LutronID, Device), CLASSID, false);
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
                string configTemp = "";
                string configuration = args.Sig.StringValue;
                configuration = configuration.Trim('{', '}', ' ');              // Removes leading and trailing curly brackets
                if (configuration.Contains(':'))
                {
                    configuration = configuration.Split(':')[1];                // Remove the header DPLY;guid=01:
                }
                while (configuration.Contains("]"))                             // Remove sq bracket sub categorization [ ]
                {
                    configuration = configuration.Remove(0, configuration.IndexOf("[") + 1);
                    configTemp += configuration.Substring(0, configuration.IndexOf("]"));
                    configuration = configuration.Remove(0, configuration.IndexOf("]") + 1);
                }

                configuration = configTemp;
                configuration = configuration.Trim(' ');                        // Remove leading and trailing spaces
                configuration = configuration.Replace("  ", " ");               // Remove spaces after commas
                configuration = configuration.Replace(", ", ",");               // Remove spaces after commas
                string[] keyValues;
                if (configuration.Contains('~'))
                {
                    keyValues = configuration.Split('~');                  // break it down to individual key-value pairs delimited by ,
                }
                else
                {
                    keyValues = configuration.Split(',');
                }

                configuration = "";
                configTemp = "";
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
    /// 
    /// </summary>
    public class ConfigPacer
    {
        public const string CLASSID = "PACE";
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

        private const int PACERCHECKINTERVALINMS = 500;                 // Intervals between checking ArgsList in ms        
        private const int PACERENABLETIME = 5000;                       // Minimum time for pacer to be enabled

        private SYSM_ConfigurationHandler Handler;                      // Used to call back to config handler
        private ControlSystem controlSystem;
        private CTimer ArgsTimer;                                       // Timer to pace out checking of list
        private List<ConfigListItem> ArgsList;                          // Transient list of configs needed to be actioned        

        /// <summary>
        /// Constructor. 
        /// Stores a reference to calling SYSM_ConfigurationHandler
        /// Initialises ArgsList
        /// Starts up cTimer to check list object
        /// </summary>
        public ConfigPacer(SYSM_ConfigurationHandler _handler, ControlSystem _controlSystem)
        {
            Handler = _handler;
            controlSystem = _controlSystem;
            ArgsList = new List<ConfigListItem>();                        
        }

        public void StartPacer()
        {
            ArgsTimer = new CTimer(ArgsTimerTimedOut, null, PACERENABLETIME, PACERCHECKINTERVALINMS);
        }

        /// <summary>
        /// Invoked when ArgsTimer has timed out.
        /// Checks ArgsList in a specific order and excutes the config line. 
        /// Checks if method is contain in list, then executes config, finally removes item from list.
        /// </summary>
        /// <param name="_notUsed"></param>
        public void ArgsTimerTimedOut(object _notUsed)
        {
            if (ArgsList.Count == 0) 
            {
                if (debug) { CrestronConsole.PrintLine("{0} *** ArgsList is now at {1}, stopping the pacer", CLASSID, ArgsList.Count); }
                controlSystem.eiscHandler.EnablePacer = false;
                ArgsTimer.Stop();                
                return; 
            }    // exit if the list is empty

            if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureMatrix) != -1)                // If a configuration line for matrix (headend) is in the list
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureMatrix);                      // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureMatrix at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureMatrix(ArgsList[index].args);                                                      // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureMatrixInput) != -1)      // Matrix input
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureMatrixInput);                 // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureMatrixInput at index {0}, total of {1} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureMatrixInput(ArgsList[index].args);                                                 // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureMatrixOutput) != -1)      // Matrix output
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureMatrixOutput);                // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureMatrixOutput at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureMatrixOutput(ArgsList[index].args);                                                // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureCamera) != -1)            // Camera
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureCamera);                      // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureCamera at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureCamera(ArgsList[index].args);                                                      // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureDSP) != -1)              // DSP
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureDSP);                         // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureDSP at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureDSP(ArgsList[index].args);                                                         // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureDSPSignal) != -1)        // DSP
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureDSPSignal);                   // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureDSPSignal at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureDSPSignal(ArgsList[index].args);                                                   // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureDisplay) != -1)          // Display
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureDisplay);                     // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureDisplay at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureDisplay(ArgsList[index].args);                                                     // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureRelay) != -1)            // Relay
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureRelay);                       // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureRelay at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureRelay(ArgsList[index].args);                                                       // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureImageProcessor) != -1)   // Relay
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureImageProcessor);              // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureImageProcessor at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureImageProcessor(ArgsList[index].args);                                              // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureLight) != -1)            // Lights
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureLight);                       // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureLight at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureLight(ArgsList[index].args);                                                       // Execute the config line
                ArgsList.RemoveAt(index);                                                                           // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                             // exit
            }
            else if (ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureLightID) != -1)           // Lights ID
            {
                int index = ArgsList.FindIndex(item => item.method == SYSM_ConfigurationHandler.Method.ConfigureLightID);                       // Get the index
                if (debug) { CrestronConsole.PrintLine("{0} *** Found Method.ConfigureLightID at index {1}, total of {2} list items", CLASSID, index, ArgsList.Count); }

                Handler.ConfigureLightID(ArgsList[index].args);                                                       // Execute the config line
                ArgsList.RemoveAt(index);                                                                             // Remove the config from the list
                if (debug) { CrestronConsole.PrintLine("{0} *** Completed configuration, total of {1} list items", CLASSID, ArgsList.Count); }
                return;                                                                                               // exit
            }
        }

        /// <summary>
        /// Add an args to the list to be checked.
        /// First checks to ensure a) the string is not empty, and b) the string is not identical to the previous one.
        /// </summary>
        public void AddToList(SYSM_ConfigurationHandler.Method _method, SigEventArgs _args)
        {
            if (_args.Sig.StringValue.Length == 0) 
            {
                if (debug) { CrestronConsole.PrintLine("{0} *** config string is empty, discarding", CLASSID); }
                return; 
            }
            if (Handler.ConfigStrings[(int)_method, _args.Sig.Number] == _args.Sig.StringValue) 
            {
                if (debug) { CrestronConsole.PrintLine("{0} *** config string for method {1} sig number {2} matches previous string {3}, discarding", CLASSID, _method, _args.Sig.Number, _args.Sig.StringValue); }
                return; 
            }  

            if (debug) { CrestronConsole.PrintLine("{0} *** Adding item to config list method {1} with string {2} ...", CLASSID, _method, _args.Sig.StringValue); }
            ArgsList.Add(new ConfigListItem(_method, _args));
        }

        /// <summary>
        /// Custom object for ArgsList to store both method enum and args in one list item
        /// </summary>
        private class ConfigListItem
        {
            public SYSM_ConfigurationHandler.Method method;
            public SigEventArgs args;

            public ConfigListItem(SYSM_ConfigurationHandler.Method _method, SigEventArgs _args)
            {
                method = _method;
                args = _args;
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