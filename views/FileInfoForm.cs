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
using System.Globalization;
using System.Windows.Forms;
using Janus.ManagedMIDI;

namespace ChordQuality.views
{
    /// <summary>
    ///     Description of FileInfoForm.
    /// </summary>
    public class FileInfoForm : Form
    {
        private readonly MidiFile _file;
        private Label _label10;
        private Label _label11;
        private Label _label21;
        private Label _label4;
        private Label _label5;
        private Label _label6;
        private Label _label7;
        private TextBox _textBox10;
        private TextBox _textBox4;
        private TextBox _textBox5;
        private TextBox _textBox6;
        private TextBox _textBox7;
        private TextBox _textBox8;
        private TextBox _textBox9;

        public FileInfoForm(MidiFile file)
        {
            _file = file;

            InitializeComponent();
        }

        #region Windows Forms Designer generated code

        /// <summary>
        ///     This method is required for Windows Forms designer support.
        ///     Do not change the method contents inside the source code editor. The Forms designer might
        ///     not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            _textBox9 = new TextBox();
            _label21 = new Label();
            _textBox6 = new TextBox();
            _textBox7 = new TextBox();
            _textBox4 = new TextBox();
            _textBox5 = new TextBox();
            _textBox8 = new TextBox();
            _label4 = new Label();
            _label5 = new Label();
            _label6 = new Label();
            _label7 = new Label();
            _label11 = new Label();
            _label10 = new Label();
            _textBox10 = new TextBox();
            SuspendLayout();
            // 
            // textBox9
            // 
            _textBox9.Location = new Point(280, 7);
            _textBox9.Name = "_textBox9";
            _textBox9.ReadOnly = true;
            _textBox9.Size = new Size(80, 20);
            _textBox9.TabIndex = 83;
            // 
            // label21
            // 
            _label21.Location = new Point(104, 52);
            _label21.Name = "_label21";
            _label21.Size = new Size(48, 15);
            _label21.TabIndex = 80;
            _label21.Text = @"octaves:";
            _label21.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            _textBox6.Location = new Point(152, 52);
            _textBox6.Name = "_textBox6";
            _textBox6.ReadOnly = true;
            _textBox6.Size = new Size(32, 20);
            _textBox6.TabIndex = 81;
            // 
            // textBox7
            // 
            _textBox7.Location = new Point(152, 30);
            _textBox7.Name = "_textBox7";
            _textBox7.ReadOnly = true;
            _textBox7.Size = new Size(32, 20);
            _textBox7.TabIndex = 71;
            // 
            // textBox4
            // 
            _textBox4.Location = new Point(152, 7);
            _textBox4.Name = "_textBox4";
            _textBox4.ReadOnly = true;
            _textBox4.Size = new Size(32, 20);
            _textBox4.TabIndex = 70;
            // 
            // textBox5
            // 
            _textBox5.Location = new Point(48, 7);
            _textBox5.Name = "_textBox5";
            _textBox5.ReadOnly = true;
            _textBox5.Size = new Size(40, 20);
            _textBox5.TabIndex = 69;
            // 
            // textBox8
            // 
            _textBox8.Location = new Point(48, 30);
            _textBox8.Name = "_textBox8";
            _textBox8.ReadOnly = true;
            _textBox8.Size = new Size(40, 20);
            _textBox8.TabIndex = 72;
            // 
            // label4
            // 
            _label4.Location = new Point(112, 7);
            _label4.Name = "_label4";
            _label4.Size = new Size(40, 15);
            _label4.TabIndex = 76;
            _label4.Text = @"tracks:";
            _label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            _label5.Location = new Point(8, 7);
            _label5.Name = "_label5";
            _label5.Size = new Size(40, 15);
            _label5.TabIndex = 77;
            _label5.Text = @"timing:";
            _label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            _label6.Location = new Point(120, 30);
            _label6.Name = "_label6";
            _label6.Size = new Size(32, 15);
            _label6.TabIndex = 78;
            _label6.Text = @"bars:";
            _label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            _label7.Location = new Point(8, 30);
            _label7.Name = "_label7";
            _label7.Size = new Size(40, 15);
            _label7.TabIndex = 79;
            _label7.Text = @"tempo:";
            _label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            _label11.Location = new Point(200, 30);
            _label11.Name = "_label11";
            _label11.Size = new Size(80, 15);
            _label11.TabIndex = 85;
            _label11.Text = @"time signature:";
            _label11.TextAlign = ContentAlignment.MiddleRight;
            _label11.Click += label11_Click;
            // 
            // label10
            // 
            _label10.Location = new Point(200, 7);
            _label10.Name = "_label10";
            _label10.Size = new Size(80, 15);
            _label10.TabIndex = 82;
            _label10.Text = @"key signature:";
            _label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox10
            // 
            _textBox10.Location = new Point(280, 30);
            _textBox10.Name = "_textBox10";
            _textBox10.ReadOnly = true;
            _textBox10.Size = new Size(80, 20);
            _textBox10.TabIndex = 84;
            // 
            // FileInfoForm
            // 
            AutoScaleBaseSize = new Size(5, 13);
            ClientSize = new Size(368, 86);
            Controls.Add(_label11);
            Controls.Add(_textBox10);
            Controls.Add(_textBox9);
            Controls.Add(_label10);
            Controls.Add(_textBox6);
            Controls.Add(_label21);
            Controls.Add(_textBox8);
            Controls.Add(_label7);
            Controls.Add(_textBox7);
            Controls.Add(_label6);
            Controls.Add(_textBox5);
            Controls.Add(_label5);
            Controls.Add(_label4);
            Controls.Add(_textBox4);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FileInfoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = @"File Info";
            TopMost = true;
            Load += FileInfoFormLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void FileInfoFormLoad(object sender, EventArgs e)
        {
            _textBox4.Text = _file.tracks.Length.ToString();
            _textBox5.Text = _file.timing.ToString();
            _textBox6.Text = ((_file.max_note - _file.min_note)/12).ToString();
            _textBox7.Text = _file.bars.ToString();
            _textBox8.Text = Math.Round(_file.tempo, 2).ToString(CultureInfo.CurrentCulture);
            _textBox9.Text = _file.key_sig == null ? "" : _file.key_sig.ValueString();
            _textBox10.Text = _file.time_sig != null ? _file.time_sig.ValueString() : "";
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }
    }
}