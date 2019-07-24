using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;

namespace PWCSharpPro
{
    public class LGHT_Lutron
    {
        public const string CLASSID = "LGHT";

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
        private bool debug = true;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string name;

        protected string rxData;
        public int BufferSize
        {
            get
            {
                return rxData.Length;
            }
        }

        protected int pollCounter = 1;
        protected CTimer rxTimer;
        protected CTimer pollTimer;
        #endregion

        public LightingSignal[] RoomSignals = new LightingSignal[50];

        public delegate void CommandToSend(object lght, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object lght, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        public void SetRoomID(int _roomNumber, string _roomID, string _roomName)
        {
            RoomSignals[_roomNumber] = new LightingSignal();
            RoomSignals[_roomNumber].guid = _roomNumber;
            RoomSignals[_roomNumber].LutronID = _roomID;
            RoomSignals[_roomNumber].Name = _roomName;
        }

        public void RecallPreset(int _roomNumber, int _scene)
        {
            if (RoomSignals[_roomNumber] != null)
            {
                RecallPreset(RoomSignals[_roomNumber].LutronID, _scene);
            }
        }
        public void RecallPreset(string _roomID, int _scene)
        {
            if (_roomID != "")
            {
                switch (_scene)
                {
                    case (0):
                        {
                            sendCommand(string.Format("#DEVICE,{0},{1},3\x0D\x0A", _roomID, 83));
                            break;
                        }
                    case (1):
                        {
                            sendCommand(string.Format("#DEVICE,{0},{1},3\x0D\x0A", _roomID, 70));
                            break;
                        }
                    case (2):
                        {
                            sendCommand(string.Format("#DEVICE,{0},{1},3\x0D\x0A", _roomID, 71));
                            break;
                        }
                    case (3):
                        {
                            sendCommand(string.Format("#DEVICE,{0},{1},3\x0D\x0A", _roomID, 76));
                            break;
                        }
                    case (4):
                        {
                            sendCommand(string.Format("#DEVICE,{0},{1},3\x0D\x0A", _roomID, 77));
                            break;
                        }
                    default:
                        {
                            throw new ArgumentOutOfRangeException("Scene number has to be 4 or under");
                        }

                }
            }
        }

        /// <summary>
        /// Sends a request to main class to send data to device.
        /// Will print to console if needed
        /// Checks to ensure event has been subscribed
        /// Resets polla nd Rx timers
        /// </summary>
        /// <param name="_command"></param>
        private void sendCommand(string _command)
        {
            if (debug) { CrestronConsole.PrintLine("{0} 000>>> {1}", CLASSID, _command); }
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, _command);
            }
        }

        public void EnqueueSerial(string _rxData)
        {
            rxData += _rxData;
        }

        private void processRx(object _args)
        {

        }

        public static ComPort.ComPortSpec GetComspec()
        {
            ComPort.ComPortSpec comPortSpec = new ComPort.ComPortSpec();
            comPortSpec.BaudRate = ComPort.eComBaudRates.ComspecBaudRate115200;
            comPortSpec.DataBits = ComPort.eComDataBits.ComspecDataBits8;
            comPortSpec.HardwareHandShake = ComPort.eComHardwareHandshakeType.ComspecHardwareHandshakeNone;
            //ComPortSpec.Pacing = 
            comPortSpec.Parity = ComPort.eComParityType.ComspecParityNone;
            comPortSpec.Protocol = ComPort.eComProtocolType.ComspecProtocolRS232;
            comPortSpec.ReportCTSChanges = false;
            comPortSpec.SoftwareHandshake = ComPort.eComSoftwareHandshakeType.ComspecSoftwareHandshakeNone;
            comPortSpec.StopBits = ComPort.eComStopBits.ComspecStopBits1;
            return (comPortSpec);
        }
    }

    public class LightingSignal
    {
        public int guid;
        public string Name;
        public string LutronID;
    }
}