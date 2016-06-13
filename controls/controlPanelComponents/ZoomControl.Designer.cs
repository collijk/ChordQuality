namespace ChordQuality.controls
{
    partial class ZoomControl
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
            this.zoomBox = new System.Windows.Forms.GroupBox();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.zoomBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // zoomBox
            // 
            this.zoomBox.AutoSize = true;
            this.zoomBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zoomBox.Controls.Add(this.zoomTrackBar);
            this.zoomBox.Location = new System.Drawing.Point(0, 0);
            this.zoomBox.Name = "zoomBox";
            this.zoomBox.Size = new System.Drawing.Size(206, 83);
            this.zoomBox.TabIndex = 0;
            this.zoomBox.TabStop = false;
            this.zoomBox.Text = "Track Zoom";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Enabled = false;
            this.zoomTrackBar.LargeChange = 1;
            this.zoomTrackBar.Location = new System.Drawing.Point(12, 19);
            this.zoomTrackBar.Maximum = 60;
            this.zoomTrackBar.Minimum = 1;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(188, 45);
            this.zoomTrackBar.TabIndex = 1;
            this.zoomTrackBar.Value = 15;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.zoomTrackBar_Scroll);
            // 
            // ZoomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.zoomBox);
            this.Name = "ZoomControl";
            this.Size = new System.Drawing.Size(209, 86);
            this.zoomBox.ResumeLayout(false);
            this.zoomBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox zoomBox;
        private System.Windows.Forms.TrackBar zoomTrackBar;
    }
}
