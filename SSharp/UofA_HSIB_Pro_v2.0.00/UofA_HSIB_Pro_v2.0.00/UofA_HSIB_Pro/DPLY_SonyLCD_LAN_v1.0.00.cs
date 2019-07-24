using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    public class DPLY_SonyLCD_LAN : DPLY
    {
        // using the ADCP protocol - ensure the authentication is set off.
        public const string CLASSID = "SONY";
        public const int IpPort = 20060;

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
                return 2;
            }
        }

        public override bool SupportsTrueFeedback
        {
            get
            {
                return false;
            }
        }
        public override bool SupportsCoolingWarming
        {
            get
            {
                return false;
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
                return true;
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
                return new Input[] { Input.HDMI1, Input.HDMI2};
            }
        }

        public DPLY_SonyLCD_LAN()
        {
            debug = false;
            ClearBuffer();
            rxTimer = new CTimer(processRx, null, 300, 300);
        }

        /// <summary>
        /// Starts the poll timer
        /// </summary>
        public void StartPolling()
        {
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

        public override void PowerOn()
        {
            if (debug) { CrestronConsole.PrintLine("{0} {1} *** Generating Power On", CLASSID, guid); }
            string command = string.Format("*SCPOWR0000000000000001\x0A");
            isPoweredOn = true;
            sendCommand(command);
        }

        public override void PowerOff()
        {
            if (debug) { CrestronConsole.PrintLine("{0} {1} *** Generating Power Off", CLASSID, guid); }
            string command = string.Format("*SCPOWR0000000000000000\x0A");
            isPoweredOn = false;
            sendCommand(command);
        }

        public override void TogglePower()
        {
            if (debug) { CrestronConsole.PrintLine("{0} {1} *** Generating Power Toggle", CLASSID, guid); }
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

        public override void SwitchtoInput(DPLY.Input _input)
        {
            if (debug) { CrestronConsole.PrintLine("{0} {1} *** Generating Input {2}", CLASSID, guid, _input); }
            string command = "";
            switch (_input)
            {
                case(Input.HDMI1):
                    {
                        command = string.Format("*SCINPT0000000100000001\x0A");
                        break;
                    }
                case(Input.HDMI2):
                {
                    command = string.Format("*SCINPT0000000100000002\x0A");
                    break;
                }
            }
            currentInput = _input;
            sendCommand(command);
        }

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

        public override void BlankOn()
        {
            string command = string.Format("*SCPMUT0000000000000001\x0A");
            isBlanked = true;
            sendCommand(command);
        }
        public override void BlankOff()
        {
            string command = string.Format("*SCPMUT0000000000000000\x0A");
            isBlanked = true;
            sendCommand(command);
        }
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

        private void sendCommand(string _command)
        {
            if (debug) { CrestronConsole.PrintLine("{0} {1} >>> {2}", CLASSID, guid,_command); }
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, _command);
            }
        }

        private void poll(object _args)
        {
            switch (pollCounter)
            {
                case(1):
                    {
                        string command = string.Format("*SEPOWR################\x0A");
                        sendCommand(command);
                        break;
                    }
                case (2):
                    {
                        string command = string.Format("*SEINPT################\x0A");
                        sendCommand(command);
                        break;
                    }
                case (3):
                    {
                        string command = string.Format("*SEPMUT################\x0A");
                        sendCommand(command);
                        break;
                    }
            }

            pollCounter++;
            if (pollCounter > 2) { pollCounter = 1; }
        }

        protected override void processRx(object _args)
        {
			try
            {
                //CrestronConsole.PrintLine("{0} 000*** RxData: {1}", cClassID, rxData.Length);
                while (rxData.Contains("\x0A"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1} <<< {2}", CLASSID, guid, rxData); }

                    int delimiterPos = rxData.IndexOf("\x0A");
                    string message = rxData.Substring(0, delimiterPos + 1);
                    rxData = rxData.Remove(0, delimiterPos + 1);
                    processSingleMessage(message);
                }
                //CTimer rxTimer = new CTimer(processRx, null, 1000);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} {1} ### processRx() Exception: {2}", CLASSID, guid, e);
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
				_message = _message.Substring(0, _message.Length - 1);
                if (_message.Contains("POWR0000000000000001"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1} *** FB: Device is ON", CLASSID, guid); }
					isPoweredOn = true;

                    if (OnFeedbackUpdate != null)
                    {
                        OnFeedbackUpdate(this, new DPLYArgs(Power.On));
                    }
                }
				else if (_message.Contains("POWR0000000000000000"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1} *** FB: Device is OFF", CLASSID, guid); }
					isPoweredOn = false;

                    if (OnFeedbackUpdate != null)
                    {
                        OnFeedbackUpdate(this, new DPLYArgs(Power.Off));
                    }
                }
				else if (_message.Contains("INPT0000000100000001"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1} *** FB: Device is on HDMI 1", CLASSID, guid); }
					currentInput = Input.HDMI1;

                    if (OnFeedbackUpdate != null)
                    {
                        OnFeedbackUpdate(this, new DPLYArgs(Input.HDMI1));
                    }
                }
				else if (_message.Contains("INPT0000000100000002"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} {1} *** FB: Device is on HDMI 2", CLASSID, guid); }
					currentInput = Input.HDMI2;
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} {1} ### processSingleMessage() Exception: {2}", CLASSID, guid, e);
            }
        }
    }
}