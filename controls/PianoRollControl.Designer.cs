namespace ChordQuality.controls
{
    partial class PianoRollControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PianoRollControl));
            this.pianoRollLayout = new System.Windows.Forms.GroupBox();
            this.noteDisplay1 = new ChordQuality.views.NoteDisplay();
            this.chordDisplay1 = new ChordQuality.views.ChordDisplay();
            this.chordNameDisplay1 = new ChordQuality.views.ChordNameDisplay();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.pianoRollLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chordNameDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // pianoRollLayout
            // 
            this.pianoRollLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pianoRollLayout.Controls.Add(this.hScrollBar1);
            this.pianoRollLayout.Controls.Add(this.chordNameDisplay1);
            this.pianoRollLayout.Controls.Add(this.chordDisplay1);
            this.pianoRollLayout.Controls.Add(this.noteDisplay1);
            this.pianoRollLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pianoRollLayout.Location = new System.Drawing.Point(0, 0);
            this.pianoRollLayout.Name = "pianoRollLayout";
            this.pianoRollLayout.Size = new System.Drawing.Size(1055, 176);
            this.pianoRollLayout.TabIndex = 0;
            this.pianoRollLayout.TabStop = false;
            // 
            // noteDisplay1
            // 
            this.noteDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.noteDisplay1.DataModel = null;
            this.noteDisplay1.DisplayModel = null;
            this.noteDisplay1.Image = ((System.Drawing.Image)(resources.GetObject("noteDisplay1.Image")));
            this.noteDisplay1.Location = new System.Drawing.Point(3, 5);
            this.noteDisplay1.Name = "noteDisplay1";
            this.noteDisplay1.Size = new System.Drawing.Size(1049, 50);
            this.noteDisplay1.TabIndex = 0;
            this.noteDisplay1.TabStop = false;
            // 
            // chordDisplay1
            // 
            this.chordDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chordDisplay1.DataModel = null;
            this.chordDisplay1.DisplayModel = null;
            this.chordDisplay1.Image = ((System.Drawing.Image)(resources.GetObject("chordDisplay1.Image")));
            this.chordDisplay1.Location = new System.Drawing.Point(3, 61);
            this.chordDisplay1.Name = "chordDisplay1";
            this.chordDisplay1.QualityModel = null;
            this.chordDisplay1.Size = new System.Drawing.Size(1049, 50);
            this.chordDisplay1.TabIndex = 1;
            this.chordDisplay1.TabStop = false;
            this.chordDisplay1.TuningModel = null;
            // 
            // chordNameDisplay1
            // 
            this.chordNameDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chordNameDisplay1.DataModel = null;
            this.chordNameDisplay1.DisplayModel = null;
            this.chordNameDisplay1.Image = ((System.Drawing.Image)(resources.GetObject("chordNameDisplay1.Image")));
            this.chordNameDisplay1.Location = new System.Drawing.Point(3, 117);
            this.chordNameDisplay1.Name = "chordNameDisplay1";
            this.chordNameDisplay1.QualityModel = null;
            this.chordNameDisplay1.Size = new System.Drawing.Size(1049, 36);
            this.chordNameDisplay1.TabIndex = 1;
            this.chordNameDisplay1.TabStop = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(3, 156);
            this.hScrollBar1.Maximum = 1;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1049, 17);
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Value = 1;
            // 
            // PianoRollControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pianoRollLayout);
            this.Name = "PianoRollControl";
            this.Size = new System.Drawing.Size(1055, 176);
            this.pianoRollLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noteDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chordNameDisplay1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox pianoRollLayout;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private views.ChordNameDisplay chordNameDisplay1;
        private views.ChordDisplay chordDisplay1;
        private views.NoteDisplay noteDisplay1;
    }
}
