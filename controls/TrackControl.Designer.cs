namespace ChordQuality.controls
{
    partial class TrackControl
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
            this.trackBox = new System.Windows.Forms.GroupBox();
            this.trackPanel = new System.Windows.Forms.Panel();
            this.trackBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBox
            // 
            this.trackBox.AutoSize = true;
            this.trackBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trackBox.Controls.Add(this.trackPanel);
            this.trackBox.Location = new System.Drawing.Point(0, 0);
            this.trackBox.Name = "trackBox";
            this.trackBox.Size = new System.Drawing.Size(228, 176);
            this.trackBox.TabIndex = 0;
            this.trackBox.TabStop = false;
            this.trackBox.Text = "Tracks:";
            // 
            // trackPanel
            // 
            this.trackPanel.AutoScroll = true;
            this.trackPanel.BackColor = System.Drawing.SystemColors.Window;
            this.trackPanel.Location = new System.Drawing.Point(3, 16);
            this.trackPanel.Name = "trackPanel";
            this.trackPanel.Size = new System.Drawing.Size(219, 141);
            this.trackPanel.TabIndex = 0;
            // 
            // TrackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.trackBox);
            this.Name = "TrackControl";
            this.Size = new System.Drawing.Size(231, 179);
            this.trackBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox trackBox;
        private System.Windows.Forms.Panel trackPanel;
    }
}
