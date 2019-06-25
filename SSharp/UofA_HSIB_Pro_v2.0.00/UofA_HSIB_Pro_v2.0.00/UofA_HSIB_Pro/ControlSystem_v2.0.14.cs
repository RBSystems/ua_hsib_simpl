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
using System.Diagnostics;

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
         * v2.0.10: Moved Fire alarm handling to new class   
         * v2.0.11: Made efficiencies in MNTS(), specifically when looking for display - module.GetType().IsSubclassOf(typeof(DPLY))) / Display display = DisplaysList.Find(x => x.Controller == _module);
         * v2.0.12: Additional code efficiencies along the same line, but with other devices
         * v2.0.13: Adding EISC block, using  SYSM_EISCHandler_v1.1.01.cs or higher
         * v2.0.14: Moved to Pacer only being used upon reconnect
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
        //public SYSM_Logger Logger;
        //public SYSM_LogManager LogManager;
        #endregion

        #region Device Objects and Handlers
        public MTRX_EvertzQuartz MTRXEvertz;
        public MTRXSignals mtrxSignals;

        public DSP_QSCCore DSPQSC;
        public CAM_Sony[] CAMSony = new CAM_Sony[50];
        public List<Display> DisplaysList = new List<Display>();
        public RLY_GlobalCache[] RLYGlobalCache = new RLY_GlobalCache[100];
        public IMGP_TVOne[] IMGPTvOne = new IMGP_TVOne[10];

        public LGHT_Lutron[] LghtLutron = new LGHT_Lutron[4];
        public Dictionary<int, int> LGHTDeviceForRoom = new Dictionary<int,int>();
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
                Thread.MaxNumberOfUserThreads = 150;

                RegisterConsoleCommands();

                //Subscribe to the controller events (System, Program, and Ethernet)
                CrestronEnvironment.SystemEventHandler += new SystemEventHandler(ControlSystem_ControllerSystemEventHandler);
                CrestronEnvironment.ProgramStatusEventHandler += new ProgramStatusEventHandler(ControlSystem_ControllerProgramEventHandler);
                CrestronEnvironment.EthernetEventHandler += new EthernetEventHandler(ControlSystem_ControllerEthernetEventHandler);

                eiscHandler = new SYSM_EISCHandler(this);
                ConfigurationHandler = new SYSM_ConfigurationHandler(this);
                //Logger = new SYSM_Logger(this);
                //LogManager = new SYSM_LogManager(Logger, this);

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
                //Logger.LogEntry("Program Ready", CLASSID, false);
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

                // Add any DEBUGGING phase hard code vars here
                eiscHandler.Debug = true;
                ConfigurationHandler.Debug = true;
                ConfigurationHandler.Pacer.Debug = true;
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

            #region Matrix commands
            if (_module.GetType() == typeof(MTRX_EvertzQuartz))
            {
                // Connect client if it isn't already (this should never trigger in this system
                if (MTRXEvertzClient.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command)); }
                    MTRXEvertzClient.ConnectToServer();
                }

                // Checkthe socket is connected and send the command
                if (MTRXEvertzClient.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (TxRxdebug) { new Thread(Print, string.Format("{0}_{1}:{2}: >>> {3}", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command)); }
                    MTRXEvertzClient.SendData(PWCConvert.StringToBytes(_command), _command.Length);
                }
                else
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command)); }
                    //Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", MTRX_EvertzQuartz.CLASSID, MTRXEvertzClient.AddressClientConnectedTo, MTRXEvertzClient.PortNumber, _command), CLASSID, false);
                }
                return;
            }
            #endregion
            #region DSP Commands
            else if (_module.GetType() == typeof(DSP_QSCCore))
            {
                if (DSPQSCClient.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command)); }
                    DSPQSCClient.ConnectToServer();
                }

                if (DSPQSCClient.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    //if (TxRxdebug) { CrestronConsole.PrintLine("{0}_{1}:{2}: >>> {3}", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command); }
                    if (TxRxdebug) { new Thread(Print, string.Format("{0}_{1}:{2}: >>> {3}", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command)); }
                    DSPQSCClient.SendData(PWCConvert.StringToBytes(_command), _command.Length);

                }
                else
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command)); }
                    //Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", DSP_QSCCore.CLASSID, DSPQSCClient.AddressClientConnectedTo, DSPQSCClient.PortNumber, _command), CLASSID, false);
                }
                return;
            }
            #endregion
            #region Display Commands
            else if (_module.GetType().IsSubclassOf(typeof(DPLY)))
            {
                Display display = DisplaysList.Find(x => x.Controller == _module);

                // If the client has been initialised, go ahead and do checks and send data
                if (display.Client != null)
                {
                    if (display.Client.ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                    {
                        if (debug) { new Thread(Print, string.Format("{0}{1}_{2}:{3}: *** Not connected, now connecting...", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command)); }
                        display.Client.ConnectToServer();
                    }

                    if (display.Client.ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                    {
                        if (TxRxdebug) { new Thread(Print, string.Format("{0}{1}_{2}:{3}: >>> {4}", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command)); }
                        display.Client.SendData(PWCConvert.StringToBytes(_command), _command.Length);

                        new CTimer(DisconnectSocket, display.Client, 1000);
                        return;
                    }
                    else
                    {
                        if (debug) { new Thread(Print, string.Format("{0}{1}_{2}:{3}: !!! Not Connected", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command)); }
                        //Logger.LogEntry(string.Format("{0}{1}_{2}:{3}: !!! Not Connected", DPLY.ABSCLASSID, display.Guid, display.Client.AddressClientConnectedTo, display.Client.PortNumber, _command), CLASSID, false);
                        return;
                    }
                }
                // Otherwise, if the COM port has been initalised, send the data out the port
                else if (display.SerialPort != null)
                {
                    //if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}_COM{2}: >>> {3}", DPLY.ABSCLASSID, display.Guid, display.SerialPort.ID, _command); }
                    if (TxRxdebug) { new Thread(Print, string.Format("{0}{1}_COM{2}: >>> {3}", DPLY.ABSCLASSID, display.Guid, display.SerialPort.ID, _command)); }
                    display.SerialPort.Send(_command);
                    return;
                }
                else
                {
                    if (debug) { new Thread(Print, string.Format("{0}{1}: !!! Both client and serialport are not initilaised", DPLY.ABSCLASSID, display.Guid)); }
                    return;
                }
            }
            #endregion
            #region Relay Commands
            else if (_module.GetType() == typeof(RLY_GlobalCache))
            {
                int index = Array.IndexOf(RLYGlobalCache, _module);

                if (RLYGlobalCacheClients[index].ClientStatus != SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: *** Not connected, now connecting...", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command)); }
                    RLYGlobalCacheClients[index].ConnectToServer();
                }

                if (RLYGlobalCacheClients[index].ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                {
                    if (TxRxdebug) { new Thread(Print, string.Format("{0}_{1}:{2}: >>> {3}", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command)); }
                    RLYGlobalCacheClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);

                    new CTimer(DisconnectSocket, RLYGlobalCacheClients[index], 1000);
                    return;
                }
                else
                {
                    if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command)); }
                    //Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", RLY_GlobalCache.CLASSID, RLYGlobalCacheClients[index].AddressClientConnectedTo, RLYGlobalCacheClients[index].PortNumber, _command), CLASSID, false);
                    return;
                }
            }
            #endregion
            #region Camera commands
            else if (_module.GetType() == typeof(CAM_Sony))
            {
                for (int index = 1; index <= CAMSony.Length; index++)
                {
                    if (_module == CAMSony[index])
                    {
                        //if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1:D2}_{2}:{3}: >>> {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, _command); }
                        if (TxRxdebug) { new Thread(Print, string.Format("{0}{1:D2}_{2}:{3}: >>> {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, _command)); }
                        SocketErrorCodes err = camSonyClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);
                        if (err != SocketErrorCodes.SOCKET_OK)
                        {
                            CrestronConsole.PrintLine("{0}{1:D2}_{2}:{3}: !!! Send Error: {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, err);
                            //Logger.LogEntry(string.Format("{0}{1:D2}_{2}:{3}: !!! Send Error: {4}", CAM_Sony.CLASSID, index, camSonyClients[index].AddressToAcceptConnectionFrom, camSonyClients[index].PortNumber, err), CLASSID, false);
                        }
                        return;
                    }
                }
            }
            #endregion
            #region Image Processor Commands
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

                        //Thread.Sleep(100);
                        //Because we are now disconnecting after each command, we may need to delay the command send to ensure
                        //that the server is ready

                        if (IMGPTvOneClients[index].ClientStatus == SocketStatus.SOCKET_STATUS_CONNECTED)
                        {
                            if (TxRxdebug) { new Thread(Print, string.Format("{0}_{1}:{2}: >>> {3}", RLY_GlobalCache.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command)); }
                            
                            IMGPTvOneClients[index].SendData(PWCConvert.StringToBytes(_command), _command.Length);
                            
                            new CTimer(DisconnectSocket, IMGPTvOneClients[index], 500);
                            return;
                        }
                        else
                        {
                            if (debug) { new Thread(Print, string.Format("{0}_{1}:{2}: !!! Not Connected", IMGP_TVOne.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command)); }
                            //Logger.LogEntry(string.Format("{0}_{1}:{2}: !!! Not Connected", IMGP_TVOne.CLASSID, IMGPTvOneClients[index].AddressClientConnectedTo, IMGPTvOneClients[index].PortNumber, _command), CLASSID, false);
                            return;
                        }
                    }
                }
            }
            #endregion
            #region Lighting Commands
            else if (_module.GetType() == typeof(LGHT_Lutron))
            {
                foreach (KeyValuePair<ComPort, Object> pair in DeviceForComPort)
                {
                    if (_module == pair.Value)
                    {
                        //if (TxRxdebug) { CrestronConsole.PrintLine("{0}_COM{1}: >>> {2}", LGHT_Lutron.CLASSID,  pair.Key.ID, _command); }
                        if (TxRxdebug) { new Thread(Print, string.Format("{0}_COM{1}: >>> {2}", LGHT_Lutron.CLASSID, pair.Key.ID, _command)); }
                        pair.Key.Send(_command);
                        return;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Invoked when status for a device has been updated - via a module, to be sent to EISC
        /// Just passes it wholesale to the EISC handler
        /// </summary>
        /// <param name="_module">The module invoking</param>
        /// <param name="args">The feedback object</param>
        public void ModuleHasUpdate(object _module, object _args)
        {
            eiscHandler.UpdateEISCSignal(_module, _args);
        }

        #region IP Socket callbacks
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
                    if (TxRxdebug) { new Thread(Print, string.Format("{0}: <<< {1}", MTRX_EvertzQuartz.CLASSID, feedback)); }
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
                else if (DisplaysList.Find(x => x.Client == myTCPClient) != default(Display))
                {
                    Display display = DisplaysList.Find(x => x.Client == myTCPClient);

                    if (display.Client == myTCPClient)
                    {
                        if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", DPLY.ABSCLASSID, display.Guid, feedback); }
                        display.Controller.EnqueueSerial(feedback);
                        myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                        return;
                    }
                }
                else if (Array.IndexOf(RLYGlobalCacheClients, myTCPClient) != -1)  
                {
                    int x = Array.IndexOf(RLYGlobalCacheClients, myTCPClient);

                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", RLY_GlobalCache.CLASSID, x, feedback); }
                    RLYGlobalCache[x].EnqueueSerial(feedback);
                    myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                    return;
                }
                else if (Array.IndexOf(IMGPTvOneClients, myTCPClient) != -1) 
                {
                    int x = Array.IndexOf(IMGPTvOneClients, myTCPClient);

                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}{1}: <<< {2}", IMGP_TVOne.CLASSID, x, feedback); }
                    IMGPTvOne[x].EnqueueSerial(feedback);
                    myTCPClient.ReceiveDataAsync(TCPClientReceiveCallback);
                    return;
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("TCP: ### TCPClientReceiveCallback: Exception {0}", e);
                //Logger.LogEntry(string.Format("TCP: ### TCPClientReceiveCallback: Exception {0}", e), CLASSID, false);
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
                //Logger.LogEntry(string.Format("{0} *** TCP {1}_{2}: Status {3}", CLASSID, myTCPClient.AddressClientConnectedTo, myTCPClient.PortNumber, clientSocketStatus), CLASSID, true);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("TCP: ### TCPClientSocketStatusChange(): Exception {0}", e);
                //Logger.LogEntry(string.Format("TCP: ### TCPClientSocketStatusChange(): Exception {0}", e), CLASSID, false);
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

        #region Serial COM port and I/O callbacks
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
                else if (DeviceForComPort[ReceivingComPort].GetType() == typeof(LGHT_Lutron))
                {
                    LGHT_Lutron lighting = (LGHT_Lutron)DeviceForComPort[ReceivingComPort];
                    if (TxRxdebug) { CrestronConsole.PrintLine("{0}: <<< {1}", LGHT_Lutron.CLASSID, args.SerialData); }
                    lighting.EnqueueSerial(args.SerialData);
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
            Print(_print);
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

        #region User console commands
        /// <summary>
        /// Adds custom console commands to the console
        /// </summary>
        private void RegisterConsoleCommands()
        {
            if (!CrestronConsole.AddNewConsoleCommand(DebugEnableDisable, "Enable", "Enable or disable HSIB Debug prints", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command Debug");
                ErrorLog.Error("{0} 03!!! Failed to register console command Debug", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DebugEvertzSwitchCommand, "Evertz", "Send Evertz commands for HSIB", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DumpConfig, "Dump", "Dump HSIB configuration", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DebugDev, "Dev", "HSIB tempo development commands", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }

            if (!CrestronConsole.AddNewConsoleCommand(DebugSetEiscIP, "SetIP", "Set IPs for IP Table in HSIB", ConsoleAccessLevelEnum.AccessOperator))
            {
                CrestronConsole.PrintLine("Failed to register console command E-Switch");
                ErrorLog.Error("{0} 03!!! Failed to register console command E-Switch", CLASSID);
            }
            if (Debug) { CrestronConsole.PrintLine("User commands all registered"); }
        }

        private void DebugDev(string _args)
        {
            //CrestronConsole.ConsoleCommandResponse("Numbers from {0} are {1}", _args, PWCConvert.ReturnNumbersOnly(_args));

            #region Sending commands directly to a COM port on LG's baud rate with a CR delimiter
            //uint port = UInt32.Parse( _args.Split('|')[0]);
            //string command = _args.Split('|')[1] + "\x0D";


            //ComPorts[port].SetComPortSpec(DPLY_LGLCD.GetComspec());
            //ComPorts[port].SerialDataReceived += new ComPortDataReceivedEvent(SerialPort_SerialDataReceived);

            //new Thread(Print, string.Format("{0}_COM{1}: >>> {2}", CLASSID, port, command));
            //ComPorts[port].Send(command);
            #endregion

            #region Send ID'd LG display commands
            //int id = Int32.Parse(_args.Split(' ')[0]);
            //string cmd = _args.Split(' ')[1];

            //DPLY_LGLCD display = (DPLY_LGLCD)DisplaysList.First(x => x.Guid == id).Controller;

            //if (cmd.ToUpper() == "ON") { display.PowerOn(id); }
            //else if (cmd.ToUpper() == "OFF") { display.PowerOff(id); }
            #endregion

            DSPQSC.EnqueueSerial("cv \"R04_Wmic01_gain_volLevel\" \"-100dB\" -100 0\x0D\x0A");
        }

        /// <summary>
        /// SetIP - Allows the modification of the IP addresses of the EISCs
        /// </summary>
        /// <param name="_args"></param>
        public void DebugSetEiscIP(string _args)
        {
            CrestronConsole.ConsoleCommandResponse("Setting EISC IPs to {0}...\r", _args);

            foreach (ThreeSeriesTcpIpEthernetIntersystemCommunications eisc in eiscs)
            {
                eisc.UnRegister();
                eisc.Dispose();
            }

            CrestronConsole.ConsoleCommandResponse("Unregistered and disposed existing EISCs...\r", _args);

            eiscs[0] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x83, _args, this);
            eiscs[1] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x84, _args, this);
            eiscs[2] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x85, _args, this);
            eiscs[3] = new ThreeSeriesTcpIpEthernetIntersystemCommunications(0x86, _args, this);

            eiscs[0].Description = "Matrix Control";
            eiscs[1].Description = "DSP Control";
            eiscs[2].Description = "Display and Camera Control";
            eiscs[3].Description = "Relay, Lights, and Image Processor Control";

            foreach (ThreeSeriesTcpIpEthernetIntersystemCommunications eisc in eiscs)
            {
                eisc.Register();
                eisc.OnlineStatusChange += new OnlineStatusChangeEventHandler(ControlSystem_OnlineStatusChange);
                eisc.SigChange += new SigEventHandler(eiscHandler.EISC_SigChange);
            }

            CrestronConsole.ConsoleCommandResponse("Complete\r", _args);
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
                    CrestronConsole.ConsoleCommandResponse("Test a Evertz switch command\rIn the format Evertz Switch <Level> <Output> <Input>\nExample: \"Evertz Switch 10 5\" for input 5 to output 10 video\r");
                    CrestronConsole.ConsoleCommandResponse("Also possible to send a free-form command\rIn the format Evertz Command <command>\re.g. Evertz Command .SV1,2 - program will add delimiters");
                }
                else
                {
                    CrestronConsole.ConsoleCommandResponse("Sytax error - type \"Evertz ?\" for more info");
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} ### DebugEvertzSwitchCommand(): Exception caught: {1}", CLASSID, e);
                //Logger.LogEntry(string.Format("{0} ### DebugEvertzSwitchCommand(): Exception caught: {1}", CLASSID, e), CLASSID, false);
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
                            CrestronConsole.ConsoleCommandResponse("Type the name of the device followed by true or false\re.g. Debug MTRX True\rValid options: MTRX, DSP, EISC, MAIN, TXRX, CONFIG, PACE, LOG, DPLY, RLY");
                            break;
                        }
                    case ("MTRX"):
                        {
                            MTRXEvertz.Debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("MTRX debug is now {0}", MTRXEvertz.Debug);
                            break;
                        }
                    case ("DSP"):
                        {
                            DSPQSC.Debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("DSP debug is now {0}", DSPQSC.Debug);
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
                    case ("PACE"):
                        {
                            ConfigurationHandler.Pacer.Debug = Convert.ToBoolean(args[1]);
                            CrestronConsole.ConsoleCommandResponse("PACE debug is now {0}", ConfigurationHandler.Pacer.Debug);
                            break;
                        }
                    case ("LOG"):
                        {
                            if (args[1].ToUpper() == "INDEPTH")
                            {
                                //Logger.IndeptMode = Convert.ToBoolean(args[2]);
                                //CrestronConsole.ConsoleCommandResponse("LOGGER in-depth mode is now {0}", Logger.IndeptMode);
                            }
                            else
                            {

                            }
                            break;
                        }
                    case ("DPLY"):
                        {
                            // Debug DPLY All True or Debug DPLY 1 False
                            bool debug = Convert.ToBoolean(args[2]);
                            if (args[1].ToUpper() == "ALL")
                            {
                                CrestronConsole.ConsoleCommandResponse("Setting Debug to {0} for all displays...\r", debug);
                                foreach (Display display in DisplaysList)
                                {
                                    display.Controller.Debug = debug;
                                    CrestronConsole.ConsoleCommandResponse("DPLY {0} debug is now {1}\r", display.Guid, display.Controller.Debug);
                                }
                            }
                            else
                            {
                                int index = DisplaysList.FindIndex(display => display.Guid == Int32.Parse(args[1]));
                                DisplaysList[index].Controller.Debug = debug;
                                CrestronConsole.ConsoleCommandResponse("DPLY {0} debug is now {1}\r", DisplaysList[index].Guid, DisplaysList[index].Controller.Debug);
                            }
                            break;
                        }
                    case ("RLY"):
                        {
                            // Debug RLY All True or Debug RLY 1 False
                            bool debug = Convert.ToBoolean(args[2]);
                            if (args[1].ToUpper() == "ALL")
                            {
                                CrestronConsole.ConsoleCommandResponse("Setting Debug to {0} for all relays...\r", debug);
                                foreach (RLY_GlobalCache relay in RLYGlobalCache)
                                {
                                    relay.Debug = debug;
                                    CrestronConsole.ConsoleCommandResponse("RLY {0} debug is now {1}\r", relay.Name, relay.Debug);
                                }
                            }
                            else
                            {
                                int index = Int32.Parse(args[1]);
                                RLYGlobalCache[index].Debug = debug;
                                CrestronConsole.ConsoleCommandResponse("RLY {0} debug is now {1}\r", index, RLYGlobalCache[index].Debug);
                            }
                            break;
                        }
                }

            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} ### DebugEnableDisable(): Exception caught: {2}", CLASSID, _args, e);
                //Logger.LogEntry(string.Format("{0} ### DebugEnableDisable(): Exception caught: {2}", CLASSID, _args, e), CLASSID, true);
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
                            CrestronConsole.ConsoleCommandResponse("Type the name of the device to dump config information to console\re.g. Dump MTRX\rValid options: MTRX, DSP, DPLY, CAM, RLY");
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
                    case ("CAM"):
                        {
                            PrintCAMSignals();
                            break;
                        }
                    case ("RLY"):
                        {
                            PrintRLYSignals();
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} ### DumpConfig(): Exception caught: {2}", CLASSID, _args, e);
                //Logger.LogEntry(string.Format("{0} ### DumpConfig(): Exception caught: {2}", CLASSID, _args, e), CLASSID, false);
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
                CrestronConsole.PrintLine("Guid: {0}, Name: {1}, IO_Num: {2}", signal.Value.Guid, signal.Value.Name, signal.Value.SignalNumber);
            }

            CrestronConsole.PrintLine("\n{0} *** Matrix Outputs configured are as follows:", CLASSID);
            foreach (KeyValuePair<int, MTRXSignalInfo> signal in mtrxSignals.Outputs)
            {
                CrestronConsole.PrintLine("Guid: {0}, Name: {1}, IO_Num: {2}", signal.Value.Guid, signal.Value.Name, signal.Value.SignalNumber);
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
            foreach (var signal in DSPQSC.dSPQSCSignals)
            {
                CrestronConsole.PrintLine("Guid: {0}, Name: {1}, Volume named control: {2}, Mute named control {3}", signal.Value.Guid, signal.Value.VolumeName, signal.Value.VolNamedControl, signal.Value.MuteNamedControl);
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

        /// <summary>
        /// Dumps all camera configurations to the console
        /// </summary>
        private void PrintCAMSignals()
        {
            for (int x = 1; x < CAMSony.Length; x++ )
            {
                if (CAMSony[x] != null)
                {
                    CrestronConsole.PrintLine("Camera: {0}, Name: {1}, IP: {2}:{3}", x, CAMSony[x].Name, camSonyClients[x].AddressToAcceptConnectionFrom, camSonyClients[x].PortNumber);
                }
            }
        }

        /// <summary>
        /// Dumps all camera configurations to the console
        /// </summary>
        private void PrintRLYSignals()
        {
            for (int x = 1; x < RLYGlobalCache.Length; x++)
            {
                if (RLYGlobalCache[x] != null)
                {
                    CrestronConsole.PrintLine("Relay: {0}, Name: {1}, IP: {2}:{3}", x, RLYGlobalCache[x].Name, RLYGlobalCacheClients[x].AddressClientConnectedTo, RLYGlobalCacheClients[x].PortNumber);
                }
            }
        }
        #endregion
        #endregion

        #region Controller Events
        public void ControlSystem_OnlineStatusChange(GenericBase currentDevice, OnlineOfflineEventArgs args)
        {
            if (debug) { CrestronConsole.PrintLine("{0} *** ControlSystem_OnlineStatusChange(): {1} DeviceOnLine: {2}", CLASSID, currentDevice, args.DeviceOnLine); }
            //Logger.LogEntry(string.Format("{0} *** ControlSystem_OnlineStatusChange(): {1} DeviceOnLine: {2}", CLASSID, currentDevice, args.DeviceOnLine), CLASSID, false);
               /*
            if (args.DeviceOnLine == true)
            {
                foreach(ThreeSeriesTcpIpEthernetIntersystemCommunications eisc in eiscs)
                {
                    if (eisc == currentDevice)
                    {
                        CrestronConsole.PrintLine("{0} *** EISC connected; enabling pacer", CLASSID, eiscHandler.PacerTimeinMs);
                        eiscHandler.EnablePacer = true;
                        ConfigurationHandler.Pacer.StartPacer();
                        break;
                    }
                }
            }
                */
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