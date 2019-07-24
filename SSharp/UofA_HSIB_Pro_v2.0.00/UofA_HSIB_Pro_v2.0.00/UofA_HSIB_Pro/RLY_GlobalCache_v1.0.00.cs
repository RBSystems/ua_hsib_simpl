using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    public class RLY_GlobalCache
    {
        public const string CLASSID = "RLGC";
        public const int NumberOfRelays = 4;
        public const int IpPort = 4998;

        protected bool debug;
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

        private string rxData;
        public int BufferSize
        {
            get
            {
                return rxData.Length;
            }
        }

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

        /// <summary>
        /// Stores which relays are closed and which are open
        /// </summary>
        public bool[] IsRelayClosed = new bool[NumberOfRelays+1];

        public delegate void CommandToSend(object dply, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object dply, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        /// <summary>
        /// Keeps track of which relay to poll
        /// </summary>
        private int pollCounter = 1;
        CTimer rxTimer;
        CTimer pollTimer;

        public RLY_GlobalCache()
        {
            //CrestronConsole.PrintLine("{0} 000*** Calling RLY_GlobalCache()", cClassID);
            ClearBuffer();
            rxTimer = new CTimer(processRx, null, 300, 300);
        }

        /// <summary>
        /// Start polling the device
        /// </summary>
        public void StartPolling()
        {
            pollTimer = new CTimer(poll, null, 12000, 12000);
        }
        /// <summary>
        /// Stop polling the device
        /// </summary>
        public void StopPolling()
        {
            if (pollTimer != null)
            {
                pollTimer.Stop();
            }
        }

        /// <summary>
        /// Closes parameter relay
        /// </summary>
        /// <param name="_relay">The relay to close</param>
        public void SetRelay(int _relay)
        {
            IsRelayClosed[_relay] = true;
            sendCommand(string.Format("setstate,1:{0},1\x0D", _relay));
        }
        /// <summary>
        /// Opens parameter relay
        /// </summary>
        /// <param name="_relay">The relay to open</param>
        public void ResetRelay(int _relay)
        {
            IsRelayClosed[_relay] = false;
            sendCommand(string.Format("setstate,1:{0},0\x0D", _relay));
        }

        /// <summary>
        /// Sends command request to main class
        /// Prints to console if Debug is on
        /// Checks to see if main class has subscribed to data event
        /// Resets the rx and poll timers
        /// </summary>
        /// <param name="_cmd"></param>
        private void sendCommand(string _command)
        {
            if (Debug) { CrestronConsole.PrintLine("{0} 000>>> {1}", CLASSID, _command); }
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, _command);
            }
            rxTimer.Reset(300, 300);
            if (pollTimer != null)
            {
                pollTimer.Reset(12000, 12000);
            }
        }

        public void EnqueueSerial(string _rxData)
        {
            rxData += _rxData;
        }
        public void ClearBuffer()
        {
            rxData = "";
        }
        /// <summary>
        ///  Checks to see if there is a full message in RxData
        /// </summary>
        /// <param name="_args"></param>
        private void processRx(object _args)
        {
            try
            {
                //CrestronConsole.PrintLine("{0} 000*** RxData: {1}", cClassID, rxData.Length);
                while (rxData.Contains("\x0D"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} 000<<< {1}", CLASSID, rxData); }

                    int delimiterPos = rxData.IndexOf("\x0D");
                    string message = rxData.Substring(0, delimiterPos + 1);
                    //rxData = rxData.Remove(delimiterPos + 1);
                    rxData = rxData.Substring(delimiterPos + 1, rxData.Length - delimiterPos - 1);
                    processSingleMessage(message);
                }
                //CTimer rxTimer = new CTimer(processRx, null, 1000);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 000!!! processRx() Exception: {1}", CLASSID, e);
            }
        }
        /// <summary>
        /// Processes a single full messsage from the device
        /// </summary>
        /// <param name="_message"></param>
        private void processSingleMessage(string _message)
        {
            try
            {
                if (debug) { CrestronConsole.PrintLine("{0} 000*** _message: {1}", CLASSID, _message); }
                if (_message.Contains("setstate") || _message.Contains("state"))
                {
                    //setstate,1:1,1[OD]
                    _message = _message.Substring(0, _message.Length - 1);
                    string[] commas = _message.Split(',');
                    string[] colons = commas[1].Split(':');
                    int relay = Convert.ToInt32(colons[1]);
                    bool state = Convert.ToBoolean(Convert.ToInt32(commas[2]));

                    IsRelayClosed[relay] = state;

                    if (debug) { CrestronConsole.PrintLine("{0} 000*** Relay {1} is {2}", CLASSID, relay, state); }

                    if (OnFeedbackUpdate != null)
                    {
                        RLYArgs args = new RLYArgs(relay, state);
                        OnFeedbackUpdate(this, args);
                    }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 000!!! processSingleMessage() Exception: {1}", CLASSID, e);
            }
        }

        /// <summary>
        /// Checks to see which relay should be polled for status info
        /// </summary>
        /// <param name="_args"></param>
        private void poll(object _args)
        {
            string command = string.Format("getstate,1:{0}\x0D", pollCounter);
            sendCommand(command);
            pollCounter++;
            if (pollCounter > NumberOfRelays) { pollCounter = 1; }
        }
    }

    /// <summary>
    /// An args class to send relay feedback back to instantiating class(es)
    /// </summary>
    public class RLYArgs
    {
        public int Relay;
        public bool IsRelayClosed;

        public RLYArgs(int Relay, bool IsRelayClosed)
        {
            this.Relay = Relay;
            this.IsRelayClosed = IsRelayClosed;
        }

    }
}