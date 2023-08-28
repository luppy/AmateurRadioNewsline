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
            this.m_pttSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_audioOutSelector = new System.Windows.Forms.ComboBox();
            this.m_filename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_browseButton = new System.Windows.Forms.Button();
            this.m_progressBar = new System.Windows.Forms.ProgressBar();
            this.m_playButton = new System.Windows.Forms.CheckBox();
            this.m_testPTT = new System.Windows.Forms.CheckBox();
            this.m_idButton = new System.Windows.Forms.Button();
            this.m_callsign = new System.Windows.Forms.TextBox();
            this.m_callsignLabel = new System.Windows.Forms.Label();
            this.m_saveSettings = new System.Windows.Forms.Button();
            this.m_currentTime = new System.Windows.Forms.TextBox();
            this.m_totalTime = new System.Windows.Forms.TextBox();
            this.m_timeoutLabel = new System.Windows.Forms.Label();
            this.m_timeout = new System.Windows.Forms.TextBox();
            this.m_timeLeft = new System.Windows.Forms.TextBox();
            this.m_segments = new System.Windows.Forms.ListBox();
            this.m_nextPauseButton = new System.Windows.Forms.Button();
            this.m_backward = new System.Windows.Forms.Button();
            this.m_autoPause = new System.Windows.Forms.TextBox();
            this.m_pauses = new System.Windows.Forms.ListBox();
            this.m_forwardButton1 = new System.Windows.Forms.Button();
            this.m_forwardButton2 = new System.Windows.Forms.Button();
            this.m_forwardButton3 = new System.Windows.Forms.Button();
            this.m_backwardButton1 = new System.Windows.Forms.Button();
            this.m_backwardButton2 = new System.Windows.Forms.Button();
            this.m_backwardButton3 = new System.Windows.Forms.Button();
            this.m_backwardButton4 = new System.Windows.Forms.Button();
            this.m_forwardButton4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_pttSelector
            // 
            this.m_pttSelector.FormattingEnabled = true;
            this.m_pttSelector.Location = new System.Drawing.Point(87, 37);
            this.m_pttSelector.Name = "m_pttSelector";
            this.m_pttSelector.Size = new System.Drawing.Size(312, 21);
            this.m_pttSelector.TabIndex = 0;
            this.m_pttSelector.SelectedIndexChanged += new System.EventHandler(this.OnComPortChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Audio Output";
            // 
            // m_audioOutSelector
            // 
            this.m_audioOutSelector.FormattingEnabled = true;
            this.m_audioOutSelector.Location = new System.Drawing.Point(87, 64);
            this.m_audioOutSelector.Name = "m_audioOutSelector";
            this.m_audioOutSelector.Size = new System.Drawing.Size(312, 21);
            this.m_audioOutSelector.TabIndex = 3;
            this.m_audioOutSelector.SelectedIndexChanged += new System.EventHandler(this.OnNewAudioOut);
            // 
            // m_filename
            // 
            this.m_filename.Location = new System.Drawing.Point(87, 92);
            this.m_filename.Name = "m_filename";
            this.m_filename.Size = new System.Drawing.Size(312, 20);
            this.m_filename.TabIndex = 4;
            this.m_filename.TextChanged += new System.EventHandler(this.OnFilenameChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filename";
            // 
            // m_browseButton
            // 
            this.m_browseButton.Location = new System.Drawing.Point(405, 90);
            this.m_browseButton.Name = "m_browseButton";
            this.m_browseButton.Size = new System.Drawing.Size(75, 23);
            this.m_browseButton.TabIndex = 6;
            this.m_browseButton.Text = "Browse";
            this.m_browseButton.UseVisualStyleBackColor = true;
            this.m_browseButton.Click += new System.EventHandler(this.OnBrowseButtonClick);
            // 
            // m_progressBar
            // 
            this.m_progressBar.Location = new System.Drawing.Point(88, 171);
            this.m_progressBar.Name = "m_progressBar";
            this.m_progressBar.Size = new System.Drawing.Size(311, 23);
            this.m_progressBar.TabIndex = 8;
            this.m_progressBar.Click += new System.EventHandler(this.OnProgressBarClick);
            this.m_progressBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnProgressBarMove);
            // 
            // m_playButton
            // 
            this.m_playButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_playButton.AutoSize = true;
            this.m_playButton.Location = new System.Drawing.Point(225, 200);
            this.m_playButton.Name = "m_playButton";
            this.m_playButton.Size = new System.Drawing.Size(37, 23);
            this.m_playButton.TabIndex = 10;
            this.m_playButton.Text = "Play";
            this.m_playButton.UseVisualStyleBackColor = true;
            this.m_playButton.CheckedChanged += new System.EventHandler(this.OnPlayButtonChanged);
            // 
            // m_testPTT
            // 
            this.m_testPTT.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_testPTT.AutoSize = true;
            this.m_testPTT.Enabled = false;
            this.m_testPTT.Location = new System.Drawing.Point(43, 35);
            this.m_testPTT.Name = "m_testPTT";
            this.m_testPTT.Size = new System.Drawing.Size(38, 23);
            this.m_testPTT.TabIndex = 11;
            this.m_testPTT.Text = "PTT";
            this.m_testPTT.UseVisualStyleBackColor = true;
            this.m_testPTT.CheckedChanged += new System.EventHandler(this.OnTestPTT);
            // 
            // m_idButton
            // 
            this.m_idButton.Location = new System.Drawing.Point(405, 9);
            this.m_idButton.Name = "m_idButton";
            this.m_idButton.Size = new System.Drawing.Size(46, 23);
            this.m_idButton.TabIndex = 12;
            this.m_idButton.Text = "ID";
            this.m_idButton.UseVisualStyleBackColor = true;
            this.m_idButton.Click += new System.EventHandler(this.OnIDButton);
            // 
            // m_callsign
            // 
            this.m_callsign.Location = new System.Drawing.Point(87, 11);
            this.m_callsign.Name = "m_callsign";
            this.m_callsign.Size = new System.Drawing.Size(312, 20);
            this.m_callsign.TabIndex = 13;
            this.m_callsign.TextChanged += new System.EventHandler(this.OnCallsignChanged);
            // 
            // m_callsignLabel
            // 
            this.m_callsignLabel.AutoSize = true;
            this.m_callsignLabel.Location = new System.Drawing.Point(38, 14);
            this.m_callsignLabel.Name = "m_callsignLabel";
            this.m_callsignLabel.Size = new System.Drawing.Size(43, 13);
            this.m_callsignLabel.TabIndex = 14;
            this.m_callsignLabel.Text = "Callsign";
            // 
            // m_saveSettings
            // 
            this.m_saveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_saveSettings.Location = new System.Drawing.Point(850, 646);
            this.m_saveSettings.Name = "m_saveSettings";
            this.m_saveSettings.Size = new System.Drawing.Size(91, 23);
            this.m_saveSettings.TabIndex = 15;
            this.m_saveSettings.Text = "Save Settings";
            this.m_saveSettings.UseVisualStyleBackColor = true;
            this.m_saveSettings.Click += new System.EventHandler(this.OnSaveSettings);
            // 
            // m_currentTime
            // 
            this.m_currentTime.Location = new System.Drawing.Point(87, 145);
            this.m_currentTime.Name = "m_currentTime";
            this.m_currentTime.ReadOnly = true;
            this.m_currentTime.Size = new System.Drawing.Size(100, 20);
            this.m_currentTime.TabIndex = 16;
            // 
            // m_totalTime
            // 
            this.m_totalTime.Location = new System.Drawing.Point(299, 144);
            this.m_totalTime.Name = "m_totalTime";
            this.m_totalTime.ReadOnly = true;
            this.m_totalTime.Size = new System.Drawing.Size(100, 20);
            this.m_totalTime.TabIndex = 17;
            // 
            // m_timeoutLabel
            // 
            this.m_timeoutLabel.AutoSize = true;
            this.m_timeoutLabel.Location = new System.Drawing.Point(32, 121);
            this.m_timeoutLabel.Name = "m_timeoutLabel";
            this.m_timeoutLabel.Size = new System.Drawing.Size(45, 13);
            this.m_timeoutLabel.TabIndex = 18;
            this.m_timeoutLabel.Text = "Timeout";
            // 
            // m_timeout
            // 
            this.m_timeout.Location = new System.Drawing.Point(87, 118);
            this.m_timeout.Name = "m_timeout";
            this.m_timeout.Size = new System.Drawing.Size(100, 20);
            this.m_timeout.TabIndex = 19;
            this.m_timeout.TextChanged += new System.EventHandler(this.OnTimeoutChanged);
            // 
            // m_timeLeft
            // 
            this.m_timeLeft.Location = new System.Drawing.Point(299, 118);
            this.m_timeLeft.Name = "m_timeLeft";
            this.m_timeLeft.ReadOnly = true;
            this.m_timeLeft.Size = new System.Drawing.Size(100, 20);
            this.m_timeLeft.TabIndex = 20;
            // 
            // m_segments
            // 
            this.m_segments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_segments.FormattingEnabled = true;
            this.m_segments.Location = new System.Drawing.Point(742, 12);
            this.m_segments.Name = "m_segments";
            this.m_segments.Size = new System.Drawing.Size(199, 602);
            this.m_segments.TabIndex = 22;
            this.m_segments.DoubleClick += new System.EventHandler(this.OnSegmentsDoubleClick);
            // 
            // m_nextPauseButton
            // 
            this.m_nextPauseButton.Location = new System.Drawing.Point(225, 229);
            this.m_nextPauseButton.Name = "m_nextPauseButton";
            this.m_nextPauseButton.Size = new System.Drawing.Size(37, 23);
            this.m_nextPauseButton.TabIndex = 23;
            this.m_nextPauseButton.Text = ">>";
            this.m_nextPauseButton.UseVisualStyleBackColor = true;
            this.m_nextPauseButton.Click += new System.EventHandler(this.OnForwardClick);
            // 
            // m_backward
            // 
            this.m_backward.Location = new System.Drawing.Point(50, 229);
            this.m_backward.Name = "m_backward";
            this.m_backward.Size = new System.Drawing.Size(37, 23);
            this.m_backward.TabIndex = 24;
            this.m_backward.Text = "<<";
            this.m_backward.UseVisualStyleBackColor = true;
            this.m_backward.Click += new System.EventHandler(this.OnBackwardClick);
            // 
            // m_autoPause
            // 
            this.m_autoPause.Location = new System.Drawing.Point(193, 144);
            this.m_autoPause.Name = "m_autoPause";
            this.m_autoPause.ReadOnly = true;
            this.m_autoPause.Size = new System.Drawing.Size(100, 20);
            this.m_autoPause.TabIndex = 25;
            // 
            // m_pauses
            // 
            this.m_pauses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pauses.FormattingEnabled = true;
            this.m_pauses.Location = new System.Drawing.Point(537, 12);
            this.m_pauses.Name = "m_pauses";
            this.m_pauses.Size = new System.Drawing.Size(199, 602);
            this.m_pauses.TabIndex = 26;
            // 
            // m_forwardButton1
            // 
            this.m_forwardButton1.Location = new System.Drawing.Point(268, 200);
            this.m_forwardButton1.Name = "m_forwardButton1";
            this.m_forwardButton1.Size = new System.Drawing.Size(38, 23);
            this.m_forwardButton1.TabIndex = 27;
            this.m_forwardButton1.Text = "+1s";
            this.m_forwardButton1.UseVisualStyleBackColor = true;
            this.m_forwardButton1.Click += new System.EventHandler(this.OnForward1);
            // 
            // m_forwardButton2
            // 
            this.m_forwardButton2.Location = new System.Drawing.Point(312, 200);
            this.m_forwardButton2.Name = "m_forwardButton2";
            this.m_forwardButton2.Size = new System.Drawing.Size(38, 23);
            this.m_forwardButton2.TabIndex = 28;
            this.m_forwardButton2.Text = "+5s";
            this.m_forwardButton2.UseVisualStyleBackColor = true;
            this.m_forwardButton2.Click += new System.EventHandler(this.OnForward2);
            // 
            // m_forwardButton3
            // 
            this.m_forwardButton3.Location = new System.Drawing.Point(356, 200);
            this.m_forwardButton3.Name = "m_forwardButton3";
            this.m_forwardButton3.Size = new System.Drawing.Size(38, 23);
            this.m_forwardButton3.TabIndex = 29;
            this.m_forwardButton3.Text = "+15s";
            this.m_forwardButton3.UseVisualStyleBackColor = true;
            this.m_forwardButton3.Click += new System.EventHandler(this.OnForward3);
            // 
            // m_backwardButton1
            // 
            this.m_backwardButton1.Location = new System.Drawing.Point(181, 200);
            this.m_backwardButton1.Name = "m_backwardButton1";
            this.m_backwardButton1.Size = new System.Drawing.Size(38, 23);
            this.m_backwardButton1.TabIndex = 32;
            this.m_backwardButton1.Text = "-1s";
            this.m_backwardButton1.UseVisualStyleBackColor = true;
            this.m_backwardButton1.Click += new System.EventHandler(this.OnBackward1);
            // 
            // m_backwardButton2
            // 
            this.m_backwardButton2.Location = new System.Drawing.Point(137, 200);
            this.m_backwardButton2.Name = "m_backwardButton2";
            this.m_backwardButton2.Size = new System.Drawing.Size(38, 23);
            this.m_backwardButton2.TabIndex = 31;
            this.m_backwardButton2.Text = "-5s";
            this.m_backwardButton2.UseVisualStyleBackColor = true;
            this.m_backwardButton2.Click += new System.EventHandler(this.OnBackward2);
            // 
            // m_backwardButton3
            // 
            this.m_backwardButton3.Location = new System.Drawing.Point(93, 200);
            this.m_backwardButton3.Name = "m_backwardButton3";
            this.m_backwardButton3.Size = new System.Drawing.Size(38, 23);
            this.m_backwardButton3.TabIndex = 30;
            this.m_backwardButton3.Text = "-15s";
            this.m_backwardButton3.UseVisualStyleBackColor = true;
            this.m_backwardButton3.Click += new System.EventHandler(this.OnBackward3);
            // 
            // m_backwardButton4
            // 
            this.m_backwardButton4.Location = new System.Drawing.Point(49, 200);
            this.m_backwardButton4.Name = "m_backwardButton4";
            this.m_backwardButton4.Size = new System.Drawing.Size(38, 23);
            this.m_backwardButton4.TabIndex = 33;
            this.m_backwardButton4.Text = "-1m";
            this.m_backwardButton4.UseVisualStyleBackColor = true;
            this.m_backwardButton4.Click += new System.EventHandler(this.OnBackward4);
            // 
            // m_forwardButton4
            // 
            this.m_forwardButton4.Location = new System.Drawing.Point(400, 200);
            this.m_forwardButton4.Name = "m_forwardButton4";
            this.m_forwardButton4.Size = new System.Drawing.Size(38, 23);
            this.m_forwardButton4.TabIndex = 34;
            this.m_forwardButton4.Text = "+1m";
            this.m_forwardButton4.UseVisualStyleBackColor = true;
            this.m_forwardButton4.Click += new System.EventHandler(this.OnForward4);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 681);
            this.Controls.Add(this.m_forwardButton4);
            this.Controls.Add(this.m_backwardButton4);
            this.Controls.Add(this.m_backwardButton1);
            this.Controls.Add(this.m_backwardButton2);
            this.Controls.Add(this.m_backwardButton3);
            this.Controls.Add(this.m_forwardButton3);
            this.Controls.Add(this.m_forwardButton2);
            this.Controls.Add(this.m_forwardButton1);
            this.Controls.Add(this.m_pauses);
            this.Controls.Add(this.m_autoPause);
            this.Controls.Add(this.m_backward);
            this.Controls.Add(this.m_nextPauseButton);
            this.Controls.Add(this.m_segments);
            this.Controls.Add(this.m_timeLeft);
            this.Controls.Add(this.m_timeout);
            this.Controls.Add(this.m_timeoutLabel);
            this.Controls.Add(this.m_totalTime);
            this.Controls.Add(this.m_currentTime);
            this.Controls.Add(this.m_saveSettings);
            this.Controls.Add(this.m_callsignLabel);
            this.Controls.Add(this.m_callsign);
            this.Controls.Add(this.m_idButton);
            this.Controls.Add(this.m_testPTT);
            this.Controls.Add(this.m_playButton);
            this.Controls.Add(this.m_progressBar);
            this.Controls.Add(this.m_browseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_filename);
            this.Controls.Add(this.m_audioOutSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_pttSelector);
            this.Name = "MainWindow";
            this.Text = "KN6WPU Amateur Radio Newsline Player";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox m_pttSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_audioOutSelector;
        private System.Windows.Forms.TextBox m_filename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button m_browseButton;
        private System.Windows.Forms.ProgressBar m_progressBar;
        private System.Windows.Forms.CheckBox m_playButton;
        private System.Windows.Forms.CheckBox m_testPTT;
        private System.Windows.Forms.Button m_idButton;
        private System.Windows.Forms.TextBox m_callsign;
        private System.Windows.Forms.Label m_callsignLabel;
        private System.Windows.Forms.Button m_saveSettings;
        private System.Windows.Forms.TextBox m_currentTime;
        private System.Windows.Forms.TextBox m_totalTime;
        private System.Windows.Forms.Label m_timeoutLabel;
        private System.Windows.Forms.TextBox m_timeout;
        private System.Windows.Forms.TextBox m_timeLeft;
        private System.Windows.Forms.ListBox m_segments;
        private System.Windows.Forms.Button m_nextPauseButton;
        private System.Windows.Forms.Button m_backward;
        private System.Windows.Forms.TextBox m_autoPause;
        private System.Windows.Forms.ListBox m_pauses;
        private System.Windows.Forms.Button m_forwardButton1;
        private System.Windows.Forms.Button m_forwardButton2;
        private System.Windows.Forms.Button m_forwardButton3;
        private System.Windows.Forms.Button m_backwardButton1;
        private System.Windows.Forms.Button m_backwardButton2;
        private System.Windows.Forms.Button m_backwardButton3;
        private System.Windows.Forms.Button m_backwardButton4;
        private System.Windows.Forms.Button m_forwardButton4;
    }
}

