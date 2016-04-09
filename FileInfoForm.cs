/*
 * Created by SharpDevelop.
 * User: janus
 * Date: 04.08.2005
 * Time: 20:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using Janus.ManagedMIDI;

namespace ChordQuality
{
	/// <summary>
	/// Description of FileInfoForm.
	/// </summary>
	public class FileInfoForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox textBox9;
		
		public FileInfoForm(MidiFile _f)
		{
			f=_f;
			
			InitializeComponent();
			
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(280, 7);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(80, 20);
            this.textBox9.TabIndex = 83;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(104, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 15);
            this.label21.TabIndex = 80;
            this.label21.Text = "octaves:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(152, 52);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(32, 20);
            this.textBox6.TabIndex = 81;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(152, 30);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(32, 20);
            this.textBox7.TabIndex = 71;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(152, 7);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(32, 20);
            this.textBox4.TabIndex = 70;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(48, 7);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(40, 20);
            this.textBox5.TabIndex = 69;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(48, 30);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(40, 20);
            this.textBox8.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(112, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 76;
            this.label4.Text = "tracks:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 77;
            this.label5.Text = "timing:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(120, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 78;
            this.label6.Text = "bars:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 79;
            this.label7.Text = "tempo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(200, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 15);
            this.label11.TabIndex = 85;
            this.label11.Text = "time signature:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(200, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 15);
            this.label10.TabIndex = 82;
            this.label10.Text = "key signature:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(280, 30);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(80, 20);
            this.textBox10.TabIndex = 84;
            // 
            // FileInfoForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(368, 86);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Info";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FileInfoFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
		MidiFile f;
		
		void FileInfoFormLoad(object sender, System.EventArgs e)
		{
			textBox4.Text=f.tracks.Length.ToString();
			textBox5.Text=f.timing.ToString();
			textBox6.Text=((f.max_note-f.min_note)/12).ToString();
			textBox7.Text=f.bars.ToString();
			textBox8.Text=Math.Round(f.tempo,2).ToString();
			if (f.key_sig!=null) textBox9.Text=f.key_sig.ValueString();
			else textBox9.Text="";
			if (f.time_sig!=null) textBox10.Text=f.time_sig.ValueString();
			else textBox10.Text="";
		}

        private void label11_Click(object sender, EventArgs e)
        {

        }
		
	}
}
