namespace ChordQuality.controls
{
    partial class CutControl
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
            this.cutBox = new System.Windows.Forms.GroupBox();
            this.displayClearButton = new System.Windows.Forms.Button();
            this.markerResetButton = new System.Windows.Forms.Button();
            this.cutButton = new System.Windows.Forms.Button();
            this.cutBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cutBox
            // 
            this.cutBox.AutoSize = true;
            this.cutBox.Controls.Add(this.displayClearButton);
            this.cutBox.Controls.Add(this.markerResetButton);
            this.cutBox.Controls.Add(this.cutButton);
            this.cutBox.Location = new System.Drawing.Point(0, 0);
            this.cutBox.Name = "cutBox";
            this.cutBox.Size = new System.Drawing.Size(202, 94);
            this.cutBox.TabIndex = 0;
            this.cutBox.TabStop = false;
            this.cutBox.Text = "Cut Controls";
            // 
            // displayClearButton
            // 
            this.displayClearButton.Location = new System.Drawing.Point(138, 32);
            this.displayClearButton.Name = "displayClearButton";
            this.displayClearButton.Size = new System.Drawing.Size(58, 40);
            this.displayClearButton.TabIndex = 2;
            this.displayClearButton.Text = "Clear Display";
            this.displayClearButton.UseVisualStyleBackColor = true;
            // 
            // markerResetButton
            // 
            this.markerResetButton.Location = new System.Drawing.Point(74, 32);
            this.markerResetButton.Name = "markerResetButton";
            this.markerResetButton.Size = new System.Drawing.Size(58, 40);
            this.markerResetButton.TabIndex = 1;
            this.markerResetButton.Text = "Reset Markers";
            this.markerResetButton.UseVisualStyleBackColor = true;
            // 
            // cutButton
            // 
            this.cutButton.Location = new System.Drawing.Point(13, 32);
            this.cutButton.Name = "cutButton";
            this.cutButton.Size = new System.Drawing.Size(55, 43);
            this.cutButton.TabIndex = 0;
            this.cutButton.Text = "Cut";
            this.cutButton.UseVisualStyleBackColor = true;
            // 
            // CutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.cutBox);
            this.Name = "CutControl";
            this.Size = new System.Drawing.Size(205, 97);
            this.cutBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox cutBox;
        private System.Windows.Forms.Button displayClearButton;
        private System.Windows.Forms.Button cutButton;
        private System.Windows.Forms.Button markerResetButton;
    }
}
