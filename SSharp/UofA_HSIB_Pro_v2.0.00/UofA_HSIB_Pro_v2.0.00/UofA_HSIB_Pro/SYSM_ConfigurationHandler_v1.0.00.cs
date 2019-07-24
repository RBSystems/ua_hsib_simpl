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

        //public void ConfigureDisplay(SigEventArgs args)
        //{
        //    // Format: Name|IP|Model
        //    Display display = new Display();
        //    int portNumber = -1;
        //    switch (args.Sig.StringValue.Split('|')[2].ToUpper())
        //    {
        //        case ("BARCO"):
        //            {
        //                display.Control = new DPLY_BarcoProjector_LAN();
        //                portNumber = DPLY_BarcoProjector_LAN.IpPort;
        //                break;
        //            }
        //        case ("CHRISTIE"):
        //            {
        //                display.Control = new DPLY_ChristieProjector_LAN();
        //                portNumber = DPLY_ChristieProjector_LAN.IpPort;
        //                break;
        //            }
        //        case ("LG"):
        //            {
        //                display.Control = new DPLY_LGLCD();
        //                portNumber = -1;
        //                break;
        //            }
        //        case ("SONYPROJECTOR"):
        //            {
        //                display.Control = new DPLY_SonyProjector_LAN();
        //                break;
        //            }
        //        case ("SONYLCD"):
        //            {
        //                display.Control = new DPLY_SonyLCD_LAN();
        //                break;
        //            }
        //        case ("SONY232"):
        //            {
        //                display.Control = new DPLY_SonyLCD_RS232C();
        //                portNumber = -1;
        //                break;
        //            }
        //        default:
        //            {
        //                return;
        //            }
        //    }

        //    if (display.Control != null)
        //    {
        //        display.Control.Name = args.Sig.StringValue.Split('|')[0];
        //        if (portNumber != -1)
        //        {
        //            display.Client = new TCPClient();
        //            display.Client.AddressClientConnectedTo = args.Sig.StringValue.Split('|')[1];
        //            display.Client.PortNumber = portNumber;
        //            display.Client.ReceiveDataAsync(controlSystem.TCPClientReceiveCallback);
        //        }

        //        controlSystem.DisplayList[args.Sig.Number] = display;

        //        display.Control.OnCommandToSend += new DPLY_SonyLCD_RS232C.CommandToSend(controlSystem.ModuleNeedsToSend);
        //        display.Control.OnFeedbackUpdate += new DPLY_SonyLCD_RS232C.FeedbackUpdate(controlSystem.ModuleHasUpdate);

        //        CrestronConsole.PrintLine("{0} *** Configured Display {1} as {2} named {3} on IP {4}", CLASSID, args.Sig.Number, display.Control.ToString(), display.Control.Name, display.Client.AddressClientConnectedTo);
        //    }
        //}

        public void ConfigureMatrix(SigEventArgs args)
        {
            if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix...", CLASSID); }
            controlSystem.MTRXEvertz = new MTRX_EvertzQuartz();
            controlSystem.MTRXEvertz.OnCommandToSend += new MTRX.CommandToSend(controlSystem.ModuleNeedsToSend);
            controlSystem.MTRXEvertz.OnFeedbackUpdate += new MTRX.FeedbackUpdate(controlSystem.ModuleHasUpdate);

            controlSystem.MTRXEvertz.Name = args.Sig.StringValue.Split('|')[0];

            controlSystem.MTRXEvertzClient = new TCPClient();
            controlSystem.MTRXEvertzClient.SocketStatusChange += new TCPClientSocketStatusChangeEventHandler(controlSystem.TCPClientSocketStatusChange);
            controlSystem.MTRXEvertzClient.AddressClientConnectedTo = args.Sig.StringValue.Split('|')[1];
            controlSystem.MTRXEvertzClient.PortNumber = MTRX_EvertzQuartz.IPPORT;
            controlSystem.MTRXEvertzClient.ConnectToServer();

            controlSystem.mtrxSignals = new MTRXSignals();

            if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix as {1} named {2} on IP {3}", CLASSID, controlSystem.MTRXEvertz.ToString(), controlSystem.MTRXEvertz.Name, controlSystem.MTRXEvertzClient.AddressClientConnectedTo); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// SYNTAX: [name]|[Evertz Input Number]
        /// EXAMPLE: room 123|24</param>
        public void ConfigureMatrixInput(SigEventArgs args)
        {
            int id = (int)args.Sig.Number - 700;
            if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Input with {1}...", CLASSID, args.Sig.StringValue); }
            controlSystem.mtrxSignals.AddInput(id, Int32.Parse(args.Sig.StringValue.Split('|')[1]), args.Sig.StringValue.Split('|')[0]);
            if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Input with guid {1} named {2} with Evertz number {3}", CLASSID, id, controlSystem.mtrxSignals.Inputs[id].Name, controlSystem.mtrxSignals.Inputs[id].SignalNumber); }
        }

        public void ConfigureMatrixOutput(SigEventArgs args)
        {
            if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Matrix Output with {1}...", CLASSID, args.Sig.StringValue); }
            controlSystem.mtrxSignals.AddOutput((int)args.Sig.Number, Int32.Parse(args.Sig.StringValue.Split('|')[1]), args.Sig.StringValue.Split('|')[0]);
            if (debug) { CrestronConsole.PrintLine("{0} *** Configured Matrix Output with guid {1} named {2} with Evertz number {3}", CLASSID, args.Sig.Number, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].Name, controlSystem.mtrxSignals.Outputs[(int)args.Sig.Number].SignalNumber); }
        }

        public void ConfigureCamera(SigEventArgs args)
        {
            int id = (int)args.Sig.Number % 50;
            if (debug) { CrestronConsole.PrintLine("{0} *** Configuring Camera {1} with {2}...", CLASSID, id, args.Sig.StringValue); }
            controlSystem.CAMSony[id] = new CAM_Sony();
            controlSystem.CAMSony[id].Name = args.Sig.StringValue.Split('|')[0];
            controlSystem.CAMSony[id].OnCommandToSend += new CAM_Sony.CommandToSend(controlSystem.ModuleNeedsToSend);
            controlSystem.CAMSony[id].OnFeedbackUpdate += new CAM_Sony.FeedbackUpdate(controlSystem.ModuleHasUpdate);

            //controlSystem.camSonyClients[id] = new UDPServer();
            //controlSystem.camSonyClients[id].AddressToAcceptConnectionFrom = args.Sig.StringValue.Split('|')[1];
            //controlSystem.camSonyClients[id].PortNumber = CAM_Sony.IpPort;
            controlSystem.camSonyClients[id] = new UDPServer(args.Sig.StringValue.Split('|')[1], CAM_Sony.IpPort, 5000);
            controlSystem.camSonyClients[id].ReceiveDataAsync(controlSystem.UDPServerReceiveCallback);
            SocketErrorCodes err =  controlSystem.camSonyClients[id].EnableUDPServer();
            if (debug) { CrestronConsole.PrintLine("{0} *** Configured Camera {1} named {2} with IP {3}", CLASSID, id, controlSystem.CAMSony[id].Name, controlSystem.camSonyClients[id].AddressToAcceptConnectionFrom); }
//CrestronConsole.PrintLine("ERR = {0}", err); ;
        }

        //public void ConfigureDSP(SigEventArgs args)
        //{
        //    controlSystem.DSPQSC.Name = args.Sig.StringValue.Split('|')[0];
        //    controlSystem.DSPQSCClient = new TCPClient();
        //    controlSystem.DSPQSCClient.AddressClientConnectedTo = args.Sig.StringValue.Split('|')[1];
        //    controlSystem.DSPQSCClient.PortNumber = DSP_QSCCore.IPPORT;

        //    CrestronConsole.PrintLine("{0} *** Configured DSP as {1} named {2} on IP {3}", CLASSID, controlSystem.DSPQSC.ToString(), controlSystem.DSPQSC.Name, controlSystem.DSPQSCClient.AddressClientConnectedTo);
        //}

        //public void ConfigureDSPSignal(SigEventArgs args)
        //{
        //    //Name|Vol|Mute
        //    //public void RegisterSignal(uint _signal, string _volumeName, string _volNamedControl, string _muteNamedControl)
        //    controlSystem.DSPQSC.RegisterSignal(args.Sig.Number, args.Sig.StringValue.Split('|')[0], args.Sig.StringValue.Split('|')[1], args.Sig.StringValue.Split('|')[2]);

        //    CrestronConsole.PrintLine("{0} *** Configured DSP signal with index {1} as named {2} with volume named control {3} and mute named control {4}", CLASSID, args.Sig.Number, controlSystem.DSPQSC.dSPQSCSignal[args.Sig.Number].VolumeName, controlSystem.DSPQSC.dSPQSCSignal[args.Sig.Number].VolNamedControl, controlSystem.DSPQSC.dSPQSCSignal[args.Sig.Number].MuteNamedControl);
        //}

        

        //public void ConfigureRelay(SigEventArgs args)
        //{
        //    //Format: Name|IP
        //    controlSystem.RLYGlobalcache[args.Sig.Number].Name = args.Sig.StringValue.Split('|')[0];
        //    controlSystem.RLYGlobalcache[args.Sig.Number + 1].Name = args.Sig.StringValue.Split('|')[0];

        //    controlSystem.rlyGlobalCacheClients[args.Sig.Number].AddressClientConnectedTo = args.Sig.StringValue.Split('|')[1];
        //}

        //public void ConfigureImageProcessor(SigEventArgs args)
        //{

        //}
    }
}