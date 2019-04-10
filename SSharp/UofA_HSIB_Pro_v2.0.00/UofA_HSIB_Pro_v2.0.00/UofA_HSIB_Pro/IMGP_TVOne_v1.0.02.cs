using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    public class IMGP_TVOne
    {
        /* Changelog
         * v1.0.01: Adding default username and pasword, blank constructor
         * */

        public const string CLASSID = "TV1P";
        public const int IpPort = 10001;
        public const string DEFAULTUSERNAME = "admin";
        public const string DEFAULTPASSWORD = "adminpw";

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
        private bool debug;

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

        private string rxData;
        public int BufferSize
        {
            get
            {
                return rxData.Length;
            }
        }

        private int pollCounter = 1;
        private CTimer rxTimer;
        //private CTimer pollTimer;

        public int CurrentPreset;
        public string Username;
        public string Password;

        /// <summary>
        /// Starts the poll timer
        /// </summary>
        //public void StartPolling()
        //{
        //    pollTimer = new CTimer(poll, null, 10000, 10000);
        //}
        ///// <summary>
        ///// Stops the poll timer
        ///// </summary>
        //public void StopPolling()
        //{
        //    if (pollTimer != null)
        //    {
        //        pollTimer.Stop();
        //    }
        //}

        public delegate void CommandToSend(object dply, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object dply, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        public IMGP_TVOne()
        {
            Username = DEFAULTUSERNAME;
            Password = DEFAULTPASSWORD;
            debug = true;
            ClearBuffer();
            rxTimer = new CTimer(processRx, null, 300, 300);
        }

        public IMGP_TVOne(string _username, string _password)
        {
            Username = _username;
            Password = _password;
            debug = true;
            ClearBuffer();
            rxTimer = new CTimer(processRx, null, 300, 300); 
        }

        public void RecallPreset(int _preset)
        {
            if (_preset <= 49)
            {
                string command = string.Format("Preset.Take = {0}\n", _preset);
                sendCommand(command);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Preset number has to be 49 or under");
            }
        }

        public void Login(string _username, string _password)
        {
            string command = string.Format("login({0},{1})\n", _username, _password);
            sendCommand(command);
        }

        private char calculateChecksum(string _command)
        {
            try
            {
                int checksum = 0;
                foreach (char character in _command)
                {
                    checksum += Convert.ToInt32(character);
                }
                return ( Convert.ToChar(checksum%0xFF) );
            }
            catch
            {
                return ('?');
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
            //rxTimer.Reset(300, 300);
            //pollTimer.Reset(10000, 10000);
        }

        public void EnqueueSerial(string _rxData)
        {
            rxData += _rxData;
        }

        /// <summary>
        /// Checks which poll command should be sent
        /// Invoked when the poll timer has expired        
        /// </summary>
        /// <param name="_args"></param>
        private void poll(object _args)
        {
            switch (pollCounter)
            {
                case (1):
                    {
                        string command = string.Format("Preset.Take\n");
                        sendCommand(command);
                        break;
                    }
            }

            pollCounter++;
            if (pollCounter > 1) { pollCounter = 1; }
        }

        private void processRx(object _args)
        {
            try
            {                
                while (rxData.Contains("\x0A"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} 000<<< {1}", CLASSID, rxData); }

                    int delimiterPos = rxData.IndexOf("\x0A");
                    string message = rxData.Substring(0, delimiterPos + 1);
                    //rxData = rxData.Remove(delimiterPos + 1);
                    rxData = rxData.Substring(delimiterPos + 1, rxData.Length - delimiterPos - 1);
                    processSingleMessage(message);
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 003!!! processRx() Exception: {1}", CLASSID, e);
            }
        }
        /// <summary>
        /// Decodes a full message from the deveice
        /// </summary>
        /// <param name="_message"></param>
        private void processSingleMessage(string _message)
        {
            /*
            try
            {
                CrestronConsole.PrintLine("{0} 000*** _message: {1}", CLASSID, _message);
                if (_message.Contains(@"Please login. Use 'login(username,password)'") || _message.Contains(@"!Error -129 : UNAUTHORISED - Not Logged In"))
                { 
                    //Login("admin", "adminpw");
                    //handling login elsewhere
                }

                
                if (_message.Contains("!Done Preset.Take"))
                {//!Done Preset.Take = 4
                    if (_message.Split(' ').Length == 4)
                    {
                    int preset = Convert.ToInt32(_message.Split(' ')[3]);
                    CurrentPreset = preset;
                    }
                }
                
                else if (_message.Contains(@"Preset.Take"))
                {//Preset.Take = 10 
                    if (_message.Split(' ').Length == 3)
                    {
                        int preset = Convert.ToInt32(_message.Split(' ')[2]);
                        CurrentPreset = preset;
                    }
                    else if (_message.Split(' ').Length == 4)
                    {
                        int preset = Convert.ToInt32(_message.Split(' ')[3]);
                        CurrentPreset = preset;
                    }
                    CrestronConsole.PrintLine("{0} 000*** Current preset: {1}", CLASSID, CurrentPreset);
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 003!!! processSingleMessage() Exception: {1}", CLASSID, e);
            }
            */

        }

        public void ClearBuffer()
        {
            rxData = "";
        }
    }
}