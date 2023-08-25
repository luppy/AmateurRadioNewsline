﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace AmateurRadioNewsline
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (String name in SerialPort.GetPortNames())
            {
                int index = m_pttSelector.Items.Add(name);
                if (Properties.Settings.Default.PTT == name)
                {
                    m_pttSelector.SelectedIndex = index;
                }
            }

            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                var name = $"{n}:{WaveOut.GetCapabilities(n).ProductName}";
                int index = m_audioOutSelector.Items.Add(name);
                if (Properties.Settings.Default.AudioOut == name)
                {
                    m_audioOutSelector.SelectedIndex = index;
                }
            }

            m_callsign.Text = Properties.Settings.Default.Callsign;

            m_testPTT.DataBindings.Add("Enabled", m_audioPlayer.ptt, "open");
            m_testPTT.DataBindings.Add("Checked", m_audioPlayer.ptt, "value");
            m_playButton.DataBindings.Add("Checked", m_audioPlayer, "play");

            m_audioPlayer.startHandler += OnAudioStart;
            m_audioPlayer.tickHandler += OnAudioTick;
            m_audioPlayer.stopHandler += OnAudioStop;

            m_filename.Text = Properties.Settings.Default.Filename;
        }

        private void OnAudioStart(AudioPlayer audioPlayer, TimeSpan length)
        {
            m_progressBar.Enabled = true;
            m_progressBar.Maximum = (int)length.TotalMilliseconds;
            m_totalTime.Text = length.ToString(@"hh\:mm\:ss\.f");
        }

        private void OnAudioTick(AudioPlayer audioPlayer, TimeSpan position)
        {
            m_progressBar.Value = (int)position.TotalMilliseconds;
            m_currentTime.Text = position.ToString(@"hh\:mm\:ss\.f");
            m_timeLeft.Text = m_audioPlayer.timeout.ToString(@"hh\:mm\:ss\.f");
        }

        private void OnAudioStop(AudioPlayer audioPlayer)
        {
            m_progressBar.Enabled = false;
        }

        private void OnNewAudioOut(object sender, EventArgs e)
        {
            m_audioPlayer.deviceNumber = m_audioOutSelector.SelectedIndex;
            Properties.Settings.Default.AudioOut = m_audioOutSelector.SelectedItem.ToString();
        }

        private void OnComPortChanged(object sender, EventArgs e)
        {
            m_audioPlayer.ptt.name = Properties.Settings.Default.PTT = m_pttSelector.SelectedItem.ToString();
        }

        private void OnBrowseButtonClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    m_filename.Text = openFileDialog.FileName;
                }
            }
        }

        private void OnFilenameChanged(object sender, EventArgs e)
        {
            try
            {
                m_audioPlayer.waveStream = new Mp3FileReader(m_filename.Text);
                Properties.Settings.Default.Filename = m_filename.Text;
                m_segments.Items.Clear();
                foreach (var segment in m_audioPlayer.waveStream.Split())
                {
                    m_segments.Items.Add(segment);
                }
            }
            catch
            {
                MessageBox.Show("Invalid filename", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnPlayButtonChanged(object sender, EventArgs e)
        {
            m_audioPlayer.play = m_playButton.Checked;
        }

        private void OnTestPTT(object sender, EventArgs e)
        {
            m_audioPlayer.ptt.value = m_testPTT.Checked;
        }

        private void OnIDButton(object sender, EventArgs e)
        {
            m_audioPlayer.PlayCallsign(m_callsign.Text);
        }

        private void OnCallsignChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Callsign = m_callsign.Text;
        }

        private void OnSaveSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void OnProgressBarClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
            {
                m_audioPlayer.SetNormalizedTime((float)me.X / m_progressBar.Width);
            }
        }

        private void OnSegmentsDoubleClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
            {
                int index = m_segments.IndexFromPoint(me.Location);
                if (index != ListBox.NoMatches)
                {
                    if (m_segments.Items[index] is Segment segment)
                    {
                        m_audioPlayer.waveStream.CurrentTime = segment.start;
                    }
                }
            }
        }

        private void OnBackwardClick(object sender, EventArgs e)
        {
            TimeSpan newValue = TimeSpan.Zero;
            foreach (Segment segment in m_segments.Items)
            {
                if (segment.start < m_audioPlayer.waveStream.CurrentTime)
                {
                    newValue = segment.start;
                }
                else break;
            }
            m_audioPlayer.waveStream.CurrentTime = newValue;
        }

        private void OnForwardClick(object sender, EventArgs e)
        {
            TimeSpan newValue = m_audioPlayer.waveStream.TotalTime;
            foreach (Segment segment in m_segments.Items)
            {
                if (segment.start > m_audioPlayer.waveStream.CurrentTime)
                {
                    newValue = segment.start;
                    break;
                }
            }
            m_audioPlayer.waveStream.CurrentTime = newValue;
        }

        private AudioPlayer m_audioPlayer = new AudioPlayer();
    }
}