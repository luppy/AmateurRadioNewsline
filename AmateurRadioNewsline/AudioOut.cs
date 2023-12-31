﻿using NAudio.Wave;
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
        public AudioOut()
        {
            GlobalTimer.m_timer.Tick += OnTick;
        }

        public int deviceNumber
        {
            get { return m_out.DeviceNumber; }
            set { Setup(value, waveStream); }
        }

        public WaveStream? waveStream
        {
            get { return m_waveStream; }
            set { Setup(deviceNumber, value); }
        }

        public bool play
        {
            get { return m_play; }
            set
            {
                if (m_play != value)
                {
                    if (value)
                    {
                        if (m_waveStream != null)
                        {
                            //m_out.Play();
                            OnStart();
                        }
                    }
                    else
                    {
                        OnStop();
                        if (m_out.PlaybackState != PlaybackState.Stopped)
                        {
                            m_out.Stop();
                        }
                    }
                }
            }
        }

        public delegate void StartHandler(AudioOut audioOut, TimeSpan length);
        public delegate void TickHandler(AudioOut audioOut, TimeSpan position);
        public delegate void StopHandler(AudioOut audioOut);

        public event StartHandler? startHandler;
        public event StopHandler? stopHandler;

        private void Setup(int deviceNumber, WaveStream? waveStream)
        {
            bool playing = m_out.PlaybackState == PlaybackState.Playing;

            if (playing && waveStream == null)
            {
                stopHandler?.Invoke(this);
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
            m_play = true;
            m_playStarted = DateTime.Now;
            startHandler?.Invoke(this, m_waveStream?.TotalTime ?? TimeSpan.Zero);
        }

        private void OnStop()
        {
            m_play = false;
            stopHandler?.Invoke(this);
        }

        private void OnPlaybackStopped(object? sender, EventArgs e)
        {
            OnStop();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            if (m_play && m_out.PlaybackState != PlaybackState.Playing && DateTime.Now - m_playStarted > new TimeSpan(0, 0, 1))
            {
                m_out.Play();

                if(m_out.PlaybackState != PlaybackState.Playing) // better safe than sorry
                {
                    OnStop();
                }
            }
        }

        private WaveOut m_out = new WaveOut();
        private WaveStream? m_waveStream;
        private bool m_play = false;
        private DateTime m_playStarted;
    };
}
