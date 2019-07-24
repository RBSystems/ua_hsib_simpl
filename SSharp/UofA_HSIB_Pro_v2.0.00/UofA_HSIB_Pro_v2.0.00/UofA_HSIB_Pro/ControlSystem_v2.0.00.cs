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
        #region Constants
        const string CLASSID = "MAIN";
        private const int BUFFERSIZE = 5000;
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
        #endregion

        #region Device Objects and Handlers
        public MTRX_EvertzQuartz MTRXEvertz;
        public MTRXSignals mtrxSignals;

        public DSP_QSCCore DSPQSC;

        public CAM_Sony[] CAMSony = new CAM_Sony[50];
        public List<Display> DisplaysList = new List<Display>();
        #endregion

        #region Device Connections - TCP and UDP Clients
        public TCPClient MTRXEvertzClient;
        public TCPClient DSPQSCClient;
        public UDPServer[] camSonyClients = new UDPServer[50];
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

                CrestronConsole.PrintLine("Exiting Constructor");
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
            if (Debug) { CrestronConsole.PrintLine("Module {0} wants to send {1}", _module, _command); }

            if (_module.GetType() == typeof(MTRX_EvertzQuartz))
            {
                if (MTRXEvertzClient.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (Debug) { CrestronConsole.PrintLine("{0}_{1}:{2}: *** Not connected, now connecting...", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command); }
                    MTRXEvertzClient.ConnectToServer();
                }

                if (MTRXEvertzClient.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    //MTRXEvertzClient.ReceiveDataAsync(TCPClientReceiveCallback);
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command); }
                    MTRXEvertzClient.SendData(PWCConvert.StringToBytes(_command), _command.Length);
                }
                else
                {
                    if (Debug) { CrestronConsole.PrintLine("{0}_{1}:{2}: !!! Not Connected", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command); }
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
                        }
                        return;
                    }
                }
            }
            else if (_module.GetType() == typeof(DSP_QSCCore))
            {
                if (DSPQSCClient.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (Debug) { CrestronConsole.PrintLine("{0}_{1}:{2}: *** Not connected, now connecting...", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command); }
                    DSPQSCClient.ConnectToServer();
                }

                if (DSPQSCClient.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command); }
                    DSPQSCClient.SendData(PWCConvert.StringToBytes(_command), _command.Length);

                }
                else
                {
                    if (Debug) { CrestronConsole.PrintLine("{0}_{1}:{2}: !!! Not Connected", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command); }
                }
                return;
            }
            foreach (Display display in DisplaysList)
            {
                if (display.Controller == _module)
                {
                    if (display.Client.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                    {
                        if (Debug) { CrestronConsole.PrintLine("{0}{1}_{2}:{3}: *** Not connected, now connecting...", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command); }
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
                        if (Debug) { CrestronConsole.PrintLine("{0}{1}_{2}:{3}: !!! Not Connected", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command); }
                        return;
                    }
                }
            }
            ////else if (_module == typeof(IMGP_TVOne))
            ////{
            //for (int index = 1; index <= IMGPTvone.Length; index++)
            //{
            //    if (_module == IMGPTvone[index])
            //    {
            //        if (imgpTvOneClients[index].ConnectToServer() == SocketErrorCodes.SOCKET_OK)
            //        {
            //            if (Debug) { CrestronConsole.PrintLine("{0}{2:D2}: >>> {1}", IMGP_TVOne.CLASSID, _command, index); }
            //            imgpTvOneClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);
            //            Thread.Sleep(200);
            //            imgpTvOneClients[index].DisconnectFromServer();
            //            return;
            //        }
            //        else
            //        {
            //            // Add to log
            //            return;
            //        }
            //    }
            //}
            ////}
            ////else if (_module == typeof(RLY_GlobalCache))
            ////{
            //for (int index = 1; index <= RLYGlobalcache.Length; index++)
            //{
            //    if (_module == RLYGlobalcache[index])
            //    {
            //        if (rlyGlobalCacheClients[index].ConnectToServer() == SocketErrorCodes.SOCKET_OK)
            //        {
            //            if (Debug) { CrestronConsole.PrintLine("{0}{2:D2}: >>> {1}", RLY_GlobalCache.CLASSID, _command, index); }
            //            rlyGlobalCacheClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);
            //            Thread.Sleep(200);
            //            rlyGlobalCacheClients[index].DisconnectFromServer();
            //            return;
            //        }
            //        else
            //        {
            //            // Add to log
            //            return;
            //        }
            //    }
            //}
            ////}           
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
            CrestronConsole.PrintLine("{0} *** ControlSystem_OnlineStatusChange(): {1} DeviceOnLine: {2}", CLASSID, currentDevice, args.DeviceOnLine);
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
            if (!CrestronConsole.AddNewConsoleCommand(DebugEnableDisable, "HSIBDebug", "Some help text", ConsoleAccessLevelEnum.AccessOperator))
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

            //if (!CrestronConsole.AddNewConsoleCommand(DebugDev, "Dev", "Some help text", ConsoleAccessLevelEnum.AccessOperator))
            //{
            //    CrestronConsole.PrintLine("Failed to register console command E-Switch");
            //    ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            //}
            if (Debug) { CrestronConsole.PrintLine("User commands all registered"); }
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

        //public object Test(object _unused)
        //{
        //    CrestronConsole.PrintLine("STARTING TEST...");
        //    Thread.Sleep(1000);
        //    CrestronConsole.PrintLine("EXITING TEST...");
        //    return null;
        //}

        //private void DebugDev(string _args)
        //{
        //    CrestronConsole.PrintLine("INVOKING TEST...");
        //    Thread t = new Thread(Test, null, Thread.eThreadStartOptions.Running);
        //}

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

        private void PrintDPLYSignals()
        {
            foreach (Display display in DisplaysList)
            {
                CrestronConsole.PrintLine("Display: {0}, Name: {1}, Type: {2}, IP: {3}:{4}", display.Guid, display.Controller.Name, display.Controller.ToString(), display.Client.AddressClientConnectedTo, display.Client.PortNumber);
            }
        }
        #endregion

        #region Socket callbacks
        /// <summary>
        /// Method invoked when a UDP server receives data
        /// </summary>
        /// <param name="myUDPServer"></param>
        /// <param name="numberOfBytesReceived"></param>
        public void UDPServerReceiveCallback(UDPServer myUDPServer, int numberOfBytesReceived)
        {
            if (debug) { CrestronConsole.PrintLine("{0}: *** UDP Rx {1} bytes from {2}:{3}", CLASSID, numberOfBytesReceived, myUDPServer.IPAddressLastMessageReceivedFrom, myUDPServer.PortNumber); }
            string feedback = PWCConvert.BytesToString(myUDPServer.IncomingDataBuffer, numberOfBytesReceived);

            for (int index = 1; index <= camSonyClients.Length; index++)
            {
                if (TxRxdebug) { CrestronConsole.PrintLine("{0}: <<< {1}", CAM_Sony.CLASSID, feedback); }
                CAMSony[index].EnqueueSerial(feedback);
                myUDPServer.ReceiveDataAsync(UDPServerReceiveCallback);
                return;
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
                if (debug) { CrestronConsole.PrintLine("{0}: *** TCP Rx {1} bytes from {2}:{3}", CLASSID, numberOfBytesReceived, myTCPClient.AddressClientConnectedTo, myTCPClient.PortNumber); }
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
                //for (int index = 1; index <= imgpTvOneClients.Length; index++)
                //{
                //    if (imgpTvOneClients[index] == myTCPClient)
                //    {
                //        IMGPTvone[index].EnqueueSerial(feedback);
                //        return;
                //    }
                //}
                //for (int index = 1; index <= rlyGlobalCacheClients.Length; index++)
                //{
                //    if (rlyGlobalCacheClients[index] == myTCPClient)
                //    {
                //        RLYGlobalcache[index].EnqueueSerial(feedback);
                //        return;
                //    }
                //}

                
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
                if (Debug) { CrestronConsole.PrintLine("{0} ControlSystem_SocketStatusChange() *** {1}", myTCPClient, clientSocketStatus); }
                if (clientSocketStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                }
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
            client.DisconnectFromServer();
        }
        #endregion
    }

    public class Display
    {
        public int Guid;
        public DPLY Controller;
        public TCPClient Client;
    }
}