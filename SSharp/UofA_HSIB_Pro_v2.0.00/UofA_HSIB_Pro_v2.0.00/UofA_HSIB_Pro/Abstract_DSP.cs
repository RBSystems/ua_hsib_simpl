using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    /// <summary>
    /// Abstract class for all DSP control modules to inherit from
    /// </summary>
    public abstract class DSP
    {
        protected const int numberSignals = 350;
        protected const int numberGroups = 21;

        public enum FeedbackType { Volume, Mute, All, Data };
        public enum Volume { Up, Down, Stop };

        public abstract bool SupportsTrueFeedback
        {
            get;
        }

        protected Volume[] volumeRamping = new Volume[numberSignals];
        public Volume[] VolumeRamping
        {
            get
            {
                return volumeRamping;
            }
        }
        protected bool[] isMuted = new bool[numberSignals];
        public bool[] IsMuted
        {
            get
            {
                return isMuted;
            }
        }

        protected float[] currentVolumes = new float[numberSignals];
        public float[] CurrentVolumes
        {
            get
            {
                return currentVolumes;
            }
        }
        protected uint[] signalFollowGroups = new uint[numberSignals];
        public uint[] SignalFollowGroups
        {
            get
            {
                return signalFollowGroups;
            }
        }  
        protected string[] returnData = new string[numberSignals];
        public string[] ReturnData
        {
            get
            {
                return returnData;
            }
        }

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
        protected bool debug;

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

        public delegate void CommandToSend(object dply, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object dply, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        public abstract void RegisterSignal(uint _signal);

        public abstract void IncreaseVolume(uint _signal);
        public abstract void DecreaseVolume(uint _signal);
        public abstract void StopVolume(uint _signal);
        public abstract void SetVolume(uint _signal, uint _crestronRange);
        public abstract void SetVolume(uint _signal, int _percentage);
        public abstract void SetVolume(uint _signal, float _volume);
        public abstract void RecallAllDefaultVolumes();
        public abstract void RecallDefaultVolume(uint _signal);

        public abstract void MuteOn(uint _signal);
        public abstract void MuteOff(uint _signal);
        public abstract void ToggleMute(uint _signal);

        public virtual void EnqueueSerial(string _rxData)
        {
            rxData += _rxData;
        }
        protected abstract void processRx(object _args);
        public void ClearBuffer()
        {
            rxData = "";
        }

        protected int GetPercentage(uint _crestronRange)
        {
            float value = (_crestronRange / 655.35f) * 100;
            return ((int)value);
        }

        protected float GetLevel(int _percentage, float _max, float _min)
        {
            float range = _max - _min;
            return _min + (_percentage * range);
        }
    }

    /// <summary>
    /// An args class to send DSP feedback back to instantiating class(es)
    /// </summary>
    public class DSPArgs
    {
        public DSP.FeedbackType FeedbackType;
        public uint Signal;
        public float Volume;
        public bool IsMuted;
        public ushort CrestronRange;

        public DSPArgs()
        {
        }

        public DSPArgs(uint _signal, float _volume)
        {
            Signal = _signal;
            FeedbackType = DSP.FeedbackType.Volume;
            Volume = _volume;
        }

        public DSPArgs(uint _signal, ushort _crestronRange)
        {
            Signal = _signal;
            FeedbackType = DSP.FeedbackType.Volume;
            CrestronRange = _crestronRange;
        }

        public DSPArgs(uint _signal, bool _mute)
        {
            Signal = _signal;
            FeedbackType = DSP.FeedbackType.Mute;
            IsMuted = _mute;
        }

        public DSPArgs(uint _signal, float _volume, bool _mute)
        {
            Signal = _signal;
            FeedbackType = DSP.FeedbackType.All;
            Volume = _volume;
            IsMuted = _mute;
        }
    }
}