namespace ChordQuality.controls
{
    partial class TuningControl
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
            this.tuningBox = new System.Windows.Forms.GroupBox();
            this.tuningsPanel = new System.Windows.Forms.Panel();
            this.tuningTransposeUpDown = new System.Windows.Forms.NumericUpDown();
            this.tuningTransposeLabel = new System.Windows.Forms.Label();
            this.qualityCheckBox = new System.Windows.Forms.CheckBox();
            this.labelCheckBox = new System.Windows.Forms.CheckBox();
            this.qualityWeightsControl = new ChordQuality.controls.QualityWeightsControl();
            this.penaltiesControl = new ChordQuality.controls.PenaltiesControl();
            this.tuningBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tuningTransposeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tuningBox
            // 
            this.tuningBox.AutoSize = true;
            this.tuningBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tuningBox.Controls.Add(this.penaltiesControl);
            this.tuningBox.Controls.Add(this.qualityWeightsControl);
            this.tuningBox.Controls.Add(this.labelCheckBox);
            this.tuningBox.Controls.Add(this.qualityCheckBox);
            this.tuningBox.Controls.Add(this.tuningTransposeLabel);
            this.tuningBox.Controls.Add(this.tuningTransposeUpDown);
            this.tuningBox.Controls.Add(this.tuningsPanel);
            this.tuningBox.Location = new System.Drawing.Point(0, 0);
            this.tuningBox.Name = "tuningBox";
            this.tuningBox.Padding = new System.Windows.Forms.Padding(5);
            this.tuningBox.Size = new System.Drawing.Size(563, 235);
            this.tuningBox.TabIndex = 0;
            this.tuningBox.TabStop = false;
            this.tuningBox.Text = "Tuning Scheme";
            // 
            // tuningsPanel
            // 
            this.tuningsPanel.AutoScroll = true;
            this.tuningsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tuningsPanel.Location = new System.Drawing.Point(8, 21);
            this.tuningsPanel.Name = "tuningsPanel";
            this.tuningsPanel.Size = new System.Drawing.Size(200, 131);
            this.tuningsPanel.TabIndex = 0;
            // 
            // tuningTransposeUpDown
            // 
            this.tuningTransposeUpDown.Location = new System.Drawing.Point(8, 181);
            this.tuningTransposeUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tuningTransposeUpDown.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.tuningTransposeUpDown.Name = "tuningTransposeUpDown";
            this.tuningTransposeUpDown.Size = new System.Drawing.Size(60, 20);
            this.tuningTransposeUpDown.TabIndex = 1;
            // 
            // tuningTransposeLabel
            // 
            this.tuningTransposeLabel.AutoSize = true;
            this.tuningTransposeLabel.Location = new System.Drawing.Point(8, 165);
            this.tuningTransposeLabel.Name = "tuningTransposeLabel";
            this.tuningTransposeLabel.Size = new System.Drawing.Size(60, 13);
            this.tuningTransposeLabel.TabIndex = 2;
            this.tuningTransposeLabel.Text = "Transpose:";
            // 
            // qualityCheckBox
            // 
            this.qualityCheckBox.AutoSize = true;
            this.qualityCheckBox.Checked = true;
            this.qualityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.qualityCheckBox.Location = new System.Drawing.Point(96, 161);
            this.qualityCheckBox.Name = "qualityCheckBox";
            this.qualityCheckBox.Size = new System.Drawing.Size(88, 17);
            this.qualityCheckBox.TabIndex = 3;
            this.qualityCheckBox.Text = "Show Quality";
            this.qualityCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelCheckBox
            // 
            this.labelCheckBox.AutoSize = true;
            this.labelCheckBox.Checked = true;
            this.labelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.labelCheckBox.Location = new System.Drawing.Point(96, 184);
            this.labelCheckBox.Name = "labelCheckBox";
            this.labelCheckBox.Size = new System.Drawing.Size(87, 17);
            this.labelCheckBox.TabIndex = 4;
            this.labelCheckBox.TabStop = false;
            this.labelCheckBox.Text = "Show Labels";
            this.labelCheckBox.UseVisualStyleBackColor = false;
            // 
            // qualityWeightsControl
            // 
            this.qualityWeightsControl.AutoSize = true;
            this.qualityWeightsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.qualityWeightsControl.Location = new System.Drawing.Point(214, 21);
            this.qualityWeightsControl.Name = "qualityWeightsControl";
            this.qualityWeightsControl.Size = new System.Drawing.Size(256, 189);
            this.qualityWeightsControl.TabIndex = 5;
            // 
            // penaltiesControl
            // 
            this.penaltiesControl.AutoSize = true;
            this.penaltiesControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.penaltiesControl.Location = new System.Drawing.Point(476, 21);
            this.penaltiesControl.Name = "penaltiesControl";
            this.penaltiesControl.Size = new System.Drawing.Size(79, 193);
            this.penaltiesControl.TabIndex = 6;
            // 
            // TuningControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tuningBox);
            this.Name = "TuningControl";
            this.Size = new System.Drawing.Size(566, 238);
            this.tuningBox.ResumeLayout(false);
            this.tuningBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tuningTransposeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tuningBox;
        private System.Windows.Forms.Panel tuningsPanel;
        private System.Windows.Forms.NumericUpDown tuningTransposeUpDown;
        private System.Windows.Forms.Label tuningTransposeLabel;
        private System.Windows.Forms.CheckBox labelCheckBox;
        private System.Windows.Forms.CheckBox qualityCheckBox;
        private PenaltiesControl penaltiesControl;
        private QualityWeightsControl qualityWeightsControl;
    }
}
