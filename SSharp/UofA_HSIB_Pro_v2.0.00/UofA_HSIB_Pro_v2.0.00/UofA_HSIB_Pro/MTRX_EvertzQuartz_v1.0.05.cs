using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using PWCSharpPro;
using PWCUtils;
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading

namespace PWCSharpPro
{
    public class MTRX_EvertzQuartz : MTRX
    {
        /* Changelog:
         * v1.0.02: Removed old timing components      
         *          Added new gate for sendCommand() to pace commands
         * v1.0.03: Fixed bug where overwriting a singla in MTRXSignals would throw an excetion; removing previous key fixed.    
         *          Removed CommandList sub class
         * v1.0.04: Added auto polling      
         * v1.0.05: 
         * */

        #region Comments
        /*
         * v1.0.01 - 2018-07-05: Adding a command list, and therefore pacing commands
         * v1.0.00 - 2018-07-05: Initial build. Starting again in S#P from the S+ version
         * */
        #endregion

        #region Constants
        public const string CLASSID = "EVTZ";         // Prefix print statements with this
        const int cNumberInputs = 1000;
        const int cNumberOutputs = 1000;
        const int cMaxTries = 2;                // Max number of times a command is sent without an ACK
        public const int IPPORT = 5001;           // The defsault IP port number to connect to  

        //Debug versions
        public const int RxCheckTimeinMs = 1000;
        public const int ListCheckTimeinMs = 300;
        public const int AckCheckTimeinMs = 1000;

        #endregion

        #region Global Variables, Properties, and Members

        public override bool SupportsTrueFeedback
        {
            get
            {
                return true;
            }
        }

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

        CTimer rxTimer;
        #endregion

        public MTRX_EvertzQuartz()
        {
            debug = false;
            currentInputForOutputs = new uint[cNumberOutputs + 1];
            ClearBuffer();
            rxTimer = new CTimer(processRx, null, RxCheckTimeinMs, RxCheckTimeinMs);
        }

        #region Auto Polling
        protected uint pollCounter = 1;
        protected CTimer pollTimer;

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

        private void poll(object _args)
        {
            PollOutput(Signal.Both, pollCounter);

            pollCounter++;
            if (pollCounter > 700) { pollCounter = 1; }
        }
        #endregion

        /// <summary>
        /// Clears all outputs of the matrix. 
        /// Will invoke sendCommand() 
        /// </summary>
        /// <param name="_signal">The level to clear - video, audio, or both</param>
        public override void ClearAllOutputs(Signal _signal)
        {
            try
            {
                for (uint output = 1; output <= cNumberInputs; output++)
                {
                    if (OnCommandToSend != null)        // Check if the delegate has been registered!
                    {
                        OnCommandToSend(this, createSwitchCommand(_signal, output, 0) );
                    }
                    else
                    {
                        if (Debug) { CrestronConsole.PrintLine("{0} !!! ClearAllOutputs({1}): OnCommandToSend() not invoked!", CLASSID, _signal); }
                        throw new Exception("OnCommandToSend() not invoked");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void PollOutput(Signal _signal, uint _output)
        {
            sendCommand(string.Format(".IV{0}\x0D", _output));
        }

        /// <summary>
        /// Makes a switch with parameters
        /// Will invoke sendCommand() 
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>        
        /// <param name="_output">The output number of the matrix</param>
        /// <param name="_input">The input number of the matrix</param>
        public override void SetInputForOutput(Signal _signal, uint _output, uint _input)
        {
            try
            {
                sendCommand(createSwitchCommand(_signal, _output, _input));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Makes a switch with parameters
        /// Will invoke sendCommand()  
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>        
        /// <param name="_output">An array of output numbers of the matrix</param>
        /// <param name="_input">The input number of the matrix</param>
        public override void SetInputForOutput(Signal _signal, uint[] _outputs, uint _input)
        {
            try
            {
                foreach (uint output in _outputs)
                {
                    sendCommand(createSwitchCommand(_signal, output, _input));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sets the parameter input for all outputs of the matrix
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>                
        /// <param name="_input">The input number of the matrix</param>
        public override void SetInputForAllOutputs(Signal _signal, uint _input)
        {
            try
            {
                for (uint output = 1; output <= cNumberOutputs; output++)
                {
                    sendCommand(createSwitchCommand(_signal, output, _input));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// DEVELOPMENT AND DEBUG USE ONLY
        /// </summary>
        /// <param name="_command">You're on your own...</param>
        public void SendDirectCommand(string _command)
        {
            bool oldDebug = Debug;
            Debug = true;
            sendCommand(_command + "\x0D");
            Debug = oldDebug;
        }

        /// <summary>
        /// Checks the data back from device to see if a full message has been received,
        /// </summary>
        /// <param name="_args">Not used</param>
        protected override void processRx(object _args)
        {
            if (rxData.Length != 0)
            {
                if (debug) { CrestronConsole.PrintLine("{0} !!! processRx() Buffer has {1} bytes: {2}", CLASSID, BufferSize, rxData); }
                char soh = '.';
                char delimiter = '\x0D';

                try
                {
                    if (rxData.IndexOf(delimiter) > 0)
                    {

                        string message = rxData.Substring(0, rxData.IndexOf(delimiter) + 1);      // Get one full message
                        rxData = rxData.Remove(0, rxData.IndexOf(delimiter) + 1);                   // Remove message from buffer

                        // Removes any junk in front of header
                        if (message.IndexOf(soh) >= 0)
                        {
                            if (debug) { CrestronConsole.PrintLine("{0} !!! processRx() Removing {1} characters from start as junk", CLASSID, message.IndexOf(soh)); }

                            message = message.Remove(0, message.IndexOf(soh));

                            if (Debug) { CrestronConsole.PrintLine("{0} <<< {1}", CLASSID, message); }
                            processSingleMessage(message);
                        }
                    }

                    // Check if the buffer is overflowing - if so, wipe out the entire buffer.
                    if (BufferSize > 10000)
                    {
                        if (debug) { CrestronConsole.PrintLine("{0} !!! {1} has rtopped 10000 - at {1}, clearing buffer", CLASSID, BufferSize); }

                        ErrorLog.Warn("{0} !!! {1} has rtopped 10000 - at {1}, clearing buffer", CLASSID, BufferSize);
                        ClearBuffer();
                    }
                }
                catch (Exception e)
                {
                    if (Debug) { CrestronConsole.PrintLine("Error caught in processRx(): {0}", e); }
                }
                if (debug) { CrestronConsole.PrintLine("\n\n"); }
            }
        }

        /// <summary>
        /// Processes a single, full message from the device
        /// Will invoke FeedbackUpdate delegate
        /// </summary>
        /// <param name="_message">A single message from the device</param>
        private void processSingleMessage(string _message)
        {
            try
            {
                if (_message.Contains(".E"))
                {
                    if (debug) { CrestronConsole.PrintLine("{0} *** processSingleMessage() Error received"); }
                    return;
                }

                string levelcharacters = getLevelCharacters(_message);
                uint output = getOutputNumber(_message);
                uint input = getInputNumber(_message);
                bool changed = false;

                if (debug) { CrestronConsole.PrintLine("{0} *** processSingleMessage() received feedback for {1}, {2}, {3}", CLASSID, levelcharacters, output, input); }

                if (output != 0)
                {
                    if (input != currentInputForOutputs[output])
                    {
                        changed = true;
                    }

                    currentInputForOutputs[output] = input;
                    if (changed)
                    {
                        if (OnFeedbackUpdate != null)
                        {
                            MTRXArgs args = new MTRXArgs(FeedbackType.All, output, input);
                            OnFeedbackUpdate(this, args);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (Debug) { CrestronConsole.PrintLine("Error caught in processSingleMessage({1}): {0}", e, _message); }
            }
        }

        /// <summary>
        /// Returns a switch command based on the parameters, after validating the parameters
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>        
        /// <param name="_output">The output number of the matrix</param>
        /// <param name="_input">The input number of the matrix</param>
        /// <returns>the switch command</returns>
        private string createSwitchCommand(Signal _signal, uint _output, uint _input)
        {
            try
            {
                if (_input <= cNumberInputs)
                {
                    if (_output <= cNumberOutputs)
                    {
                        if (_input != currentInputForOutputs[_output])
                        {
                            currentInputForOutputs[_output] = _input;           // FAKE NE- I mean, feedback ;)
                            if (OnFeedbackUpdate != null)
                            {
                                MTRXArgs args = new MTRXArgs(FeedbackType.All, _output, _input);
                                OnFeedbackUpdate(this, args);
                            }
                        }

                        if (_signal == Signal.Video)
                        {
                            return (string.Format(".SV{0},{1}\x0D", _output, _input));
                        }
                        else if (_signal == Signal.Audio)
                        {
                            return (string.Format(".SA{0},{1}\x0D", _output, _input));
                        }
                        else if (_signal == Signal.Both)
                        {
                            return (string.Format(".SVA{0},{1}\x0D", _output, _input));
                        }
                        else
                        {
                            if (Debug) { CrestronConsole.PrintLine("{0} !!! createSwitchCommand({1}, {2}, {3}): Level character(s) invalid", CLASSID, _input, _output, _signal, cNumberOutputs); }
                            throw new IndexOutOfRangeException("Level character(s) invalid");
                        }
                    }
                    else
                    {
                        if (Debug) { CrestronConsole.PrintLine("{0} !!! createSwitchCommand({1}, {2}, {3}): Output exceeds {4}", CLASSID, _input, _output, _signal, cNumberOutputs); }
                        throw new IndexOutOfRangeException("Output out of range");
                    }
                }
                else
                {
                    if (Debug) { CrestronConsole.PrintLine("{0} !!! createSwitchCommand({1}, {2}, {3}): Input exceeds {4}", CLASSID, _input, _output, _signal, cNumberInputs); }
                    throw new IndexOutOfRangeException("Input out of range");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Section used to pace the commands to Evertz. Sending commands as fast as possible stops the Evertz from working
        public bool PacingBlock = false;
        private const int TimeBetweenCommandsInMs = 100;
        private CTimer PacingTimer;

        private void PacingTimerExpired(object _unused)
        {
            PacingBlock = false;
        }
        #endregion

        /// <summary>
        /// Sends command to device, and prints to console if neceesary
        /// Will invoke CommandToSend delegate, and checks if it's invoked 
        /// </summary>
        /// <param name="_command">The full command to send</param>
        private void sendCommand(string _command)
        {
            while (PacingBlock)
            {
                Thread.Sleep(new Random().Next(0, 10));
            }

            PacingBlock = true;

            if (OnCommandToSend != null)        // Check if the delegate has been registered!
            {
                if (Debug) { CrestronConsole.PrintLine("{0} >>> {1}", CLASSID, _command); }
                OnCommandToSend(this, _command);
            }
            else
            {
                if (Debug) { CrestronConsole.PrintLine("{0} !!! sendCommand(1)): OnCommandToSend() not invoked!", CLASSID, _command); }
                throw new Exception("OnCommandToSend() not invoked");
            }

            PacingTimer = new CTimer(PacingTimerExpired, TimeBetweenCommandsInMs);
        }

        /// <summary>
        /// Returns all level characters from message, which are uppercase letters
        /// </summary>
        /// <param name="_message">A single message from the device</param>
        /// <returns>All level characters from parameter</returns>
        private string getLevelCharacters(string _message)
        {
            try
            {
                char[] message = _message.ToCharArray();
                string levelcharacters = "";

                for (int character = 2; character < message.Length; character++)   // Note - we are starting from 1 because 0 and 1 are ".U" or ".A"
                {
                    if (char.IsUpper(message[character]))
                    {
                        levelcharacters += message[character];
                    }
                    else
                    {
                        break;
                    }
                }

                //if (debug) { CrestronConsole.PrintLine("{0} *** getOutputNumber() Level string is {1}", CLASSID, levelcharacters); }
                return ((levelcharacters));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the output number from a single message from device
        /// </summary>
        /// <param name="_message">A single message from the device</param>
        /// <returns>The matrix output number</returns>
        private uint getOutputNumber(string _message)
        {
            try
            {
                char[] message = _message.ToCharArray();
                string number = "";

                for (int character = 1; character <= message.Length; character++)   // Note - we are starting from 1 because 0 is a "."
                {
                    if (char.IsNumber(message[character]))
                    {
                        number += message[character];
                    }
                    else if (message[character] == ',')
                    {
                        break;
                    }
                }
                //if (debug) { CrestronConsole.PrintLine("{0} *** getOutputNumber() Output string is {1}", CLASSID, number); }
                return (Convert.ToUInt32(number));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the input number from a single message from device
        /// </summary>
        /// <param name="_message">A single message from the device</param>
        /// <returns>The matrix input number</returns>
        private uint getInputNumber(string _message)
        {
            try
            {
                char[] message = _message.ToCharArray();
                string number = "";
                int commaPos = _message.IndexOf(",");

                for (int character = commaPos + 1; character <= message.Length; character++)   // Note - we are starting from 1 because 0 is a "."
                {
                    if (char.IsNumber(message[character]))
                    {
                        number += message[character];
                    }
                    else if (message[character] == '\x0D')
                    {
                        break;
                    }
                }
                //if (debug) { CrestronConsole.PrintLine("{0} *** getInputNumber() Input string is {1}", CLASSID, number); }
                return (Convert.ToUInt32(number));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Class is an args class to store a signals details, such as guid, signal number (on Evertz), name
    /// </summary>
    public class MTRXSignalInfo
    {
        public enum eSignalType { Output, Input };

        public int Guid;
        public int SignalNumber;
        public eSignalType SignalType;
        public string Name;

        public MTRXSignalInfo(int Guid, int SignalNumber, eSignalType SignalType, string Name)
        {
            this.Guid = Guid;
            this.SignalNumber = SignalNumber;
            this.SignalType = SignalType;
            this.Name = Name;
        }
    }

    /// <summary>
    /// Class sotres a list of all the inputs and outputs used in the system
    /// </summary>
    public class MTRXSignals
    {
        public Dictionary<int, MTRXSignalInfo> Inputs = new Dictionary<int, MTRXSignalInfo>();
        public Dictionary<int, MTRXSignalInfo> Outputs = new Dictionary<int, MTRXSignalInfo>();

        public MTRXSignals()
        {
            Inputs = new Dictionary<int, MTRXSignalInfo>();
            Outputs = new Dictionary<int, MTRXSignalInfo>();

            Inputs.Add(0, new MTRXSignalInfo(0, 0, MTRXSignalInfo.eSignalType.Input, "Blank Src"));
        }

        public void AddInput(int Guid, int SignalNumber, string Name)
        {
            MTRXSignalInfo SignalInfo = new MTRXSignalInfo(Guid, SignalNumber, MTRXSignalInfo.eSignalType.Input, Name);

            if (Inputs.ContainsKey(Guid))
            {
                CrestronConsole.PrintLine("{0} *** Removing previous input for GUID {1}", MTRX_EvertzQuartz.CLASSID, Guid);
                Inputs.Remove(Guid);
            }

            Inputs.Add(Guid, SignalInfo);
        }

        public void AddOutput(int Guid, int SignalNumber, string Name)
        {
            MTRXSignalInfo SignalInfo = new MTRXSignalInfo(Guid, SignalNumber, MTRXSignalInfo.eSignalType.Output, Name);

            if (Outputs.ContainsKey(Guid))
            {
                CrestronConsole.PrintLine("{0} *** Removing previous output for GUID {1}", MTRX_EvertzQuartz.CLASSID, Guid);
                Outputs.Remove(Guid);
            }

            Outputs.Add(Guid, SignalInfo);
        }

        public int GetOutputForGuid(int Guid)
        {
            if (Outputs.ContainsKey(Guid))
            {
                return Outputs[Guid].SignalNumber;
            }
            return -1;
        }

        public int GetInputForGuid(int Guid)
        {
            if (Inputs.ContainsKey(Guid))
            {
                return Inputs[Guid].SignalNumber;
            }
            else if (Guid == 0)
            {
                return 0;
            }
            return -1;
        }

        public int GetGuidForInput(int Input)
        {
            if (Input == 0)
            {
                return 0;
            }

            if (Inputs.FirstOrDefault(x => x.Value.SignalNumber == Input).Key != 0)
            {
                return (Inputs.FirstOrDefault(x => x.Value.SignalNumber == Input).Key);
            }
            return 10000 + Input;
            
        }

        public int GetGuidForOutput(int Output)
        {
            if (Outputs.FirstOrDefault(x => x.Value.SignalNumber == Output).Key != 0)
            {
                return (Outputs.FirstOrDefault(x => x.Value.SignalNumber == Output).Key);
            }
            return -1;
        }
    }

    public class EvertzListArgs
    {
        /// <summary>
        ///  The input of the switch command
        /// </summary>
        public uint Input;
        /// <summary>
        /// The output number of the switch command
        /// </summary>
        public uint Output;
        /// <summary>
        /// The level of switch for the command - video, audio, or both
        /// </summary>
        public MTRX.Signal Signal;
        /// <summary>
        /// Number of times the command has been sent without an ACK
        /// </summary>
        public int Retries;
        /// <summary>
        /// EvertzQuartz.checkList() will check this flag to see if a command needs to be re/sent
        /// </summary>
        public bool Send;

        public EvertzListArgs(MTRX.Signal _signal, uint _output, uint _input)
        {
            Signal = _signal;
            Output = _output;
            Input = _input;
            Retries = 0;
            Send = true;

        }
    }
}