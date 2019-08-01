using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;
using PWCSharpPro;
using PWCUtils;
using Crestron.SimplSharpPro.CrestronThread;        	// For Threading
using UofA_HSIB_Pro;


namespace PWCSharpPro
{
    public class MTRX_EvertzQuartz : MTRX
    {
        /* Changelog:
         * v1.0.02: Removed old timing components      
         *          Added new gate for sendCommand() to pace commands
         * v1.0.03: Fixed bug where overwriting a singla in MTRX_Data would throw an excetion; removing previous key fixed.    
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
        ControlSystem controlSystem;
        #endregion



        public MTRX_EvertzQuartz(ControlSystem _controlSystem)
        {
            controlSystem = _controlSystem;
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
                if (_input != currentInputForOutputs[_output])
                {
                    currentInputForOutputs[_output] = _input;           // FAKE NE- I mean, feedback ;)
                    if (OnFeedbackUpdate != null)
                    {
                        MTRXArgs args = new MTRXArgs(FeedbackType.All, _output, _input);
                        OnFeedbackUpdate(this, args);
                    }
                }
                if (controlSystem.mtrxData.GtoIO[MTRX_Item.eIO_Type.Output][(int)_output].A_MTRX_io_Num > 0)
                    _signal = Signal.Audio;

                if (_signal == Signal.Video)
                    return (string.Format(".SV{0},{1}\x0D", _output, _input));
                else if (_signal == Signal.Audio)
                    return (string.Format(".SA{0},{1}\x0D", _output, _input));
                else if (_signal == Signal.Both)
                    return (string.Format(".SVA{0},{1}\x0D", _output, _input));
                else
                {
                    if (Debug) { CrestronConsole.PrintLine("{0} !!! createSwitchCommand({1}, {2}, {3}): Level character(s) invalid", CLASSID, _input, _output, _signal, cNumberOutputs); }
                    throw new IndexOutOfRangeException("Level character(s) invalid");
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
    public class MTRX_Item
    {
        public enum eIO_Type { Output, Input };

        public int Guid;
        public int V_MTRX_io_Num;
        public int A_MTRX_io_Num;
        public eIO_Type IO_Type;
        public string Name;

        public MTRX_Item(int _Guid, int _V_MTRX_io_Num, int _A_MTRX_io_Num, eIO_Type _IO_Type, string _Name)
        {
            Guid = _Guid;
            V_MTRX_io_Num = _V_MTRX_io_Num;
            A_MTRX_io_Num = _A_MTRX_io_Num;
            IO_Type = _IO_Type;
            Name = _Name;
        }
    }

    /// <summary>
    /// Class sotres a list of all the inputs and outputs used in the system
    /// </summary>
    public class MTRX_Data
    {
        //GtoIO[input/output]<(int)guid, (obj)MTRX_Item>
        public Dictionary<MTRX_Item.eIO_Type, Dictionary<int, MTRX_Item>>
            GtoIO = new Dictionary<MTRX_Item.eIO_Type, Dictionary<int, MTRX_Item>>();
        //IOtoG[input/output]<(int)io_num, (int)guid>
        public Dictionary<MTRX_Item.eIO_Type, Dictionary<int, int>>
            IOtoG = new Dictionary<MTRX_Item.eIO_Type, Dictionary<int, int>>();
            
        public MTRX_Data()
        {
            //create the mtrx io lists
            GtoIO[MTRX_Item.eIO_Type.Input] = new Dictionary<int, MTRX_Item>();
            GtoIO.Add(MTRX_Item.eIO_Type.Output, new Dictionary<int, MTRX_Item>());
            //add "blank source" / "none" to the inputs list
            GtoIO[MTRX_Item.eIO_Type.Input].Add(0, new MTRX_Item(0, 0, 0, MTRX_Item.eIO_Type.Input, "Blank Src"));


            IOtoG.Add(MTRX_Item.eIO_Type.Input, new Dictionary<int, int>());
            IOtoG.Add(MTRX_Item.eIO_Type.Output, new Dictionary<int, int>());

            IOtoG[MTRX_Item.eIO_Type.Input].Add(0, 0);
        }

        public void AddIO(int Guid, int V_MTRX_io_Num, int A_MTRX_io_Num, string Name, MTRX_Item.eIO_Type io_type)
        {
            if (GtoIO[io_type].ContainsKey(Guid))
                GtoIO[io_type].Remove(Guid);
            GtoIO[io_type].Add(Guid, new MTRX_Item(Guid, V_MTRX_io_Num, A_MTRX_io_Num, io_type, Name));
            
            if(V_MTRX_io_Num > 0)   IOtoG[io_type].Add(V_MTRX_io_Num, Guid);
            else if(A_MTRX_io_Num > 0) IOtoG[io_type].Add(A_MTRX_io_Num, Guid);
        }

        public int[] GetIOtoG(int _io, MTRX_Item.eIO_Type _type)
        {
            int[] io_num = new int[2];
            io_num[0] = 0;
            io_num[1] = 0;
            if (IOtoG[_type].ContainsKey(_io))
            {
                io_num[0] = IOtoG[_type][_io];
                io_num[1] = IOtoG[_type][_io];
                return (io_num);
            }
            return (io_num);
        }

        public int[] GetGtoIO(int _guid, MTRX_Item.eIO_Type _type)
        {
            int[] io_num = new int[2];
            io_num[0]=0;
            io_num[1]=0;
            if (GtoIO[_type].ContainsKey(_guid))
            {
                io_num[0] = GtoIO[_type][_guid].V_MTRX_io_Num;
                io_num[1] = GtoIO[_type][_guid].A_MTRX_io_Num;
                return (io_num);
            }
            return (io_num);
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