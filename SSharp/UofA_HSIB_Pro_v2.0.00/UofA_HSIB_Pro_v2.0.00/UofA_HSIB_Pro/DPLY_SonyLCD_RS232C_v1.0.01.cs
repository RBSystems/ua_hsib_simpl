using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;

namespace PWCSharpPro
{
    public class DPLY_SonyLCD_RS232C: DPLY
    {
        /* Changelog
         * v1.0.01: Making GetComspec() a static method
         * */

        public const string CLASSID = "SONY";

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
                return new Input[] { Input.HDMI1, Input.HDMI2};
            }
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

        public DPLY_SonyLCD_RS232C()
        {
            debug = true;
            ClearBuffer();            
            rxTimer = new CTimer(processRx, null, 300, 300); 
        }

        public override void PowerOn()
        {
CrestronConsole.PrintLine("Hit Sony 232 - POWER ON");
            string command = string.Format("\x8C\x00\x00\x02\x01\x8F");
            isPoweredOn = true;
            sendCommand(command);
        }

        public void Initialise()
        {
            string command = string.Format("\x8C\x00\x01\x02\x01\x90");            
            sendCommand(command);
        }

        public override void PowerOff()
        {
            string command = string.Format("\x8C\x00\x00\x02\x00\x8E");
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
                case(Input.HDMI1):
                    {
                        command = string.Format("\x8C\x00\x02\x03\x04\x01\x95");
                        currentInput = Input.HDMI1;
                        sendCommand(command);
                        break;
                    }
                case (Input.HDMI2):
                    {
                        command = string.Format("\x8C\x00\x02\x03\x04\x02\x96");
                        currentInput = Input.HDMI2;
                        sendCommand(command);
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
            //if (debug) { CrestronConsole.PrintLine("{0} 000>>> {1}", cClassID, _command); }
            if (debug) { CrestronConsole.PrintLine("{0} 000>>> {1}", CLASSID, _command); }
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, _command);
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
                        string command = string.Format("\x83\x00\x00\xFF\xFF\x81");
                        sendCommand(command);
                        break;
                    }
                case (2):
                    {
                        string command = string.Format("\x83\x00\x02\xFF\xFF\x83");
                        sendCommand(command);
                        break;
                    }
            }

            pollCounter++;
            if (pollCounter > 2) { pollCounter = 1; }
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
            if (rxData.Length > 0)
            {
                //CrestronConsole.PrintLine("{0} 000<<< {1}", cClassID, );
                //PWCUtils.PWCConvert.HexPrint(cClassID, "000<<<", rxData);
                int sohPos = rxData.IndexOf('\x70');
                //CrestronConsole.PrintLine("{0} 000*** SOH found at {1}", cClassID, sohPos);

                while (rxData.Contains("\x70\x00\x70") || rxData.Contains("\x70\x04\x74"))
                {
                    rxData = rxData.Replace("\x70\x00\x70", "");
                    rxData = rxData.Replace("\x70\x04\x74", "");
                    //CrestronConsole.PrintLine("{0} 000*** Removed an ACK", cClassID);
                }

                if (rxData.Length > 0)
                {
                    sohPos = rxData.IndexOf('\x70');
                    while (sohPos != -1)
                    {
                        if (rxData.Length > sohPos + 1 + 3)
                        {
                            int dataSecLength = Convert.ToInt32(rxData[sohPos + 2]);
                            //CrestronConsole.PrintLine("{0} 000*** Data length is {1}", cClassID, dataSecLength);

                            if (rxData.Length >= sohPos + dataSecLength + 3)
                            {
                                string message = rxData.Substring(sohPos, dataSecLength + 3);
                                rxData = rxData.Remove(0, sohPos + dataSecLength + 3);
                                processSingleMessage(message);
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                        sohPos = rxData.IndexOf('\x70');
                    }
                }
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
                //CrestronConsole.PrintLine("{0} 000*** _message: {1}", cClassID, _message);
                if(debug){PWCUtils.PWCConvert.HexPrint(CLASSID, "000<<<", _message);}

                if (_message.Contains("\x70\x00\x02\x01"))
                {
                    isPoweredOn = true;
                    if (debug) { CrestronConsole.PrintLine("{0} 000*** Display is On", CLASSID); }
                }
                else if (_message.Contains("\x70\x00\x02\x00"))
                {
                    isPoweredOn = true;
                    if (debug) { CrestronConsole.PrintLine("{0} 000*** Display is Off", CLASSID); }
                }
                else if (_message.Contains("\x70\x00\x03\x04\x01"))                
                {
                    currentInput = Input.HDMI1;
                    if (debug) { CrestronConsole.PrintLine("{0} 000*** Display is on Input HDMI 1", CLASSID); }
                }
                else if (_message.Contains("\x70\x00\x03\x04\x02"))
                {
                    currentInput = Input.HDMI2;
                    if (debug) { CrestronConsole.PrintLine("{0} 000*** Display is on Input HDMI 2", CLASSID); }
                }
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 003!!! processSingleMessage() Exception: {1}", CLASSID, e);
            }
        }
    }
}