using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using PWCSharpPro;
using PWCUtils;

namespace PWCSharpPro
{
    public class MTRX_EvertzQuartz : MTRX
    {
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
        private EvertzCommandList evertzCommandList = new EvertzCommandList();

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
        #endregion

        public MTRX_EvertzQuartz()
        {
            debug = false;
            currentInputForOutputs = new uint[cNumberOutputs + 1];
            ClearBuffer();
            CTimer rxTimer = new CTimer(processRx, null, RxCheckTimeinMs, RxCheckTimeinMs);
            CTimer listTimer = new CTimer(checkList, null, ListCheckTimeinMs);
            CTimer ackTimer = new CTimer(checkAcks, null, AckCheckTimeinMs);
        }

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
                        //OnCommandToSend(this, createSwitchCommand(_signal, output, 0) );
                        addCommandToQueue(_signal, output, 0);
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
                //if (debug) { CrestronConsole.PrintLine("{0} *** SetInputForOutput() Adding command Out{1} In{2} to Queue", CLASSID, _output, _input); }
                //addCommandToQueue(_signal, _output, _input);
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
                    //sendCommand(createSwitchCommand(_signal, output, _input));
                    addCommandToQueue(_signal, output, _input);
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
                    //sendCommand(createSwitchCommand(_signal, output, _input));
                    addCommandToQueue(_signal, output, _input);
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
            if (BufferSize != 0)
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
        /// Checks evertzCommandList to see which commands need to be sent
        /// </summary>
        /// <param name="_args">Not used</param>
        private void checkList(object _args)
        {
            try
            {
                for (int index = 0; index < evertzCommandList.NumberofCommandsInList; index++)
                {
                    EvertzListArgs evertzListArgs = evertzCommandList.GetCommand(index);
                    if (evertzListArgs.Send)
                    {
                        evertzListArgs.Send = false;
                        if (debug) { CrestronConsole.PrintLine("{0} *** checkList() Found a command {1}, {2}, {3}", CLASSID, evertzListArgs.Signal, evertzListArgs.Output, evertzListArgs.Input); }
                        string command = createSwitchCommand(evertzListArgs.Signal, evertzListArgs.Output, evertzListArgs.Input);
                        if (debug) { CrestronConsole.PrintLine("{0} *** checkList() Created command {1}", CLASSID, command); }
                        sendCommand(command);
                        Crestron.SimplSharpPro.CrestronThread.Thread.Sleep(10);
                    }
                }
                CTimer listTimer = new CTimer(checkList, null, ListCheckTimeinMs);
            }
            catch (Exception e)
            {
                if (Debug) { CrestronConsole.PrintLine("Error caught in checkList(): {0}", e); }
                CTimer listTimer = new CTimer(checkList, null, ListCheckTimeinMs);
            }
        }

        /// <summary>
        /// Checks if any commands need to be resent or needs to be deleted
        /// </summary>
        /// <param name="_args">Not used</param>
        private void checkAcks(object _args)
        {
            try
            {
                for (int index = 0; index < evertzCommandList.NumberofCommandsInList; index++)
                {
                    EvertzListArgs evertzListArgs = evertzCommandList.GetCommand(index);
                    evertzListArgs.Retries++;
                    if (evertzListArgs.Retries >= cMaxTries)
                    {
                        if (Debug) { CrestronConsole.PrintLine("{0} !!! Command ({1},{2},{3}) has reached or exceeded max retries of {4}", CLASSID, evertzListArgs.Signal, evertzListArgs.Output, evertzListArgs.Input, cMaxTries); }
                        ErrorLog.Warn("{0} !!! Command ({1},{2},{3}) has reached or exceeded max retries of {4}", CLASSID, evertzListArgs.Signal, evertzListArgs.Output, evertzListArgs.Input, cMaxTries);
                        evertzListArgs.Send = false;
                        if (debug) { CrestronConsole.PrintLine("{0} *** Number of commands in  List {1}", CLASSID, evertzCommandList.NumberofCommandsInList); }
                        evertzCommandList.RemoveCommandFromList(index);
                        if (debug) { CrestronConsole.PrintLine("{0} *** Number of commands in  List After Delete:{1}", CLASSID, evertzCommandList.NumberofCommandsInList); }
                    }
                    else
                    {
                        if (debug) { CrestronConsole.PrintLine("{0} *** checkAcks() evertzCommandList[{1}] needs to be resent: {2}", CLASSID, index, createSwitchCommand(evertzListArgs.Signal, evertzListArgs.Output, evertzListArgs.Input)); }
                        evertzListArgs.Send = true;
                    }
                }
                CTimer listTimer = new CTimer(checkAcks, null, AckCheckTimeinMs);
            }
            catch (Exception e)
            {
                if (Debug) { CrestronConsole.PrintLine("Error caught in checkAcks(): {0}", e); }
                CTimer listTimer = new CTimer(checkList, null, ListCheckTimeinMs);
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

                    //evertzCommandList.RemoveCommandFromList(Signal.Both, output, input);
                    //if (debug) { CrestronConsole.PrintLine("{0} *** processSingleMessage() Commands waiting for ACKS: {1}", CLASSID, evertzCommandList.NumberofCommandsInList); }

                    
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

        /// <summary>
        /// Sends command to device, and prints to console if neceesary
        /// Will invoke CommandToSend delegate, and checks if it's invoked 
        /// </summary>
        /// <param name="_command">The full command to send</param>
        private void sendCommand(string _command)
        {
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
        }

        /// <summary>
        /// Adds a command to the queue to be sent
        /// Commands will be sent in checkList
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>        
        /// <param name="_output">The output number of the matrix</param>
        /// <param name="_input">The input number of the matrix</param>
        private void addCommandToQueue(Signal _signal, uint _output, uint _input)
        {
            evertzCommandList.AddCommandToList(_signal, _output, _input);
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

                if (debug) { CrestronConsole.PrintLine("{0} *** getOutputNumber() Level string is {1}", CLASSID, levelcharacters); }
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
                if (debug) { CrestronConsole.PrintLine("{0} *** getOutputNumber() Output string is {1}", CLASSID, number); }
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
                if (debug) { CrestronConsole.PrintLine("{0} *** getInputNumber() Input string is {1}", CLASSID, number); }
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
        }

        public void AddInput(int Guid, int SignalNumber, string Name)
        {
            MTRXSignalInfo SignalInfo = new MTRXSignalInfo(Guid, SignalNumber, MTRXSignalInfo.eSignalType.Input, Name);
            Inputs.Add(Guid, SignalInfo);
        }

        public void AddOutput(int Guid, int SignalNumber, string Name)
        {
            MTRXSignalInfo SignalInfo = new MTRXSignalInfo(Guid, SignalNumber, MTRXSignalInfo.eSignalType.Output, Name);
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

            foreach (KeyValuePair<int, MTRXSignalInfo> input in Inputs)
            {
                if (input.Value.SignalNumber == Input)
                {
                    return input.Key;
                }
            }
            //return -1;
            return 10000 + Input;
        }

        public int GetGuidForOutput(int Output)
        {
            foreach (KeyValuePair<int, MTRXSignalInfo> input in Outputs)
            {
                if (input.Value.SignalNumber == Output)
                {
                    return input.Key;
                }
            }
            return -1;
        }
    }

    public class EvertzCommandList
    {
        #region Comments
        /*        
         * v1.0.00 - 2018-07-05: Initial build. Needed something to keep track of the commands to be sent. 
         *      A List enables removing at any index, wheras a Queue does not, otherwise the queue would have been better.
         * */
        #endregion

        public List<EvertzListArgs> CommandList = new List<EvertzListArgs>();

        /// <summary>
        /// Returns the number of commands currently in the list
        /// </summary>
        public int NumberofCommandsInList
        {
            get
            {
                return CommandList.Count;
            }
        }

        /// <summary>
        /// Adds a command to the list
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>        
        /// <param name="_output">The output number of the matrix</param>
        /// <param name="_input">The input number of the matrix</param>
        public void AddCommandToList(MTRX.Signal _signal, uint _output, uint _input)
        {
            EvertzListArgs args = new EvertzListArgs(_signal, _output, _input);
            CommandList.Add(args);
        }

        /// <summary>
        /// Removes a command from the list by index
        /// </summary>
        /// <param name="_index">The index of the command to remove</param>
        public void RemoveCommandFromList(int _index)
        {
            try
            {
                if (_index <= CommandList.Count)
                {
                    CommandList.RemoveAt(_index);
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Request index{0} more than current number of commands {1}", _index, CommandList.Count));
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Removes a command from the list by detail
        /// </summary>
        /// <param name="_signal">The level to switch - video, audio, or both</param>        
        /// <param name="_output">The output number of the matrix</param>
        /// <param name="_input">The input number of the matrix</param>
        public void RemoveCommandFromList(MTRX.Signal _signal, uint _output, uint _input)
        {
            try
            {
                CrestronConsole.PrintLine("RemoveCommandFromList({0},{1},{2})", _signal, _output, _input);

                for (int index = 0; index < CommandList.Count; index++)
                {
                    if (CommandList[index].Signal == _signal && CommandList[index].Output == _output && CommandList[index].Input == _input)
                    {
                        CrestronConsole.PrintLine("Found match at index {0}", index);
                        CommandList.RemoveAt(index);
                        return;
                    }
                }
                throw new Exception("No such command exists in queue");
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the command at an index
        /// </summary>
        /// <param name="_index">The index of the command to obtain</param>
        /// <returns>an args that contains all the information</returns>
        public EvertzListArgs GetCommand(int _index)
        {
            try
            {
                if (_index <= CommandList.Count)
                {
                    return (CommandList[_index]);
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Request index{0} more than current number of commands {1}", _index, CommandList.Count));
                }
            }
            catch
            {
                throw;
            }
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