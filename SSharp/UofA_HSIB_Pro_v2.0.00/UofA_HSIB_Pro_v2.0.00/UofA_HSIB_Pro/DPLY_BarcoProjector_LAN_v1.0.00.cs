using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    /// <summary>
    /// Inherits abstract L3AV DPLY display class
    /// Class expects to connect to device using TCP client, and use the ADCP protocol
    /// </summary>
    public class DPLY_BarcoProjector_LAN : DPLY
    {
        // PULSE API JSON RPC Reference for UDX series.pdf
        public const string CLASSID = "BARC";
        /// <summary>
        /// The IP port used to connect to the device
        /// </summary>
        public const int IpPort = 9090;

        public override int PowerOnTimeInMs
        {
            get
            {
                return 5000;
            }
        }
        public override int PowerOffTimeInMs
        {
            get
            {
                return 5000;
            }
        }
        public override int NumberOfInputs
        {
            get
            {
                return 3;
            }
        }

        public override bool SupportsTrueFeedback
        {
            get
            {
                return true;
            }
        }
        public override bool SupportsCoolingWarming
        {
            get
            {
                return true;
            }
        }
        public override bool SupportsVolume
        {
            get
            {
                return false;
            }
        }
        public override bool SupportsBlanking
        {
            get
            {
                return false;
            }
        }
        public override bool SupportsLampHours
        {
            get
            {
                return false;
            }
        }
        public override uint NumberOfLamps
        {
            get
            {
                return 0;
            }
        }
        public override Input[] InputsSupported
        {
            get
            {
                return new Input[] { Input.HDMI1, Input.DisplayPort, Input.HDBaseT };
            }
        }

        /// <summary>
        /// Constructor
        /// Starts RxTimer
        /// </summary>
        public DPLY_BarcoProjector_LAN()
        {
            debug = true;
            ClearBuffer();
            rxTimer = new CTimer(processRx, null, 300, 300);                        
        }

        /// <summary>
        /// Starts the poll timer
        /// </summary>
        public void StartPolling()
        {
            string command = string.Format(@"{""jsonrpc"": ""2.0"", ""method"": ""property.subscribe"", ""id"": 2, ""params"": {""property"": [""system.state""]}}");
            sendCommand(command);
            command = string.Format(@"{""jsonrpc"": ""2.0"",""method"": ""property.subscribe"",""params"": { ""property: ""image.window.main.source"" },""id"": 5}");
            sendCommand(command);
            pollTimer = new CTimer(poll, null, 10000, 10000);
        }
        /// <summary>
        /// Stops the poll timer
        /// </summary>
        public void StopPolling()
        {
            if (pollTimer != null)
            {
                pollTimer.Stop();
            }
        }

        /// <summary>
        /// Turns on the device
        /// </summary>
        public override void PowerOn()
        {
            string command = string.Format(@"{{""jsonrpc"": ""2.0"", ""method"": ""system.poweron""}}");
            isPoweredOn = true;
            sendCommand(command);
        }
        /// <summary>
        /// Turns on the device
        /// </summary>
        public override void PowerOff()
        {
            string command = string.Format(@"{{""jsonrpc"": ""2.0"", ""method"": ""system.poweroff""}}");
            //{"jsonrpc": "2.0", "method": "system.poweroff"}
            isPoweredOn = false;
            sendCommand(command);
        }
        /// <summary>
        /// Turns on device if off, and turns off device if on
        /// </summary>
        public override void TogglePower()
        {
            if (IsPoweredOn)
            {
                PowerOff();
                isPoweredOn = false;
            }
            else
            {
                PowerOn();
                isPoweredOn = true;
            }
        }        

        /// <summary>
        /// Sets the parameter input 
        /// </summary>
        /// <param name="_input"></param>
        public override void SwitchtoInput(DPLY.Input _input)
        {
            string command = "";
            switch (_input)
            {
                case(Input.HDMI1):
                    {
                        command = string.Format(@"{{""jsonrpc"": ""2.0"", ""method"": ""property.set"", ""params"": {{""property"": ""image.window.main.source"", ""value"": ""L1 HDMI""}} }}");
                        break;
                    }
                case(Input.HDBaseT):
                {
                    command = string.Format(@"{{""jsonrpc"": ""2.0"", ""method"": ""property.set"", ""params"": {{""property"": ""image.window.main.source"", ""value"": ""L1 HDBaseT 1""}} }}");
                    break;
                }
                case (Input.DisplayPort):
                {
                    command = string.Format(@"{{""jsonrpc"": ""2.0"", ""method"": ""property.set"", ""params"": {{""property"": ""image.window.main.source"", ""value"": ""L1 DisplayPort""}} }}");
                    break;
                }
            }
            currentInput = _input;
            sendCommand(command);
        }
        /// <summary>
        /// Check if the paramter input is supported by device
        /// </summary>
        /// <param name="_input"></param>
        /// <returns>true if supported, false if not supported</returns>
        public override bool SupportsInput(DPLY.Input _input)
        {
            foreach (Input input in InputsSupported)
            {
                if (input == _input)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Turns on the video muting
        /// </summary>
        public override void BlankOn()
        {
            string command = string.Format("blank \"on\"\x0D\x0A");
            isBlanked = true;
            sendCommand(command);
        }
        /// <summary>
        /// Turns off the video muting
        /// </summary>
        public override void BlankOff()
        {
            string command = string.Format("blank \"off\"\x0D\x0A");
            isBlanked = true;
            sendCommand(command);
        }
        /// <summary>
        /// Turns on the video muting if already off, and turns off the video muting if already on
        /// </summary>
        public override void ToggleBlank()
        {
            if (IsPoweredOn)
            {
                MuteOff();
                isBlanked = false;
            }
            else
            {
                MuteOn();
                isBlanked = true;
            }
        }

        #region Not implemented methods
        public override uint GetLampHours()
        {
            throw new NotImplementedException();
        }
        public override uint GetLampHours(uint _lamp)
        {
            throw new NotImplementedException();
        }

        public override void IncreaseVolume()
        {
            throw new NotImplementedException();
        }
        public override void DecreaseVolume()
        {
            throw new NotImplementedException();
        }
        public override void StopVolume()
        {
            throw new NotImplementedException();
        }
        public override void SetVolume(uint _volume)
        {
            throw new NotImplementedException();
        }

        public override void MuteOn()        
        {
            throw new NotImplementedException();
        }
        public override void MuteOff()
        {
            throw new NotImplementedException();
        }
        public override void ToggleMute()
        {
            throw new NotImplementedException();
        }
        #endregion

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

        /// <summary>
        /// Checks which poll command should be sent
        /// Invoked when the poll timer has expired        
        /// </summary>
        /// <param name="_args"></param>
        private void poll(object _args)
        {
            switch (pollCounter)
            {
                case(1):
                    {
                        string command = string.Format(@"{""jsonrpc"": ""2.0"", ""method"": ""property.get"", ""id"": 1, ""params"": {""property"": ""system.state""}}");
                        sendCommand(command);
                        break;
                    }
                case (2):
                    {
                        string command = string.Format(@"{""jsonrpc"": ""2.0"",""method"": ""property.get"",""params"": {""property"": ""image.window.main.source""},""id"": 0}");
                        sendCommand(command);
                        break;
                    }
            }

            pollCounter++;
            if (pollCounter > 2) { pollCounter = 1; }
        }

        /// <summary>
        /// checks if a there is a full message fromt he device
        /// Is invoked when the rxTimer has expired
        /// </summary>
        /// <param name="_args"></param>
        protected override void processRx(object _args)
        {
            try
            {
                if (rxData.Length > 0)
                {
                    if (debug) { CrestronConsole.PrintLine("{0} 000<<< {1}", CLASSID, rxData); }
                    ClearBuffer();
                    //Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(rxData);
                    //jObject.SelectToken("");
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
            try
            {
                //CrestronConsole.PrintLine("{0} 000*** _message: {1}", CLASSID, _message);
                if (_message.IndexOf('"') != -1)
                {
                    string[] values = _message.Split('"');
                    switch (values[1])
                    {
                        case ("on"):
                            {
                                isPoweredOn = true;
                                break;
                            }
                        case ("standby"):
                            {
                                isPoweredOn = false;
                                break;
                            }
                        case ("hdmi1"):
                            {
                                currentInput = Input.HDMI1;
                                break;
                            }
                        case ("hdmi2"):
                            {
                                currentInput = Input.HDMI2;
                                break;
                            }
                        case ("rgb"):
                            {
                                currentInput = Input.VGA;
                                break;
                            }
                    }
                }
                else
                {
                    if (debug) { CrestronConsole.PrintLine("{0} 001@@@ processSingleMessage() No speech mark found in {1}", CLASSID, _message); }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 003!!! processSingleMessage() Exception: {1}", CLASSID, e);
            }
        }
    }
}