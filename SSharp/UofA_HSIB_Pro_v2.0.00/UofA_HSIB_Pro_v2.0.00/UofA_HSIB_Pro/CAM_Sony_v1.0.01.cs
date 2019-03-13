using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using PWCUtils;

namespace PWCSharpPro
{
    public class CAM_Sony : CAM
    {
        /* Changelog
         * v1.0.01: Adding default ID, blank constructor
         * */

        public const string CLASSID = "SONY";
        public const int IpPort = 52381;
        public const uint DEFAULTID = 0x81;

        public override bool SupportsPresets
        {
            get
            {
                return true;
            }
        }
        public override int NumberOfPresets
        {
            get
            {
                return 16;
            }
        }
        public override bool SupportsPower
        {
            get
            {
                return false;
            }
        }

        public string[] SupportedModels
        {
            get
            {
                return new string[] { "SRG-360SHE", "SRG-120DS" };
            }
        }

        public bool Debug = false;

        public uint ID
        {
            get
            {
                return ID;
            }
            set
            {
                id = value;
                idChar = (char)id;

            }
        }
        private uint id;
        private char idChar;

        private int transaction = 1;

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

        public CAM_Sony()
        {
            id = DEFAULTID;
            idChar = (char)id;
        }

        public CAM_Sony(uint _id)
        {
            id = _id;
            idChar = (char)id;
        }

        public override void PowerOn()
        {
            throw new NotImplementedException();
        }
        public override void PowerOff()
        {
            throw new NotImplementedException();
        }
        public override void TogglePower()
        {
            throw new NotImplementedException();
        }

        public override void MoveCamera(Move _move)
        {
            char panSpeed = '\x11';
            char tiltSpeed = '\x11';
            string movement = "";    

            switch (_move)
            {
                case(Move.Up):
                    {
                        movement = "\x03\x01";
                        break;
                    }
                case (Move.Down):
                    {
                        movement = "\x03\x02";
                        break;
                    }
                case (Move.Left):
                    {
                        movement = "\x01\x03";
                        break;
                    }
                case (Move.Right):
                    {
                        movement = "\x02\x03";
                        break;
                    }
                case (Move.Stop):
                    {
                        movement = "\x03\x03";
                        break;
                    }                
            }
            string command = string.Format("{0}\x01\x06\x01{1}{2}{3}\xFF", idChar, panSpeed, tiltSpeed, movement);
            command = getHeader(command, true) + command;
            sendCommand(command);
        }
        public override void MoveCamera(Zoom _zoom)
        {
            ZoomCamera(_zoom);
        }

        public override void ZoomCamera(Zoom _zoom)
        {
            //char panSpeed = (char)11;
            //char tiltSpeed = (char)11;
            string movement = "";

            switch (_zoom)
            {
                case(Zoom.In):
                    {
                        movement = "\x02";
                        break;
                    }
                case (Zoom.Out):
                    {
                        movement = "\x03";
                        break;
                    }
                case (Zoom.Stop):
                    {
                        movement = "\x00";
                        break;
                    }
            }
            string command = string.Format("{0}\x01\x04\x07{1}\xFF", idChar, movement);
            command = getHeader(command, true) + command;
            sendCommand(command);
        }

        public void InitCamera()
        {
            sendCommand("\x02\x00\x00\x01\x00\x00\x00\x01\x01\xFF");
            //             02  00  00  01  00  00  00  01  01  FF
        }

        private void sendCommand(string _command)
        {            
            if (Debug) { PWCConvert.HexPrint(CLASSID, "000>>>", _command); }
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, _command);
            }
        }

        public override void MoveToPreset(int _preset)
        {            
            char preset = Convert.ToChar( _preset-1);
            string command = string.Format("{0}\x01\x04\x3F\x02{1}\xFF", idChar, preset);
            command = getHeader(command, true) + command;
            sendCommand(command);
        }

        public override void SavePreset(int _preset)
        {
            char preset = Convert.ToChar(_preset-1);
            string command = string.Format("{0}\x01\x04\x3F\x01{1}\xFF", idChar, preset);
            command = getHeader(command, true) + command;
            sendCommand(command);
        }

        protected override void processRx(object _args)
        {

        }

        private string getHeader(string _cmd, bool _isCommand)
        {
            transaction++;
            if (_isCommand)
            {
                return( "\x01\x00" + "\x00" + Convert.ToChar(_cmd.Length) + getTransaction(transaction));
            }
            else
                {
                    return ("\x01\x10" + "\x00" + Convert.ToChar(_cmd.Length) + getTransaction(transaction));
            }
        }

        private string getTransaction(int _transaction)
        {
            try
            {
                char[] chars = new char[4];
                chars[3] = Convert.ToChar(_transaction % 0xFF);
                chars[2] = Convert.ToChar((_transaction / 0xFF) % 0xFF);
                chars[1] = Convert.ToChar((_transaction / 0xFFFF) % 0xFF);
                chars[0] = Convert.ToChar((_transaction / 0xFFFFFF) % 0xFF);
                //if (Debug) { CrestronConsole.PrintLine("{0} 000*** Transaction values {1} {2} {3} {4}: {5}", cClassID, (_transaction / 0xFFFFFF) % 0xFF, (_transaction / 0xFFFF) % 0xFF, (_transaction / 0xFF) % 0xFF, _transaction % 0xFF, new string(chars)); }
                return (new string(chars));
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("{0} 000!!! getTransaction() Exception: {1}", CLASSID, e);
                return "\x00\x00\x00\x00";
            }
        }        
    }
}