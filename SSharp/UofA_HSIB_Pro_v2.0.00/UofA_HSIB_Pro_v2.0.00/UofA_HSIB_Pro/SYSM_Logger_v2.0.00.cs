using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using PWCUtils;
using UofA_HSIB_Pro;

namespace PWCSharpPro
{
    /// <summary>
    /// Class writes lines to the log file.
    /// LogManager will check to ensure the file has not exceeded the maximum number of lines or size
    /// </summary>
    public class SYSM_Logger
    {
        /* Changelog
         * v2.0.00:
         */

        public const string DIRECTORY = @"\RM\Logs";
        public const string LOGFILENAME = "UofA_HSIB_Log";

        private string LogFileName = string.Format(@"{0}\{1}_{2}.txt", DIRECTORY, DateTime.Now.ToString(("MM-dd-yyyy HH-mm-ss")), LOGFILENAME);

        public bool IndeptMode
        {
            get
            {
                return inDepthMode;
            }
            set
            {
                inDepthMode = value;
            }
        }
        private bool inDepthMode;

        private PWCUtils.PWCFile fileOps;       // File operations object
        public string fileNameAndPath;         // The name and path of the file to write to
        ControlSystem controlSystem;

        /// <summary>
        /// Constructor
        /// Calls LogEntry() to add when file was created
        /// </summary>
        /// <param name="_fileNameAndPath">The name and path to the file to be created</param>
        public SYSM_Logger(ControlSystem _controlSystem)
        {
            this.controlSystem = _controlSystem;
            fileOps = new PWCUtils.PWCFile();
            fileOps.Debug = false;
            fileNameAndPath = string.Copy(LogFileName);            
        }

        /// <summary>
        /// Enter a log into the log file
        /// </summary>
        /// <param name="_message">The mian contents of the log entry</param>
        /// <param name="_object">The class name or filename of class</param>
        /// <param name="_id">The type of command, e.g USR, SYSM, CMD</param>
        public void LogEntry(string _message, string _classID, bool _isInDepth)
        {
            try
            {
                _message = _message.Replace("False", "Unsuccessful").Replace("True", "Successful").Replace(",", ".");
                if (!_isInDepth || inDepthMode)// Only log if the entry is not an in-depth entry, in-depth mode is true
                {
                    fileOps.AppendToFile(fileNameAndPath, string.Format("{0} {{{1}}} - {2}\x0D\x0A", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), _classID, _message));
                }
            }
            // File is in use, probably by another instance of LogEntry; wait a random period of time and try again.
            catch (Crestron.SimplSharp.CrestronIO.IOException)
            {
                CrestronEnvironment.Sleep(500 + new Random().Next(0, 500));
                LogEntry(_message, _classID, _isInDepth);
            }
            catch(Exception)
            {
                CrestronConsole.PrintLine("SIMPL#: caught exception when trying to write to file {0}", fileNameAndPath);
            }
            finally
            {
                //controlSystem.LogManager.CheckLogFileSize();
            }
        }
    }

    public class SYSM_LogManager
    {
        public const int MAXLINESTOREAD = 500;
        public const int MAXFILESIZE = 50000;

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
        private bool debug;

        private SYSM_Logger logger;
        private PWCFile fileOps = new PWCFile();
        ControlSystem controlSystem;

        public SYSM_LogManager(SYSM_Logger _logger, ControlSystem _controlSystem)
        {
            logger = _logger;
            this.controlSystem = _controlSystem;
            fileOps = new PWCFile();
            fileOps.Debug = false;
        }

        /// <summary>
        /// Check if the current log file exceeds the max file size, and makes a new instance of it if so
        /// </summary>
        /// <returns>true if a new file has been made</returns>
        public bool CheckLogFileSize()
        {
            try
            {
                // Check if the file exceeds max number of lines
                if (fileOps.OpenFile(logger.fileNameAndPath).Split(Crestron.SimplSharp.CrestronEnvironment.NewLine.ToCharArray()).Length >= MAXLINESTOREAD - 1)
                {
                    if (debug) { CrestronConsole.PrintLine("{1} has reached {0} lines, starting a new file", MAXLINESTOREAD, logger.fileNameAndPath); }
                    logger = new SYSM_Logger(controlSystem);
                    return true;
                }

                //Check if the file exceeds max file size
                if (fileOps.OpenFile(logger.fileNameAndPath).Length > MAXFILESIZE)
                {
                    if (debug) { CrestronConsole.PrintLine("{1} has reached {0} bytes, starting a new file", MAXFILESIZE, logger.fileNameAndPath); }
                    logger = new SYSM_Logger(controlSystem);
                    return true;
                }
                return false;
            }
            // File is in use, probably by another instance of LogEntry; wait a random period of time and try again.
            catch (Crestron.SimplSharp.CrestronIO.IOException)
            {
                if (debug) { CrestronConsole.PrintLine("CSLogManager.CheckLogFileSize() File was busy, retying..."); }
                CrestronEnvironment.Sleep(new Random().Next(0, 300));
                return CheckLogFileSize();
            }
            catch
            {
                return false;
            }
        } 
    }
}