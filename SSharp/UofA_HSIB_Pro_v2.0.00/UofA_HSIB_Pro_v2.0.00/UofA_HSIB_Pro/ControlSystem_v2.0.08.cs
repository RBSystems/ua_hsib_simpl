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
    public class ControlSystem : CrestronControlSystem
    {
        /* Changelog:
         * v2.0.02: Internal debug prints now use a custom method invoked in a new thread, with up to a 200ms random delay
         *              Done to combat issue where normal Print() would cause random commands to not get sent.
         * v2.0.03: Added COM port to Display Class 
         *          Set all properties in Display to invalid state upon declaration.
         *          Added LG LCD to ModuleNeedsToSend()
         * v2.0.04: Changed DeviceForComPort to Dictionary<ComPort, Object>      
         * v2.0.05: Added RLY_GlobalCache units
         * v2.0.06: Added IMGP_TVOne units
         * v2.0.07: Added Logger and LogMAnager
         * v2.0.08: Added Versiport suppport
         *          Added default IP for DSP, and dedicated Fire alarm connection
         * */

        #region Constants
        const string CLASSID = "MAIN";
        private const int BUFFERSIZE = 5000;
        public const int GLOBALCACHESERIALPORTIPPORT = 4999;
        #endregion

        #region Variables
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

        public bool TxRxDebug
        {
            get
            {
                return TxRxdebug;
            }
            set
            {
                TxRxdebug = value;
            }
        }
        private bool TxRxdebug = false;
        #endregion

        #region System Objects - EISC, Loggers, etc
        public ThreeSeriesTcpIpEthernetIntersystemCommunications[] eiscs;
        public SYSM_EISCHandler eiscHandler;
        public SYSM_ConfigurationHandler ConfigurationHandler;
        public Dictionary<ComPort, Object> DeviceForComPort;        // Holds which device is connected to which COM port
        public SYSM_Logger Logger;
        public SYSM_LogManager LogManager;
        #endregion

        #region Device Objects and Handlers
        public MTRX_EvertzQuartz MTRXEvertz;
        public MTRXSignals mtrxSignals;

        public DSP_QSCCore DSPQSC;
        public CAM_Sony[] CAMSony = new CAM_Sony[50];
        public List<Display> DisplaysList = new List<Display>();
        public RLY_GlobalCache[] RLYGlobalCache = new RLY_GlobalCache[100];
        public IMGP_TVOne[] IMGPTvOne = new IMGP_TVOne[10];
        #endregion

        #region Device Connections - TCP and UDP Clients
        public TCPClient MTRXEvertzClient;
        public TCPClient DSPQSCClient;
        public UDPServer[] camSonyClients = new UDPServer[50];
        public TCPClient[] RLYGlobalCacheClients = new TCPClient[100];
        public TCPClient[] IMGPTvOneClients = new TCPClient[10];
        #endregion

        /// <summary>
        /// ControlSystem Constructor. Starting point for the SIMPL#Pro program.
        /// Use the constructor to:
        /// * Initialize the maximum number of threads (max = 400)
        /// * Register devices
        /// * Register event handlers
        /// * Add Console Commands
        /// 
        /// Please be aware that the constructor needs to exit quickly; if it doesn't
        /// exit in time, the SIMPL#Pro program will exit.
        /// 
        /// You cannot send / receive data in the constructor
        /// </summary>
        public ControlSystem() : base()
        {
            try
            {
                Thread.MaxNumberOfUserThreads = 100;

                RegisterConsoleCommands();

                //Subscribe to the controller events (System, Program, and Ethernet)
                CrestronEnvironment.SystemEventHandler += new SystemEventHandler(ControlSystem_ControllerSystemEventHandler);
                CrestronEnvironment.ProgramStatusEventHandler += new ProgramStatusEventHandler(ControlSystem_ControllerProgramEventHandler);
                CrestronEnvironment.EthernetEventHandler += new EthernetEventHandler(ControlSystem_ControllerEthernetEventHandler);

                eiscHandler = new SYSM_EISCHandler(this);
                ConfigurationHandler = new SYSM_ConfigurationHandler(this);
                Logger = new SYSM_Logger(this);
                LogManager = new SYSM_LogManager(Logger, this);

                if (this.SupportsComPort)
                {
                    foreach (ComPort port in this.ComPorts)
                    {
                        if (port.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
                        {
                            CrestronConsole.PrintLine("Failed to register COM port {0}", port.ID);
                        }
                    }
                    DeviceForComPort = new Dictionary<ComPort, Object>();
                }
                if(this.SupportsDigitalInput)
                {
                    foreach(DigitalInput port in DigitalInputPorts)
                    {
                        if (port.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
                        {
                            CrestronConsole.PrintLine("Failed to register IO port {0}", port.ID);
                        }
                        port.StateChange += new DigitalInputEventHandler(ControlSystem_StateChange);
                    }
                }

                if (this.SupportsVersiport)
                {
                    CrestronConsole.PrintLine("SUPPORTS VERISPORTS - REGISTERING AND SUBSCRIBING...");
                    foreach (Versiport port in VersiPorts)
                    {
                        if (port.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
                        {
                            CrestronConsole.PrintLine("Failed to register Versiport {0}", port.ID);
                        }
                        port.SetVersiportConfiguration(eVersiportConfiguration.DigitalInput);// = eVersiportConfiguration.DigitalInput;
                        port.VersiportChange += new VersiportEventHandler(port_VersiportChange);
                        
                    }
                    CrestronConsole.PrintLine("VERISPORTS - REGISTERED AND SUBSCRIBED");
                }

                CrestronConsole.PrintLine("Exiting Constructor");
                Logger.LogEntry("Program Ready", CLASSID, false);
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in the constructor: {0}", e.Message);
            }
        }

        /// <summary>
        /// InitializeSystem - this method gets called after the constructor 
        /// has finished. 
        /// 
        /// Use InitializeSystem to:
        /// * Start threads
        /// * Configure ports, such as serial and verisports
        /// * Start and initialize socket connections
        /// Send initial device configurations
        /// 
        /// Please be aware that InitializeSystem needs to exit quickly also; 
        /// if it doesn't exit in time, the SIMPL#Pro program will exit.
        /// </summary>
        public override void InitializeSystem()
        {
            try
            {
                eiscHandler.RegisterEISCs();

                new CTimer(CheckID, 2000);
                CrestronConsole.PrintLine("Exiting Initialisor");
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in InitializeSystem: {0}", e.Message);
            }
        }

        /// <summary>
        /// Invoked when a module needs to send commands to a device to be sent to client or COM port
        /// </summary>
        /// <param name="_module">The module invoking</param>
        /// <param name="_command">The command to send</param>
        public void ModuleNeedsToSend(object _module, string _command)
        {
            if (debug) { new Thread(Print, string.Format("Module {0} wants to send {1}", _module, _command)); }

            if (_module.GetType() == typeof(MTRX_EvertzQuartz))
            {
                if (MTRXEvertzClient.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command)); }
                    MTRXEvertzClient.ConnectToServer();
                }

                if (MTRXEvertzClient.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command); }
                    MTRXEvertzClient.SendData(PWCConvert.StringToBytes(_command), _command.Length);
                }
                else
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command)); }
                    Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command), CLASSID, false);
                }
                return;
            }
            else if (_module.GetType() == typeof(CAM_Sony))
            {
                for (int index = 1; index <= CAMSony.Length; index++)
                {
                    if (_module == CAMSony[index])
                    {
                        if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1:D2}_{2}:{3}: >>> {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, _command); }
                        SocketErrorCodes err = camSonyClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);
                        if (err != SocketErrorCodes.SOCKET_OK)
                        {
                            CrestronConsole.PrintLine("{0}{1:D2}_{2}:{3}: !!! Send Error: {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, err);
                            Logger.LogEntry(string.Format("{0}{1:D2}_{2}:{3}: !!! Send Error: {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, err), CLASSID, false);
                        }
                        return;
                    }
                }
            }
            else if (_module.GetType() == typeof(DSP_QSCCore))
            {
                if (DSPQSCClient.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command)); }
                    DSPQSCClient.ConnectToServer();
                }

                if (DSPQSCClient.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command); }
                    DSPQSCClient.SendData(PWCConvert.StringToBytes(_command), _command.Length);

                }
                else
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command)); }
                    Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command), CLASSID, false);
                }
                return;
            }
            else if (_module.GetType() == typeof(RLY_GlobalCache))
            {
                for (int index = 1; index <= RLYGlobalCache.Length; index++)
                {
                    if (_module == RLYGlobalCache[index])
                    {
                        if (RLYGlobalCacheClients[index].ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command)); }
                            RLYGlobalCacheClients[index].ConnectToServer();
                        }

                        if (RLYGlobalCacheClients[index].ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command); }
                            RLYGlobalCacheClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);

                            new CTimer(DisconnectSocket, RLYGlobalCacheClients[index], 1000);
                            return;
                        }
                        else
                        {
                            if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command)); }
                            Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command), CLASSID, false);
                            return;
                        }
                    }
                }
            }
            else if (_module.GetType() == typeof(IMGP_TVOne))
            {
                for (int index = 1; index <= IMGPTvOne.Length; index++)
                {
                    if (_module == IMGPTvOne[index])
                    {
                        if (IMGPTvOneClients[index].ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", IMGP_TVOne.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command)); }
                            IMGPTvOneClients[index].ConnectToServer();
                        }

                        if (IMGPTvOneClients[index].ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", RLY_GlobalCache.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command); }
                            IMGPTvOneClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);

                            new CTimer(DisconnectSocket, RLYGlobalCacheClients[index], 1000);
                            return;
                        }
                        else
                        {
                            if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", IMGP_TVOne.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command)); }
                            Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", IMGP_TVOne.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command), CLASSID, false);
                            return;
                        }
                    }
                }
            }
            foreach (Display display in DisplaysList)
            {
                if (display.Controller == _module)
                {
                    if (display.Client != null)
                    {
                        if (display.Client.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (debug) { new Thread(Print, string.Format("{0}{1}_{2}:{3}: *** Not connected, now connecting...", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command)); }
                            display.Client.ConnectToServer();
                        }

                        if (display.Client.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}_{2}:{3}: >>> {4}", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command); }
                            display.Client.SendData(PWCConvert.StringToBytes(_command), _command.Length);

                            new CTimer(DisconnectSocket, display.Client, 1000);
                            return;
                        }
                        else
                        {
                            if (debug) { new Thread(Print, string.Format("{0}{1}_{2}:{3}: !!! Not Connected", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command)); }
                            Logger.LogEntry(string.Format("{0}{1}_{2}:{3}: !!! Not Connected", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command), CLASSID, false);
                            return;
                        }
                    }
                    else if (display.SerialPort != null)
                    {
                        if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}_COM{2}: >>> {3}", DPLY.ABSCLASSID, display.Guid, display.SerialPort.ID, _command); }
                        display.SerialPort.Send(_command);
                        return;
                    }
                    else
                    {
                        if (debug) { new Thread(Print, string.Format("{0}{1}: !!! Both client and serialport are not initilaised", DPLY.ABSCLASSID, display.Guid)); }
                        return;
                    }
                }
            }                      
        }

        /// <summary>
        /// Invoked when status for a device has been updated - via a module, to be sent to EISC
        /// </summary>
        /// <param name="_module">The module invoking</param>
        /// <param name="args">The feedback object</param>
        public void ModuleHasUpdate(object _module, object _args)
        {
            eiscHandler.UpdateEISCSignal(_module, _args);
        }

        #region Controller Events
        public void ControlSystem_OnlineStatusChange(GenericBase currentDevice, OnlineOfflineEventArgs args)
        {
            if (debug) { CrestronConsole.PrintLine("{0} *** ControlSystem_OnlineStatusChange(): {1} DeviceOnLine: {2}", CLASSID, currentDevice, args.DeviceOnLine); }
            Logger.LogEntry(string.Format("{0} *** ControlSystem_OnlineStatusChange(): {1} DeviceOnLine: {2}", CLASSID, currentDevice, args.DeviceOnLine), CLASSID, false);
        }
        
        /// <summary>
        /// Event Handler for Ethernet events: Link Up and Link Down. 
        /// Use these events to close / re-open sockets, etc. 
        /// </summary>
        /// <param name="ethernetEventArgs">This parameter holds the values 
        /// such as whether it's a Link Up or Link Down event. It will also indicate 
        /// wich Ethernet adapter this event belongs to.
        /// </param>
        void ControlSystem_ControllerEthernetEventHandler(EthernetEventArgs ethernetEventArgs)
        {
            switch (ethernetEventArgs.EthernetEventType)
            {//Determine the event type Link Up or Link Down
                case (eEthernetEventType.LinkDown):
                    //Next need to determine which adapter the event is for. 
                    //LAN is the adapter is the port connected to external networks.
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {
                        //
                    }
                    break;
                case (eEthernetEventType.LinkUp):
                    if (ethernetEventArgs.EthernetAdapter == EthernetAdapterType.EthernetLANAdapter)
                    {

                    }
                    break;
            }
        }

        /// <summary>
        /// Event Handler for Programmatic events: Stop, Pause, Resume.
        /// Use this event to clean up when a program is stopping, pausing, and resuming.
        /// This event only applies to this SIMPL#Pro program, it doesn't receive events
        /// for other programs stopping
        /// </summary>
        /// <param name="programStatusEventType"></param>
        void ControlSystem_ControllerProgramEventHandler(eProgramStatusEventType programStatusEventType)
        {
            switch (programStatusEventType)
            {
                case (eProgramStatusEventType.Paused):
                    //The program has been paused.  Pause all user threads/timers as needed.
                    break;
                case (eProgramStatusEventType.Resumed):
                    //The program has been resumed. Resume all the user threads/timers as needed.
                    break;
                case (eProgramStatusEventType.Stopping):
                    //The program has been stopped.
                    //Close all threads. 
                    //Shutdown all Client/Servers in the system.
                    //General cleanup.
                    //Unsubscribe to all System Monitor events
                    break;
            }

        }

        /// <summary>
        /// Event Handler for system events, Disk Inserted/Ejected, and Reboot
        /// Use this event to clean up when someone types in reboot, or when your SD /USB
        /// removable media is ejected / re-inserted.
        /// </summary>
        /// <param name="systemEventType"></param>
        void ControlSystem_ControllerSystemEventHandler(eSystemEventType systemEventType)
        {
            switch (systemEventType)
            {
                case (eSystemEventType.DiskInserted):
                    //Removable media was detected on the system
                    break;
                case (eSystemEventType.DiskRemoved):
                    //Removable media was detached from the system
                    break;
                case (eSystemEventType.Rebooting):
                    //The system is rebooting. 
                    //Very limited time to preform clean up and save any settings to disk.
                    break;
            }

        }
        #endregion

        #region User console commands
        /// <summary>
        /// Adds custom console commands to the console
        /// </summary>
        private void RegisterConsoleCommands()
        {
            if (!CrestronConsole.AddNewConsoleCommand(DebugEnableDisable, "Enable", "Some help text", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command Debug");
                ErrorLog.Error("{0} 03!!! Failed to register console command Debug", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DebugEvertzSwitchCommand, "Evertz", "Some help text", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DumpConfig, "Dump", "Some help text", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DebugDev, "Dev", "Some help text", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }
            if (Debug) { CrestronConsole.PrintLine("User commands all registered"); }
        }

        private void DebugDev(string _args)
        {
            CrestronConsole.ConsoleCommandResponse("Numbers from {0} are {1}", _args, PWCConvert.ReturnNumbersOnly(_args));
        }

        /// <summary>
        /// Evertz - Request a switch in the Evertz
        /// </summary>        
        private void DebugEvertzSwitchCommand(string _args)
        {
            try
            {
                string[] args = _args.Split(' ');

                if (args[0].ToUpper() == "COMMAND")
                {
                    // Evertz Command .SV2,1        Will add the CR at the end
                    MTRXEvertz.Debug = true;
                    MTRXEvertz.SendDirectCommand(args[2]);
                }
                else if (args[0].ToUpper() == "SWITCH")
                {
                    // Evertz Switch 1 2
                    uint output = Convert.ToUInt32(args[1]);
                    uint input = Convert.ToUInt32(args[2]);
                    MTRXEvertz.SetInputForOutput(MTRX.Signal.Both, output, input);
                }
                else if (_args.Contains("?"))
                {
                    CrestronConsole.ConsoleCommandResponse("Test a Evertz switch command, automically sets DEBUG to on\nIn the format E-Switch <Level> <Output> <Input>\nExample: \"E-Switch Video 10 5\" for input 5 to output 10 video\n");
                }
                else
                {
                    CrestronConsole.ConsoleCommandResponse("Sytax error - type \"Evertz ?\" for more info");
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} !!! Test(1)): Exception caught: {2}", "MAIN", _args, e);
            }
        }        

        /// <summary>
        /// User Console Command. Allows console to set or reset debugs
        /// </summary>
        /// <param name="_args">
        /// SYNTAX: Debug [ID] [True or False], where IDs are in case statements below
        /// EXAMPLE: Debug EISC True</param>
        private void DebugEnableDisable(string _args)
        {
            try
            {
                string[] args = _args.Split(' ');

                switch (args[0].ToUpper())
                {
                    case ("?"):
                        {
                            CrestronConsole.ConsoleCommandResponse("Type the name of the device followed by true or false\ne.g. Debug MTRX True");
                            break;
                        }
                    case ("MTRX"):
                        {
                            MTRXEvertz.Debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("MTRX debug is now {0}", MTRXEvertz.Debug);
                            break;
                        }
                    case ("QSC"):
                        {
                            //DSPQSC.Debug = Convert.ToBoolean(args[1]);
                            break;
                        }
                    case ("EISC"):
                        {
                            eiscHandler.Debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("EISC debug is now {0}", eiscHandler.Debug);
                            break;
                        }
                    case ("MAIN"):
                        {
                            debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("MAIN debug is now {0}", debug);
                            break;
                        }
                    case ("TXRX"):
                        {
                            TxRxdebug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("TXRX debug is now {0}", TxRxdebug);
                            break;
                        }
                    case ("CONFIG"):
                        {
                            ConfigurationHandler.Debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("CONFIG debug is now {0}", ConfigurationHandler.Debug);
                            break;
                        }
                    case ("DPLY"):
                        {
                            // Debug DPLY All True or Debug DPLY 1 False
                            bool debug = Convert.ToBoolean(args[2]);
                            if (args[1].ToUpper() == "ALL")
                            {
                                CrestronConsole.ConsoleCommandResponse("Setting Debug to {0} for all displays...\n", debug);
                                foreach (Display display in DisplaysList)
                                {
                                    display.Controller.Debug = debug;
                                    CrestronConsole.ConsoleCommandResponse("MTRX {0} debug is now {1}\n", display.Guid, display.Controller.Debug);
                                }
                            }
                            else
                            {
                                int index = DisplaysList.FindIndex(display => display.Guid == Int32.Parse(args[1]));
                                DisplaysList[index].Controller.Debug = debug;
                                CrestronConsole.ConsoleCommandResponse("MTRX {0} debug is now {1}\n", DisplaysList[index].Guid, DisplaysList[index].Controller.Debug);
                            }
                            break;
                        }
                }

            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} !!! DebugEnableDisable(): Exception caught: {2}", "MAIN", _args, e);
            }
        }

        #region Configuration dumping to console
        private void DumpConfig(string _args)
        {
            try
            {
                string[] args = _args.Split(' ');

                switch (args[0].ToUpper())
                {
                    case ("?"):
                        {
                            CrestronConsole.ConsoleCommandResponse("Type the name of the device to dump config information to console\ne.g. Dump MTRX");
                            break;
                        }
                    case ("MTRX"):
                        {
                            PrintMTRXSignals();
                            break;
                        }
                    case ("DSP"):
                        {
                            PrintDSPSignals();
                            break;
                        }
                    case ("DPLY"):
                        {
                            PrintDPLYSignals();
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} !!! Test(1)): Exception caught: {2}", "MAIN", _args, e);
            }
        }

        /// <summary>
        /// Dumps all matrix configuration to the console
        /// </summary>
        private void PrintMTRXSignals()
        {
            CrestronConsole.PrintLine("{0} *** Matrix {1} is on IP {2}", CLASSID, MTRXEvertz.Name, MTRXEvertzClient.LocalAddressOfClient);

            CrestronConsole.PrintLine("{0} *** Matrix Inputs configured are as follows:", CLASSID);
            foreach (KeyValuePair<int, MTRXSignalInfo> signal in mtrxSignals.Inputs)
            {
                CrestronConsole.PrintLine("Guid: {0}, Name: {1}, Number: {2}", signal.Value.Guid, signal.Value.Name, signal.Value.SignalNumber);
            }

            CrestronConsole.PrintLine("\n{0} *** Matrix Outputs configured are as follows:", CLASSID);
            foreach (KeyValuePair<int, MTRXSignalInfo> signal in mtrxSignals.Outputs)
            {
                CrestronConsole.PrintLine("Guid: {0}, Name: {1}, Number: {2}", signal.Value.Guid, signal.Value.Name, signal.Value.SignalNumber);
            }
            CrestronConsole.PrintLine("{0} *** End of Matrix Signal configuration Dump", CLASSID);
        }

        /// <summary>
        /// Dumps all DSP configuration to the console
        /// </summary>
        private void PrintDSPSignals()
        {
            CrestronConsole.PrintLine("{0} *** DSP {1} is on IP {2}", CLASSID, DSPQSC.Name, DSPQSCClient.LocalAddressOfClient);

            CrestronConsole.PrintLine("{0} *** DSP Signals configured are as follows:", CLASSID);
            foreach (DSPQSCSignal signal in DSPQSC.dSPQSCSignal)
            {
                CrestronConsole.PrintLine("Guid: {0}, Name: {1}, Volume named control: {2}, Mute named control {3}", signal.Guid, signal.VolumeName, signal.VolNamedControl, signal.MuteNamedControl);
            }
            CrestronConsole.PrintLine("{0} *** End of DSP Signal configuration Dump", CLASSID);
        }

        /// <summary>
        /// Dumps all display configurations to the console
        /// </summary>
        private void PrintDPLYSignals()
        {
            foreach (Display display in DisplaysList)
            {
                if (display.Client != null)
                {
                    CrestronConsole.PrintLine("Display: {0}, Name: {1}, Type: {2}, IP: {3}:{4}", display.Guid, display.Controller.Name, display.Controller.ToString(), display.Client.AddressClientConnectedTo, display.Client.PortNumber);
                }
                else if (display.SerialPort != null)
                {
                    CrestronConsole.PrintLine("Display: {0}, Name: {1}, Type: {2}, ICOM: {3]", display.Guid, display.Controller.Name, display.Controller.ToString(), display.SerialPort.ID);
                }
            }
        }
        #endregion
        #endregion

        #region Socket callbacks
        /// <summary>
        /// Method invoked when a UDP server receives data
        /// </summary>
        /// <param name="myUDPServer"></param>
        /// <param name="numberOfBytesReceived"></param>
        public void UDPServerReceiveCallback(UDPServer myUDPServer, int numberOfBytesReceived)
        {
            if (debug) { new Thread(Print, string.Format("{0} <<< UDP {1}_{2}: {3} Bytes", CLASSID, myUDPServer.IPAddressLastMessageReceivedFrom, myUDPServer.PortNumber, numberOfBytesReceived)); }
            string feedback = PWCConvert.BytesToString(myUDPServer.IncomingDataBuffer, numberOfBytesReceived);

            for (int x = 1; x <= camSonyClients.Length; x++)
            {
                if (camSonyClients[x] == myUDPServer)
                {
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}: <<< {1}", CAM_Sony.CLASSID, feedback); }
                    CAMSony[x].EnqueueSerial(feedback);
                    myUDPServer.ReceiveDataAsync(UDPServerReceiveCallback);
                    return;
                }
            }
        }

        /// <summary>
        /// Method invoked when a TCP client receives data
        /// </summary>
        /// <param name="myTCPClient"></param>
        /// <param name="numberOfBytesReceived"></param>
        public void TCPClientReceiveCallback(TCPClient myTCPClient, int numberOfBytesReceived)
        {
            try
            {
                if (debug) { new Thread(Print, string.Format("{0} <<< TCP {1}_{2}: {3} Bytes", CLASSID, myTCPClient.AddressClientConnectedTo, myTCPClient.PortNumber, numberOfBytesReceived)); }
                string feedback = PWCConvert.BytesToString(myTCPClient.IncomingDataBuffer, numberOfBytesReceived);

                if (MTRXEvertzClient == myTCPClient)
                {
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}: <<< {1}", MTRX_EvertzQuartz.CLASSID, feedback); }
                    MTRXEvertz.EnqueueSerial(feedback);
                    myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                    return;
                }
                else if (DSPQSCClient == myTCPClient)
                {
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}: <<< {1}", DSP_QSCCore.CLASSID, feedback); }
                    DSPQSC.EnqueueSerial(feedback);
                    myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                    return;
                }
                foreach(Display display in DisplaysList)
                {
                    if (display.Client == myTCPClient)
                    {
                        if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", DPLY.ABSCLASSID, display.Guid, feedback); }
                        display.Controller.EnqueueSerial(feedback);
                        myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                        return;
                    }
                }
                for (int x = 1; x <= RLYGlobalCacheClients.Length; x++)
                {
                    if (RLYGlobalCacheClients[x] == myTCPClient)
                    {
                        if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", RLY_GlobalCache.CLASSID, x, feedback); }
                        RLYGlobalCache[x].EnqueueSerial(feedback);
                        myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                        return;
                    }
                }
                for (int x = 1; x <= IMGPTvOneClients.Length; x++)
                {
                    if (IMGPTvOneClients[x] == myTCPClient)
                    {
                        if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", IMGP_TVOne.CLASSID, x, feedback); }
                        IMGPTvOne[x].EnqueueSerial(feedback);
                        myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("TCP: !!! ControlSystem_SocketStatusChange: Exception {0}", e);
                myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
            }
        }

        /// <summary>
        /// Method invoked when a TCP client changes state
        /// </summary>
        /// <param name="myTCPClient"></param>
        /// <param name="clientSocketStatus"></param>
        public void TCPClientSocketStatusChange(TCPClient myTCPClient, SocketStatus clientSocketStatus)
        {
            try
            {
                if (debug) { new Thread(Print, string.Format("{0} *** TCP {1}_{2}: Status {3}", CLASSID, myTCPClient.AddressClientConnectedTo, myTCPClient.PortNumber, clientSocketStatus)); }
                if (clientSocketStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                }
                Logger.LogEntry(string.Format("{0} *** TCP {1}_{2}: Status {3}", CLASSID, myTCPClient.AddressClientConnectedTo, myTCPClient.PortNumber, clientSocketStatus), CLASSID, true);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("TCP: !!! ControlSystem_SocketStatusChange: Exception {0}", e);
            }
        }

        /// <summary>
        /// CTimer expired; disconnect parameter client from server
        /// </summary>
        /// <param name="_client"></param>
        public void DisconnectSocket(object _client)
        {
            TCPClient client = (TCPClient)_client;
            if (debug) { new Thread(Print, string.Format("{0} *** TCP {1}_{2}: Disconnecting", CLASSID, client.AddressClientConnectedTo, client.PortNumber)); }
            client.DisconnectFromServer();
        }
        #endregion

        #region COM port and Digital I/O callbacks
        public void SerialPort_SerialDataReceived(ComPort ReceivingComPort, ComPortSerialDataEventArgs args)
        {
            if (debug) { new Thread(Print, string.Format("{0} <<< COM{1}: {2}", CLASSID, ReceivingComPort.ID, args.SerialData)); }

            if (DeviceForComPort.ContainsKey(ReceivingComPort))
            {
                if(DeviceForComPort[ReceivingComPort].GetType() == typeof(Display))
                {
                    Display display = (Display)DeviceForComPort[ReceivingComPort];
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", DPLY.ABSCLASSID, display.Guid, args.SerialData); }
                    display.Controller.EnqueueSerial(args.SerialData);
                }
            }
        }

        private void ControlSystem_StateChange(DigitalInput digitalInput, DigitalInputEventArgs args)
        {
            CrestronConsole.PrintLine("{0} <<< IO{1}: {2}", CLASSID, digitalInput.ID, args.State);
            //if (debug) { new Thread(Print, string.Format("{0} <<< COM{1}: {2}", CLASSID, ReceivingComPort.ID, args.SerialData)); }
            //throw new NotImplementedException();
        }

        void port_VersiportChange(Versiport port, VersiportEventArgs args)
        {
            CrestronConsole.PrintLine("{0} <<< V-IO{1}: {2}: Value:{3}", CLASSID, port.ID, args.Event, port.DigitalIn);

            if (port.ID >= 5 && port.ID <= 8)
            {
                CheckID(null);
            }
            else if (port.ID >= 1 && port.ID <= 4)
            {
                RecallFireAlarmPreset(port.ID, port.DigitalIn);
            }
        }
        #endregion

        /// <summary>
        /// Method to allow Print() to be called from a new thread.
        /// 
        /// </summary>
        /// <param name="_args"></param>
        /// <returns></returns>
        public object Print(object _args)
        {
            string _print = (string)_args;
            Print(_args);
            return null;
        }
        /// <summary>
        /// Prints a string with a random delay between 0 - 300ms
        /// Due to random timing of this, a timestamp is added
        /// </summary>
        /// <param name="_print"></param>
        public void Print(string _print)
        {
            string timestamp = DateTime.Now.ToString("[HH:mm:ss:");
            Thread.Sleep(new Random().Next(0, 200));
            CrestronConsole.PrintLine(timestamp + (CrestronEnvironment.TickCount % 1000).ToString() + "] " + _print);
        }

        #region Fire Alarm Preset Hard Coding
        public bool EnableFireAlarm = false;
        public uint ControlSystemID = 1;                        // Assume this is unit 1 until told otherwise
        public string DSPIPAddress = "10.156.24.62";
        //public string DSPIPAddress = "10.156.24.216";        //Laptop for testing

        /// <summary>
        /// Checks which CP3 this is in the stack
        /// </summary>
        /// <param name="_unused"></param>
        public void CheckID(object _unused)
        {
            if (this.SupportsVersiport)
            {
                for (uint x = 5; x <= this.NumberOfVersiPorts; x++)
                {
                    if (this.VersiPorts[x].DigitalIn == true)
                    {
                        ControlSystemID = x - 4;
                        CrestronConsole.PrintLine("{0} *** THIS IS CP3 NUMBER {1} SYS-ID CP-5A-{1:D2}", CLASSID, ControlSystemID, ControlSystemID+2);
                    }
                }

                EnableFireAlarm = true;
            }
        }

        /// <summary>
        /// Recalls a fire alarm preset in the QSC via a dedicated TCP client in this method.
        /// </summary>
        /// <param name="_portNumber"></param>
        /// <param name="_isClosed"></param>
        public void RecallFireAlarmPreset(uint _portNumber, bool _isClosed)
        {
            if (EnableFireAlarm)
            {
                uint floor = ((ControlSystemID - 1) * 4) + _portNumber;
                CrestronConsole.PrintLine("{0} !!! ID: {1}, Port {2}: {3}. Floor is {4}", "FIRE", ControlSystemID, _portNumber, _isClosed, floor);
                string command = "";
                if (_isClosed)
                {
                    command = string.Format("csp Fire_Unmute_{0:D3}\x0AA", floor);
                }
                else
                {
                    command = string.Format("csp Fire_Mute_{0:D3}\x0AA", floor);
                }

                if (command.Length > 0)
                {
                    TCPClient client = new TCPClient(DSPIPAddress, DSP_QSCCore.IPPORT, 5000);
                    if (client.ConnectToServer() == SocketErrorCodes.SOCKET_OK)
                    {
                        CrestronConsole.PrintLine("{0} !!! {1}:{2} >>> {3}", "FIRE", client.AddressClientConnectedTo, client.PortNumber, command);
                        client.SendData(PWCConvert.StringToBytes(command), command.Length);
                        client.DisconnectFromServer();
                    }
                    else
                    {
                        CrestronConsole.PrintLine("{0} !!! FIRE ALARM CLIENT DIDN'T CONNECT", "FIRE");
                    }
                }
            }
            else
            {
                CrestronConsole.PrintLine("{0} !!! Fire Alarm not enabled yet", "FIRE");
            }
        }
        #endregion
    }

    /// <summary>
    /// Class to hold a display's controller (the actaul DPLY class, a TCP client, and a COM port
    /// </summary>
    public class Display
    {
        public int Guid = -1;
        public DPLY Controller = null;
        public TCPClient Client = null;
        public ComPort SerialPort = null;
    }
}