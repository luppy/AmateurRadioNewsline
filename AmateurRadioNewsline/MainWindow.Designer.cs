namespace AmateurRadioNewsline
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_pttSelector = new ComboBox();
            label2 = new Label();
            m_audioOutSelector = new ComboBox();
            m_filename = new TextBox();
            label3 = new Label();
            m_browseButton = new Button();
            m_progressBar = new ProgressBar();
            m_playButton = new CheckBox();
            m_testPTT = new CheckBox();
            m_idButton = new Button();
            m_callsign = new TextBox();
            m_callsignLabel = new Label();
            m_saveSettings = new Button();
            m_currentTime = new TextBox();
            m_totalTime = new TextBox();
            m_timeoutLabel = new Label();
            m_timeout = new TextBox();
            m_timeLeft = new TextBox();
            m_segments = new ListBox();
            m_nextPauseButton = new Button();
            m_backward = new Button();
            m_autoPause = new TextBox();
            m_pauses = new ListBox();
            m_forwardButton1 = new Button();
            m_forwardButton2 = new Button();
            m_forwardButton3 = new Button();
            m_backwardButton1 = new Button();
            m_backwardButton2 = new Button();
            m_backwardButton3 = new Button();
            m_backwardButton4 = new Button();
            m_forwardButton4 = new Button();
            m_IDSkip = new TextBox();
            m_forward = new Button();
            m_addButton = new Button();
            m_removeButton = new Button();
            SuspendLayout();
            // 
            // m_pttSelector
            // 
            m_pttSelector.FormattingEnabled = true;
            m_pttSelector.Location = new Point(102, 43);
            m_pttSelector.Margin = new Padding(4, 3, 4, 3);
            m_pttSelector.Name = "m_pttSelector";
            m_pttSelector.Size = new Size(363, 23);
            m_pttSelector.TabIndex = 0;
            m_pttSelector.SelectedIndexChanged += OnComPortChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 77);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "Audio Output";
            // 
            // m_audioOutSelector
            // 
            m_audioOutSelector.FormattingEnabled = true;
            m_audioOutSelector.Location = new Point(102, 74);
            m_audioOutSelector.Margin = new Padding(4, 3, 4, 3);
            m_audioOutSelector.Name = "m_audioOutSelector";
            m_audioOutSelector.Size = new Size(363, 23);
            m_audioOutSelector.TabIndex = 3;
            m_audioOutSelector.SelectedIndexChanged += OnNewAudioOut;
            // 
            // m_filename
            // 
            m_filename.Location = new Point(102, 106);
            m_filename.Margin = new Padding(4, 3, 4, 3);
            m_filename.Name = "m_filename";
            m_filename.Size = new Size(363, 23);
            m_filename.TabIndex = 4;
            m_filename.TextChanged += OnFilenameChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 110);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "Filename";
            // 
            // m_browseButton
            // 
            m_browseButton.Location = new Point(472, 104);
            m_browseButton.Margin = new Padding(4, 3, 4, 3);
            m_browseButton.Name = "m_browseButton";
            m_browseButton.Size = new Size(88, 27);
            m_browseButton.TabIndex = 6;
            m_browseButton.Text = "Browse";
            m_browseButton.UseVisualStyleBackColor = true;
            m_browseButton.Click += OnBrowseButtonClick;
            // 
            // m_progressBar
            // 
            m_progressBar.Location = new Point(103, 197);
            m_progressBar.Margin = new Padding(4, 3, 4, 3);
            m_progressBar.Name = "m_progressBar";
            m_progressBar.Size = new Size(363, 27);
            m_progressBar.TabIndex = 8;
            m_progressBar.Click += OnProgressBarClick;
            m_progressBar.MouseMove += OnProgressBarMove;
            // 
            // m_playButton
            // 
            m_playButton.Appearance = Appearance.Button;
            m_playButton.AutoSize = true;
            m_playButton.Location = new Point(262, 231);
            m_playButton.Margin = new Padding(4, 3, 4, 3);
            m_playButton.Name = "m_playButton";
            m_playButton.Size = new Size(39, 25);
            m_playButton.TabIndex = 10;
            m_playButton.Text = "Play";
            m_playButton.UseVisualStyleBackColor = true;
            m_playButton.CheckedChanged += OnPlayButtonChanged;
            // 
            // m_testPTT
            // 
            m_testPTT.Appearance = Appearance.Button;
            m_testPTT.AutoSize = true;
            m_testPTT.Enabled = false;
            m_testPTT.Location = new Point(50, 40);
            m_testPTT.Margin = new Padding(4, 3, 4, 3);
            m_testPTT.Name = "m_testPTT";
            m_testPTT.Size = new Size(36, 25);
            m_testPTT.TabIndex = 11;
            m_testPTT.Text = "PTT";
            m_testPTT.UseVisualStyleBackColor = true;
            m_testPTT.CheckedChanged += OnTestPTT;
            // 
            // m_idButton
            // 
            m_idButton.Location = new Point(472, 10);
            m_idButton.Margin = new Padding(4, 3, 4, 3);
            m_idButton.Name = "m_idButton";
            m_idButton.Size = new Size(54, 27);
            m_idButton.TabIndex = 12;
            m_idButton.Text = "ID";
            m_idButton.UseVisualStyleBackColor = true;
            m_idButton.Click += OnIDButton;
            // 
            // m_callsign
            // 
            m_callsign.Location = new Point(102, 13);
            m_callsign.Margin = new Padding(4, 3, 4, 3);
            m_callsign.Name = "m_callsign";
            m_callsign.Size = new Size(363, 23);
            m_callsign.TabIndex = 13;
            m_callsign.TextChanged += OnCallsignChanged;
            // 
            // m_callsignLabel
            // 
            m_callsignLabel.AutoSize = true;
            m_callsignLabel.Location = new Point(44, 16);
            m_callsignLabel.Margin = new Padding(4, 0, 4, 0);
            m_callsignLabel.Name = "m_callsignLabel";
            m_callsignLabel.Size = new Size(49, 15);
            m_callsignLabel.TabIndex = 14;
            m_callsignLabel.Text = "Callsign";
            // 
            // m_saveSettings
            // 
            m_saveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_saveSettings.Location = new Point(752, 746);
            m_saveSettings.Margin = new Padding(4, 3, 4, 3);
            m_saveSettings.Name = "m_saveSettings";
            m_saveSettings.Size = new Size(106, 27);
            m_saveSettings.TabIndex = 15;
            m_saveSettings.Text = "Save Settings";
            m_saveSettings.UseVisualStyleBackColor = true;
            m_saveSettings.Click += OnSaveSettings;
            // 
            // m_currentTime
            // 
            m_currentTime.Location = new Point(102, 167);
            m_currentTime.Margin = new Padding(4, 3, 4, 3);
            m_currentTime.Name = "m_currentTime";
            m_currentTime.ReadOnly = true;
            m_currentTime.Size = new Size(116, 23);
            m_currentTime.TabIndex = 16;
            // 
            // m_totalTime
            // 
            m_totalTime.Location = new Point(349, 166);
            m_totalTime.Margin = new Padding(4, 3, 4, 3);
            m_totalTime.Name = "m_totalTime";
            m_totalTime.ReadOnly = true;
            m_totalTime.Size = new Size(116, 23);
            m_totalTime.TabIndex = 17;
            // 
            // m_timeoutLabel
            // 
            m_timeoutLabel.AutoSize = true;
            m_timeoutLabel.Location = new Point(37, 140);
            m_timeoutLabel.Margin = new Padding(4, 0, 4, 0);
            m_timeoutLabel.Name = "m_timeoutLabel";
            m_timeoutLabel.Size = new Size(51, 15);
            m_timeoutLabel.TabIndex = 18;
            m_timeoutLabel.Text = "Timeout";
            // 
            // m_timeout
            // 
            m_timeout.Location = new Point(102, 136);
            m_timeout.Margin = new Padding(4, 3, 4, 3);
            m_timeout.Name = "m_timeout";
            m_timeout.Size = new Size(116, 23);
            m_timeout.TabIndex = 19;
            m_timeout.TextChanged += OnTimeoutChanged;
            // 
            // m_timeLeft
            // 
            m_timeLeft.Location = new Point(349, 136);
            m_timeLeft.Margin = new Padding(4, 3, 4, 3);
            m_timeLeft.Name = "m_timeLeft";
            m_timeLeft.ReadOnly = true;
            m_timeLeft.Size = new Size(116, 23);
            m_timeLeft.TabIndex = 20;
            // 
            // m_segments
            // 
            m_segments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            m_segments.FormattingEnabled = true;
            m_segments.ItemHeight = 15;
            m_segments.Location = new Point(618, 10);
            m_segments.Margin = new Padding(4, 3, 4, 3);
            m_segments.Name = "m_segments";
            m_segments.Size = new Size(240, 724);
            m_segments.Sorted = true;
            m_segments.TabIndex = 22;
            m_segments.DoubleClick += OnSegmentsDoubleClick;
            // 
            // m_nextPauseButton
            // 
            m_nextPauseButton.Location = new Point(262, 264);
            m_nextPauseButton.Margin = new Padding(4, 3, 4, 3);
            m_nextPauseButton.Name = "m_nextPauseButton";
            m_nextPauseButton.Size = new Size(43, 27);
            m_nextPauseButton.TabIndex = 23;
            m_nextPauseButton.Text = ">>";
            m_nextPauseButton.UseVisualStyleBackColor = true;
            m_nextPauseButton.Click += OnSoftForward;
            // 
            // m_backward
            // 
            m_backward.Location = new Point(211, 264);
            m_backward.Margin = new Padding(4, 3, 4, 3);
            m_backward.Name = "m_backward";
            m_backward.Size = new Size(43, 27);
            m_backward.TabIndex = 24;
            m_backward.Text = "|<<";
            m_backward.UseVisualStyleBackColor = true;
            m_backward.Click += OnBackwardClick;
            // 
            // m_autoPause
            // 
            m_autoPause.Location = new Point(225, 166);
            m_autoPause.Margin = new Padding(4, 3, 4, 3);
            m_autoPause.Name = "m_autoPause";
            m_autoPause.ReadOnly = true;
            m_autoPause.Size = new Size(116, 23);
            m_autoPause.TabIndex = 25;
            // 
            // m_pauses
            // 
            m_pauses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            m_pauses.FormattingEnabled = true;
            m_pauses.ItemHeight = 15;
            m_pauses.Location = new Point(102, 310);
            m_pauses.Margin = new Padding(4, 3, 4, 3);
            m_pauses.Name = "m_pauses";
            m_pauses.Size = new Size(240, 424);
            m_pauses.Sorted = true;
            m_pauses.TabIndex = 26;
            m_pauses.SelectedIndexChanged += OnPausesSelected;
            m_pauses.DoubleClick += OnPausesDoubleClick;
            // 
            // m_forwardButton1
            // 
            m_forwardButton1.Location = new Point(313, 231);
            m_forwardButton1.Margin = new Padding(4, 3, 4, 3);
            m_forwardButton1.Name = "m_forwardButton1";
            m_forwardButton1.Size = new Size(44, 27);
            m_forwardButton1.TabIndex = 27;
            m_forwardButton1.Text = "+1s";
            m_forwardButton1.UseVisualStyleBackColor = true;
            m_forwardButton1.Click += OnForward1;
            // 
            // m_forwardButton2
            // 
            m_forwardButton2.Location = new Point(364, 231);
            m_forwardButton2.Margin = new Padding(4, 3, 4, 3);
            m_forwardButton2.Name = "m_forwardButton2";
            m_forwardButton2.Size = new Size(44, 27);
            m_forwardButton2.TabIndex = 28;
            m_forwardButton2.Text = "+5s";
            m_forwardButton2.UseVisualStyleBackColor = true;
            m_forwardButton2.Click += OnForward2;
            // 
            // m_forwardButton3
            // 
            m_forwardButton3.Location = new Point(415, 231);
            m_forwardButton3.Margin = new Padding(4, 3, 4, 3);
            m_forwardButton3.Name = "m_forwardButton3";
            m_forwardButton3.Size = new Size(44, 27);
            m_forwardButton3.TabIndex = 29;
            m_forwardButton3.Text = "+15s";
            m_forwardButton3.UseVisualStyleBackColor = true;
            m_forwardButton3.Click += OnForward3;
            // 
            // m_backwardButton1
            // 
            m_backwardButton1.Location = new Point(211, 231);
            m_backwardButton1.Margin = new Padding(4, 3, 4, 3);
            m_backwardButton1.Name = "m_backwardButton1";
            m_backwardButton1.Size = new Size(44, 27);
            m_backwardButton1.TabIndex = 32;
            m_backwardButton1.Text = "-1s";
            m_backwardButton1.UseVisualStyleBackColor = true;
            m_backwardButton1.Click += OnBackward1;
            // 
            // m_backwardButton2
            // 
            m_backwardButton2.Location = new Point(160, 231);
            m_backwardButton2.Margin = new Padding(4, 3, 4, 3);
            m_backwardButton2.Name = "m_backwardButton2";
            m_backwardButton2.Size = new Size(44, 27);
            m_backwardButton2.TabIndex = 31;
            m_backwardButton2.Text = "-5s";
            m_backwardButton2.UseVisualStyleBackColor = true;
            m_backwardButton2.Click += OnBackward2;
            // 
            // m_backwardButton3
            // 
            m_backwardButton3.Location = new Point(108, 231);
            m_backwardButton3.Margin = new Padding(4, 3, 4, 3);
            m_backwardButton3.Name = "m_backwardButton3";
            m_backwardButton3.Size = new Size(44, 27);
            m_backwardButton3.TabIndex = 30;
            m_backwardButton3.Text = "-15s";
            m_backwardButton3.UseVisualStyleBackColor = true;
            m_backwardButton3.Click += OnBackward3;
            // 
            // m_backwardButton4
            // 
            m_backwardButton4.Location = new Point(57, 231);
            m_backwardButton4.Margin = new Padding(4, 3, 4, 3);
            m_backwardButton4.Name = "m_backwardButton4";
            m_backwardButton4.Size = new Size(44, 27);
            m_backwardButton4.TabIndex = 33;
            m_backwardButton4.Text = "-1m";
            m_backwardButton4.UseVisualStyleBackColor = true;
            m_backwardButton4.Click += OnBackward4;
            // 
            // m_forwardButton4
            // 
            m_forwardButton4.Location = new Point(467, 231);
            m_forwardButton4.Margin = new Padding(4, 3, 4, 3);
            m_forwardButton4.Name = "m_forwardButton4";
            m_forwardButton4.Size = new Size(44, 27);
            m_forwardButton4.TabIndex = 34;
            m_forwardButton4.Text = "+1m";
            m_forwardButton4.UseVisualStyleBackColor = true;
            m_forwardButton4.Click += OnForward4;
            // 
            // m_IDSkip
            // 
            m_IDSkip.Location = new Point(473, 43);
            m_IDSkip.Margin = new Padding(4, 3, 4, 3);
            m_IDSkip.Name = "m_IDSkip";
            m_IDSkip.Size = new Size(116, 23);
            m_IDSkip.TabIndex = 35;
            m_IDSkip.TextChanged += OnIDSkipChanged;
            // 
            // m_forward
            // 
            m_forward.Location = new Point(314, 264);
            m_forward.Margin = new Padding(4, 3, 4, 3);
            m_forward.Name = "m_forward";
            m_forward.Size = new Size(43, 27);
            m_forward.TabIndex = 36;
            m_forward.Text = ">>|";
            m_forward.UseVisualStyleBackColor = true;
            m_forward.Click += OnForward;
            // 
            // m_addButton
            // 
            m_addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_addButton.Location = new Point(567, 662);
            m_addButton.Margin = new Padding(4, 3, 4, 3);
            m_addButton.Name = "m_addButton";
            m_addButton.Size = new Size(43, 27);
            m_addButton.TabIndex = 37;
            m_addButton.Text = "<---";
            m_addButton.UseVisualStyleBackColor = true;
            m_addButton.Click += OnAddPause;
            // 
            // m_removeButton
            // 
            m_removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            m_removeButton.Location = new Point(350, 662);
            m_removeButton.Margin = new Padding(4, 3, 4, 3);
            m_removeButton.Name = "m_removeButton";
            m_removeButton.Size = new Size(43, 27);
            m_removeButton.TabIndex = 38;
            m_removeButton.Text = "--->";
            m_removeButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 787);
            Controls.Add(m_removeButton);
            Controls.Add(m_addButton);
            Controls.Add(m_forward);
            Controls.Add(m_IDSkip);
            Controls.Add(m_forwardButton4);
            Controls.Add(m_backwardButton4);
            Controls.Add(m_backwardButton1);
            Controls.Add(m_backwardButton2);
            Controls.Add(m_backwardButton3);
            Controls.Add(m_forwardButton3);
            Controls.Add(m_forwardButton2);
            Controls.Add(m_forwardButton1);
            Controls.Add(m_pauses);
            Controls.Add(m_autoPause);
            Controls.Add(m_backward);
            Controls.Add(m_nextPauseButton);
            Controls.Add(m_segments);
            Controls.Add(m_timeLeft);
            Controls.Add(m_timeout);
            Controls.Add(m_timeoutLabel);
            Controls.Add(m_totalTime);
            Controls.Add(m_currentTime);
            Controls.Add(m_saveSettings);
            Controls.Add(m_callsignLabel);
            Controls.Add(m_callsign);
            Controls.Add(m_idButton);
            Controls.Add(m_testPTT);
            Controls.Add(m_playButton);
            Controls.Add(m_progressBar);
            Controls.Add(m_browseButton);
            Controls.Add(label3);
            Controls.Add(m_filename);
            Controls.Add(m_audioOutSelector);
            Controls.Add(label2);
            Controls.Add(m_pttSelector);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainWindow";
            Text = "KN6WPU Amateur Radio Newsline Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox m_pttSelector;
        private Label label2;
        private ComboBox m_audioOutSelector;
        private TextBox m_filename;
        private Label label3;
        private Button m_browseButton;
        private ProgressBar m_progressBar;
        private CheckBox m_playButton;
        private CheckBox m_testPTT;
        private Button m_idButton;
        private TextBox m_callsign;
        private Label m_callsignLabel;
        private Button m_saveSettings;
        private TextBox m_currentTime;
        private TextBox m_totalTime;
        private Label m_timeoutLabel;
        private TextBox m_timeout;
        private TextBox m_timeLeft;
        private ListBox m_segments;
        private Button m_nextPauseButton;
        private Button m_backward;
        private TextBox m_autoPause;
        private ListBox m_pauses;
        private Button m_forwardButton1;
        private Button m_forwardButton2;
        private Button m_forwardButton3;
        private Button m_backwardButton1;
        private Button m_backwardButton2;
        private Button m_backwardButton3;
        private Button m_backwardButton4;
        private Button m_forwardButton4;
        private TextBox m_IDSkip;
        private Button m_forward;
        private Button m_addButton;
        private Button m_removeButton;
    }
}

