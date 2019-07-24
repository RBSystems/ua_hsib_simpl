using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    /// <summary>
    /// Abstract class for all display control modules to inherit from
    /// </summary>
    public abstract class DPLY
    {
        public const string ABSCLASSID = "DPLY";

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

        public enum Input { HDMI1, HDMI2, HDMI3, VGA, DisplayPort, Video, HDBaseT, DVI_D, DVI_I, Invalid = -1};
        public enum Power { On, Off, Cooling, Warming, Invalid = -1 };
        public enum FeedbackType { Power, Input, LampHours, Volume, Mute, Blank};
        public enum Volume { Up, Down, Stop, Invalid = -1 };
        
        public abstract int PowerOnTimeInMs
        {
            get;
        }
        public abstract int PowerOffTimeInMs
        {
            get;
        }
        public abstract int NumberOfInputs
        {
            get;
        }

        public abstract bool SupportsTrueFeedback
        {
            get;
        }
        public abstract bool SupportsCoolingWarming
        {
            get;
        }
        public abstract bool SupportsVolume
        {
            get;
        }
        public abstract bool SupportsBlanking
        {
            get;
        }
        public abstract bool SupportsLampHours
        {
            get;
        }
        public abstract uint NumberOfLamps
        {
            get;
        }
        public abstract Input[] InputsSupported
        {
            get;
        }

        protected bool isPoweredOn;
        public bool IsPoweredOn
        {
            get
            {
                return isPoweredOn;
            }
        }

        protected bool isWarmingUp;
        public bool IsWarmingUp
        {
            get
            {
                return isWarmingUp;
            }
        }

        protected bool isCoolingDown;
        public bool IsCoolingDown
        {
            get
            {
                return isCoolingDown;
            }
        }

        protected bool isMuted;
        public bool IsMuted
        {
            get
            {
                return isMuted;
            }
        }

        protected bool isBlanked;
        public bool IsBlanked
        {
            get
            {
                return isBlanked;
            }
        }

        protected DPLY.Input currentInput;
        public DPLY.Input CurrentInput
        {
            get
            {
                return currentInput;
            }
        }

        protected uint currentVolume;
        public uint CurrentVolume
        {
            get
            {
                return currentVolume;
            }
        }

        protected Volume volumeRamping;
        public Volume VolumeRamping
        {
            get
            {
                return volumeRamping;
            }
        }

        protected uint[] lampHours = new uint[5];
        public uint[] LampHours
        {
            get
            {
                return lampHours;
            }
        }

        protected string rxData;
        public int BufferSize
        {
            get
            {
                return rxData.Length;
            }
        }

        protected string name;
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

        protected int guid;
        public int Guid
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
            }
        }

        protected int pollCounter = 1;
        protected CTimer rxTimer;
        protected CTimer pollTimer;
        
        public delegate void CommandToSend(object dply, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object dply, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        public abstract void PowerOn();
        public abstract void PowerOff();
        public abstract void TogglePower();

        public abstract void SwitchtoInput(DPLY.Input _input);
        public abstract bool SupportsInput(DPLY.Input _input);

        public abstract uint GetLampHours();
        public abstract uint GetLampHours(uint _lamp);

        public abstract void IncreaseVolume();
        public abstract void DecreaseVolume();
        public abstract void StopVolume();
        public abstract void SetVolume(uint _volume);

        public abstract void MuteOn();
        public abstract void MuteOff();
        public abstract void ToggleMute();

        public abstract void BlankOn();
        public abstract void BlankOff();
        public abstract void ToggleBlank();

        public virtual void EnqueueSerial(string _rxData)
        {
            rxData += _rxData;
        }
        protected abstract void processRx(object _args);
        public void ClearBuffer()
        {
            rxData = "";
        }
    }

    /// <summary>
    /// An args class to send display feedback back to instantiating class(es)
    /// </summary>
    public class DPLYArgs
    {
        public DPLY.FeedbackType FeedbackType;
        public DPLY.Power Power = DPLY.Power.Invalid;
        public DPLY.Input Input = DPLY.Input.Invalid;
        public uint[] LampHours = new uint[5] { 0, 0, 0, 0, 0 };
        public uint Volume = 0;
        public bool IsMuted;
        public bool IsBlanked;

        public DPLYArgs()
        {
        }

        public DPLYArgs(DPLY.FeedbackType _feedbackType, DPLY.Power _power, DPLY.Input _input)
        {
            FeedbackType = _feedbackType;
            Power = _power;
            Input = _input;
        }

        public DPLYArgs(DPLY.Power _power)
        {
            FeedbackType = DPLY.FeedbackType.Power;
            Power = _power;
        }

        public DPLYArgs(DPLY.Input _input)
        {
            FeedbackType = DPLY.FeedbackType.Input;
            Input = _input;
        }

        public DPLYArgs(uint _volume)
        {
            FeedbackType = DPLY.FeedbackType.Volume;
            Volume = _volume;
        }

        public DPLYArgs(DPLY.FeedbackType _feedbackType, bool _value)
        {
            FeedbackType = _feedbackType;
            if (_feedbackType == DPLY.FeedbackType.Mute) 
            {
                IsMuted = _value;
            }
            else if (_feedbackType == DPLY.FeedbackType.Blank)
            {
                IsBlanked = _value;
            }
        }
    }
}