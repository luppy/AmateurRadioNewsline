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
using System.CodeDom;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                var cap = WaveOut.GetCapabilities(n);
                if (cap.Channels == 2)
                {
                    Console.WriteLine(cap.Channels);
                }
                else
                {
                    Console.WriteLine(cap.Channels);
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
            m_audioPlayer.idDoneHandler += OnIDDone;

            m_filename.Text = Properties.Settings.Default.Filename;
            m_timeout.Text = Properties.Settings.Default.Timeout.ToString();
            m_IDSkip.Text = Properties.Settings.Default.IDSkip.ToString(@"hh\:mm\:ss\.fff");

            if (Properties.Settings.Default.Splits.Deserialize<List<TimeSpan>>() is List<TimeSpan> splits)
                m_splits = splits;

            RefreshSegments();
            SelectSegmentByTime(TimeSpan.Zero);
        }

        private void OnAudioStart(AudioPlayer audioPlayer, TimeSpan length)
        {
        }

        private void OnAudioTick(AudioPlayer audioPlayer, TimeSpan position)
        {
            if (position >= m_autoPauseValue && m_audioPlayer.play)
            {
                m_audioPlayer.play = false;
                NextSegment();
            }
            m_progressBar.Value = (int)position.TotalMilliseconds;
            m_currentTime.Text = position.ToString(@"hh\:mm\:ss\.f");
            m_timeLeft.Text = m_audioPlayer.timeout.ToString(@"hh\:mm\:ss\.f");
        }

        private void OnAudioStop(AudioPlayer audioPlayer)
        {
        }

        private void OnIDDone(AudioPlayer audioPlayer)
        {
            NextSegment();
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
                m_pauses.Items.Clear();
                foreach (var segment in m_audioPlayer.waveStream.Split())
                {
                    m_pauses.Items.Add(segment);
                }

                m_splits.Clear();
                RefreshSegments();
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
            Properties.Settings.Default.Splits = m_splits.SerializeToString();
            Properties.Settings.Default.Save();
        }

        private void SelectSegment()
        {
            if (m_segments.SelectedItem is Segment segment)
            {
                m_autoPause.Text = segment.end.ToString("mm\\:ss\\.f");
                m_autoPauseValue = segment.end;
                if (m_audioPlayer.waveStream is WaveStream waveStream)
                    waveStream.CurrentTime = segment.start;
            }
        }

        private void PrevSegment()
        {
            if (m_segments.SelectedIndex >= 0)
            {
                --m_segments.SelectedIndex;
                SelectSegment();
            }
        }

        private void NextSegment()
        {
            if (m_segments.SelectedIndex < m_segments.Items.Count - 1)
            {
                ++m_segments.SelectedIndex;
                SelectSegment();
            }
        }

        private void OnBackwardClick(object sender, EventArgs e)
        {
            PrevSegment();
        }

        private void OnForward(object sender, EventArgs e)
        {
            NextSegment();
        }

        private void OnSoftForward(object sender, EventArgs e)
        {
            if (m_audioPlayer.waveStream is WaveStream waveStream)
                waveStream.CurrentTime = m_autoPauseValue - new TimeSpan(0, 0, 5);
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

        private void OnIDSkipChanged(object sender, EventArgs e)
        {
            TimeSpan idskip;
            if (TimeSpan.TryParse(m_IDSkip.Text, out idskip))
            {
                Properties.Settings.Default.IDSkip = idskip;
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

        private void OnSegmentSelected(object sender, EventArgs e)
        {
        }

        private void OnSegmentsDoubleClick(object sender, EventArgs e)
        {
            SelectSegment();
        }

        private void OnPausesDoubleClick(object sender, EventArgs e)
        {
            if (m_pauses.SelectedItem is Segment segment && m_audioPlayer.waveStream is WaveStream waveStream)
            {
                waveStream.CurrentTime = segment.start;
            }
        }

        private void OnAddPause(object sender, EventArgs e)
        {
            if (m_pauses.SelectedItem is Segment segment)
            {
                if (!m_splits.Contains(segment.end))
                {
                    m_splits.Add(segment.end);
                    m_splits.Sort();
                    RefreshSegments();
                    SelectSegmentByTime(segment.end);
                }
            }
        }

        private void RefreshSegments()
        {
            m_segments.Items.Clear();
            if (m_audioPlayer.waveStream is WaveStream waveStream)
            {
                TimeSpan current = TimeSpan.Zero;
                foreach (TimeSpan split in m_splits)
                {
                    m_segments.Items.Add(new Segment { start = current, duration = split - current });
                    current = split;
                }
                m_segments.Items.Add(new Segment { start = current, duration = waveStream.TotalTime - current });
            }
        }

        private void SelectSegmentByTime(TimeSpan time)
        {
            for (int i = 0; i < m_segments.Items.Count; i++)
            {
                if (m_segments.Items[i] is Segment segment && segment.end > time)
                {
                    m_segments.SelectedIndex = i;
                    break;
                }
            }
            SelectSegment();
        }

        private AudioPlayer m_audioPlayer = new AudioPlayer();
        private TimeSpan m_autoPauseValue = TimeSpan.MaxValue;
        private List<TimeSpan> m_splits = new List<TimeSpan>();
    }
}
