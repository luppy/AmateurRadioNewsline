using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace AmateurRadioNewsline
{
    internal class AudioPlayer : INotifyPropertyChanged
    {
        public PTT ptt { get; private set; } = new PTT();

        public int deviceNumber
        {
            set
            {
                m_deviceNumber = value;
                Setup();
            }
        }

        public WaveStream waveStream
        {
            get
            {
                return m_waveStream;
            }

            set
            {
                m_newWaveStream = value;
                Setup();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("play"));
            }
        }

        public bool play
        {
            get
            {
                return m_audioOut?.PlaybackState == PlaybackState.Playing;
            }

            set
            {
                if (m_audioOut != null)
                {
                    switch (m_audioOut.PlaybackState)
                    {
                        case PlaybackState.Stopped:
                            if (value) m_audioOut.Play();
                            break;
                        case PlaybackState.Playing:
                            if (!value)
                            {
                                m_audioOut.Pause();
                            }
                            break;
                        case PlaybackState.Paused:
                            if (value)
                            {
                                //m_audioOut.Resume();
                                Setup();// KN6WPU: There is a bug in NAudio when seeking in WaveStream while WaveOut is paused
                                m_audioOut.Play();
                            }
                            break;
                    }
                    ptt.value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("play"));
                }
            }
        }

        public TimeSpan timeout
        {
            set
            {
                m_timeout = value;
            }
            get
            {
                return m_timeout - ptt.onAirTime;
            }
        }

        public void SetNormalizedTime(float t)
        {
            m_waveStream.CurrentTime = new TimeSpan((long)(m_waveStream.TotalTime.Ticks * t));
        }

        public void FastForward(TimeSpan t)
        {
            m_waveStream.CurrentTime += t;
        }

        public void PlayCallsign(String callsign)
        {
            if (m_originalWaveStream == null)
            {
                m_originalWaveStream = waveStream;
                m_originalWasPlaying = play;
                waveStream = Callsign(callsign);
                play = true;
            }
        }

        public delegate void StartHandler(AudioPlayer audioPlayer, TimeSpan length);
        public delegate void TickHandler(AudioPlayer audioPlayer, TimeSpan position);
        public delegate void StopHandler(AudioPlayer audioPlayer);

        public event StartHandler startHandler;
        public event TickHandler tickHandler;
        public event StopHandler stopHandler;
        public event PropertyChangedEventHandler PropertyChanged;

        private void Setup()
        {
            bool wasSetup = m_audioOut != null;
            bool played = play;
            bool willSetup = m_deviceNumber is int && m_newWaveStream != null;
            bool newStream = m_waveStream != m_newWaveStream;

            if (wasSetup)
            {
                if (!willSetup)
                {
                    ptt.value = false;
                    m_timer.Dispose();
                    m_timer = null;
                }

                m_audioOut.Dispose();
                m_audioOut = null;

                if (!willSetup || newStream)
                {
                    stopHandler(this);
                }
            }

            if (newStream)
            {
                if(m_waveStream != m_originalWaveStream)
                {
                    m_waveStream?.Dispose();
                }
                m_waveStream = m_newWaveStream;
            }

            if (willSetup)
            {
                m_audioOut = new WaveOut();
                m_audioOut.DeviceNumber = m_deviceNumber.Value;
                m_audioOut.Init(m_waveStream);
                m_audioOut.PlaybackStopped += OnPlaybackStopped;

                if (!wasSetup || newStream)
                {
                    startHandler(this, m_waveStream.TotalTime);
                }

                if (m_timer == null)
                {
                    m_timer = new Timer();
                    m_timer.Tick += OnTick;
                    m_timer.Interval = 50;
                    m_timer.Start();
                }
                if(m_waveStream == m_originalWaveStream)
                {
                    m_originalWaveStream = null;
                    played = m_originalWasPlaying;
                    m_originalWasPlaying = false;
                }
                if (played)
                {
                    ptt.value = true;
                    m_audioOut.Play();
                }
            }
        }

        private static WaveStream Callsign(String callsign)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                var stream = new MemoryStream();
                synthesizer.SetOutputToAudioStream(stream, new SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
                synthesizer.SelectVoiceByHints(VoiceGender.Male);
                synthesizer.Volume = 100;
                synthesizer.Rate = -3;
                StringBuilder builder = new StringBuilder();
                foreach (char c in callsign)
                {
                    builder.Append(c);
                    builder.Append(' ');
                }
                builder.Remove(builder.Length - 1, 1);
                synthesizer.Speak(builder.ToString());
                stream.Seek(0, SeekOrigin.Begin);
                return new RawSourceWaveStream(stream, new WaveFormat(44100, 16, 1));
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            tickHandler.Invoke(this, m_waveStream.CurrentTime);
        }

        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            waveStream = m_originalWaveStream;
        }

        private int? m_deviceNumber;
        private WaveOut m_audioOut;
        private WaveStream m_waveStream;
        private WaveStream m_newWaveStream;
        private WaveStream m_originalWaveStream;
        private bool m_originalWasPlaying;
        private Timer m_timer;
        private TimeSpan m_timeout = new TimeSpan(0, 5, 0);
    }
}
