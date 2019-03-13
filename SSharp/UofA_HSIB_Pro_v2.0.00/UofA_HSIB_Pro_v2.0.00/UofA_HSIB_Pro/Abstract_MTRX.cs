using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace PWCSharpPro
{
    /// <summary>
    /// Abstract class for all matrix control modules to inherit from
    /// </summary>
    public abstract class MTRX
    {
        public enum Signal { Video, Audio, Both };
        public enum FeedbackType { Audio, Video, All };

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

        public abstract bool SupportsTrueFeedback
        {
            get;
        }

        protected uint[] currentInputForOutputs;
        public uint[] CurrentInputForOutputs
        {
            get
            {
                return currentInputForOutputs;
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

        public delegate void CommandToSend(object mtrx, string command);
        public CommandToSend OnCommandToSend { get; set; }

        public delegate void FeedbackUpdate(object mtrx, object args);
        public FeedbackUpdate OnFeedbackUpdate { get; set; }

        public abstract void ClearAllOutputs(Signal _signal);
        public abstract void SetInputForOutput(Signal _signal, uint _output, uint _input);
        public abstract void SetInputForOutput(Signal _signal, uint[] _outputs, uint _input);
        public abstract void SetInputForAllOutputs(Signal _signal, uint _input);

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
    /// An args class to send matrix feedback back to instantiating class(es)
    /// </summary>
    public class MTRXArgs
    {
        public MTRX.FeedbackType FeedbackType;
        public uint Ouput;
        public uint Input;

        public MTRXArgs(MTRX.FeedbackType _feedbackType, uint _output, uint _input)
        {
            FeedbackType = _feedbackType;
            Ouput = _output;
            Input = _input;
        }
    }
}