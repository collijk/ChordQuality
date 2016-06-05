namespace ChordQuality.controls
{
    partial class QualityWeightsControl
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
            this.qualityWeightsBox = new System.Windows.Forms.GroupBox();
            this.chordBox = new System.Windows.Forms.GroupBox();
            this.thirdMajorChordLabel = new System.Windows.Forms.Label();
            this.fifthChordLabel = new System.Windows.Forms.Label();
            this.thirdMajorChordVScroll = new System.Windows.Forms.VScrollBar();
            this.fifthChordVScroll = new System.Windows.Forms.VScrollBar();
            this.intervalBox = new System.Windows.Forms.GroupBox();
            this.thirdMajorIntervalVScroll = new System.Windows.Forms.VScrollBar();
            this.fourthIntervalLabel = new System.Windows.Forms.Label();
            this.fourthIntervalVScroll = new System.Windows.Forms.VScrollBar();
            this.thirdMinorIntervalLabel = new System.Windows.Forms.Label();
            this.fifthIntervalLabel = new System.Windows.Forms.Label();
            this.thirdMajorIntervalLabel = new System.Windows.Forms.Label();
            this.fifthIntervalVScroll = new System.Windows.Forms.VScrollBar();
            this.thirdMinorIntervalVScroll = new System.Windows.Forms.VScrollBar();
            this.sixthMinorIntervalLabel = new System.Windows.Forms.Label();
            this.sixthMajorIntervalLabel = new System.Windows.Forms.Label();
            this.sixthMinorIntervalVScroll = new System.Windows.Forms.VScrollBar();
            this.sixthMajorIntervalVScroll = new System.Windows.Forms.VScrollBar();
            this.qualityWeightsBox.SuspendLayout();
            this.chordBox.SuspendLayout();
            this.intervalBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // qualityWeightsBox
            // 
            this.qualityWeightsBox.AutoSize = true;
            this.qualityWeightsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.qualityWeightsBox.Controls.Add(this.chordBox);
            this.qualityWeightsBox.Controls.Add(this.intervalBox);
            this.qualityWeightsBox.Location = new System.Drawing.Point(0, 0);
            this.qualityWeightsBox.Name = "qualityWeightsBox";
            this.qualityWeightsBox.Size = new System.Drawing.Size(253, 186);
            this.qualityWeightsBox.TabIndex = 0;
            this.qualityWeightsBox.TabStop = false;
            this.qualityWeightsBox.Text = "QualityWeights";
            // 
            // chordBox
            // 
            this.chordBox.AutoSize = true;
            this.chordBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chordBox.Controls.Add(this.thirdMajorChordLabel);
            this.chordBox.Controls.Add(this.fifthChordLabel);
            this.chordBox.Controls.Add(this.thirdMajorChordVScroll);
            this.chordBox.Controls.Add(this.fifthChordVScroll);
            this.chordBox.Location = new System.Drawing.Point(187, 19);
            this.chordBox.Name = "chordBox";
            this.chordBox.Size = new System.Drawing.Size(60, 146);
            this.chordBox.TabIndex = 0;
            this.chordBox.TabStop = false;
            this.chordBox.Text = "Chords";
            // 
            // thirdMajorChordLabel
            // 
            this.thirdMajorChordLabel.AutoSize = true;
            this.thirdMajorChordLabel.Location = new System.Drawing.Point(32, 117);
            this.thirdMajorChordLabel.Name = "thirdMajorChordLabel";
            this.thirdMajorChordLabel.Size = new System.Drawing.Size(22, 13);
            this.thirdMajorChordLabel.TabIndex = 3;
            this.thirdMajorChordLabel.Text = "3M";
            // 
            // fifthChordLabel
            // 
            this.fifthChordLabel.AutoSize = true;
            this.fifthChordLabel.Location = new System.Drawing.Point(12, 117);
            this.fifthChordLabel.Name = "fifthChordLabel";
            this.fifthChordLabel.Size = new System.Drawing.Size(13, 13);
            this.fifthChordLabel.TabIndex = 2;
            this.fifthChordLabel.Text = "5";
            // 
            // thirdMajorChordVScroll
            // 
            this.thirdMajorChordVScroll.Enabled = false;
            this.thirdMajorChordVScroll.LargeChange = 1;
            this.thirdMajorChordVScroll.Location = new System.Drawing.Point(35, 24);
            this.thirdMajorChordVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.thirdMajorChordVScroll.Maximum = 20;
            this.thirdMajorChordVScroll.Name = "thirdMajorChordVScroll";
            this.thirdMajorChordVScroll.Size = new System.Drawing.Size(17, 88);
            this.thirdMajorChordVScroll.TabIndex = 1;
            this.thirdMajorChordVScroll.Value = 10;
            this.thirdMajorChordVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.thirdMajorChordVScroll_Scroll);
            // 
            // fifthChordVScroll
            // 
            this.fifthChordVScroll.Enabled = false;
            this.fifthChordVScroll.LargeChange = 1;
            this.fifthChordVScroll.Location = new System.Drawing.Point(8, 24);
            this.fifthChordVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.fifthChordVScroll.Maximum = 20;
            this.fifthChordVScroll.Name = "fifthChordVScroll";
            this.fifthChordVScroll.Size = new System.Drawing.Size(17, 88);
            this.fifthChordVScroll.TabIndex = 0;
            this.fifthChordVScroll.Value = 10;
            this.fifthChordVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fifthChordVScroll_Scroll);
            // 
            // intervalBox
            // 
            this.intervalBox.AutoSize = true;
            this.intervalBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.intervalBox.Controls.Add(this.thirdMajorIntervalVScroll);
            this.intervalBox.Controls.Add(this.fourthIntervalLabel);
            this.intervalBox.Controls.Add(this.fourthIntervalVScroll);
            this.intervalBox.Controls.Add(this.thirdMinorIntervalLabel);
            this.intervalBox.Controls.Add(this.fifthIntervalLabel);
            this.intervalBox.Controls.Add(this.thirdMajorIntervalLabel);
            this.intervalBox.Controls.Add(this.fifthIntervalVScroll);
            this.intervalBox.Controls.Add(this.thirdMinorIntervalVScroll);
            this.intervalBox.Controls.Add(this.sixthMinorIntervalLabel);
            this.intervalBox.Controls.Add(this.sixthMajorIntervalLabel);
            this.intervalBox.Controls.Add(this.sixthMinorIntervalVScroll);
            this.intervalBox.Controls.Add(this.sixthMajorIntervalVScroll);
            this.intervalBox.Location = new System.Drawing.Point(6, 19);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Padding = new System.Windows.Forms.Padding(5);
            this.intervalBox.Size = new System.Drawing.Size(175, 148);
            this.intervalBox.TabIndex = 0;
            this.intervalBox.TabStop = false;
            this.intervalBox.Text = "Intervals";
            // 
            // thirdMajorIntervalVScroll
            // 
            this.thirdMajorIntervalVScroll.Enabled = false;
            this.thirdMajorIntervalVScroll.LargeChange = 1;
            this.thirdMajorIntervalVScroll.Location = new System.Drawing.Point(121, 24);
            this.thirdMajorIntervalVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.thirdMajorIntervalVScroll.Maximum = 20;
            this.thirdMajorIntervalVScroll.Name = "thirdMajorIntervalVScroll";
            this.thirdMajorIntervalVScroll.Size = new System.Drawing.Size(17, 88);
            this.thirdMajorIntervalVScroll.TabIndex = 10;
            this.thirdMajorIntervalVScroll.Value = 10;
            this.thirdMajorIntervalVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.thirdMajorIntervalVScroll_Scroll);
            // 
            // fourthIntervalLabel
            // 
            this.fourthIntervalLabel.AutoSize = true;
            this.fourthIntervalLabel.Location = new System.Drawing.Point(96, 117);
            this.fourthIntervalLabel.Name = "fourthIntervalLabel";
            this.fourthIntervalLabel.Size = new System.Drawing.Size(13, 13);
            this.fourthIntervalLabel.TabIndex = 3;
            this.fourthIntervalLabel.Text = "4";
            // 
            // fourthIntervalVScroll
            // 
            this.fourthIntervalVScroll.Enabled = false;
            this.fourthIntervalVScroll.LargeChange = 1;
            this.fourthIntervalVScroll.Location = new System.Drawing.Point(94, 24);
            this.fourthIntervalVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.fourthIntervalVScroll.Maximum = 20;
            this.fourthIntervalVScroll.Name = "fourthIntervalVScroll";
            this.fourthIntervalVScroll.Size = new System.Drawing.Size(17, 88);
            this.fourthIntervalVScroll.TabIndex = 9;
            this.fourthIntervalVScroll.Value = 10;
            this.fourthIntervalVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fourthIntervalVScroll_Scroll);
            // 
            // thirdMinorIntervalLabel
            // 
            this.thirdMinorIntervalLabel.AutoSize = true;
            this.thirdMinorIntervalLabel.Location = new System.Drawing.Point(146, 117);
            this.thirdMinorIntervalLabel.Name = "thirdMinorIntervalLabel";
            this.thirdMinorIntervalLabel.Size = new System.Drawing.Size(21, 13);
            this.thirdMinorIntervalLabel.TabIndex = 5;
            this.thirdMinorIntervalLabel.Text = "3m";
            // 
            // fifthIntervalLabel
            // 
            this.fifthIntervalLabel.AutoSize = true;
            this.fifthIntervalLabel.Location = new System.Drawing.Point(69, 117);
            this.fifthIntervalLabel.Name = "fifthIntervalLabel";
            this.fifthIntervalLabel.Size = new System.Drawing.Size(13, 13);
            this.fifthIntervalLabel.TabIndex = 2;
            this.fifthIntervalLabel.Text = "5";
            // 
            // thirdMajorIntervalLabel
            // 
            this.thirdMajorIntervalLabel.AutoSize = true;
            this.thirdMajorIntervalLabel.Location = new System.Drawing.Point(118, 117);
            this.thirdMajorIntervalLabel.Name = "thirdMajorIntervalLabel";
            this.thirdMajorIntervalLabel.Size = new System.Drawing.Size(22, 13);
            this.thirdMajorIntervalLabel.TabIndex = 4;
            this.thirdMajorIntervalLabel.Text = "3M";
            // 
            // fifthIntervalVScroll
            // 
            this.fifthIntervalVScroll.Enabled = false;
            this.fifthIntervalVScroll.LargeChange = 1;
            this.fifthIntervalVScroll.Location = new System.Drawing.Point(67, 24);
            this.fifthIntervalVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.fifthIntervalVScroll.Maximum = 20;
            this.fifthIntervalVScroll.Name = "fifthIntervalVScroll";
            this.fifthIntervalVScroll.Size = new System.Drawing.Size(17, 88);
            this.fifthIntervalVScroll.TabIndex = 8;
            this.fifthIntervalVScroll.Value = 10;
            this.fifthIntervalVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fifthIntervalVScroll_Scroll);
            // 
            // thirdMinorIntervalVScroll
            // 
            this.thirdMinorIntervalVScroll.Enabled = false;
            this.thirdMinorIntervalVScroll.LargeChange = 1;
            this.thirdMinorIntervalVScroll.Location = new System.Drawing.Point(148, 24);
            this.thirdMinorIntervalVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.thirdMinorIntervalVScroll.Maximum = 20;
            this.thirdMinorIntervalVScroll.Name = "thirdMinorIntervalVScroll";
            this.thirdMinorIntervalVScroll.Size = new System.Drawing.Size(17, 88);
            this.thirdMinorIntervalVScroll.TabIndex = 11;
            this.thirdMinorIntervalVScroll.Value = 10;
            this.thirdMinorIntervalVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.thirdMinorIntervalVScroll_Scroll);
            // 
            // sixthMinorIntervalLabel
            // 
            this.sixthMinorIntervalLabel.AutoSize = true;
            this.sixthMinorIntervalLabel.Location = new System.Drawing.Point(38, 117);
            this.sixthMinorIntervalLabel.Name = "sixthMinorIntervalLabel";
            this.sixthMinorIntervalLabel.Size = new System.Drawing.Size(21, 13);
            this.sixthMinorIntervalLabel.TabIndex = 1;
            this.sixthMinorIntervalLabel.Text = "6m";
            // 
            // sixthMajorIntervalLabel
            // 
            this.sixthMajorIntervalLabel.AutoSize = true;
            this.sixthMajorIntervalLabel.Location = new System.Drawing.Point(10, 117);
            this.sixthMajorIntervalLabel.Name = "sixthMajorIntervalLabel";
            this.sixthMajorIntervalLabel.Size = new System.Drawing.Size(22, 13);
            this.sixthMajorIntervalLabel.TabIndex = 0;
            this.sixthMajorIntervalLabel.Text = "6M";
            // 
            // sixthMinorIntervalVScroll
            // 
            this.sixthMinorIntervalVScroll.Enabled = false;
            this.sixthMinorIntervalVScroll.LargeChange = 1;
            this.sixthMinorIntervalVScroll.Location = new System.Drawing.Point(40, 24);
            this.sixthMinorIntervalVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.sixthMinorIntervalVScroll.Maximum = 20;
            this.sixthMinorIntervalVScroll.Name = "sixthMinorIntervalVScroll";
            this.sixthMinorIntervalVScroll.Size = new System.Drawing.Size(17, 88);
            this.sixthMinorIntervalVScroll.TabIndex = 7;
            this.sixthMinorIntervalVScroll.Value = 10;
            this.sixthMinorIntervalVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sixthMinorIntervalVScroll_Scroll);
            // 
            // sixthMajorIntervalVScroll
            // 
            this.sixthMajorIntervalVScroll.Enabled = false;
            this.sixthMajorIntervalVScroll.LargeChange = 1;
            this.sixthMajorIntervalVScroll.Location = new System.Drawing.Point(13, 24);
            this.sixthMajorIntervalVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.sixthMajorIntervalVScroll.Maximum = 20;
            this.sixthMajorIntervalVScroll.Name = "sixthMajorIntervalVScroll";
            this.sixthMajorIntervalVScroll.Size = new System.Drawing.Size(17, 88);
            this.sixthMajorIntervalVScroll.TabIndex = 6;
            this.sixthMajorIntervalVScroll.Value = 10;
            this.sixthMajorIntervalVScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sixthMajorIntervalVScroll_Scroll);
            // 
            // QualityWeightsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.qualityWeightsBox);
            this.Name = "QualityWeightsControl";
            this.Size = new System.Drawing.Size(256, 189);
            this.qualityWeightsBox.ResumeLayout(false);
            this.qualityWeightsBox.PerformLayout();
            this.chordBox.ResumeLayout(false);
            this.chordBox.PerformLayout();
            this.intervalBox.ResumeLayout(false);
            this.intervalBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox qualityWeightsBox;
        private System.Windows.Forms.GroupBox chordBox;
        private System.Windows.Forms.GroupBox intervalBox;
        private System.Windows.Forms.VScrollBar thirdMinorIntervalVScroll;
        private System.Windows.Forms.VScrollBar thirdMajorIntervalVScroll;
        private System.Windows.Forms.VScrollBar fourthIntervalVScroll;
        private System.Windows.Forms.Label sixthMajorIntervalLabel;
        private System.Windows.Forms.VScrollBar fifthIntervalVScroll;
        private System.Windows.Forms.VScrollBar sixthMinorIntervalVScroll;
        private System.Windows.Forms.VScrollBar sixthMajorIntervalVScroll;
        private System.Windows.Forms.Label thirdMajorIntervalLabel;
        private System.Windows.Forms.Label thirdMinorIntervalLabel;
        private System.Windows.Forms.Label fourthIntervalLabel;
        private System.Windows.Forms.Label sixthMinorIntervalLabel;
        private System.Windows.Forms.Label fifthIntervalLabel;
        private System.Windows.Forms.VScrollBar thirdMajorChordVScroll;
        private System.Windows.Forms.VScrollBar fifthChordVScroll;
        private System.Windows.Forms.Label thirdMajorChordLabel;
        private System.Windows.Forms.Label fifthChordLabel;
    }
}
