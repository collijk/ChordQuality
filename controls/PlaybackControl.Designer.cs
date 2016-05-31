namespace ChordQuality
{
    partial class PlaybackControl
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playbackGroup = new System.Windows.Forms.GroupBox();
            this.bpmLabel = new System.Windows.Forms.Label();
            this.tempoLabel = new System.Windows.Forms.Label();
            this.tempoTrackBar = new System.Windows.Forms.TrackBar();
            this.instrumentComboBox = new System.Windows.Forms.ComboBox();
            this.midiOutComboBox = new System.Windows.Forms.ComboBox();
            this.instrumentLabel = new System.Windows.Forms.Label();
            this.midiOutLabel = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.playbackGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempoTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // playbackGroup
            // 
            this.playbackGroup.Controls.Add(this.bpmLabel);
            this.playbackGroup.Controls.Add(this.tempoLabel);
            this.playbackGroup.Controls.Add(this.tempoTrackBar);
            this.playbackGroup.Controls.Add(this.instrumentComboBox);
            this.playbackGroup.Controls.Add(this.midiOutComboBox);
            this.playbackGroup.Controls.Add(this.instrumentLabel);
            this.playbackGroup.Controls.Add(this.midiOutLabel);
            this.playbackGroup.Controls.Add(this.volumeLabel);
            this.playbackGroup.Controls.Add(this.volumeTrackBar);
            this.playbackGroup.Controls.Add(this.stopButton);
            this.playbackGroup.Controls.Add(this.pauseButton);
            this.playbackGroup.Controls.Add(this.playButton);
            this.playbackGroup.Location = new System.Drawing.Point(0, 0);
            this.playbackGroup.Name = "playbackGroup";
            this.playbackGroup.Size = new System.Drawing.Size(300, 205);
            this.playbackGroup.TabIndex = 0;
            this.playbackGroup.TabStop = false;
            this.playbackGroup.Text = "Playback";
            // 
            // bpmLabel
            // 
            this.bpmLabel.AutoSize = true;
            this.bpmLabel.Location = new System.Drawing.Point(16, 176);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(48, 13);
            this.bpmLabel.TabIndex = 62;
            this.bpmLabel.Text = "120 bpm";
            // 
            // tempoLabel
            // 
            this.tempoLabel.AutoSize = true;
            this.tempoLabel.Location = new System.Drawing.Point(16, 154);
            this.tempoLabel.Name = "tempoLabel";
            this.tempoLabel.Size = new System.Drawing.Size(43, 13);
            this.tempoLabel.TabIndex = 61;
            this.tempoLabel.Text = "Tempo:";
            // 
            // tempoTrackBar
            // 
            this.tempoTrackBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tempoTrackBar.Location = new System.Drawing.Point(65, 154);
            this.tempoTrackBar.Maximum = 200;
            this.tempoTrackBar.Minimum = 40;
            this.tempoTrackBar.Name = "tempoTrackBar";
            this.tempoTrackBar.Size = new System.Drawing.Size(226, 45);
            this.tempoTrackBar.TabIndex = 57;
            this.tempoTrackBar.TickFrequency = 10;
            this.tempoTrackBar.Value = 120;
            this.tempoTrackBar.Scroll += new System.EventHandler(this.tempoTrackBar_Scroll);
            // 
            // instrumentComboBox
            // 
            this.instrumentComboBox.FormattingEnabled = true;
            this.instrumentComboBox.Location = new System.Drawing.Point(9, 127);
            this.instrumentComboBox.Name = "instrumentComboBox";
            this.instrumentComboBox.Size = new System.Drawing.Size(231, 21);
            this.instrumentComboBox.TabIndex = 60;
            this.instrumentComboBox.SelectedIndexChanged += new System.EventHandler(this.instrumentComboBox_SelectedIndexChanged);
            // 
            // midiOutComboBox
            // 
            this.midiOutComboBox.FormattingEnabled = true;
            this.midiOutComboBox.Location = new System.Drawing.Point(9, 87);
            this.midiOutComboBox.Name = "midiOutComboBox";
            this.midiOutComboBox.Size = new System.Drawing.Size(231, 21);
            this.midiOutComboBox.TabIndex = 59;
            // 
            // instrumentLabel
            // 
            this.instrumentLabel.AutoSize = true;
            this.instrumentLabel.Location = new System.Drawing.Point(6, 111);
            this.instrumentLabel.Name = "instrumentLabel";
            this.instrumentLabel.Size = new System.Drawing.Size(59, 13);
            this.instrumentLabel.TabIndex = 58;
            this.instrumentLabel.Text = "Instrument:";
            // 
            // midiOutLabel
            // 
            this.midiOutLabel.AutoSize = true;
            this.midiOutLabel.Location = new System.Drawing.Point(6, 71);
            this.midiOutLabel.Name = "midiOutLabel";
            this.midiOutLabel.Size = new System.Drawing.Size(53, 13);
            this.midiOutLabel.TabIndex = 57;
            this.midiOutLabel.Text = "MIDI Out:";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(249, 24);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(42, 13);
            this.volumeLabel.TabIndex = 56;
            this.volumeLabel.Text = "Volume";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.volumeTrackBar.Location = new System.Drawing.Point(246, 40);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeTrackBar.Size = new System.Drawing.Size(45, 108);
            this.volumeTrackBar.TabIndex = 55;
            this.volumeTrackBar.TickFrequency = 20;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(165, 19);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(84, 19);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Location = new System.Drawing.Point(3, 19);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // PlaybackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.playbackGroup);
            this.Name = "PlaybackControl";
            this.Size = new System.Drawing.Size(303, 208);
            this.playbackGroup.ResumeLayout(false);
            this.playbackGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tempoTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox playbackGroup;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.ComboBox instrumentComboBox;
        private System.Windows.Forms.ComboBox midiOutComboBox;
        private System.Windows.Forms.Label instrumentLabel;
        private System.Windows.Forms.Label midiOutLabel;
        private System.Windows.Forms.TrackBar tempoTrackBar;
        private System.Windows.Forms.Label tempoLabel;
        private System.Windows.Forms.Label bpmLabel;
    }
}
