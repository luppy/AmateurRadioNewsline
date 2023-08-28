using NAudio.Wave;
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

            m_pauses.Items.Add(new Segment() { start = new TimeSpan(0, 0, 4, 20, 855), duration = new TimeSpan(0, 0, 0, 0, 333) });
            m_pauses.Items.Add(new Segment() { start = new TimeSpan(0, 0, 6, 38, 965), duration = new TimeSpan(0, 0, 0, 0, 809) });
            m_pauses.Items.Add(new Segment() { start = new TimeSpan(0, 0, 10, 01, 873), duration = new TimeSpan(0, 0, 0, 0, 408) });
            m_pauses.Items.Add(new Segment() { start = new TimeSpan(0, 0, 13, 05, 309), duration = new TimeSpan(0, 0, 0, 0, 390) });
            m_pauses.Items.Add(new Segment() { start = new TimeSpan(0, 0, 17, 55, 497), duration = new TimeSpan(0, 0, 0, 0, 302) });


            m_testPTT.DataBindings.Add("Enabled", m_audioPlayer.ptt, "open");
            m_testPTT.DataBindings.Add("Checked", m_audioPlayer.ptt, "value");
            m_playButton.DataBindings.Add("Checked", m_audioPlayer, "play");

            m_audioPlayer.startHandler += OnAudioStart;
            m_audioPlayer.tickHandler += OnAudioTick;
            m_audioPlayer.stopHandler += OnAudioStop;

            m_filename.Text = Properties.Settings.Default.Filename;
            m_timeout.Text = Properties.Settings.Default.Timeout.ToString();
        }

        private void OnAudioStart(AudioPlayer audioPlayer, TimeSpan length)
        {
            if (m_audioPlayer.waveStream is WaveStream)
            {
                SetAutoPause(FindLastBetween(m_audioPlayer.waveStream.CurrentTime, m_audioPlayer.waveStream.CurrentTime + m_audioPlayer.timeout));
            }
        }

        private void SetAutoPause(Segment segment)
        {
            m_autoPause.Text = segment.start.ToString();
            m_autoPauseValue = segment.start + segment.duration;
            m_pauses.SelectedItem = segment;
        }

        private void OnAudioTick(AudioPlayer audioPlayer, TimeSpan position)
        {
            if (position >= m_autoPauseValue)
            {
                m_audioPlayer.play = false;
            }
            m_progressBar.Value = (int)position.TotalMilliseconds;
            m_currentTime.Text = position.ToString(@"hh\:mm\:ss\.f");
            m_timeLeft.Text = m_audioPlayer.timeout.ToString(@"hh\:mm\:ss\.f");
        }

        private void OnAudioStop(AudioPlayer audioPlayer)
        {
        }

        private void OnNewAudioOut(object sender, EventArgs e)
        {
            m_audioPlayer.deviceNumber = m_audioOutSelector.SelectedIndex;
            Properties.Settings.Default.AudioOut = m_audioOutSelector.SelectedItem.ToString();
        }

        private void OnComPortChanged(object sender, EventArgs e)
        {
            String comPort = m_pttSelector.SelectedItem.ToString() ?? "";
            Properties.Settings.Default.PTT = comPort;
            m_audioPlayer.ptt.name = comPort;
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
                m_progressBar.Maximum = (int)m_audioPlayer.waveStream.TotalTime.TotalMilliseconds;
                m_totalTime.Text = m_audioPlayer.waveStream.TotalTime.ToString(@"hh\:mm\:ss\.f");

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

        private void OnSegmentsDoubleClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
            {
                int index = m_segments.IndexFromPoint(me.Location);
                if (index != ListBox.NoMatches)
                {
                    if (m_segments.Items[index] is Segment segment)
                    {
                        if (Control.ModifierKeys == Keys.None)
                        {
                            if (m_audioPlayer.waveStream is WaveStream)
                            {
                                m_audioPlayer.waveStream.CurrentTime = segment.start;
                            }
                        }
                        else
                        {
                            SetAutoPause(segment);
                        }
                    }
                }
            }
        }

        private void OnBackwardClick(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
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
        }

        private Segment FindLastBetween(TimeSpan begin, TimeSpan end)
        {
            for (int i = m_pauses.Items.Count; i-- > 0;)
            {
                if (m_pauses.Items[i] is Segment segment)
                {
                    if (segment.start <= begin) break;
                    if (segment.start < end) return segment;
                }
            }
            return new Segment() { start = m_audioPlayer.waveStream?.TotalTime ?? TimeSpan.Zero, duration = TimeSpan.Zero };
        }

        private void OnForwardClick(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
            {
                m_audioPlayer.waveStream.CurrentTime = m_autoPauseValue - new TimeSpan(0, 0, 5);
            }
        }

        private void OnTimeoutChanged(object sender, EventArgs e)
        {
            TimeSpan timeout;
            if (TimeSpan.TryParse(m_timeout.Text, out timeout))
            {
                m_audioPlayer.timeout = timeout;
                Properties.Settings.Default.Timeout = timeout;
            }
        }

        private void OnBackward1(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime -= new TimeSpan(0, 0, 1);
        }

        private void OnBackward2(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime -= new TimeSpan(0, 0, 5);
        }

        private void OnBackward3(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime -= new TimeSpan(0, 0, 15);
        }

        private void OnBackward4(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime -= new TimeSpan(0, 1, 0);
        }

        private void OnForward1(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime += new TimeSpan(0, 0, 1);
        }

        private void OnForward2(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime += new TimeSpan(0, 0, 5);
        }

        private void OnForward3(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime += new TimeSpan(0, 0, 15);
        }

        private void OnForward4(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream)
                m_audioPlayer.waveStream.CurrentTime += new TimeSpan(0, 1, 0);
        }

        private void OnProgressBarClick(object sender, EventArgs e)
        {
            if (e is MouseEventArgs me)
            {
                m_audioPlayer.SetNormalizedTime((float)me.X / m_progressBar.Width);
            }
        }
        private void OnProgressBarMove(object sender, MouseEventArgs e)
        {
            if (!m_audioPlayer.play && e is MouseEventArgs me && (me.Button & MouseButtons.Left) != 0)
            {
                m_audioPlayer.SetNormalizedTime((float)me.X / m_progressBar.Width);
            }
        }


        private AudioPlayer m_audioPlayer = new AudioPlayer();
        private TimeSpan m_autoPauseValue = TimeSpan.MaxValue;

    }
}
