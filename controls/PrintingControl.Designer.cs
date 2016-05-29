namespace ChordQuality.controls
{
    partial class PrintingControl
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
            this.printLayoutBox = new System.Windows.Forms.GroupBox();
            this.pagesLabel = new System.Windows.Forms.Label();
            this.barsPerPageLabel = new System.Windows.Forms.Label();
            this.applyPrintSettingsButton = new System.Windows.Forms.Button();
            this.relativeThicknessTextBox = new System.Windows.Forms.TextBox();
            this.rowsPerPageTextBox = new System.Windows.Forms.TextBox();
            this.barsPerRowTextBox = new System.Windows.Forms.TextBox();
            this.relativeThicknessLabel = new System.Windows.Forms.Label();
            this.rowsPerPageLabel = new System.Windows.Forms.Label();
            this.barsPerRowLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.printLayoutBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // printLayoutBox
            // 
            this.printLayoutBox.AutoSize = true;
            this.printLayoutBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.printLayoutBox.Controls.Add(this.textBox2);
            this.printLayoutBox.Controls.Add(this.textBox1);
            this.printLayoutBox.Controls.Add(this.pagesLabel);
            this.printLayoutBox.Controls.Add(this.barsPerPageLabel);
            this.printLayoutBox.Controls.Add(this.applyPrintSettingsButton);
            this.printLayoutBox.Controls.Add(this.relativeThicknessTextBox);
            this.printLayoutBox.Controls.Add(this.rowsPerPageTextBox);
            this.printLayoutBox.Controls.Add(this.barsPerRowTextBox);
            this.printLayoutBox.Controls.Add(this.relativeThicknessLabel);
            this.printLayoutBox.Controls.Add(this.rowsPerPageLabel);
            this.printLayoutBox.Controls.Add(this.barsPerRowLabel);
            this.printLayoutBox.Location = new System.Drawing.Point(0, 0);
            this.printLayoutBox.Margin = new System.Windows.Forms.Padding(5);
            this.printLayoutBox.Name = "printLayoutBox";
            this.printLayoutBox.Padding = new System.Windows.Forms.Padding(5);
            this.printLayoutBox.Size = new System.Drawing.Size(122, 190);
            this.printLayoutBox.TabIndex = 0;
            this.printLayoutBox.TabStop = false;
            this.printLayoutBox.Text = "Printing Layout";
            // 
            // pagesLabel
            // 
            this.pagesLabel.AutoSize = true;
            this.pagesLabel.Location = new System.Drawing.Point(10, 153);
            this.pagesLabel.Margin = new System.Windows.Forms.Padding(5);
            this.pagesLabel.Name = "pagesLabel";
            this.pagesLabel.Size = new System.Drawing.Size(40, 13);
            this.pagesLabel.TabIndex = 8;
            this.pagesLabel.Text = "Pages:";
            // 
            // barsPerPageLabel
            // 
            this.barsPerPageLabel.AutoSize = true;
            this.barsPerPageLabel.Location = new System.Drawing.Point(10, 130);
            this.barsPerPageLabel.Margin = new System.Windows.Forms.Padding(5);
            this.barsPerPageLabel.Name = "barsPerPageLabel";
            this.barsPerPageLabel.Size = new System.Drawing.Size(61, 13);
            this.barsPerPageLabel.TabIndex = 7;
            this.barsPerPageLabel.Text = "Bars/Page:";
            // 
            // applyPrintSettingsButton
            // 
            this.applyPrintSettingsButton.Location = new System.Drawing.Point(13, 92);
            this.applyPrintSettingsButton.Name = "applyPrintSettingsButton";
            this.applyPrintSettingsButton.Size = new System.Drawing.Size(101, 23);
            this.applyPrintSettingsButton.TabIndex = 6;
            this.applyPrintSettingsButton.Text = "Apply Settings";
            this.applyPrintSettingsButton.UseVisualStyleBackColor = true;
            // 
            // relativeThicknessTextBox
            // 
            this.relativeThicknessTextBox.Location = new System.Drawing.Point(85, 66);
            this.relativeThicknessTextBox.Name = "relativeThicknessTextBox";
            this.relativeThicknessTextBox.Size = new System.Drawing.Size(29, 20);
            this.relativeThicknessTextBox.TabIndex = 5;
            this.relativeThicknessTextBox.Text = "0.5";
            this.relativeThicknessTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rowsPerPageTextBox
            // 
            this.rowsPerPageTextBox.Location = new System.Drawing.Point(85, 43);
            this.rowsPerPageTextBox.Name = "rowsPerPageTextBox";
            this.rowsPerPageTextBox.Size = new System.Drawing.Size(29, 20);
            this.rowsPerPageTextBox.TabIndex = 4;
            this.rowsPerPageTextBox.Text = "3";
            this.rowsPerPageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // barsPerRowTextBox
            // 
            this.barsPerRowTextBox.Location = new System.Drawing.Point(85, 20);
            this.barsPerRowTextBox.Name = "barsPerRowTextBox";
            this.barsPerRowTextBox.Size = new System.Drawing.Size(29, 20);
            this.barsPerRowTextBox.TabIndex = 3;
            this.barsPerRowTextBox.Text = "13";
            this.barsPerRowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // relativeThicknessLabel
            // 
            this.relativeThicknessLabel.AutoSize = true;
            this.relativeThicknessLabel.Location = new System.Drawing.Point(10, 69);
            this.relativeThicknessLabel.Margin = new System.Windows.Forms.Padding(5);
            this.relativeThicknessLabel.Name = "relativeThicknessLabel";
            this.relativeThicknessLabel.Size = new System.Drawing.Size(62, 13);
            this.relativeThicknessLabel.TabIndex = 2;
            this.relativeThicknessLabel.Text = "Rel. Thick.:";
            // 
            // rowsPerPageLabel
            // 
            this.rowsPerPageLabel.AutoSize = true;
            this.rowsPerPageLabel.Location = new System.Drawing.Point(10, 46);
            this.rowsPerPageLabel.Margin = new System.Windows.Forms.Padding(5);
            this.rowsPerPageLabel.Name = "rowsPerPageLabel";
            this.rowsPerPageLabel.Size = new System.Drawing.Size(67, 13);
            this.rowsPerPageLabel.TabIndex = 1;
            this.rowsPerPageLabel.Text = "Rows/Page:";
            // 
            // barsPerRowLabel
            // 
            this.barsPerRowLabel.AutoSize = true;
            this.barsPerRowLabel.Location = new System.Drawing.Point(10, 23);
            this.barsPerRowLabel.Margin = new System.Windows.Forms.Padding(5);
            this.barsPerRowLabel.Name = "barsPerRowLabel";
            this.barsPerRowLabel.Size = new System.Drawing.Size(58, 13);
            this.barsPerRowLabel.TabIndex = 0;
            this.barsPerRowLabel.Text = "Bars/Row:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "75";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 149);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PrintingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.printLayoutBox);
            this.Name = "PrintingControl";
            this.Size = new System.Drawing.Size(127, 195);
            this.printLayoutBox.ResumeLayout(false);
            this.printLayoutBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox printLayoutBox;
        private System.Windows.Forms.Label relativeThicknessLabel;
        private System.Windows.Forms.Label rowsPerPageLabel;
        private System.Windows.Forms.Label barsPerRowLabel;
        private System.Windows.Forms.TextBox relativeThicknessTextBox;
        private System.Windows.Forms.TextBox rowsPerPageTextBox;
        private System.Windows.Forms.TextBox barsPerRowTextBox;
        private System.Windows.Forms.Button applyPrintSettingsButton;
        private System.Windows.Forms.Label pagesLabel;
        private System.Windows.Forms.Label barsPerPageLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
