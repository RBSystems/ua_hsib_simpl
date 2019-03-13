using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using PWCSharpPro;
using PWCUtils;

namespace PWCSharpPro
{
    public class DSP_QSCCore : DSP
    {
        public const string CLASSID = "QSCX";         // Prefix print statements with this

        public override bool SupportsTrueFeedback
        {
            get
            {
                return true;
            }
        }
        public string[] PresetNames = new string[100];
        public const int IPPORT = 1702;           // The defsault IP port number to connect to 

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

        public string RouterName
        {
            get
            {
                return routerName;
            }
            //set
            //{
            //    routerName = value;
            //}
        }
        private string routerName;

        public DSPQSCSignal[] dSPQSCSignal = new DSPQSCSignal[numberSignals];

        /// <summary>
        /// Not implemented in this class.
        /// </summary>
        /// <param name="_signal"></param>
        public override void RegisterSignal(uint _signal)
        {
            throw new System.InvalidOperationException("This device does not support this method");
        }

        /// <summary>
        /// Registers paramter signal with max volume of 6dB, min of -20dB, and default of 0dB
        /// </summary>
        /// <param name="_signal">The signal number to register</param>
        /// <param name="_volumeName">A name for the signal e.g. Program Audio</param>
        /// <param name="_volNamedControl">The Named Control for this volume level</param>
        /// <param name="_muteNamedControl">The Named control for this volume mute control</param>
        public void RegisterSignal(uint _signal, string _volumeName, string _volNamedControl, string _muteNamedControl)
        {
            RegisterSignal(_signal, _volumeName, _volNamedControl, _muteNamedControl, 6.0f, -20.0f, 0.0f);
        }

        public void RegisterPreset(uint _signal, string _presetName)
        {
            if (_signal >= 1 && _signal <= 99)
            {
                PresetNames[_signal] = _presetName;
            }
        }

        public void RegisterRouter(string _routerName)
        {
            routerName = _routerName;
        }

        /// <summary>
        /// Registers parameter signal
        /// </summary>
        /// <param name="_signal">The signal number to register</param>
        /// <param name="_volumeName">A name for the signal e.g. Program Audio</param>
        /// <param name="_volNamedControl">The Named Control for this volume level</param>
        /// <param name="_muteNamedControl">The Named control for this volume mute control</param>
        /// <param name="_max">The maximum level in dB of the level</param>
        /// <param name="_min">Theminimum levelin Db of the level</param>
        /// <param name="_defaultLevel">The level in dB to set the level upon default called</param>
        public void RegisterSignal(uint _signal, string _volumeName, string _volNamedControl, string _muteNamedControl, float _max, float _min, float _defaultLevel)
        {
            dSPQSCSignal[_signal] = new DSPQSCSignal(_signal, _volumeName, _volNamedControl, _muteNamedControl, _max, _min, _defaultLevel);
        }

        public void RecallPreset(uint _signal)
        {
            if (OnCommandToSend != null)
            {
                OnCommandToSend(this, string.Format("ct {0}\x0A", PresetNames[(int)_signal]));
            }
        }

        /// <summary>
        /// Increases volume of parameter fader
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void IncreaseVolume(uint _signal)
        {
            if (OnCommandToSend != null)
            {
                currentVolumes[_signal]++;
                if (currentVolumes[_signal] > dSPQSCSignal[_signal].MaxLevel)
                {
                    currentVolumes[_signal] = dSPQSCSignal[_signal].MaxLevel;
                }
                volumeRamping[_signal] = Volume.Up;

                string command = getVolumeCommand(_signal);
                if (command != "")
                {
                    OnCommandToSend(this, command);
                    CTimer volTimer = new CTimer(volumeTimer, _signal, 500);
                }
            }
        }
        /// <summary>
        /// Decreases volume of parameter fader
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void DecreaseVolume(uint _signal)
        {
            if (OnCommandToSend != null)
            {
                currentVolumes[_signal]--;
                if (currentVolumes[_signal] > dSPQSCSignal[_signal].MinLevel)
                {
                    currentVolumes[_signal] = dSPQSCSignal[_signal].MinLevel;
                }
                volumeRamping[_signal] = Volume.Down;

                string command = getVolumeCommand(_signal);
                if (command != "")
                {
                    OnCommandToSend(this, command);
                    CTimer volTimer = new CTimer(volumeTimer, _signal, 500);
                }
            }
        }

        /// <summary>
        /// Stop volume ramping of parameter fader
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void StopVolume(uint _signal)
        {
            volumeRamping[_signal] = Volume.Stop;
        }

        /// <summary>
        /// Checks if a repeat volume command needs to be send
        /// </summary>
        /// <param name="args"></param>
        private void volumeTimer(object args)
        {
            uint _signal = (uint)args;
            switch (volumeRamping[_signal])
            {
                case Volume.Up:
                    {
                        if (OnCommandToSend != null)
                        {
                            currentVolumes[_signal]++;
                            if (currentVolumes[_signal] > dSPQSCSignal[_signal].MaxLevel)
                            {
                                currentVolumes[_signal] = dSPQSCSignal[_signal].MaxLevel;
                            }
                            volumeRamping[_signal] = Volume.Up;
                            string command = getVolumeCommand(_signal);
                            if (command != "")
                            {
                                OnCommandToSend(this, command);
                            }
                        }
                        CTimer volTimer = new CTimer(volumeTimer, null, 300);
                        break;
                    }
                case Volume.Down:
                    {
                        if (OnCommandToSend != null)
                        {
                            currentVolumes[_signal]--;
                            if (currentVolumes[_signal] > dSPQSCSignal[_signal].MinLevel)
                            {
                                currentVolumes[_signal] = dSPQSCSignal[_signal].MinLevel;
                            }
                            volumeRamping[_signal] = Volume.Down;
                            string command = getVolumeCommand(_signal);
                            if (command != "")
                            {
                                OnCommandToSend(this, command);
                            }
                        }
                        CTimer volTimer = new CTimer(volumeTimer, null, 300);
                        break;
                    }
            }

        }

        /// <summary>
        /// Sets volume of parameter fader to desired level.
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        /// <param name="_crestronRange">0 - 65535 i.e. ARAMP value range and standard Crestron range</param>
        public override void SetVolume(uint _signal, uint _crestronRange)
        {
            if (dSPQSCSignal[(int)_signal] != null)
            {
                if (OnCommandToSend != null)
                {
                    int percent = GetPercentage(_crestronRange);
                    SetVolume(_signal, percent);
                }
            }
        }
        /// <summary>
        /// Sets volume of parameter fader to desired level.
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        /// <param name="_percentage">0-100 for percentage</param>
        public override void SetVolume(uint _signal, int _percentage)
        {
            if (dSPQSCSignal[(int)_signal] != null)
            {
                float volume = GetLevel(_percentage, dSPQSCSignal[_signal].MaxLevel, dSPQSCSignal[_signal].MinLevel);
                SetVolume(_signal, volume);
            }
        }
        /// <summary>
        /// Sets volume of parameter fader to desired level.
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        /// <param name="_volume">The absolute value to set e.g. -10.5f for -10.5dB</param>
        public override void SetVolume(uint _signal, float _volume)
        {
            if (dSPQSCSignal[(int)_signal] != null)
            {
                if (Debug) { CrestronConsole.PrintLine("{0}: *** Settting Volume {1} {2} to {3}dB", CLASSID, _signal, dSPQSCSignal[(int)_signal].VolumeName, _volume); }
                if (OnCommandToSend != null)
                {
                    currentVolumes[_signal] = _volume;

                    string command = getVolumeCommand(_signal);
                    if (command != "")
                    {
                        OnCommandToSend(this, command);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the mute on of parameter fader 
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void MuteOn(uint _signal)
        {
            if (dSPQSCSignal[(int)_signal] != null)
            {
                if (OnCommandToSend != null)
                {
                    isMuted[_signal] = true;
                    string command = string.Format("csp {0} 1\x0A", dSPQSCSignal[_signal].MuteNamedControl);
                    OnCommandToSend(this, command);
                }
            }
        }
        /// <summary>
        /// Sets the mute off of parameter fader 
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void MuteOff(uint _signal)
        {
            if (dSPQSCSignal[(int)_signal] != null)
            {
                if (OnCommandToSend != null)
                {
                    isMuted[_signal] = false;
                    string command = string.Format("csp {0} 0\x0A", dSPQSCSignal[_signal].MuteNamedControl);
                    OnCommandToSend(this, command);
                }
            }
        }
        /// <summary>
        /// Toggles the mute on of parameter fader 
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void ToggleMute(uint _signal)
        {
            if (isMuted[_signal])
            {
                MuteOff(_signal);
            }
            else
            {
                MuteOn(_signal);
            }
        }

        /// <summary>
        /// Returns a full command for parameter signal
        /// </summary>
        /// <param name="_signal">The signal to create the level command for</param>
        /// <returns>The command to send to the device</returns>
        private string getVolumeCommand(uint _signal)
        {
            string command = "";
            command = string.Format("csv {0} {1}\x0A", dSPQSCSignal[_signal].VolNamedControl, currentVolumes[_signal]);
            return (command);
        }

        /// <summary>
        /// Sets all registered faders to default level.
        /// </summary>
        public override void RecallAllDefaultVolumes()
        {
            if (OnCommandToSend != null)
            {
                for (uint signal = 1; signal <= numberSignals; signal++)
                {
                    if (dSPQSCSignal[signal].IsRegistered)
                    {
                        currentVolumes[signal] = dSPQSCSignal[signal].DefaultLevel;
                        string command = getVolumeCommand(signal);
                        if (command != "")
                        {
                            OnCommandToSend(this, command);
                        }

                    }
                }
            }
        }
        /// <summary>
        /// Sets parameter fader to default level. 
        /// </summary>
        /// <param name="_signal">The fader to manipulate. 1 - 30</param>
        public override void RecallDefaultVolume(uint _signal)
        {
            if (OnCommandToSend != null)
            {
                currentVolumes[_signal] = dSPQSCSignal[_signal].DefaultLevel;
                string command = getVolumeCommand(_signal);
                if (command != "")
                {
                    OnCommandToSend(this, command);
                };
            }
        }

        protected override void processRx(object _args)
        {
            //todo
            ClearBuffer();
        }

        /// <summary>
        /// Sets an input to be tied to an output using named controls. 
        /// Will first recall UnsetPoint() to clear all existing routes.
        /// </summary>
        /// <param name="_output"></param>
        /// <param name="_input"></param>
        public void SetPoint(int _output, int _input)
        {
            UnsetPoint(_output);
            if (OnCommandToSend != null)
            {
                // Route_Outnnn_Innnn
                string command = string.Format("csp Route_Out{0:D3}_In{1:D3}} 1\x0AA", _output, _input);
                OnCommandToSend(this, command);
            }
        }

        /// <summary>
        /// Clears all the inputs routed to an input using a Preset
        /// </summary>
        /// <param name="_output"></param>
        public void UnsetPoint(int _output)
        {
            if (OnCommandToSend != null)
            {
                string command = string.Format("ct Route_Clear_Out{0:D3}\x0AA", _output);
                OnCommandToSend(this, command);
            }
        }
    }

    /// <summary>
    /// A class to hold all signal information
    /// </summary>
    public class DSPQSCSignal
    {
        public bool IsRegistered;
        public string VolumeName;
        public string VolNamedControl;
        public string MuteNamedControl;
        public float MaxLevel;
        public float MinLevel;
        public float DefaultLevel;
        public uint Guid;

        public DSPQSCSignal(uint _signal, string _volumeName, string _volNamedControl, string _muteNamedControl, float _max, float _min, float _defaultLevel)
        {
            Guid = _signal;
            VolumeName = _volumeName;
            VolNamedControl = _volNamedControl;
            MuteNamedControl = _muteNamedControl;
            MaxLevel = _max;
            MinLevel = _min;
            DefaultLevel = _defaultLevel;

            IsRegistered = true;
        }
    }
}