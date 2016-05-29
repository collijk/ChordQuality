namespace ChordQuality.controls
{
    partial class ControlPanel
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
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.printingControl = new ChordQuality.controls.PrintingControl();
            this.tuningControl = new ChordQuality.controls.TuningControl();
            this.cutControl = new ChordQuality.controls.CutControl();
            this.trackControl = new ChordQuality.controls.TrackControl();
            this.fileTransposeControl = new ChordQuality.controls.FileTransposeControl();
            this.playbackControl = new ChordQuality.PlaybackControl();
            this.controlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBox
            // 
            this.controlBox.AutoSize = true;
            this.controlBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlBox.Controls.Add(this.printingControl);
            this.controlBox.Controls.Add(this.tuningControl);
            this.controlBox.Controls.Add(this.cutControl);
            this.controlBox.Controls.Add(this.trackControl);
            this.controlBox.Controls.Add(this.fileTransposeControl);
            this.controlBox.Controls.Add(this.playbackControl);
            this.controlBox.Location = new System.Drawing.Point(0, 0);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(1253, 309);
            this.controlBox.TabIndex = 0;
            this.controlBox.TabStop = false;
            // 
            // printingControl
            // 
            this.printingControl.AutoSize = true;
            this.printingControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.printingControl.Location = new System.Drawing.Point(1120, 3);
            this.printingControl.Name = "printingControl";
            this.printingControl.Size = new System.Drawing.Size(127, 195);
            this.printingControl.TabIndex = 5;
            // 
            // tuningControl
            // 
            this.tuningControl.AutoSize = true;
            this.tuningControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tuningControl.Location = new System.Drawing.Point(548, 3);
            this.tuningControl.Name = "tuningControl";
            this.tuningControl.Size = new System.Drawing.Size(566, 238);
            this.tuningControl.TabIndex = 4;
            // 
            // cutControl
            // 
            this.cutControl.AutoSize = true;
            this.cutControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cutControl.Location = new System.Drawing.Point(315, 193);
            this.cutControl.Name = "cutControl";
            this.cutControl.Size = new System.Drawing.Size(205, 97);
            this.cutControl.TabIndex = 3;
            // 
            // trackControl
            // 
            this.trackControl.AutoSize = true;
            this.trackControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trackControl.Location = new System.Drawing.Point(315, 3);
            this.trackControl.Name = "trackControl";
            this.trackControl.Size = new System.Drawing.Size(231, 179);
            this.trackControl.TabIndex = 2;
            // 
            // fileTransposeControl
            // 
            this.fileTransposeControl.AutoSize = true;
            this.fileTransposeControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileTransposeControl.Location = new System.Drawing.Point(6, 217);
            this.fileTransposeControl.Name = "fileTransposeControl";
            this.fileTransposeControl.Size = new System.Drawing.Size(161, 73);
            this.fileTransposeControl.TabIndex = 1;
            // 
            // playbackControl
            // 
            this.playbackControl.AutoSize = true;
            this.playbackControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playbackControl.Location = new System.Drawing.Point(6, 3);
            this.playbackControl.Name = "playbackControl";
            this.playbackControl.Size = new System.Drawing.Size(303, 208);
            this.playbackControl.TabIndex = 0;
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.controlBox);
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(1256, 312);
            this.controlBox.ResumeLayout(false);
            this.controlBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox controlBox;
        private PlaybackControl playbackControl;
        private FileTransposeControl fileTransposeControl;
        private PrintingControl printingControl;
        private TuningControl tuningControl;
        private CutControl cutControl;
        private TrackControl trackControl;
    }
}
