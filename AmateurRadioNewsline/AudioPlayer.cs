using NAudio.CoreAudioApi;
using NAudio.Gui;
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
    internal class GlobalTimer
    {
        static GlobalTimer()
        {
            m_timer.Interval = 50;
            m_timer.Start();
        }

        public static Timer m_timer = new Timer();
    }

    internal class AudioPlayer : INotifyPropertyChanged
    {
        public AudioPlayer()
        {
            GlobalTimer.m_timer.Tick += OnTick;

            m_newsline.startHandler += OnNewslineStart;
            m_newsline.stopHandler += OnNewslineStop;
            m_callsign.startHandler += OnCallsignStart;
            m_callsign.stopHandler += OnCallsignStop;
        }

        public PTT ptt { get; private set; } = new PTT();

        public int deviceNumber
        {
            set
            {
                m_newsline.deviceNumber = value;
                m_callsign.deviceNumber = value;
            }
        }

        public WaveStream? waveStream
        {
            get { return m_newsline.waveStream; }

            set
            {
                m_newsline.waveStream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("play"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("currentTimeInSec"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("totalTimeInSec"));
            }
        }

        public int currentTimeInSec
        {
            get { return m_newsline.waveStream?.CurrentTime.Seconds ?? 0; }
        }

        public int totalTimeInSec
        {
            get { return m_newsline.waveStream?.TotalTime.Seconds ?? 0; }
        }

        public bool play
        {
            get { return m_newsline.play; }
            set
            {
                m_newsline.play = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("play"));
            }
        }

        public TimeSpan timeout
        {
            set { m_timeout = value; }
            get { return m_timeout - ptt.onAirTime; }
        }

        public void SetNormalizedTime(float t)
        {
            if (waveStream is WaveStream)
            {
                waveStream.CurrentTime = new TimeSpan((long)(waveStream.TotalTime.Ticks * t));
            }
        }

        public void FastForward(TimeSpan t)
        {
            if (waveStream is WaveStream)
            {
                waveStream.CurrentTime += t;
            }
        }

        public void PlayCallsign(String callsign)
        {
            if (!m_callsign.play)
            {
                //m_callsign.waveStream = Callsign(callsign);
                m_callsign.waveStream = Callsign2("-.- -. -.... .-- .--. ..-", 880, 3150);
                m_callsign.play = true;
            }
        }


        public delegate void StartHandler(AudioPlayer audioPlayer, TimeSpan length);
        public delegate void TickHandler(AudioPlayer audioPlayer, TimeSpan position);
        public delegate void StopHandler(AudioPlayer audioPlayer);

        public event StartHandler? startHandler;
        public event TickHandler? tickHandler;
        public event StopHandler? stopHandler;
        public event StopHandler? idDoneHandler;
        public event PropertyChangedEventHandler? PropertyChanged;


        private void OnNewslineStart(AudioOut audioOut, TimeSpan length)
        {
            ptt.value = true;
            startHandler?.Invoke(this, length);
        }
        private void OnNewslineStop(AudioOut audioOut)
        {
            stopHandler?.Invoke(this);
            ptt.value = m_callsign.play;
        }

        private void OnCallsignStart(AudioOut audioOut, TimeSpan length)
        {
            m_newslinePlaying = m_newsline.play;
            m_newsline.play = false;
            ptt.value = true;
        }
        private void OnCallsignStop(AudioOut audioOut)
        {
            m_newsline.play = m_newslinePlaying;
            ptt.value = m_newslinePlaying;
            idDoneHandler?.Invoke(this);
        }

        private void OnTick(object? sender, EventArgs e)
        {
            tickHandler?.Invoke(this, m_newsline.waveStream?.CurrentTime ?? TimeSpan.Zero);
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

        private static WaveStream Callsign2(String morse, float frequency, int unitLength)
        {
            var stream = new MemoryStream();

            float dt = frequency / 44100;
            float t = 0;
            foreach (char c in morse)
            {
                int length = unitLength;
                int amplitude = 32767;
                switch (c)
                {
                    case '.': break;
                    case '-': length *= 3; break;
                    case ' ': amplitude = 0; break;
                    default: length = 0; break;
                }

                for (int i = length; i-- > 0;)
                {
                    short sample = (short)Math.Round(Math.Sin(t * Math.PI * 2) * amplitude);
                    stream.WriteByte((byte)(sample & 0xff));
                    stream.WriteByte((byte)(sample >> 8));
                    t = (t + dt) % 1;
                }
                for (int i = unitLength; i-- > 0;)
                {
                    stream.WriteByte(0);
                    stream.WriteByte(0);
                }
            }

            stream.Seek(0, SeekOrigin.Begin);
            return new RawSourceWaveStream(stream, new WaveFormat(44100, 16, 1));
        }



        private AudioOut m_newsline = new AudioOut();
        private AudioOut m_callsign = new AudioOut();
        private TimeSpan m_timeout = new TimeSpan(0, 5, 0);
        private bool m_newslinePlaying;
    }
}
