using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;

namespace PWCSharpPro
{
    public class DPLY_LGLCD : DPLY
    {
        /* Changelog
         * v1.0.01: Making GetComspec() a static method
         * */

        public const string CLASSID = "LGTV";
        public int IpPort = 9761;

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
                return new Input[] { Input.HDMI1, Input.HDMI2, Input.VGA };
            }
        }

        public DPLY_LGLCD()
        {            
            ClearBuffer();
            debug = false;
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
            string command = string.Format("ka 0 01\x0D");
            isPoweredOn = true;
            sendCommand(command);
        }

        public override void PowerOff()
        {
            string command = string.Format("ka 0 00\x0D");
            isPoweredOn = false;
            sendCommand(command);
        }

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

        public override void SwitchtoInput(DPLY.Input _input)
        {
            string command = "";
            switch (_input)
            {
                case (Input.HDMI1):
                    {
                        command = string.Format("xb 0 90\x0D");
                        break;
                    }
                case (Input.HDMI2):
                    {
                        command = string.Format("xb 0 91\x0D");
                        break;
                    }
                case (Input.VGA):
                    {
                        command = string.Format("xb 0 60\x0D");
                        break;
                    }
            }
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
            //if (Enumerable.Range(1, 100).Contains((int)_volume) )
            //{
            //    string command = string.Format("kf 0 {0}\x0D", _volume.ToString("X2"));
            //}
            throw new NotImplementedException();
        }

        public override void MuteOn()
        {
            string command = string.Format("ke 0 01\x0D");
            throw new NotImplementedException();
        }
        public override void MuteOff()
        {
            string command = string.Format("ke 0 00\x0D");
            throw new NotImplementedException();
        }
        public override void ToggleMute()
        {
            throw new NotImplementedException();
        }

        public override void BlankOn()
        {
            throw new NotImplementedException();
        }
        public override void BlankOff()
        {
            throw new NotImplementedException();
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
            if (debug) { CrestronConsole.PrintLine("{0} 000>>> {1}", CLASSID, _command); }
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, _command);
            }
            rxTimer.Reset(300, 300);
            //pollTimer.Reset(10000, 10000);            
        }

        public static ComPort.ComPortSpec GetComspec()
        {
            ComPort.ComPortSpec comPortSpec = new ComPort.ComPortSpec();
            comPortSpec.BaudRate = ComPort.eComBaudRates.ComspecBaudRate9600;
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

        protected override void processRx(object _args)
        {
            //CrestronConsole.PrintLine("{0} *** Checking Rx", cClassID);
            if (rxData.Length != 0)
            {                
                //PWCUtils.PWCConvert.MixPrint(cClassID, "00<<<", rxData);                
                //PWCUtils.PWCConvert.HexPrint(cClassID, "00<<<", rxData);
                //CrestronConsole.PrintLine("{0} <<< ", rxData);
                while (rxData.Contains("x"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} 000<<< {1}", CLASSID, rxData); }

                    int delimiterPos = rxData.IndexOf("x");
                    string message = rxData.Substring(0, delimiterPos + 1);
                    rxData = rxData.Remove(0, delimiterPos + 1);
                    //rxData = rxData.Substring(delimiterPos + 1, rxData.Length - delimiterPos - 1);
                    processSingleMessage(message);
                }
            }
        }

        private void processSingleMessage(string _message)
        {
            try
            {
                CrestronConsole.PrintLine("{0} 000*** _message: {1}", CLASSID, _message);
                if (_message.IndexOf(' ') != -1)
                {
                    _message = _message.Substring(0, _message.Length - 1);
                    string[] values = _message.Split(' ');
                    switch (values[0])
                    {
                        case ("a"):
                            {
                                switch (values[2])
                                {
                                    case ("OK01"):
                                        {
                                            isPoweredOn = true;
                                            
                                            break;
                                        }
                                    case ("OK00"):
                                        {
                                            isPoweredOn = false;
                                            break;
                                        }
                                }
                                if (debug) { CrestronConsole.PrintLine("{0} 000*** Device isPoweredOn: {1}", CLASSID, isPoweredOn); }
                                break;
                            }
                        case ("b"):
                            {
                                switch (values[2])
                                {
                                    case ("OK90"):
                                        {
                                            currentInput = Input.HDMI1;
                                            break;
                                        }
                                    case ("OKA0"):
                                        {
                                            currentInput = Input.HDMI1;
                                            break;
                                        }
                                    case ("OK60"):
                                        {
                                            currentInput = Input.VGA;
                                            break;
                                        }
                                        
                                }
                                if (debug) { CrestronConsole.PrintLine("{0} 000*** Device currentInput: {1}", CLASSID, currentInput); }
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 003!!! processSingleMessage() Exception: {1}", CLASSID, e);
            }
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
                        string command = string.Format("ka 01 FF\x0D");
                        sendCommand(command);
                        break;
                    }
                case (2):
                    {
                        string command = string.Format("xb 01 FF\x0D");
                        sendCommand(command);
                        break;
                    }
            }

            pollCounter++;
            if (pollCounter > 2) { pollCounter = 1; }
        }
    }
}