using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    public abstract class CAM
    {
        public enum Power { On, Off, Cooling, Warming, Invalid = -1 };
        public enum Move { Up, Down, Left, Right, Stop, Invalid = -1 };
        public enum Zoom { In, Out, Stop, Invalid = -1 };

        public abstract bool SupportsPresets
        {
            get;
        }
        public abstract int NumberOfPresets
        {
            get;
        }
        public abstract bool SupportsPower
        {
            get;
        }

        protected string rxData;
        public int BufferSize
        {
            get
            {
                return rxData.Length;
            }
        }

        public delegate void CommandToSend(int index, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object dply, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        public abstract void PowerOn();
        public abstract void PowerOff();
        public abstract void TogglePower();

        public abstract void MoveCamera(Move _move);
        public abstract void MoveCamera(Zoom _zoom);
        public abstract void ZoomCamera(Zoom _zoom);

        public abstract void MoveToPreset(int _preset);

        public abstract void SavePreset(int _preset);

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
}