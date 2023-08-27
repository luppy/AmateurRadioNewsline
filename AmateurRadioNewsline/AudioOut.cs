using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace AmateurRadioNewsline
{
    class AudioOut
    {
        public int deviceNumber
        {
            get { return m_out.DeviceNumber; }
            set { Setup(value, waveStream); }
        }

        public WaveStream waveStream
        {
            get { return m_waveStream; }
            set { Setup(deviceNumber, value); }
        }

        public bool play
        {
            get { return m_out.PlaybackState == PlaybackState.Playing; }
            set
            {
                if (value != play)
                {
                    if (value)
                    {
                        if (m_waveStream != null)
                        {
                            m_out.Play();
                            OnStart();
                        }
                    }
                    else
                    {
                        OnStop();
                        m_out.Stop();
                    }
                }
            }
        }

        public delegate void StartHandler(AudioOut audioOut, TimeSpan length);
        public delegate void TickHandler(AudioOut audioOut, TimeSpan position);
        public delegate void StopHandler(AudioOut audioOut);

        public event StartHandler startHandler;
        public event TickHandler tickHandler;
        public event StopHandler stopHandler;

        private void Setup(int deviceNumber, WaveStream waveStream)
        {
            bool playing = play;

            if (playing && waveStream == null)
            {
                stopHandler(this);
            }

            if (m_waveStream != waveStream)
            {
                m_waveStream?.Dispose();
                m_waveStream = waveStream;
            }

            m_out.Dispose();
            m_out = new WaveOut();
            m_out.PlaybackStopped += OnPlaybackStopped;
            m_out.DeviceNumber = deviceNumber;
            if (m_waveStream != null)
            {
                m_out.Init(m_waveStream);
                if (playing)
                {
                    m_out.Play();
                }
            }
        }

        private void OnStart()
        {
            startHandler?.Invoke(this, m_waveStream.TotalTime);
        }

        private void OnStop()
        {
            stopHandler?.Invoke(this);
        }

        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            OnStop();
        }

        private WaveOut m_out = new WaveOut();
        private WaveStream m_waveStream;
    };
}
