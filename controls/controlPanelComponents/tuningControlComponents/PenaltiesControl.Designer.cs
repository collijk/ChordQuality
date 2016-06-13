namespace ChordQuality.controls
{
    partial class PenaltiesControl
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
            this.penaltyBox = new System.Windows.Forms.GroupBox();
            this.thresholdUpDown = new System.Windows.Forms.DomainUpDown();
            this.penaltyShortLabel = new System.Windows.Forms.Label();
            this.penaltyAddLabel = new System.Windows.Forms.Label();
            this.penaltyShortVScroll = new System.Windows.Forms.VScrollBar();
            this.penaltyAddVScroll = new System.Windows.Forms.VScrollBar();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.penaltyBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // penaltyBox
            // 
            this.penaltyBox.AutoSize = true;
            this.penaltyBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.penaltyBox.Controls.Add(this.thresholdUpDown);
            this.penaltyBox.Controls.Add(this.penaltyShortLabel);
            this.penaltyBox.Controls.Add(this.penaltyAddLabel);
            this.penaltyBox.Controls.Add(this.penaltyShortVScroll);
            this.penaltyBox.Controls.Add(this.penaltyAddVScroll);
            this.penaltyBox.Controls.Add(this.thresholdLabel);
            this.penaltyBox.Location = new System.Drawing.Point(0, 0);
            this.penaltyBox.Name = "penaltyBox";
            this.penaltyBox.Size = new System.Drawing.Size(76, 190);
            this.penaltyBox.TabIndex = 0;
            this.penaltyBox.TabStop = false;
            this.penaltyBox.Text = "Penalties";
            // 
            // thresholdUpDown
            // 
            this.thresholdUpDown.Enabled = false;
            this.thresholdUpDown.Items.Add("1");
            this.thresholdUpDown.Items.Add("1/2");
            this.thresholdUpDown.Items.Add("1/4");
            this.thresholdUpDown.Items.Add("1/8");
            this.thresholdUpDown.Items.Add("1/16");
            this.thresholdUpDown.Items.Add("1/32");
            this.thresholdUpDown.Items.Add("1/64");
            this.thresholdUpDown.Location = new System.Drawing.Point(9, 43);
            this.thresholdUpDown.Name = "thresholdUpDown";
            this.thresholdUpDown.ReadOnly = true;
            this.thresholdUpDown.Size = new System.Drawing.Size(54, 20);
            this.thresholdUpDown.TabIndex = 55;
            this.thresholdUpDown.Text = "1";
            this.thresholdUpDown.Wrap = true;
            // 
            // penaltyShortLabel
            // 
            this.penaltyShortLabel.AutoSize = true;
            this.penaltyShortLabel.Location = new System.Drawing.Point(38, 161);
            this.penaltyShortLabel.Name = "penaltyShortLabel";
            this.penaltyShortLabel.Size = new System.Drawing.Size(32, 13);
            this.penaltyShortLabel.TabIndex = 5;
            this.penaltyShortLabel.Text = "Short";
            // 
            // penaltyAddLabel
            // 
            this.penaltyAddLabel.AutoSize = true;
            this.penaltyAddLabel.Location = new System.Drawing.Point(6, 161);
            this.penaltyAddLabel.Name = "penaltyAddLabel";
            this.penaltyAddLabel.Size = new System.Drawing.Size(26, 13);
            this.penaltyAddLabel.TabIndex = 4;
            this.penaltyAddLabel.Text = "Add";
            // 
            // penaltyShortVScroll
            // 
            this.penaltyShortVScroll.Enabled = false;
            this.penaltyShortVScroll.Location = new System.Drawing.Point(46, 71);
            this.penaltyShortVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.penaltyShortVScroll.Name = "penaltyShortVScroll";
            this.penaltyShortVScroll.Size = new System.Drawing.Size(17, 85);
            this.penaltyShortVScroll.TabIndex = 3;
            // 
            // penaltyAddVScroll
            // 
            this.penaltyAddVScroll.Enabled = false;
            this.penaltyAddVScroll.Location = new System.Drawing.Point(9, 71);
            this.penaltyAddVScroll.Margin = new System.Windows.Forms.Padding(5);
            this.penaltyAddVScroll.Name = "penaltyAddVScroll";
            this.penaltyAddVScroll.Size = new System.Drawing.Size(17, 85);
            this.penaltyAddVScroll.TabIndex = 2;
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(6, 27);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(57, 13);
            this.thresholdLabel.TabIndex = 1;
            this.thresholdLabel.Text = "Threshold:";
            // 
            // PenaltiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.penaltyBox);
            this.Name = "PenaltiesControl";
            this.Size = new System.Drawing.Size(79, 193);
            this.penaltyBox.ResumeLayout(false);
            this.penaltyBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox penaltyBox;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.VScrollBar penaltyShortVScroll;
        private System.Windows.Forms.VScrollBar penaltyAddVScroll;
        private System.Windows.Forms.Label penaltyShortLabel;
        private System.Windows.Forms.Label penaltyAddLabel;
        private System.Windows.Forms.DomainUpDown thresholdUpDown;
    }
}
