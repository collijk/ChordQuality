namespace ChordQuality.controls
{
    partial class FileTransposeControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.offsetValueLabel = new System.Windows.Forms.Label();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.fileTransposeUpDown = new System.Windows.Forms.NumericUpDown();
            this.fileTransposeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileTransposeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.offsetValueLabel);
            this.groupBox1.Controls.Add(this.offsetLabel);
            this.groupBox1.Controls.Add(this.fileTransposeUpDown);
            this.groupBox1.Controls.Add(this.fileTransposeLabel);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Transposition";
            // 
            // offsetValueLabel
            // 
            this.offsetValueLabel.AutoSize = true;
            this.offsetValueLabel.Location = new System.Drawing.Point(90, 46);
            this.offsetValueLabel.Name = "offsetValueLabel";
            this.offsetValueLabel.Size = new System.Drawing.Size(37, 13);
            this.offsetValueLabel.TabIndex = 3;
            this.offsetValueLabel.Text = "0 Bars";
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(80, 28);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(57, 13);
            this.offsetLabel.TabIndex = 2;
            this.offsetLabel.Text = "Bar Offset:";
            // 
            // fileTransposeUpDown
            // 
            this.fileTransposeUpDown.Enabled = false;
            this.fileTransposeUpDown.Location = new System.Drawing.Point(6, 44);
            this.fileTransposeUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.fileTransposeUpDown.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.fileTransposeUpDown.Name = "fileTransposeUpDown";
            this.fileTransposeUpDown.Size = new System.Drawing.Size(60, 20);
            this.fileTransposeUpDown.TabIndex = 1;
            this.fileTransposeUpDown.ValueChanged += new System.EventHandler(this.fileTransposeUpDown_ValueChanged);
            // 
            // fileTransposeLabel
            // 
            this.fileTransposeLabel.AutoSize = true;
            this.fileTransposeLabel.Location = new System.Drawing.Point(3, 28);
            this.fileTransposeLabel.Name = "fileTransposeLabel";
            this.fileTransposeLabel.Size = new System.Drawing.Size(60, 13);
            this.fileTransposeLabel.TabIndex = 0;
            this.fileTransposeLabel.Text = "Transpose:";
            // 
            // FileTransposeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox1);
            this.Name = "FileTransposeControl";
            this.Size = new System.Drawing.Size(161, 73);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileTransposeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label fileTransposeLabel;
        private System.Windows.Forms.NumericUpDown fileTransposeUpDown;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.Label offsetValueLabel;
    }
}
