using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Janus.ManagedMIDI;
using Janus.Misc;
using ChordQuality.Services;
using ChordQuality.events.messages;
using ChordQuality.events;
using ChordQuality.services;

namespace ChordQuality
{
    public class MainForm : Form
    {
        private System.ComponentModel.IContainer components;
        private GroupBox layoutBox;
        private GroupBox chordBox;
        private ContextMenu contextMenu1;
        private Button applyButton;
        private GroupBox qualityBox;
        private Label label12;
        private Label label16;
        private GroupBox tuningBox;
        private TextBox barsPerPageBox;
        private VScrollBar weightScroll4;
        private VScrollBar weightScroll5;
        private PrintPreviewControl printPreviewDialog1;
        private VScrollBar penaltyScrollAdd;
        private Timer timer1;
        private Panel tuningPanel;
        private DomainUpDown thresholdUpDown;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label13;
        private Label label7;
        private Label label6;
        private Label label5;
        private Panel trackPanel;
        private Label label14;
        private Label label15;
        private Label label9;
        private Label label8;
        private ToolTip toolTip1;
        private VScrollBar penaltyScrollShort;
        private GroupBox penaltyBox;
        private VScrollBar weightScroll6min;
        private CheckBox labelCheck;
        private PictureBox chordNameDisplay;
        private VScrollBar weightScroll3Maj;
        private Panel cursor;
        private TextBox barsEdit;
        private PictureBox noteDisplay;
        private ColorDialog colorDialog1;
        private Panel panel2;
        private Panel panel1;
        private NumericUpDown transposeTuningUpDown;
        private VScrollBar weightScroll3min;
        private MenuItem menuItem1;
        private TextBox rowsEdit;
        private HScrollBar offsetScroll;
        private Label label4;
        private CheckBox qualityCheck;
        private VScrollBar weightScrollCh3;
        private Label label20;
        private Label label22;
        private VScrollBar weightScrollCh5;
        private TextBox pagesBox;
        private GroupBox intervalBox;
        private PictureBox chordDisplay;
        private VScrollBar zoomScroll;
        private VScrollBar weightScroll6Maj;
        private TransparentPanel hoverBar;
        private TransparentPanel cutBarFirst;
        private TransparentPanel cutBarSecond;
        private GroupBox groupBox1;
        private Button cutCutBtn;
        private Button cutResetBtn;
        private Panel cutPanel;
        private Button cutClrBtn;
        private Panel cutRowCursor;
        private float rf;
        private IEventAggregator eventAggregator;
        private ISubscription<PlayMessage> playSubscription;
        private ISubscription<PauseMessage> pauseSubscription;
        private ISubscription<StopMessage> stopSubscription;
        private ISubscription<FileOpenedMessage> midiFileSubscription;
        private ISubscription<MidiPlayerUpdatedMessage> midiPlayerSubscription;
        private ISubscription<FileTransposedMessage> fileTransposeSubscription;
        private ISubscription<CloseRequestMessage> closeRequestSubscription;
        private ISubscription<MarkersChangedMessage> markersChangedSubscription;
        private ISubscription<FindBestTuningsMessage> bestTuningsSubscription;
        private controls.FileTransposeControl fileTransposeControl1;
        private PlaybackControl playbackControl;
        private PianoRollArtist artist;
        private controls.MainMenuControl mainMenuControl1;
        private PrintDocumentProvider printDocProvider;



        public MainForm()
        {
            
            InitializeComponent();            
            

        }



        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new MainForm());
        }

        #region Windows Forms Designer generated code
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.weightScroll6Maj = new System.Windows.Forms.VScrollBar();
            this.zoomScroll = new System.Windows.Forms.VScrollBar();
            this.chordDisplay = new System.Windows.Forms.PictureBox();
            this.intervalBox = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.weightScroll6min = new System.Windows.Forms.VScrollBar();
            this.weightScroll3min = new System.Windows.Forms.VScrollBar();
            this.weightScroll3Maj = new System.Windows.Forms.VScrollBar();
            this.weightScroll4 = new System.Windows.Forms.VScrollBar();
            this.weightScroll5 = new System.Windows.Forms.VScrollBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pagesBox = new System.Windows.Forms.TextBox();
            this.weightScrollCh5 = new System.Windows.Forms.VScrollBar();
            this.label20 = new System.Windows.Forms.Label();
            this.weightScrollCh3 = new System.Windows.Forms.VScrollBar();
            this.qualityCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.offsetScroll = new System.Windows.Forms.HScrollBar();
            this.rowsEdit = new System.Windows.Forms.TextBox();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.transposeTuningUpDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileTransposeControl1 = new ChordQuality.controls.FileTransposeControl();
            this.playbackControl = new ChordQuality.PlaybackControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cutClrBtn = new System.Windows.Forms.Button();
            this.cutCutBtn = new System.Windows.Forms.Button();
            this.cutResetBtn = new System.Windows.Forms.Button();
            this.layoutBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.factor = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.barsPerPageBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.barsEdit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.penaltyBox = new System.Windows.Forms.GroupBox();
            this.thresholdUpDown = new System.Windows.Forms.DomainUpDown();
            this.penaltyScrollShort = new System.Windows.Forms.VScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.penaltyScrollAdd = new System.Windows.Forms.VScrollBar();
            this.tuningBox = new System.Windows.Forms.GroupBox();
            this.labelCheck = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tuningPanel = new System.Windows.Forms.Panel();
            this.qualityBox = new System.Windows.Forms.GroupBox();
            this.chordBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cutPanel = new System.Windows.Forms.Panel();
            this.cutBarSecond = new ChordQuality.TransparentPanel();
            this.cutBarFirst = new ChordQuality.TransparentPanel();
            this.chordNameDisplay = new System.Windows.Forms.PictureBox();
            this.cursor = new System.Windows.Forms.Panel();
            this.hoverBar = new ChordQuality.TransparentPanel();
            this.noteDisplay = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewControl();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cutRowCursor = new System.Windows.Forms.Panel();
            this.mainMenuControl1 = new ChordQuality.controls.MainMenuControl();
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay)).BeginInit();
            this.intervalBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transposeTuningUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.layoutBox.SuspendLayout();
            this.penaltyBox.SuspendLayout();
            this.tuningBox.SuspendLayout();
            this.qualityBox.SuspendLayout();
            this.chordBox.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chordNameDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // weightScroll6Maj
            // 
            this.weightScroll6Maj.LargeChange = 1;
            this.weightScroll6Maj.Location = new System.Drawing.Point(8, 12);
            this.weightScroll6Maj.Maximum = 20;
            this.weightScroll6Maj.Name = "weightScroll6Maj";
            this.weightScroll6Maj.Size = new System.Drawing.Size(16, 72);
            this.weightScroll6Maj.TabIndex = 24;
            this.weightScroll6Maj.Value = 10;
            this.weightScroll6Maj.ValueChanged += new System.EventHandler(this.WeightScroll6MajValueChanged);
            // 
            // zoomScroll
            // 
            this.zoomScroll.LargeChange = 1;
            this.zoomScroll.Location = new System.Drawing.Point(968, 6);
            this.zoomScroll.Maximum = 60;
            this.zoomScroll.Minimum = 1;
            this.zoomScroll.Name = "zoomScroll";
            this.zoomScroll.Size = new System.Drawing.Size(16, 114);
            this.zoomScroll.TabIndex = 44;
            this.zoomScroll.Value = 15;
            this.zoomScroll.ValueChanged += new System.EventHandler(this.ZoomScrollValueChanged);
            // 
            // chordDisplay
            // 
            this.chordDisplay.BackColor = System.Drawing.Color.White;
            this.chordDisplay.Location = new System.Drawing.Point(8, 56);
            this.chordDisplay.Name = "chordDisplay";
            this.chordDisplay.Size = new System.Drawing.Size(960, 48);
            this.chordDisplay.TabIndex = 42;
            this.chordDisplay.TabStop = false;
            this.chordDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChordDisplayMouseMove);
            // 
            // intervalBox
            // 
            this.intervalBox.Controls.Add(this.label22);
            this.intervalBox.Controls.Add(this.label16);
            this.intervalBox.Controls.Add(this.weightScroll6min);
            this.intervalBox.Controls.Add(this.weightScroll6Maj);
            this.intervalBox.Controls.Add(this.weightScroll3min);
            this.intervalBox.Controls.Add(this.weightScroll3Maj);
            this.intervalBox.Controls.Add(this.weightScroll4);
            this.intervalBox.Controls.Add(this.weightScroll5);
            this.intervalBox.Controls.Add(this.label15);
            this.intervalBox.Controls.Add(this.label14);
            this.intervalBox.Controls.Add(this.label13);
            this.intervalBox.Controls.Add(this.label12);
            this.intervalBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.intervalBox.Location = new System.Drawing.Point(8, 12);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(120, 110);
            this.intervalBox.TabIndex = 16;
            this.intervalBox.TabStop = false;
            this.intervalBox.Text = "Intervals";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(24, 84);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 22);
            this.label22.TabIndex = 27;
            this.label22.Text = "6 m";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 22);
            this.label16.TabIndex = 26;
            this.label16.Text = "6 M";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // weightScroll6min
            // 
            this.weightScroll6min.LargeChange = 1;
            this.weightScroll6min.Location = new System.Drawing.Point(24, 12);
            this.weightScroll6min.Maximum = 20;
            this.weightScroll6min.Name = "weightScroll6min";
            this.weightScroll6min.Size = new System.Drawing.Size(16, 72);
            this.weightScroll6min.TabIndex = 25;
            this.weightScroll6min.Value = 10;
            this.weightScroll6min.ValueChanged += new System.EventHandler(this.WeightScroll6minValueChanged);
            // 
            // weightScroll3min
            // 
            this.weightScroll3min.LargeChange = 1;
            this.weightScroll3min.Location = new System.Drawing.Point(88, 12);
            this.weightScroll3min.Maximum = 20;
            this.weightScroll3min.Name = "weightScroll3min";
            this.weightScroll3min.Size = new System.Drawing.Size(16, 72);
            this.weightScroll3min.TabIndex = 23;
            this.weightScroll3min.Value = 10;
            this.weightScroll3min.ValueChanged += new System.EventHandler(this.WeightScroll3minValueChanged);
            // 
            // weightScroll3Maj
            // 
            this.weightScroll3Maj.LargeChange = 1;
            this.weightScroll3Maj.Location = new System.Drawing.Point(72, 12);
            this.weightScroll3Maj.Maximum = 20;
            this.weightScroll3Maj.Name = "weightScroll3Maj";
            this.weightScroll3Maj.Size = new System.Drawing.Size(16, 72);
            this.weightScroll3Maj.TabIndex = 22;
            this.weightScroll3Maj.Value = 10;
            this.weightScroll3Maj.ValueChanged += new System.EventHandler(this.WeightScroll3MajValueChanged);
            // 
            // weightScroll4
            // 
            this.weightScroll4.LargeChange = 1;
            this.weightScroll4.Location = new System.Drawing.Point(56, 12);
            this.weightScroll4.Maximum = 20;
            this.weightScroll4.Name = "weightScroll4";
            this.weightScroll4.Size = new System.Drawing.Size(16, 72);
            this.weightScroll4.TabIndex = 21;
            this.weightScroll4.Value = 10;
            this.weightScroll4.ValueChanged += new System.EventHandler(this.WeightScroll4ValueChanged);
            // 
            // weightScroll5
            // 
            this.weightScroll5.LargeChange = 1;
            this.weightScroll5.Location = new System.Drawing.Point(40, 12);
            this.weightScroll5.Maximum = 20;
            this.weightScroll5.Name = "weightScroll5";
            this.weightScroll5.Size = new System.Drawing.Size(16, 72);
            this.weightScroll5.TabIndex = 20;
            this.weightScroll5.Value = 10;
            this.weightScroll5.ValueChanged += new System.EventHandler(this.WeightScroll5ValueChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(56, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 17);
            this.label15.TabIndex = 19;
            this.label15.Text = "4";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(88, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 22);
            this.label14.TabIndex = 18;
            this.label14.Text = "3 m";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(72, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 22);
            this.label13.TabIndex = 17;
            this.label13.Text = "3 M";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(40, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "5";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pagesBox
            // 
            this.pagesBox.Location = new System.Drawing.Point(88, 127);
            this.pagesBox.Name = "pagesBox";
            this.pagesBox.ReadOnly = true;
            this.pagesBox.Size = new System.Drawing.Size(32, 20);
            this.pagesBox.TabIndex = 7;
            this.pagesBox.Text = "0";
            // 
            // weightScrollCh5
            // 
            this.weightScrollCh5.LargeChange = 1;
            this.weightScrollCh5.Location = new System.Drawing.Point(8, 12);
            this.weightScrollCh5.Maximum = 20;
            this.weightScrollCh5.Name = "weightScrollCh5";
            this.weightScrollCh5.Size = new System.Drawing.Size(16, 72);
            this.weightScrollCh5.TabIndex = 0;
            this.weightScrollCh5.Value = 10;
            this.weightScrollCh5.ValueChanged += new System.EventHandler(this.WeightScrollCh5ValueChanged);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(309, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 12);
            this.label20.TabIndex = 48;
            this.label20.Text = "Tracks:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // weightScrollCh3
            // 
            this.weightScrollCh3.LargeChange = 1;
            this.weightScrollCh3.Location = new System.Drawing.Point(24, 12);
            this.weightScrollCh3.Maximum = 20;
            this.weightScrollCh3.Name = "weightScrollCh3";
            this.weightScrollCh3.Size = new System.Drawing.Size(16, 72);
            this.weightScrollCh3.TabIndex = 1;
            this.weightScrollCh3.Value = 10;
            this.weightScrollCh3.ValueChanged += new System.EventHandler(this.WeightScrollCh3ValueChanged);
            // 
            // qualityCheck
            // 
            this.qualityCheck.Checked = true;
            this.qualityCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.qualityCheck.Location = new System.Drawing.Point(104, 130);
            this.qualityCheck.Name = "qualityCheck";
            this.qualityCheck.Size = new System.Drawing.Size(90, 21);
            this.qualityCheck.TabIndex = 50;
            this.qualityCheck.Text = "Show Quality";
            this.qualityCheck.CheckedChanged += new System.EventHandler(this.QualityCheckCheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.label4.Location = new System.Drawing.Point(32, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "short";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offsetScroll
            // 
            this.offsetScroll.LargeChange = 1;
            this.offsetScroll.Location = new System.Drawing.Point(8, 125);
            this.offsetScroll.Maximum = 0;
            this.offsetScroll.Name = "offsetScroll";
            this.offsetScroll.Size = new System.Drawing.Size(960, 12);
            this.offsetScroll.TabIndex = 41;
            this.offsetScroll.ValueChanged += new System.EventHandler(this.OffsetScrollValueChanged);
            // 
            // rowsEdit
            // 
            this.rowsEdit.Location = new System.Drawing.Point(88, 30);
            this.rowsEdit.Name = "rowsEdit";
            this.rowsEdit.Size = new System.Drawing.Size(32, 20);
            this.rowsEdit.TabIndex = 3;
            this.rowsEdit.Text = "3";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Color...";
            this.menuItem1.Click += new System.EventHandler(this.MenuItem1Click);
            // 
            // transposeTuningUpDown
            // 
            this.transposeTuningUpDown.Location = new System.Drawing.Point(28, 148);
            this.transposeTuningUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.transposeTuningUpDown.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.transposeTuningUpDown.Name = "transposeTuningUpDown";
            this.transposeTuningUpDown.Size = new System.Drawing.Size(40, 20);
            this.transposeTuningUpDown.TabIndex = 47;
            this.transposeTuningUpDown.ValueChanged += new System.EventHandler(this.TransposeTuningUpDownValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.fileTransposeControl1);
            this.panel1.Controls.Add(this.penaltyBox);
            this.panel1.Controls.Add(this.playbackControl);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.layoutBox);
            this.panel1.Controls.Add(this.tuningBox);
            this.panel1.Controls.Add(this.qualityBox);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.trackPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 287);
            this.panel1.TabIndex = 45;
            // 
            // fileTransposeControl1
            // 
            this.fileTransposeControl1.AutoSize = true;
            this.fileTransposeControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fileTransposeControl1.Location = new System.Drawing.Point(3, 211);
            this.fileTransposeControl1.Name = "fileTransposeControl1";
            this.fileTransposeControl1.Size = new System.Drawing.Size(161, 73);
            this.fileTransposeControl1.TabIndex = 1;
            // 
            // playbackControl
            // 
            this.playbackControl.AutoSize = true;
            this.playbackControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playbackControl.Location = new System.Drawing.Point(0, 3);
            this.playbackControl.Name = "playbackControl";
            this.playbackControl.Size = new System.Drawing.Size(303, 208);
            this.playbackControl.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cutClrBtn);
            this.groupBox1.Controls.Add(this.cutCutBtn);
            this.groupBox1.Controls.Add(this.cutResetBtn);
            this.groupBox1.Location = new System.Drawing.Point(210, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 60);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cut";
            // 
            // cutClrBtn
            // 
            this.cutClrBtn.Location = new System.Drawing.Point(133, 17);
            this.cutClrBtn.Name = "cutClrBtn";
            this.cutClrBtn.Size = new System.Drawing.Size(56, 37);
            this.cutClrBtn.TabIndex = 2;
            this.cutClrBtn.Text = "Clear\r\nDisplay";
            this.cutClrBtn.UseVisualStyleBackColor = true;
            this.cutClrBtn.Click += new System.EventHandler(this.cutClrBtn_Click);
            // 
            // cutCutBtn
            // 
            this.cutCutBtn.Location = new System.Drawing.Point(70, 17);
            this.cutCutBtn.Name = "cutCutBtn";
            this.cutCutBtn.Size = new System.Drawing.Size(56, 37);
            this.cutCutBtn.TabIndex = 1;
            this.cutCutBtn.Text = "Cut";
            this.cutCutBtn.UseVisualStyleBackColor = true;
            this.cutCutBtn.Click += new System.EventHandler(this.cutCutBtn_Click);
            // 
            // cutResetBtn
            // 
            this.cutResetBtn.Location = new System.Drawing.Point(8, 17);
            this.cutResetBtn.Name = "cutResetBtn";
            this.cutResetBtn.Size = new System.Drawing.Size(56, 37);
            this.cutResetBtn.TabIndex = 0;
            this.cutResetBtn.Text = "Reset\r\nMarker";
            this.cutResetBtn.UseVisualStyleBackColor = true;
            this.cutResetBtn.Click += new System.EventHandler(this.cutResetBtn_Click);
            // 
            // layoutBox
            // 
            this.layoutBox.Controls.Add(this.label10);
            this.layoutBox.Controls.Add(this.factor);
            this.layoutBox.Controls.Add(this.applyButton);
            this.layoutBox.Controls.Add(this.pagesBox);
            this.layoutBox.Controls.Add(this.label9);
            this.layoutBox.Controls.Add(this.barsPerPageBox);
            this.layoutBox.Controls.Add(this.label7);
            this.layoutBox.Controls.Add(this.rowsEdit);
            this.layoutBox.Controls.Add(this.barsEdit);
            this.layoutBox.Controls.Add(this.label6);
            this.layoutBox.Controls.Add(this.label5);
            this.layoutBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.layoutBox.Location = new System.Drawing.Point(1093, 3);
            this.layoutBox.Name = "layoutBox";
            this.layoutBox.Size = new System.Drawing.Size(132, 151);
            this.layoutBox.TabIndex = 54;
            this.layoutBox.TabStop = false;
            this.layoutBox.Text = "Printing Layout";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 19);
            this.label10.TabIndex = 10;
            this.label10.Text = "rel.thick.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // factor
            // 
            this.factor.Location = new System.Drawing.Point(88, 50);
            this.factor.Name = "factor";
            this.factor.Size = new System.Drawing.Size(32, 20);
            this.factor.TabIndex = 9;
            this.factor.Text = ".5";
            // 
            // applyButton
            // 
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyButton.Location = new System.Drawing.Point(6, 78);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(112, 17);
            this.applyButton.TabIndex = 8;
            this.applyButton.Text = "apply";
            this.applyButton.Click += new System.EventHandler(this.ApplyButtonClick);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Pages:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barsPerPageBox
            // 
            this.barsPerPageBox.Location = new System.Drawing.Point(88, 103);
            this.barsPerPageBox.Name = "barsPerPageBox";
            this.barsPerPageBox.ReadOnly = true;
            this.barsPerPageBox.Size = new System.Drawing.Size(32, 20);
            this.barsPerPageBox.TabIndex = 5;
            this.barsPerPageBox.Text = "75";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Bars/Page:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barsEdit
            // 
            this.barsEdit.Location = new System.Drawing.Point(88, 12);
            this.barsEdit.Name = "barsEdit";
            this.barsEdit.Size = new System.Drawing.Size(32, 20);
            this.barsEdit.TabIndex = 2;
            this.barsEdit.Text = "13";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Rows/Page:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bars/Row:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // penaltyBox
            // 
            this.penaltyBox.Controls.Add(this.thresholdUpDown);
            this.penaltyBox.Controls.Add(this.penaltyScrollShort);
            this.penaltyBox.Controls.Add(this.label4);
            this.penaltyBox.Controls.Add(this.label3);
            this.penaltyBox.Controls.Add(this.penaltyScrollAdd);
            this.penaltyBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.penaltyBox.Location = new System.Drawing.Point(909, 20);
            this.penaltyBox.Name = "penaltyBox";
            this.penaltyBox.Size = new System.Drawing.Size(64, 113);
            this.penaltyBox.TabIndex = 53;
            this.penaltyBox.TabStop = false;
            this.penaltyBox.Text = "Penalties";
            // 
            // thresholdUpDown
            // 
            this.thresholdUpDown.Items.Add("1");
            this.thresholdUpDown.Items.Add("1/2");
            this.thresholdUpDown.Items.Add("1/4");
            this.thresholdUpDown.Items.Add("1/8");
            this.thresholdUpDown.Items.Add("1/16");
            this.thresholdUpDown.Items.Add("1/32");
            this.thresholdUpDown.Items.Add("1/64");
            this.thresholdUpDown.Location = new System.Drawing.Point(8, 12);
            this.thresholdUpDown.Name = "thresholdUpDown";
            this.thresholdUpDown.ReadOnly = true;
            this.thresholdUpDown.Size = new System.Drawing.Size(48, 20);
            this.thresholdUpDown.TabIndex = 55;
            this.thresholdUpDown.Text = "1";
            this.thresholdUpDown.Wrap = true;
            this.thresholdUpDown.SelectedItemChanged += new System.EventHandler(this.ThresholdUpDownSelectedItemChanged);
            // 
            // penaltyScrollShort
            // 
            this.penaltyScrollShort.LargeChange = 1;
            this.penaltyScrollShort.Location = new System.Drawing.Point(40, 36);
            this.penaltyScrollShort.Maximum = 10;
            this.penaltyScrollShort.Name = "penaltyScrollShort";
            this.penaltyScrollShort.Size = new System.Drawing.Size(16, 59);
            this.penaltyScrollShort.TabIndex = 2;
            this.penaltyScrollShort.ValueChanged += new System.EventHandler(this.PenaltyScrollShortValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "add";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // penaltyScrollAdd
            // 
            this.penaltyScrollAdd.LargeChange = 1;
            this.penaltyScrollAdd.Location = new System.Drawing.Point(8, 36);
            this.penaltyScrollAdd.Maximum = 10;
            this.penaltyScrollAdd.Name = "penaltyScrollAdd";
            this.penaltyScrollAdd.Size = new System.Drawing.Size(16, 59);
            this.penaltyScrollAdd.TabIndex = 0;
            this.penaltyScrollAdd.ValueChanged += new System.EventHandler(this.PenaltyScrollAddValueChanged);
            // 
            // tuningBox
            // 
            this.tuningBox.Controls.Add(this.qualityCheck);
            this.tuningBox.Controls.Add(this.labelCheck);
            this.tuningBox.Controls.Add(this.label8);
            this.tuningBox.Controls.Add(this.transposeTuningUpDown);
            this.tuningBox.Controls.Add(this.tuningPanel);
            this.tuningBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tuningBox.Location = new System.Drawing.Point(518, 6);
            this.tuningBox.Name = "tuningBox";
            this.tuningBox.Size = new System.Drawing.Size(208, 176);
            this.tuningBox.TabIndex = 50;
            this.tuningBox.TabStop = false;
            this.tuningBox.Text = "Tuning";
            // 
            // labelCheck
            // 
            this.labelCheck.Checked = true;
            this.labelCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.labelCheck.Location = new System.Drawing.Point(104, 151);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(88, 22);
            this.labelCheck.TabIndex = 49;
            this.labelCheck.Text = "Show Labels";
            this.labelCheck.CheckedChanged += new System.EventHandler(this.QualityCheckCheckedChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "Transpose:";
            // 
            // tuningPanel
            // 
            this.tuningPanel.AutoScroll = true;
            this.tuningPanel.BackColor = System.Drawing.Color.White;
            this.tuningPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tuningPanel.Location = new System.Drawing.Point(8, 12);
            this.tuningPanel.Name = "tuningPanel";
            this.tuningPanel.Size = new System.Drawing.Size(192, 113);
            this.tuningPanel.TabIndex = 46;
            // 
            // qualityBox
            // 
            this.qualityBox.Controls.Add(this.chordBox);
            this.qualityBox.Controls.Add(this.intervalBox);
            this.qualityBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.qualityBox.Location = new System.Drawing.Point(724, 6);
            this.qualityBox.Name = "qualityBox";
            this.qualityBox.Size = new System.Drawing.Size(184, 127);
            this.qualityBox.TabIndex = 51;
            this.qualityBox.TabStop = false;
            this.qualityBox.Text = "Quality Weights";
            // 
            // chordBox
            // 
            this.chordBox.Controls.Add(this.weightScrollCh5);
            this.chordBox.Controls.Add(this.label2);
            this.chordBox.Controls.Add(this.label1);
            this.chordBox.Controls.Add(this.weightScrollCh3);
            this.chordBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.chordBox.Location = new System.Drawing.Point(131, 12);
            this.chordBox.Name = "chordBox";
            this.chordBox.Size = new System.Drawing.Size(48, 110);
            this.chordBox.TabIndex = 17;
            this.chordBox.TabStop = false;
            this.chordBox.Text = "Chords";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "3 M";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "5";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackPanel
            // 
            this.trackPanel.AutoScroll = true;
            this.trackPanel.BackColor = System.Drawing.Color.White;
            this.trackPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackPanel.Location = new System.Drawing.Point(312, 18);
            this.trackPanel.Name = "trackPanel";
            this.trackPanel.Size = new System.Drawing.Size(200, 113);
            this.trackPanel.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.cutPanel);
            this.panel2.Controls.Add(this.cutBarSecond);
            this.panel2.Controls.Add(this.cutBarFirst);
            this.panel2.Controls.Add(this.chordNameDisplay);
            this.panel2.Controls.Add(this.zoomScroll);
            this.panel2.Controls.Add(this.chordDisplay);
            this.panel2.Controls.Add(this.offsetScroll);
            this.panel2.Controls.Add(this.cursor);
            this.panel2.Controls.Add(this.hoverBar);
            this.panel2.Controls.Add(this.noteDisplay);
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1228, 396);
            this.panel2.TabIndex = 46;
            this.panel2.Resize += new System.EventHandler(this.Panel2Resize);
            // 
            // cutPanel
            // 
            this.cutPanel.AutoScroll = true;
            this.cutPanel.Location = new System.Drawing.Point(8, 140);
            this.cutPanel.Name = "cutPanel";
            this.cutPanel.Size = new System.Drawing.Size(976, 235);
            this.cutPanel.TabIndex = 47;
            // 
            // cutBarSecond
            // 
            this.cutBarSecond.BackColor = System.Drawing.Color.BlueViolet;
            this.cutBarSecond.Location = new System.Drawing.Point(8, 6);
            this.cutBarSecond.Name = "cutBarSecond";
            this.cutBarSecond.Size = new System.Drawing.Size(1, 47);
            this.cutBarSecond.TabIndex = 31;
            this.cutBarSecond.Visible = false;
            // 
            // cutBarFirst
            // 
            this.cutBarFirst.BackColor = System.Drawing.Color.BlueViolet;
            this.cutBarFirst.Location = new System.Drawing.Point(8, 6);
            this.cutBarFirst.Name = "cutBarFirst";
            this.cutBarFirst.Size = new System.Drawing.Size(1, 47);
            this.cutBarFirst.TabIndex = 31;
            this.cutBarFirst.Visible = false;
            // 
            // chordNameDisplay
            // 
            this.chordNameDisplay.BackColor = System.Drawing.Color.White;
            this.chordNameDisplay.Location = new System.Drawing.Point(8, 109);
            this.chordNameDisplay.Name = "chordNameDisplay";
            this.chordNameDisplay.Size = new System.Drawing.Size(960, 16);
            this.chordNameDisplay.TabIndex = 46;
            this.chordNameDisplay.TabStop = false;
            // 
            // cursor
            // 
            this.cursor.BackColor = System.Drawing.Color.Red;
            this.cursor.Location = new System.Drawing.Point(8, 6);
            this.cursor.Name = "cursor";
            this.cursor.Size = new System.Drawing.Size(1, 47);
            this.cursor.TabIndex = 30;
            // 
            // hoverBar
            // 
            this.hoverBar.BackColor = System.Drawing.Color.DarkGray;
            this.hoverBar.Location = new System.Drawing.Point(8, 6);
            this.hoverBar.Name = "hoverBar";
            this.hoverBar.Size = new System.Drawing.Size(1, 47);
            this.hoverBar.TabIndex = 31;
            this.hoverBar.Visible = false;
            // 
            // noteDisplay
            // 
            this.noteDisplay.BackColor = System.Drawing.Color.White;
            this.noteDisplay.Location = new System.Drawing.Point(8, 6);
            this.noteDisplay.Name = "noteDisplay";
            this.noteDisplay.Size = new System.Drawing.Size(960, 47);
            this.noteDisplay.TabIndex = 29;
            this.noteDisplay.TabStop = false;
            this.noteDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoteDisplayMouseDown);
            this.noteDisplay.MouseLeave += new System.EventHandler(this.NoteDisplayOnMouseLeave);
            this.noteDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoteDisplayMouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.Location = new System.Drawing.Point(0, 0);
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Size = new System.Drawing.Size(100, 100);
            this.printPreviewDialog1.TabIndex = 0;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // cutRowCursor
            // 
            this.cutRowCursor.BackColor = System.Drawing.Color.Red;
            this.cutRowCursor.Location = new System.Drawing.Point(8, 6);
            this.cutRowCursor.Name = "cutRowCursor";
            this.cutRowCursor.Size = new System.Drawing.Size(1, 47);
            this.cutRowCursor.TabIndex = 0;
            this.cutRowCursor.Visible = false;
            // 
            // mainMenuControl1
            // 
            this.mainMenuControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.mainMenuControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMenuControl1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mainMenuControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainMenuControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenuControl1.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl1.Name = "mainMenuControl1";
            this.mainMenuControl1.Size = new System.Drawing.Size(1228, 25);
            this.mainMenuControl1.TabIndex = 60;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1228, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainMenuControl1);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "ChordQuality";
            this.Closed += new System.EventHandler(this.MainFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay)).EndInit();
            this.intervalBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transposeTuningUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.layoutBox.ResumeLayout(false);
            this.layoutBox.PerformLayout();
            this.penaltyBox.ResumeLayout(false);
            this.tuningBox.ResumeLayout(false);
            this.qualityBox.ResumeLayout(false);
            this.chordBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chordNameDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteDisplay)).EndInit();
            this.ResumeLayout(false);

        }
        private TextBox factor;
        private Label label10;
        #endregion

        private void initializeServices()
        {
            artist = new PianoRollArtist(noteDisplay, chordDisplay, tunings, qualityWeights, chordNameDisplay);
            printDocProvider = PrintDocumentProvider.Instance;
            printDocProvider.setArtist(artist);
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            playSubscription = eventAggregator.Subscribe<PlayMessage>(Message =>
            {
                Play(Message.deviceIndex);
            });
            pauseSubscription = eventAggregator.Subscribe<PauseMessage>(Message =>
            {
                Pause();
            });
            stopSubscription = eventAggregator.Subscribe<StopMessage>(Message =>
            {
                Stop();
            });
            midiPlayerSubscription = eventAggregator.Subscribe<MidiPlayerUpdatedMessage>(Message =>
            {
                updatePlayer(Message.player);
            });
            midiFileSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                onFileOpened(Message.file);
            });
            fileTransposeSubscription = eventAggregator.Subscribe<FileTransposedMessage>(Message =>
            {
                chords = Message.chords;
                update_tuning_avg();
                redraw();
            });
            closeRequestSubscription = eventAggregator.Subscribe<CloseRequestMessage>(Message =>
            {
                Close();
            });
            markersChangedSubscription = eventAggregator.Subscribe<MarkersChangedMessage>(Message =>
            {
                onMarkersChanged();
            });
            bestTuningsSubscription = eventAggregator.Subscribe<FindBestTuningsMessage>(Message =>
            {
                findBestTunings();
            });
        }

        private void onMarkersChanged()
        {
            trackDisplay = new TrackDisplay(f.tracks, trackColors);
            TrackDisplayChangedMessage tmessage = new TrackDisplayChangedMessage();
            tmessage.trackDisplay = trackDisplay;
            eventAggregator.Publish(tmessage);

            redraw();
        }

        private void updatePlayer(MidiFilePlayer player)
        {
            pl = player;
        }

        MidiFile f = null;
        Color[] colors = new Color[19] {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black };
        Color[] trackColors = new Color[19] {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black };
        Color selectColor = Color.FromArgb(32, 0, 0, 255);
        Pen pen = new Pen(Color.Black, 2);
        Pen barpen = new Pen(Color.LightGray, 1);
        Pen orientpen = new Pen(Color.LightGray, 1);
        Pen thinpen = new Pen(Color.Black, 1);
        Pen framepen = new Pen(Color.Black, 3);
        Font drawFont = new Font("Courier New", 10);
        Font smallFont = new Font("Courier New", 6);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionVertical);
        MidiFilePlayer pl = null;
        ArrayList chords;
        TuningScheme[] tunings;
        double play_start = -1, play_stop = -1;        
        RadioButton[] tuningRadios;
        CheckBox[] tuningChecks, trackChecks;
        QualityWeights qualityWeights;

        int RowsPerPage = 5, Pages = 0;
        TrackDisplay trackDisplay = null;

        //the starting and ending bar for each cut row
        ArrayList cutRows = new ArrayList();
        double cutFirst = -1, cutSecond = -1;
        int cutRowDragX = -1;

        void MainFormLoad(object sender, EventArgs e)
        {
            initializeSubscriptions();
            // misc init.'s
            orientpen.DashStyle = DashStyle.Dot;
            qualityWeights = new QualityWeights();
            QualityWeightsUpdatedMessage qMessage = new QualityWeightsUpdatedMessage();
            qMessage.qualityWeights = qualityWeights;
            eventAggregator.Publish(qMessage);

            // load tunings from textfiles
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
            FileInfo[] fi = di.GetFiles("*.tng");
            tunings = new TuningScheme[fi.Length + 1];
            tunings[0] = new TuningScheme();
            for(int n = 0; n < fi.Length; n++)
                tunings[n + 1] = new TuningScheme(fi[n].Name);
            TuningsUpdatedMessage tMessage = new TuningsUpdatedMessage();
            tMessage.tunings = tunings;
            eventAggregator.Publish(tMessage);
            tuningChecks = new CheckBox[tunings.Length];
            tuningRadios = new RadioButton[tunings.Length];
            for(int n = 0; n < tunings.Length; n++)
            {
                tuningChecks[n] = new CheckBox();
                tuningChecks[n].Location = new Point(4, 4 + n * 16);
                tuningChecks[n].Size = new Size(152, 16);
                tuningChecks[n].ForeColor = colors[n];
                tuningChecks[n].Text = tunings[n].Name;
                tuningChecks[n].CheckedChanged += new System.EventHandler(TuningCheckedChanged);
                tuningPanel.Controls.Add(tuningChecks[n]);
                tuningRadios[n] = new RadioButton();
                tuningRadios[n].Location = new Point(156, 4 + n * 16);
                tuningRadios[n].Size = new Size(16, 16);
                tuningRadios[n].ForeColor = colors[n];
                tuningRadios[n].CheckedChanged += new System.EventHandler(TuningRadioCheckedChanged);
                tuningPanel.Controls.Add(tuningRadios[n]);
            }
            tuningChecks[0].Checked = true;
            tuningRadios[0].Checked = true;

            // adjust chordDisplay size
            double q, maxq = 0;
            for(int i = 0; i < tunings.Length; i++)
            {
                q = tunings[i].MaxQuality();
                if(q > maxq)
                    maxq = q;
            }
            chordDisplay.Top = noteDisplay.Bottom + 1;
            chordDisplay.Height = (int) (2 * maxq);
            chordNameDisplay.Top = chordDisplay.Bottom + 1;
            offsetScroll.Top = chordNameDisplay.Bottom;
            zoomScroll.Height = noteDisplay.Height + chordDisplay.Height + chordNameDisplay.Height + 2;
            
            initializeServices();
        }

        private void onFileOpened(MidiFile file)
        {
            f = file;

            // Synchronize the file among all services.
            FileUpdatedMessage fMessage = new FileUpdatedMessage();
            fMessage.file = file;
            eventAggregator.Publish(fMessage);

            play_start = -1;
            play_stop = -1;
            PlaySelectionChangedMessage pMessage = new PlaySelectionChangedMessage();
            pMessage.playStart = play_start; pMessage.playStop = play_stop;
            eventAggregator.Publish(pMessage);

            // load the track display into memory
            trackDisplay = new TrackDisplay(f.tracks, trackColors);
            TrackDisplayChangedMessage tmessage = new TrackDisplayChangedMessage();
            tmessage.trackDisplay = trackDisplay;
            eventAggregator.Publish(tmessage);


            for(int i = 0; i < tuningRadios.Length; i++)
            {
                if(tuningRadios[i].Checked)
                {
                    pl.Tuning = tunings[i];
                }
            }

            // show file information
            Text = "ChordQuality   ---   " + f.name;

            // adjust noteDisplay size
            noteDisplay.Height = (f.max_note - f.min_note) * 2 + 1;
            cursor.Height = noteDisplay.Height;
            hoverBar.Height = noteDisplay.Height;
            cutBarFirst.Height = noteDisplay.Height;
            cutBarSecond.Height = noteDisplay.Height;
            chordDisplay.Top = noteDisplay.Bottom + 1;
            noteDisplay.Image = new Bitmap(noteDisplay.Width, noteDisplay.Height);
            chordDisplay.Image = new Bitmap(chordDisplay.Width, chordDisplay.Height);
            chordNameDisplay.Image = new Bitmap(chordNameDisplay.Width, chordNameDisplay.Height);

            // display track names
            trackPanel.Controls.Clear();
            trackChecks = new CheckBox[f.tracks.Length];
            for(int n = 0; n < f.tracks.Length; n++)
            {
                trackChecks[n] = new CheckBox();
                trackChecks[n].Location = new Point(4, 4 + n * 16);
                trackChecks[n].Size = new Size(192, 16);
                trackChecks[n].ForeColor = trackColors[n];
                trackChecks[n].Text = "#" + (n + 1).ToString() + ": " + f.tracks[n].name;
                trackChecks[n].Checked = true;
                trackChecks[n].CheckedChanged += new System.EventHandler(TrackCheckedChanged);
                trackChecks[n].ContextMenu = contextMenu1;
                trackPanel.Controls.Add(trackChecks[n]);
            }

           

            //
            chords = f.FindChords();
            update_tuning_avg();

            //
            
            zoomScroll.Maximum = f.bars;
            if(f.bars < zoomScroll.Value)
            {
                zoomScroll.Value = f.bars;
                ZoomScrollChangedMessage message = new ZoomScrollChangedMessage();
                message.zoomValue = zoomScroll.Value;
                eventAggregator.Publish(message);
            }
            offsetScroll.Maximum = Math.Max(f.bars - zoomScroll.Value, 0);
            offsetScroll.Value = 0;

            //
            QualityCheckCheckedChanged(this, new EventArgs());
            applyButton.PerformClick();

            //place cut panel below
            cutPanel.Top = offsetScroll.Bottom + 5;
            //redraw();           
        }

        void Timer1Tick(object sender, EventArgs e)
        {
            double p = pl.Position;
            if(p < 0)
                return;
            if(p >= f.bars)
            {
                Stop();
            } else
            {
                if(p >= offsetScroll.Value + zoomScroll.Value)
                {
                    offsetScroll.Value = Math.Min(offsetScroll.Value + zoomScroll.Value, offsetScroll.Maximum);
                } else if(p < offsetScroll.Value)
                {
                    offsetScroll.Value = (int) p;
                }

                cursor.Left = noteDisplay.Left + (int) ((p - offsetScroll.Value) * noteDisplay.Width / zoomScroll.Value);
                if((play_start != play_stop) && (cursor.Left > noteDisplay.Width * (Math.Max(play_start, play_stop) - offsetScroll.Value) / zoomScroll.Value))
                {
                    Stop();
                }

                //place a cursor in the cut rows as well
                cutRowCursor.Left = cursor.Left;
            }
        }

        void OffsetScrollValueChanged(object sender, EventArgs e)
        {
            BarOffsetChangedMessage message = new BarOffsetChangedMessage();
            message.offsetValue = offsetScroll.Value.ToString();
            eventAggregator.Publish(message);
            redraw();
        }

        void ZoomScrollValueChanged(object sender, EventArgs e)
        {
            ZoomScrollChangedMessage message = new ZoomScrollChangedMessage();
            message.zoomValue = zoomScroll.Value;
            eventAggregator.Publish(message);
            barsEdit.Text = zoomScroll.Value.ToString();
            applyButton.PerformClick();
            if(f != null)
            {
                offsetScroll.Maximum = Math.Max(f.bars - zoomScroll.Value, 0);
                redraw();
            }
        }

        void MainFormClosed(object sender, EventArgs e)
        {
            if(pl != null)
            {
                System.Diagnostics.Debug.Write(pl.ToString());
                Stop();

            }
        }




       






        void TransposeTuningUpDownValueChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < tunings.Length; i++)
                tunings[i].Transpose = (int) transposeTuningUpDown.Value;
            if(f != null)
            {
                update_tuning_avg();
                redraw_chords();
            }
            if(pl != null)
            {
                for(int i = 0; i < tuningRadios.Length; i++)
                    if(tuningRadios[i].Checked)
                        pl.Tuning = tunings[i];
            }
            TuningsTransposedMessage tMessage = new TuningsTransposedMessage();
            tMessage.transposeValue = (int) transposeTuningUpDown.Value;
            eventAggregator.Publish(tMessage);
        }

        void QualityCheckCheckedChanged(object sender, EventArgs e)
        {
            chordDisplay.Visible = qualityCheck.Checked;
            chordNameDisplay.Visible = labelCheck.Checked;
            zoomScroll.Height = noteDisplay.Height;
            if(chordDisplay.Visible)
            {
                chordNameDisplay.Top = chordDisplay.Bottom + 1;
                zoomScroll.Height += chordDisplay.Height + 1;
            } else
                chordNameDisplay.Top = noteDisplay.Bottom + 1;
            if(chordNameDisplay.Visible)
            {
                offsetScroll.Top = chordNameDisplay.Bottom;
                zoomScroll.Height += chordNameDisplay.Height + 1;
            } else if(chordDisplay.Visible)
                offsetScroll.Top = chordDisplay.Bottom;
            else
                offsetScroll.Top = noteDisplay.Bottom;

            if(f != null)
                redraw();
        }

        void Panel2Resize(object sender, EventArgs e)
        {
            if(panel2.Width > 0)
            {
                noteDisplay.Width = panel2.Width - 32;
                chordDisplay.Width = noteDisplay.Width;
                chordNameDisplay.Width = noteDisplay.Width;
                offsetScroll.Width = noteDisplay.Width;
                zoomScroll.Left = noteDisplay.Right;
                noteDisplay.Image = new Bitmap(noteDisplay.Width, noteDisplay.Height);
                chordDisplay.Image = new Bitmap(chordDisplay.Width, chordDisplay.Height);
                chordNameDisplay.Image = new Bitmap(chordNameDisplay.Width, chordNameDisplay.Height);
                if(f != null)
                    redraw();
            }
        }

        void WeightScroll6MajValueChanged(object sender, EventArgs e)
        {
            qualityWeights.M6 = (20 - weightScroll6Maj.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void WeightScroll6minValueChanged(object sender, EventArgs e)
        {
            qualityWeights.m6 = (20 - weightScroll6min.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void WeightScroll5ValueChanged(object sender, EventArgs e)
        {
            qualityWeights.fifth = (20 - weightScroll5.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void WeightScroll4ValueChanged(object sender, EventArgs e)
        {
            qualityWeights.fourth = (20 - weightScroll4.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void WeightScroll3MajValueChanged(object sender, EventArgs e)
        {
            qualityWeights.M3 = (20 - weightScroll3Maj.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void WeightScroll3minValueChanged(object sender, EventArgs e)
        {
            qualityWeights.m3 = (20 - weightScroll3min.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        

        void WeightScrollCh5ValueChanged(object sender, EventArgs e)
        {
            qualityWeights.Ch5 = (20 - weightScrollCh5.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void WeightScrollCh3ValueChanged(object sender, EventArgs e)
        {
            qualityWeights.Ch3 = (20 - weightScrollCh3.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void PenaltyScrollAddValueChanged(object sender, EventArgs e)
        {
            qualityWeights.Add = (10 - penaltyScrollAdd.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        void ThresholdUpDownSelectedItemChanged(object sender, EventArgs e)
        {
            if(f != null)
            {
                switch(thresholdUpDown.SelectedIndex)
                {
                    case 0:
                        qualityWeights.Threshold = 4 * f.timing;
                        break;
                    case 1:
                        qualityWeights.Threshold = 4 * f.timing / 2.0;
                        break;
                    case 2:
                        qualityWeights.Threshold = 4 * f.timing / 4.0;
                        break;
                    case 3:
                        qualityWeights.Threshold = 4 * f.timing / 8.0;
                        break;
                    case 4:
                        qualityWeights.Threshold = 4 * f.timing / 16.0;
                        break;
                    case 5:
                        qualityWeights.Threshold = 4 * f.timing / 32.0;
                        break;
                    case 6:
                        qualityWeights.Threshold = 4 * f.timing / 64.0;
                        break;
                }
                update_tuning_avg();
                redraw_chords();
                PenaltiesChangedMessage pMessage = new PenaltiesChangedMessage();
                pMessage.penalties = thresholdUpDown.Text;
                eventAggregator.Publish(pMessage);
            }
        }

        /***** Menu Items Event Handlers Begins *****/   

        private void MenuItem1Click(object sender, EventArgs e)
        {
            for(int i = 0; i < f.tracks.Length; i++)
                if(contextMenu1.SourceControl == trackChecks[i])
                    colorDialog1.Color = trackColors[i];
            colorDialog1.ShowDialog();
            for(int i = 0; i < f.tracks.Length; i++)
                if(contextMenu1.SourceControl == trackChecks[i])
                {
                    trackColors[i] = colorDialog1.Color;
                    trackChecks[i].ForeColor = colorDialog1.Color;
                }
            redraw();
        }

        
        

        private void findBestTunings()
        {
            int mini = 0, minj = 0;
            double q, minq = 100;
            for(int i = 0; i < tunings.Length; i++)
                for(int j = 0; j < 12; j++)
                {
                    tunings[i].Transpose = j;
                    q = tunings[i].AvgQuality(chords, qualityWeights);
                    if(q < minq)
                    {
                        minq = q;
                        mini = i;
                        minj = j;
                    }
                }
            MessageBox.Show(tunings[mini].Name + " +" + minj + " (" + Math.Round(minq, 5) + ")", "Best Tuning");
            transposeTuningUpDown.Value = minj;
            TransposeTuningUpDownValueChanged(this, null);
        }

       

        /***** Playback Event Handlers Begin *****/
        void Play(int outputDevice)
        {
            if(play_start == play_stop)
            {
                pl.Play(outputDevice);
            } else
            {
                double selectionStart = Math.Min(play_start, play_stop);
                double selectionStop = Math.Max(play_start, play_stop);
                pl.Play(outputDevice, selectionStart, selectionStop);
            }
            timer1.Enabled = true;
        }

        void Stop()
        {
            pl.Stop();
            timer1.Enabled = false;
            cursor.Left = noteDisplay.Left;

            ///get rid of the cut row cursor
            this.cutRowCursor.Visible = false;
            foreach(PictureBox p in this.cutPanel.Controls)
            {

            }
        }

        private void Pause()
        {
            pl.Pause();
            timer1.Enabled = false;
        }



        /***** Tracks Event Handlers Begin *****/
        void TrackCheckedChanged(object sender, EventArgs e)
        {
            if(f != null)
            {
                for(int i = 0; i < f.tracks.Length; i++)
                    f.tracks[i].enabled = trackChecks[i].Checked;
                chords = f.FindChords();
                update_tuning_avg();

                // update the in memory track display
                trackDisplay = new TrackDisplay(f.tracks, trackColors);
                TrackDisplayChangedMessage tmessage = new TrackDisplayChangedMessage();
                tmessage.trackDisplay = trackDisplay;
                eventAggregator.Publish(tmessage);

                redraw();
            }
        }

        /***** Cut Event Handlers Begin *****/
        private void cutResetBtn_Click(object sender, EventArgs e)
        {
            cutBarFirst.Visible = false;
            cutBarSecond.Visible = false;
            cutFirst = -1;
            cutSecond = -1;
        }

        private void cutCutBtn_Click(object sender, EventArgs e)
        {
            double cutStart = Math.Min(cutFirst, cutSecond);
            double cutEnd = Math.Max(cutFirst, cutSecond);

            //the bar we're starting on and the number of bars we want
            int barStart = (int) Math.Round(cutStart);
            int barDiff = (int) Math.Round(cutEnd - cutStart);
            int barEnd = barStart + barDiff;
            if(barDiff == 0)
            {
                //make sure we have at least one
                barDiff = 1;
            }

            //we're fixing the numer of bars/cut row (=10.0) for now
            double width = barDiff / 10.0 * noteDisplay.Width;
            if(cutStart < 0 || cutEnd < 0)
            {
                return;
            }

            //create a new picture box for our cut row
            PictureBox cutRow = new PictureBox();
            cutRow.BackColor = System.Drawing.Color.White;
            cutRow.Location = new System.Drawing.Point(0, cutRows.Count * this.noteDisplay.Height);
            cutRow.Size = new System.Drawing.Size((int) Math.Round(width), this.noteDisplay.Height);
            cutRow.Cursor = Cursors.SizeWE;
            cutRow.TabStop = false;
            cutRow.Image = new Bitmap(cutRow.Width, cutRow.Height);
            cutRows.Add(new Tuple<int, int>(barStart, barEnd));

            //we need to listen to these events so we can perform left/right dragging
            cutRow.MouseDown += new MouseEventHandler(this.cutRow_MouseDown);
            cutRow.MouseMove += new MouseEventHandler(this.cutRow_MouseMove);

            //draw note in our cut row
            artist.draw_notes(Graphics.FromImage(cutRow.Image), barStart, 0, 2, barDiff);

            //add to our cut panel so it can be showed
            cutPanel.Controls.Add(cutRow);

            //then reset
            cutResetBtn_Click(sender, e);
        }

        private void cutClrBtn_Click(object sender, EventArgs e)
        {
            cutRows.Clear();
            cutPanel.Controls.Clear();
        }

        /***** Tunning Event Handlers Begin *****/
        void TuningCheckedChanged(object sender, EventArgs e)
        {
            if(f != null)
            {
                for(int i = 0; i < tunings.Length; i++)
                    tunings[i].enabled = tuningChecks[i].Checked;
                redraw_chords();
            }
        }

        void TuningRadioCheckedChanged(object sender, EventArgs e)
        {
            if(pl != null)
            {
                for(int i = 0; i < tuningRadios.Length; i++)
                    if(tuningRadios[i].Checked)
                        pl.Tuning = tunings[i];
            }
        }

        /***** Penalties Event Handlers Begin *****/
        private void PenaltyScrollShortValueChanged(object sender, EventArgs e)
        {
            qualityWeights.Short = (10 - penaltyScrollShort.Value) / 10.0;
            update_tuning_avg();
            if(f != null)
                redraw_chords();
        }

        /***** Print Layout Event Handlers Begin *****/
        private void ApplyButtonClick(object sender, EventArgs e)
        {
            int bars = Int32.Parse(barsEdit.Text);
            RowsPerPage = Int32.Parse(rowsEdit.Text);
            RowsPerPageChangedMessage rppMessage = new RowsPerPageChangedMessage();
            rppMessage.RowsPerPage = RowsPerPage;
            eventAggregator.Publish(rppMessage);
            int barspp = bars * RowsPerPage;
            barsPerPageBox.Text = barspp.ToString();
            rf = (float) Double.Parse(factor.Text);
            RelThicknessChangedMessage rMessage = new RelThicknessChangedMessage();
            rMessage.relThickness = rf;
            eventAggregator.Publish(rMessage);
            redraw();
            if(f != null)
            {
                Pages = (int) Math.Ceiling((double) f.bars / barspp);
                pagesBox.Text = Pages.ToString();
            }
            zoomScroll.Value = bars;
            ZoomScrollChangedMessage message = new ZoomScrollChangedMessage();
            message.zoomValue = zoomScroll.Value;
            eventAggregator.Publish(message);
        }

        /***** Note Display Event Handlers Begin *****/
        private void NoteDisplayOnMouseLeave(object sender, EventArgs e)
        {
            //hide the hover bar when the mouse is not in range
            this.hoverBar.Visible = false;
        }

        private void NoteDisplayMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                play_start = ((double) e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
                play_stop = play_start;
                PlaySelectionChangedMessage pMessage = new PlaySelectionChangedMessage();
                pMessage.playStart = play_start;
                pMessage.playStop = play_stop;
                eventAggregator.Publish(pMessage);
            } else if(e.Button == MouseButtons.Right)
            {
                //save the locations of our cuts
                //we're naming them first and second as opposed to
                //begin and end because first can come after second
                if(cutFirst < 0)
                {
                    cutFirst = ((double) e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
                    this.cutBarFirst.Visible = true;
                    this.cutBarFirst.Left = this.noteDisplay.Left + e.X;
                } else if(cutSecond < 0)
                {
                    cutSecond = ((double) e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
                    this.cutBarSecond.Visible = true;
                    this.cutBarSecond.Left = this.noteDisplay.Left + e.X;
                }
            }
        }

        private void NoteDisplayMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(f == null)
                return;
            int b = e.X * zoomScroll.Value / noteDisplay.Width + offsetScroll.Value + 1;
            int n = ClosestNote(e.X, e.Y);
            if(n >= 0)
            {
                toolTip1.SetToolTip(noteDisplay, "bar " + b.ToString() + "\n" + KeyList.NoteName(n));
            } else
            {
                toolTip1.SetToolTip(noteDisplay, "bar " + b.ToString());
            }
            if((e.Button == MouseButtons.Left) && (play_start >= 0))
            {
                play_stop = ((double) e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
                PlaySelectionChangedMessage pMessage = new PlaySelectionChangedMessage();
                pMessage.playStart = play_start;
                pMessage.playStop = play_stop;
                eventAggregator.Publish(pMessage);
                redraw_notes();
                
            }
            noteDisplay.Refresh();

            this.hoverBar.Visible = true;
            this.hoverBar.Left = this.noteDisplay.Left + e.X;
        }

        /***** Chord Display Event Handlers Begin *****/
        private void ChordDisplayMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(f == null)
                return;
            int b = e.X * zoomScroll.Value / chordDisplay.Width + offsetScroll.Value + 1;
            toolTip1.SetToolTip(chordDisplay, "bar " + b.ToString());
        }

        /***** Cut Panel Event Handlers Begin *****/
        private void cutRow_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                //this will be the point where we start out dragging
                cutRowDragX = e.X;
            }
        }

        private void cutRow_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if(p != null && e.Button == MouseButtons.Left && cutRowDragX > 0)
            {
                //perform the dragging
                int newLeft = p.Left + (e.X - cutRowDragX);
                if(newLeft > 0 && newLeft + p.Width < p.Parent.Right)
                {
                    p.Left = newLeft;
                }
            }
        }

        /***** Helper Functions Begin *****/
        public String getMidiFileName()
        {
            return f.name;
        }

        private bool IsNote(Bitmap bm, int x, int y)
        {
            switch(unchecked((uint) bm.GetPixel(x, y).ToArgb()))
            {
                case 0xffffffff: // white
                case 0xffd3d3d3: // light gray
                case 0xffdfdfff: // white selected
                case 0xffb9b9d9: // light gray selected
                    return false;
                default:
                    return true;
            }
        }

       

        private int ClosestNote(int x, int y)
        {
            Bitmap bm = (Bitmap) noteDisplay.Image;
            if(x < 0 || x >= bm.Width || y < 0 || y >= bm.Height)
                return -1;
            if(IsNote(bm, x, y))
            {
                Color c = bm.GetPixel(x, y);
                if(y + 2 < bm.Height && bm.GetPixel(x, y + 2) == c)
                    return f.max_note - (y + 2) / 2;
                else if(y > 1 && bm.GetPixel(x, y - 2) == c)
                    return f.max_note - (y) / 2;
                else
                    return f.max_note - (y + 1) / 2;
            }
            if(y + 1 < bm.Height && IsNote(bm, x, y + 1))
            {
                Color c = bm.GetPixel(x, y + 1);
                if(y + 3 < bm.Height && bm.GetPixel(x, y + 3) == c)
                    return f.max_note - (y + 4) / 2;
                else
                    return f.max_note - (y + 2) / 2;
            }
            if(y > 0 && IsNote(bm, x, y - 1))
            {
                Color c = bm.GetPixel(x, y - 1);
                if(y > 2 && bm.GetPixel(x, y - 3) == c)
                    return f.max_note - (y - 2) / 2;
                else
                    return f.max_note - (y) / 2;
            }
            if(y + 2 < bm.Height && IsNote(bm, x, y + 2))
            {
                Color c = bm.GetPixel(x, y + 2);
                if(y + 4 < bm.Height && bm.GetPixel(x, y + 4) == c)
                    return f.max_note - (y + 5) / 2;
                else
                    return f.max_note - (y + 3) / 2;
            }
            if(y > 1 && IsNote(bm, x, y - 2))
            {
                Color c = bm.GetPixel(x, y - 2);
                if(y > 3 && bm.GetPixel(x, y - 4) == c)
                    return f.max_note - (y - 3) / 2;
                else
                    return f.max_note - (y - 1) / 2;
            }
            return -1;
        }

        void update_tuning_avg()
        {
            if(chords == null)
                return;
            for(int i = 0; i < tunings.Length; i++)
            {
                double q = Math.Round(tunings[i].AvgQuality(chords, qualityWeights), 1);
                tuningChecks[i].Text = tunings[i].Name + " (" + q.ToString() + ")";
            }
        }

        void redraw()
        {
            redraw_notes();
            redraw_chords();
        }

        void redraw_notes()
        {
            Graphics.FromImage(noteDisplay.Image).Clear(Color.White);
            artist.draw_notes(Graphics.FromImage(noteDisplay.Image), offsetScroll.Value, 0, 2);
        }

        void redraw_chords()
        {
            Graphics.FromImage(chordDisplay.Image).Clear(Color.White);
            artist.draw_chords(Graphics.FromImage(chordDisplay.Image), offsetScroll.Value, 0);
            Graphics.FromImage(chordNameDisplay.Image).Clear(Color.White);
            artist.draw_chordnames(Graphics.FromImage(chordNameDisplay.Image), offsetScroll.Value, 0);
        }

    }

    class TransparentPanel : Panel
    {
        //from http://stackoverflow.com/questions/547172/pass-through-mouse-events-to-parent-control
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if(m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr) HTTRANSPARENT;
            } else
            {
                base.WndProc(ref m);
            }
        }
    }

}




