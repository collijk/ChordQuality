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

namespace ChordQuality
{
    public class MainForm : Form
    {
		private System.ComponentModel.IContainer components;
		private MenuItem menuItemOpen;
		private NumericUpDown transposeFileUpDown;
		private GroupBox layoutBox;
		private GroupBox chordBox;
		private ContextMenu contextMenu1;
		private Button applyButton;
		private GroupBox qualityBox;
		private MenuItem menuItemExit;
		private Label label12;
		private MenuItem menuItemRemove;
		private Label label16;
		private Label label17;
		private Button pauseButton;
		private MenuItem menuItemFile;
		private GroupBox tuningBox;
		private MenuItem menuItemAnalysis;
		private Button stopButton;
		private TextBox barsPerPageBox;
		private VScrollBar weightScroll4;
		private VScrollBar weightScroll5;
		private MenuItem menuItemAdd;
		private PrintDialog printDialog1;
		private PrintPreviewControl printPreviewDialog1;
		private VScrollBar penaltyScrollAdd;
		private MenuItem menuItemPrint;
		private MenuItem menuItemBest;
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
		private Label label18;
		private Label label19;
		private ToolTip toolTip1;
		private MainMenu mainMenu1;
		private VScrollBar penaltyScrollShort;
		private GroupBox penaltyBox;
		private MenuItem menuItemMarkers;
		private VScrollBar weightScroll6min;
		private CheckBox labelCheck;
		private PictureBox chordNameDisplay;
		private VScrollBar weightScroll3Maj;
		private Panel cursor;
		private TextBox barsEdit;
		private PictureBox noteDisplay;
		private TrackBar volumeBar;
		private SaveFileDialog saveTxtFileDialog;
		private MenuItem menuItemMidi2Txt;
		private ComboBox outputBox;
		private ColorDialog colorDialog1;
		private TrackBar tempoBar;
		private SaveFileDialog saveMidFileDialog;
		private Panel panel2;
		private Panel panel1;
		private Label offsetLabel;
		private GroupBox playbackBox;
		private GroupBox transposeBox;
		private Button playButton;
		private MenuItem menuItemSave;
		private NumericUpDown transposeTuningUpDown;
		private VScrollBar weightScroll3min;
		private MenuItem menuItem1;
		private Label tempoLabel;
		private TextBox rowsEdit;
		private HScrollBar offsetScroll;
		private OpenFileDialog openMidFileDialog;
		private MenuItem menuItemExport;
		private ComboBox instrBox;
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
		private MenuItem menuItemInfo;
		private VScrollBar weightScroll6Maj;
		private MenuItem menuItemPrintPreview;
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

		public MainForm()
		{
            // The InitializeComponent() call is required for 
            // Windows Forms designer support.
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
            this.menuItemInfo = new System.Windows.Forms.MenuItem();
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
            this.instrBox = new System.Windows.Forms.ComboBox();
            this.menuItemExport = new System.Windows.Forms.MenuItem();
            this.openMidFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.offsetScroll = new System.Windows.Forms.HScrollBar();
            this.rowsEdit = new System.Windows.Forms.TextBox();
            this.tempoLabel = new System.Windows.Forms.Label();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.transposeTuningUpDown = new System.Windows.Forms.NumericUpDown();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.playButton = new System.Windows.Forms.Button();
            this.transposeBox = new System.Windows.Forms.GroupBox();
            this.transposeFileUpDown = new System.Windows.Forms.NumericUpDown();
            this.playbackBox = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.ComboBox();
            this.pauseButton = new System.Windows.Forms.Button();
            this.tempoBar = new System.Windows.Forms.TrackBar();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.chordNameDisplay = new System.Windows.Forms.PictureBox();
            this.cursor = new System.Windows.Forms.Panel();
            this.noteDisplay = new System.Windows.Forms.PictureBox();
            this.saveMidFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuItemMidi2Txt = new System.Windows.Forms.MenuItem();
            this.saveTxtFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuItemMarkers = new System.Windows.Forms.MenuItem();
            this.menuItemAdd = new System.Windows.Forms.MenuItem();
            this.menuItemRemove = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemPrintPreview = new System.Windows.Forms.MenuItem();
            this.menuItemPrint = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemAnalysis = new System.Windows.Forms.MenuItem();
            this.menuItemBest = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewControl();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cutRowCursor = new System.Windows.Forms.Panel();
            this.cutBarSecond = new ChordQuality.TransparentPanel();
            this.cutBarFirst = new ChordQuality.TransparentPanel();
            this.hoverBar = new ChordQuality.TransparentPanel();
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay)).BeginInit();
            this.intervalBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transposeTuningUpDown)).BeginInit();
            this.transposeBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transposeFileUpDown)).BeginInit();
            this.playbackBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempoBar)).BeginInit();
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
            // menuItemInfo
            // 
            this.menuItemInfo.Enabled = false;
            this.menuItemInfo.Index = 2;
            this.menuItemInfo.Text = "Info ...";
            this.menuItemInfo.Click += new System.EventHandler(this.MenuItemInfoClick);
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
            this.label20.Location = new System.Drawing.Point(233, 0);
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
            // instrBox
            // 
            this.instrBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.instrBox.Location = new System.Drawing.Point(8, 85);
            this.instrBox.MaxDropDownItems = 32;
            this.instrBox.Name = "instrBox";
            this.instrBox.Size = new System.Drawing.Size(168, 21);
            this.instrBox.TabIndex = 6;
            this.instrBox.SelectedIndexChanged += new System.EventHandler(this.InstrBoxSelectedIndexChanged);
            // 
            // menuItemExport
            // 
            this.menuItemExport.Index = 1;
            this.menuItemExport.Text = "Export to File ...";
            this.menuItemExport.Click += new System.EventHandler(this.MenuItemExportClick);
            // 
            // openMidFileDialog
            // 
            this.openMidFileDialog.Filter = "MIDI-Files|*.mid";
            this.openMidFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
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
            // tempoLabel
            // 
            this.tempoLabel.Location = new System.Drawing.Point(4, 107);
            this.tempoLabel.Name = "tempoLabel";
            this.tempoLabel.Size = new System.Drawing.Size(60, 30);
            this.tempoLabel.TabIndex = 58;
            this.tempoLabel.Text = "tempo: 120 bpm";
            this.tempoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // menuItemSave
            // 
            this.menuItemSave.Enabled = false;
            this.menuItemSave.Index = 1;
            this.menuItemSave.Text = "Save...";
            this.menuItemSave.Click += new System.EventHandler(this.MenuItemSaveClick);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.SystemColors.Control;
            this.playButton.Enabled = false;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playButton.Location = new System.Drawing.Point(8, 15);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(56, 18);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.PlayButtonClick);
            // 
            // transposeBox
            // 
            this.transposeBox.Controls.Add(this.transposeFileUpDown);
            this.transposeBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.transposeBox.Location = new System.Drawing.Point(8, 156);
            this.transposeBox.Name = "transposeBox";
            this.transposeBox.Size = new System.Drawing.Size(88, 44);
            this.transposeBox.TabIndex = 52;
            this.transposeBox.TabStop = false;
            this.transposeBox.Text = "Transpose File";
            // 
            // transposeFileUpDown
            // 
            this.transposeFileUpDown.Location = new System.Drawing.Point(16, 15);
            this.transposeFileUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.transposeFileUpDown.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.transposeFileUpDown.Name = "transposeFileUpDown";
            this.transposeFileUpDown.Size = new System.Drawing.Size(56, 20);
            this.transposeFileUpDown.TabIndex = 0;
            this.transposeFileUpDown.ValueChanged += new System.EventHandler(this.TransposeFileUpDownValueChanged);
            // 
            // playbackBox
            // 
            this.playbackBox.Controls.Add(this.stopButton);
            this.playbackBox.Controls.Add(this.label19);
            this.playbackBox.Controls.Add(this.tempoLabel);
            this.playbackBox.Controls.Add(this.volumeBar);
            this.playbackBox.Controls.Add(this.label18);
            this.playbackBox.Controls.Add(this.instrBox);
            this.playbackBox.Controls.Add(this.label17);
            this.playbackBox.Controls.Add(this.outputBox);
            this.playbackBox.Controls.Add(this.pauseButton);
            this.playbackBox.Controls.Add(this.playButton);
            this.playbackBox.Controls.Add(this.tempoBar);
            this.playbackBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playbackBox.Location = new System.Drawing.Point(8, 0);
            this.playbackBox.Name = "playbackBox";
            this.playbackBox.Size = new System.Drawing.Size(224, 154);
            this.playbackBox.TabIndex = 15;
            this.playbackBox.TabStop = false;
            this.playbackBox.Text = "Playback";
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.Control;
            this.stopButton.Enabled = false;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.stopButton.Location = new System.Drawing.Point(120, 15);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(56, 18);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(168, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 12);
            this.label19.TabIndex = 56;
            this.label19.Text = "Volume";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // volumeBar
            // 
            this.volumeBar.Location = new System.Drawing.Point(176, 20);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeBar.Size = new System.Drawing.Size(45, 83);
            this.volumeBar.TabIndex = 55;
            this.volumeBar.TickFrequency = 20;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.volumeBar.Value = 100;
            this.volumeBar.Scroll += new System.EventHandler(this.VolumeBarScroll);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 12);
            this.label18.TabIndex = 54;
            this.label18.Text = "Instrument:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 12);
            this.label17.TabIndex = 51;
            this.label17.Text = "MIDI Out:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputBox
            // 
            this.outputBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputBox.Location = new System.Drawing.Point(8, 48);
            this.outputBox.MaxDropDownItems = 12;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(168, 21);
            this.outputBox.TabIndex = 5;
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pauseButton.Location = new System.Drawing.Point(64, 15);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(56, 18);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // tempoBar
            // 
            this.tempoBar.Location = new System.Drawing.Point(64, 107);
            this.tempoBar.Maximum = 200;
            this.tempoBar.Minimum = 40;
            this.tempoBar.Name = "tempoBar";
            this.tempoBar.Size = new System.Drawing.Size(152, 45);
            this.tempoBar.TabIndex = 57;
            this.tempoBar.TickFrequency = 10;
            this.tempoBar.Value = 120;
            this.tempoBar.ValueChanged += new System.EventHandler(this.TempoBarValueChanged);
            // 
            // offsetLabel
            // 
            this.offsetLabel.Location = new System.Drawing.Point(102, 161);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(88, 12);
            this.offsetLabel.TabIndex = 43;
            this.offsetLabel.Text = "offset: 0 bars";
            this.offsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.playbackBox);
            this.panel1.Controls.Add(this.layoutBox);
            this.panel1.Controls.Add(this.penaltyBox);
            this.panel1.Controls.Add(this.offsetLabel);
            this.panel1.Controls.Add(this.transposeBox);
            this.panel1.Controls.Add(this.tuningBox);
            this.panel1.Controls.Add(this.qualityBox);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.trackPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 200);
            this.panel1.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cutClrBtn);
            this.groupBox1.Controls.Add(this.cutCutBtn);
            this.groupBox1.Controls.Add(this.cutResetBtn);
            this.groupBox1.Location = new System.Drawing.Point(236, 131);
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
            this.layoutBox.Location = new System.Drawing.Point(909, 0);
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
            this.penaltyBox.Location = new System.Drawing.Point(843, 0);
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
            this.tuningBox.Location = new System.Drawing.Point(442, 0);
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
            this.qualityBox.Location = new System.Drawing.Point(653, 0);
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
            this.trackPanel.Location = new System.Drawing.Point(236, 14);
            this.trackPanel.Name = "trackPanel";
            this.trackPanel.Size = new System.Drawing.Size(200, 113);
            this.trackPanel.TabIndex = 47;
            // 
            // panel2
            // 
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 245);
            this.panel2.TabIndex = 46;
            this.panel2.Resize += new System.EventHandler(this.Panel2Resize);
            // 
            // cutPanel
            // 
            this.cutPanel.Location = new System.Drawing.Point(8, 196);
            this.cutPanel.Name = "cutPanel";
            this.cutPanel.Size = new System.Drawing.Size(976, 235);
            this.cutPanel.TabIndex = 47;
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
            // saveMidFileDialog
            // 
            this.saveMidFileDialog.DefaultExt = "mid";
            this.saveMidFileDialog.Filter = "MIDI-Files|*.mid";
            this.saveMidFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1FileOk);
            // 
            // menuItemMidi2Txt
            // 
            this.menuItemMidi2Txt.Enabled = false;
            this.menuItemMidi2Txt.Index = 5;
            this.menuItemMidi2Txt.Text = "MIDI 2 TXT";
            this.menuItemMidi2Txt.Click += new System.EventHandler(this.MenuItemMidi2TxtClick);
            // 
            // saveTxtFileDialog
            // 
            this.saveTxtFileDialog.DefaultExt = "txt";
            this.saveTxtFileDialog.Filter = "TXT-Files|*.txt";
            this.saveTxtFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveTxtFileDialogFileOk);
            // 
            // menuItemMarkers
            // 
            this.menuItemMarkers.Enabled = false;
            this.menuItemMarkers.Index = 1;
            this.menuItemMarkers.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAdd,
            this.menuItemRemove});
            this.menuItemMarkers.Text = "Markers";
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.Enabled = false;
            this.menuItemAdd.Index = 0;
            this.menuItemAdd.Text = "Add";
            this.menuItemAdd.Click += new System.EventHandler(this.menuItemAdd_Click);
            // 
            // menuItemRemove
            // 
            this.menuItemRemove.Index = 1;
            this.menuItemRemove.Text = "Remove";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemMarkers,
            this.menuItemAnalysis});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemInfo,
            this.menuItemPrintPreview,
            this.menuItemPrint,
            this.menuItemMidi2Txt,
            this.menuItemExit});
            this.menuItemFile.Text = "File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Text = "Open...";
            this.menuItemOpen.Click += new System.EventHandler(this.MenuItemOpenClick);
            // 
            // menuItemPrintPreview
            // 
            this.menuItemPrintPreview.Enabled = false;
            this.menuItemPrintPreview.Index = 3;
            this.menuItemPrintPreview.Text = "Print Preview";
            this.menuItemPrintPreview.Click += new System.EventHandler(this.MenuItemPrintClick);
            // 
            // menuItemPrint
            // 
            this.menuItemPrint.Enabled = false;
            this.menuItemPrint.Index = 4;
            this.menuItemPrint.Text = "Print...";
            this.menuItemPrint.Click += new System.EventHandler(this.MenuItemPrintClick);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 6;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExitClick);
            // 
            // menuItemAnalysis
            // 
            this.menuItemAnalysis.Enabled = false;
            this.menuItemAnalysis.Index = 2;
            this.menuItemAnalysis.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemBest,
            this.menuItemExport});
            this.menuItemAnalysis.Text = "Analysis";
            // 
            // menuItemBest
            // 
            this.menuItemBest.Index = 0;
            this.menuItemBest.Text = "Find Best Tuning";
            this.menuItemBest.Click += new System.EventHandler(this.MenuItemBestClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSomePages = true;
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
            // hoverBar
            // 
            this.hoverBar.BackColor = System.Drawing.Color.DarkGray;
            this.hoverBar.Location = new System.Drawing.Point(8, 6);
            this.hoverBar.Name = "hoverBar";
            this.hoverBar.Size = new System.Drawing.Size(1, 47);
            this.hoverBar.TabIndex = 31;
            this.hoverBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1049, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChordQuality";
            this.Closed += new System.EventHandler(this.MainFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay)).EndInit();
            this.intervalBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transposeTuningUpDown)).EndInit();
            this.transposeBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transposeFileUpDown)).EndInit();
            this.playbackBox.ResumeLayout(false);
            this.playbackBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempoBar)).EndInit();
            this.panel1.ResumeLayout(false);
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
		PrintDocument pd;
		int pages_printed;
		MenuItem[] menuItems, menuItemsRem;
		QualityWeights qualityWeights = new QualityWeights();
		int RowsPerPage = 5, Pages = 0;
		TrackDisplay trackDisplay = null;

		//the starting and ending bar for each cut row
		ArrayList cutRows = new ArrayList();
		double cutFirst = -1, cutSecond = -1;
		int cutRowDragX = -1;

		void MainFormLoad(object sender, EventArgs e)
		{
			// misc init.'s
			orientpen.DashStyle = DashStyle.Dot;
			// detect output ports
			MidiOutDevs mout = new MidiOutDevs();
			for (int i = 0; i < mout.NumDevs; i++)
				outputBox.Items.Add(mout.Label(i));
			outputBox.SelectedIndex = 0;
			// load tunings from textfiles
			DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
			FileInfo[] fi = di.GetFiles("*.tng");
			tunings = new TuningScheme[fi.Length + 1];
			tunings[0] = new TuningScheme();
			for (int n = 0; n < fi.Length; n++)
				tunings[n + 1] = new TuningScheme(fi[n].Name);
			tuningChecks = new CheckBox[tunings.Length];
			tuningRadios = new RadioButton[tunings.Length];
			for (int n = 0; n < tunings.Length; n++)
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
			// load patch map
			if (File.Exists("MIDI_PatchMap.txt"))
			{
				StreamReader sr = new StreamReader("MIDI_PatchMap.txt");
				for (int i = 0; i < 128; i++)
					instrBox.Items.Add(sr.ReadLine());
				sr.Close();
			}
			else
			{
				for (int i = 1; i < 129; i++)
					instrBox.Items.Add(i.ToString().PadLeft(3, '0'));
			}
			instrBox.SelectedIndex = 0;
			// adjust chordDisplay size
			double q, maxq = 0;
			for (int i = 0; i < tunings.Length; i++)
			{
				q = tunings[i].MaxQuality();
				if (q > maxq) maxq = q;
			}
			chordDisplay.Top = noteDisplay.Bottom + 1;
			chordDisplay.Height = (int)(2 * maxq);
			chordNameDisplay.Top = chordDisplay.Bottom + 1;
			offsetScroll.Top = chordNameDisplay.Bottom;
			offsetLabel.Top = offsetScroll.Bottom + 8;
			zoomScroll.Height = noteDisplay.Height + chordDisplay.Height + chordNameDisplay.Height + 2;
		}

		void OpenFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (stopButton.Enabled) StopPlayback();
			playButton.Enabled = true;
			menuItemSave.Enabled = true;
			menuItemPrint.Enabled = true;
			menuItemMidi2Txt.Enabled = true;
			menuItemMarkers.Enabled = true;
			menuItemAnalysis.Enabled = true;
			menuItemInfo.Enabled = true;
			menuItemPrintPreview.Enabled = true;
			play_start = -1;
			play_stop = -1;
			// read midi file
			MidiFileReader fr = new MidiFileReader();
			f = fr.Read(openMidFileDialog.FileName);

			// load the track display into memory
			trackDisplay = new TrackDisplay(f.tracks, trackColors);

			// init file player
			pl = new MidiFilePlayer(f);
			pl.Volume = ((double)volumeBar.Value) / volumeBar.Maximum;
			pl.Tempo = f.tempo;
			if (f.instrument >= 0) pl.Instrument = f.instrument;
			for (int i = 0; i < tuningRadios.Length; i++)
			{
				if (tuningRadios[i].Checked)
				{
					pl.Tuning = tunings[i];
				}
			}

			// show file information
			Text = "ChordQuality   ---   " + f.name;
			if (f.tempo >= tempoBar.Minimum && f.tempo <= tempoBar.Maximum)
			{
				tempoBar.Value = (int)f.tempo;
			}
			if (f.instrument >= 0)
			{
				instrBox.SelectedIndex = f.instrument;
			}
			transposeFileUpDown.Maximum = 127 - f.max_note;
			transposeFileUpDown.Minimum = 0 - f.min_note;

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
			for (int n = 0; n < f.tracks.Length; n++)
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

			// create "markers -> add" menu
			menuItems = new MenuItem[f.tracks.Length];
			for (int i = 0; i < f.tracks.Length; i++)
			{
				menuItems[i] = new MenuItem();
				menuItems[i].Text = "#" + (i + 1).ToString() + ": " + f.tracks[i].name;
				menuItems[i].Click += new System.EventHandler(MenuItemClick);
			}
			menuItemAdd.MenuItems.Clear();
			menuItemAdd.MenuItems.AddRange(menuItems);

			// create "markers -> remove" menu
			menuItemsRem = new MenuItem[f.tracks.Length];
			for (int i = 0; i < f.tracks.Length; i++)
			{
				menuItemsRem[i] = new MenuItem();
				menuItemsRem[i].Text = "#" + (i + 1).ToString() + ": " + f.tracks[i].name;
				menuItemsRem[i].Click += new System.EventHandler(MenuItemRemClick);
			}
			menuItemRemove.MenuItems.Clear();
			menuItemRemove.MenuItems.AddRange(menuItemsRem);

			//
			chords = f.FindChords();
			update_tuning_avg();

			//
			thresholdUpDown.SelectedIndex++;
			thresholdUpDown.SelectedIndex--;
			zoomScroll.Maximum = f.bars;
			if (f.bars < zoomScroll.Value)
			{
				zoomScroll.Value = f.bars;
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
			if (p < 0) return;
			if (p >= f.bars)
			{
				StopPlayback();
			}
			else
			{
				if (p >= offsetScroll.Value + zoomScroll.Value)
				{
					offsetScroll.Value = Math.Min(offsetScroll.Value + zoomScroll.Value, offsetScroll.Maximum);
				}
				else if (p < offsetScroll.Value)
				{
					offsetScroll.Value = (int)p;
				}

				cursor.Left = noteDisplay.Left + (int)((p - offsetScroll.Value) * noteDisplay.Width / zoomScroll.Value);
				if ((play_start != play_stop) && (cursor.Left > noteDisplay.Width * (Math.Max(play_start, play_stop) - offsetScroll.Value) / zoomScroll.Value))
				{
					StopPlayback();
				}

				//place a cursor in the cut rows as well
				cutRowCursor.Left = cursor.Left;
			}
		}

		void OffsetScrollValueChanged(object sender, EventArgs e)
		{
			offsetLabel.Text = "offset: " + offsetScroll.Value.ToString() + " bars";
			redraw();
		}

		void ZoomScrollValueChanged(object sender, EventArgs e)
		{
			barsEdit.Text = zoomScroll.Value.ToString();
			applyButton.PerformClick();
			if (f != null)
			{
				offsetScroll.Maximum = Math.Max(f.bars - zoomScroll.Value, 0);
				redraw();
			}
		}

		void MainFormClosed(object sender, EventArgs e)
		{
			if (stopButton.Enabled)
			{
				StopPlayback();
			}
		}

		void InstrCheckCheckedChanged(object sender, EventArgs e)
		{
			if (pl != null) pl.Instrument = instrBox.SelectedIndex;
		}

		void InstrBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			if (pl != null) pl.Instrument = instrBox.SelectedIndex;
		}

		void PrintPage(object sender, PrintPageEventArgs ev)
		{
			ev.Graphics.PageUnit = GraphicsUnit.Pixel;

			string s = openMidFileDialog.FileName + " [" + (pages_printed + 1).ToString() + "]";
			ev.Graphics.DrawString(s, drawFont, drawBrush, 0, 0);
			int h0 = (int)(drawFont.Height * ev.Graphics.DpiX / 96);
			int vscale = (int)(ev.Graphics.VisibleClipBounds.Height - h0) / RowsPerPage / (f.max_note - f.min_note);
			int h = vscale * (f.max_note - f.min_note);
			if (pd.PrinterSettings.PrintRange == PrintRange.SomePages && pages_printed < pd.PrinterSettings.FromPage - 1)
				pages_printed = pd.PrinterSettings.FromPage - 1;

			for (int i = 0; i < RowsPerPage; i++)
			{
				if ((RowsPerPage * pages_printed + i) * zoomScroll.Value >= f.bars) break;
				draw_notes(ev.Graphics, (RowsPerPage * pages_printed + i) * zoomScroll.Value, h0 + i * h, vscale);
				ev.Graphics.DrawLine(framepen, 0, h0 + i * h, 0, h0 + (i + 1) * h);
				ev.Graphics.DrawLine(framepen, ev.Graphics.VisibleClipBounds.Width - 1, h0 + i * h, ev.Graphics.VisibleClipBounds.Width - 1, h0 + (i + 1) * h);
				ev.Graphics.DrawLine(framepen, 0, h0 + i * h, ev.Graphics.VisibleClipBounds.Width, h0 + i * h);
				ev.Graphics.DrawLine(framepen, 0, h0 + (i + 1) * h, ev.Graphics.VisibleClipBounds.Width, h0 + (i + 1) * h);
				/*if (qualityCheck.Checked)
				{
					draw_chords(ev.Graphics,(n*pages_printed+i)*zoomScroll.Value,h0+i*h+noteDisplay.Height);
					ev.Graphics.DrawLine(barpen,0,h0+(i+1)*h+noteDisplay.Height,ev.Graphics.VisibleClipBounds.Width,h0+(i+1)*h+noteDisplay.Height);
				}*/
			}
			pages_printed++;
			if (pd.PrinterSettings.PrintRange == PrintRange.SomePages)
			{
				if (pages_printed < pd.PrinterSettings.ToPage)
					ev.HasMorePages = true;
				else ev.HasMorePages = false;
			}
			else
			{
				if (pages_printed * RowsPerPage * zoomScroll.Value < f.bars)
					ev.HasMorePages = true;
				else ev.HasMorePages = false;
			}
		}

		void TempoBarValueChanged(object sender, EventArgs e)
		{
			if (pl != null) pl.Tempo = tempoBar.Value;
			tempoLabel.Text = "tempo: " + tempoBar.Value.ToString() + " bpm";
		}

		void SaveFileDialog1FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MidiFileWriter fw = new MidiFileWriter();
			fw.Write(f, saveMidFileDialog.FileName);
		}

		void TransposeTuningUpDownValueChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < tunings.Length; i++)
				tunings[i].Transpose = (int)transposeTuningUpDown.Value;
			if (f != null)
			{
				update_tuning_avg();
				redraw_chords();
			}
			if (pl != null)
			{
				for (int i = 0; i < tuningRadios.Length; i++)
					if (tuningRadios[i].Checked)
						pl.Tuning = tunings[i];
			}
		}

		void QualityCheckCheckedChanged(object sender, EventArgs e)
		{
			chordDisplay.Visible = qualityCheck.Checked;
			chordNameDisplay.Visible = labelCheck.Checked;
			zoomScroll.Height = noteDisplay.Height;
			if (chordDisplay.Visible)
			{
				chordNameDisplay.Top = chordDisplay.Bottom + 1;
				zoomScroll.Height += chordDisplay.Height + 1;
			}
			else chordNameDisplay.Top = noteDisplay.Bottom + 1;
			if (chordNameDisplay.Visible)
			{
				offsetScroll.Top = chordNameDisplay.Bottom;
				zoomScroll.Height += chordNameDisplay.Height + 1;
			}
			else if (chordDisplay.Visible)
				offsetScroll.Top = chordDisplay.Bottom;
			else
				offsetScroll.Top = noteDisplay.Bottom;
			offsetLabel.Top = offsetScroll.Bottom + 8;
			if (f != null) redraw();
		}

		void Panel2Resize(object sender, EventArgs e)
		{
			if (panel2.Width > 0)
			{
				noteDisplay.Width = panel2.Width - 32;
				chordDisplay.Width = noteDisplay.Width;
				chordNameDisplay.Width = noteDisplay.Width;
				offsetScroll.Width = noteDisplay.Width;
				zoomScroll.Left = noteDisplay.Right;
				noteDisplay.Image = new Bitmap(noteDisplay.Width, noteDisplay.Height);
				chordDisplay.Image = new Bitmap(chordDisplay.Width, chordDisplay.Height);
				chordNameDisplay.Image = new Bitmap(chordNameDisplay.Width, chordNameDisplay.Height);
				if (f != null) redraw();
			}
		}

		void WeightScroll6MajValueChanged(object sender, EventArgs e)
		{
			qualityWeights.M6 = (20 - weightScroll6Maj.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void WeightScroll6minValueChanged(object sender, EventArgs e)
		{
			qualityWeights.m6 = (20 - weightScroll6min.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void WeightScroll5ValueChanged(object sender, EventArgs e)
		{
			qualityWeights.fifth = (20 - weightScroll5.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void WeightScroll4ValueChanged(object sender, EventArgs e)
		{
			qualityWeights.fourth = (20 - weightScroll4.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void WeightScroll3MajValueChanged(object sender, EventArgs e)
		{
			qualityWeights.M3 = (20 - weightScroll3Maj.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void WeightScroll3minValueChanged(object sender, EventArgs e)
		{
			qualityWeights.m3 = (20 - weightScroll3min.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void SaveTxtFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			AnalysisFileWriter w = new AnalysisFileWriter(saveTxtFileDialog.FileName);
			w.WriteTracks(f, (int)transposeFileUpDown.Value);
			w.WriteTunings(tunings);
			w.WriteTuningTranspose((int)transposeTuningUpDown.Value);
			w.WriteWeights(qualityWeights, thresholdUpDown);
			w.WriteChords(chords, f, tunings, qualityWeights);
			w.Close();
			Shell.Execute(saveTxtFileDialog.FileName);
		}

		void WeightScrollCh5ValueChanged(object sender, EventArgs e)
		{
			qualityWeights.Ch5 = (20 - weightScrollCh5.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void WeightScrollCh3ValueChanged(object sender, EventArgs e)
		{
			qualityWeights.Ch3 = (20 - weightScrollCh3.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void TransposeFileUpDownValueChanged(object sender, EventArgs e)
		{
			if (f != null)
			{
				f.Transpose((int)transposeFileUpDown.Value);
				chords = f.FindChords();
				update_tuning_avg();
				redraw();
			}

		}

		void PenaltyScrollAddValueChanged(object sender, EventArgs e)
		{
			qualityWeights.Add = (10 - penaltyScrollAdd.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		void ThresholdUpDownSelectedItemChanged(object sender, EventArgs e)
		{
			if (f != null)
			{
				switch (thresholdUpDown.SelectedIndex)
				{
					case 0: qualityWeights.Threshold = 4 * f.timing; break;
					case 1: qualityWeights.Threshold = 4 * f.timing / 2.0; break;
					case 2: qualityWeights.Threshold = 4 * f.timing / 4.0; break;
					case 3: qualityWeights.Threshold = 4 * f.timing / 8.0; break;
					case 4: qualityWeights.Threshold = 4 * f.timing / 16.0; break;
					case 5: qualityWeights.Threshold = 4 * f.timing / 32.0; break;
					case 6: qualityWeights.Threshold = 4 * f.timing / 64.0; break;
				}
				update_tuning_avg();
				redraw_chords();
			}
		}

		/***** Menu Items Event Handlers Begins *****/
		private void menuItemAdd_Click(object sender, EventArgs e)
		{

		}

		private void MenuItem1Click(object sender, EventArgs e)
		{
			for (int i = 0; i < f.tracks.Length; i++)
				if (contextMenu1.SourceControl == trackChecks[i])
					colorDialog1.Color = trackColors[i];
			colorDialog1.ShowDialog();
			for (int i = 0; i < f.tracks.Length; i++)
				if (contextMenu1.SourceControl == trackChecks[i])
				{
					trackColors[i] = colorDialog1.Color;
					trackChecks[i].ForeColor = colorDialog1.Color;
				}
			redraw();
		}

		private void MenuItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < f.tracks.Length; i++)
				if (sender == menuItems[i])
				{
					f.InsertMarker(i, (int)(play_start * 4 * f.timing), (int)(play_stop * 4 * f.timing));

				}
			//TrackCheckedChanged(null, null);
			trackDisplay = new TrackDisplay(f.tracks, trackColors);

			redraw();
		}

		private void MenuItemRemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < f.tracks.Length; i++)
				if (sender == menuItemsRem[i])
				{
					if (play_start != play_stop)
						f.RemoveMarkers(i, (int)(play_start * 4 * f.timing), (int)(play_stop * 4 * f.timing));
					else f.RemoveAllMarkers(i);

				}
			// TrackCheckedChanged(null, null);
			trackDisplay = new TrackDisplay(f.tracks, trackColors);

			redraw();
		}

		private void MenuItemOpenClick(object sender, EventArgs e)
		{
			openMidFileDialog.ShowDialog();
		}

		private void MenuItemSaveClick(object sender, EventArgs e)
		{
			saveMidFileDialog.ShowDialog();
		}

		private void MenuItemExitClick(object sender, EventArgs e)
		{
			Close();
		}

		private void MenuItemPrintClick(object sender, EventArgs e)
		{
			pd = new PrintDocument();
			pd.DefaultPageSettings.Landscape = true;
			pd.PrintPage += new PrintPageEventHandler(PrintPage);
			pd.PrinterSettings.FromPage = 1;
			pd.PrinterSettings.MaximumPage = Pages;
			pd.PrinterSettings.ToPage = pd.PrinterSettings.MaximumPage;
			pages_printed = 0;
			if (sender.Equals(menuItemPrintPreview))
			{

				PrintPreviewForm ppf = new PrintPreviewForm(RowsPerPage, pd.DefaultPageSettings.PrinterSettings.ToPage, zoomScroll.Value, openMidFileDialog.FileName, f, trackDisplay, rf, pd);
				ppf.Show();

			}
			else
			{
				printDialog1.Document = pd;
				if (printDialog1.ShowDialog() == DialogResult.OK)
					pd.Print();
			}
		}

		private void MenuItemInfoClick(object sender, EventArgs e)
		{
			FileInfoForm fif = new FileInfoForm(f);
			fif.Show();
		}

		private void MenuItemMidi2TxtClick(object sender, EventArgs e)
		{
			if (f == null) return;
			string fn = openMidFileDialog.FileName;
			fn = Path.ChangeExtension(fn, ".txt");
			StreamWriter sw = new StreamWriter(fn);
			foreach (MidiTrack t in f.tracks)
			{
				sw.WriteLine("######## TRACK " + (Array.IndexOf(f.tracks, t) + 1).ToString() + " ########################");
				for (int i = 0; i < t.events.Count; i++)
					sw.WriteLine(t.events[i].ToString());
			}
			sw.Close();
			Shell.Execute(fn);
		}

		private void MenuItemBestClick(object sender, EventArgs e)
		{
			int mini = 0, minj = 0;
			double q, minq = 100;
			for (int i = 0; i < tunings.Length; i++)
				for (int j = 0; j < 12; j++)
				{
					tunings[i].Transpose = j;
					q = tunings[i].AvgQuality(chords, qualityWeights);
					if (q < minq)
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

		private void MenuItemExportClick(object sender, EventArgs e)
		{
			saveTxtFileDialog.FileName = Path.ChangeExtension(f.name, null);
			saveTxtFileDialog.FileName += "_analysis.txt";
			saveTxtFileDialog.ShowDialog();
		}

		/***** Playback Event Handlers Begin *****/
		private void PlayButtonClick(object sender, EventArgs e)
		{
			playButton.Enabled = false;
			pauseButton.Enabled = true;
			stopButton.Enabled = true;
			outputBox.Enabled = false;
			if (play_start == play_stop)
				pl.Play(outputBox.SelectedIndex);
			else
				pl.Play(outputBox.SelectedIndex, Math.Min(play_start, play_stop), Math.Max(play_start, play_stop));
			timer1.Enabled = true;
		}

		private void StopButtonClick(object sender, EventArgs e)
		{
			StopPlayback();
		}

		private void PauseButtonClick(object sender, EventArgs e)
		{
			pl.Pause();
			playButton.Enabled = true;
			pauseButton.Enabled = false;
			timer1.Enabled = false;
		}

		private void VolumeBarScroll(object sender, EventArgs e)
		{
			if (pl != null)
				pl.Volume = ((double)volumeBar.Value) / volumeBar.Maximum;
		}

		/***** Tracks Event Handlers Begin *****/
		void TrackCheckedChanged(object sender, EventArgs e)
		{
			if (f != null)
			{
				for (int i = 0; i < f.tracks.Length; i++)
					f.tracks[i].enabled = trackChecks[i].Checked;
				chords = f.FindChords();
				update_tuning_avg();

				// update the in memory track display
				trackDisplay = new TrackDisplay(f.tracks, trackColors);

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
			int barStart = (int)Math.Round(cutStart);
			int barDiff = (int)Math.Round(cutEnd - cutStart);
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
			cutRow.Size = new System.Drawing.Size((int)Math.Round(width), this.noteDisplay.Height);
			cutRow.Cursor = Cursors.SizeWE;
			cutRow.TabStop = false;
			cutRow.Image = new Bitmap(cutRow.Width, cutRow.Height);
			cutRows.Add(new Tuple<int, int>(barStart, barEnd));

			//we need to listen to these events so we can perform left/right dragging
			cutRow.MouseDown += new MouseEventHandler(this.cutRow_MouseDown);
			cutRow.MouseMove += new MouseEventHandler(this.cutRow_MouseMove);

			//draw note in our cut row
			draw_notes(Graphics.FromImage(cutRow.Image), barStart, 0, 2, barDiff);

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
			if (f != null)
			{
				for (int i = 0; i < tunings.Length; i++)
					tunings[i].enabled = tuningChecks[i].Checked;
				redraw_chords();
			}
		}

		void TuningRadioCheckedChanged(object sender, EventArgs e)
		{
			if (pl != null)
			{
				for (int i = 0; i < tuningRadios.Length; i++)
					if (tuningRadios[i].Checked)
						pl.Tuning = tunings[i];
			}
		}

		/***** Penalties Event Handlers Begin *****/
		private void PenaltyScrollShortValueChanged(object sender, EventArgs e)
		{
			qualityWeights.Short = (10 - penaltyScrollShort.Value) / 10.0;
			update_tuning_avg();
			if (f != null) redraw_chords();
		}

		/***** Print Layout Event Handlers Begin *****/
		private void ApplyButtonClick(object sender, EventArgs e)
		{
			int bars = Int32.Parse(barsEdit.Text);
			RowsPerPage = Int32.Parse(rowsEdit.Text);
			int barspp = bars * RowsPerPage;
			barsPerPageBox.Text = barspp.ToString();
			rf = (float)Double.Parse(factor.Text);
			redraw();
			if (f != null)
			{
				Pages = (int)Math.Ceiling((double)f.bars / barspp);
				pagesBox.Text = Pages.ToString();
			}
			zoomScroll.Value = bars;
		}

		/***** Note Display Event Handlers Begin *****/
		private void NoteDisplayOnMouseLeave(object sender, EventArgs e)
		{
			//hide the hover bar when the mouse is not in range
			this.hoverBar.Visible = false;
		}

		private void NoteDisplayMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				play_start = ((double)e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
				play_stop = play_start;
			}
			else if (e.Button == MouseButtons.Right)
			{
				//save the locations of our cuts
				//we're naming them first and second as opposed to
				//begin and end because first can come after second
				if (cutFirst < 0)
				{
					cutFirst = ((double)e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
					this.cutBarFirst.Visible = true;
					this.cutBarFirst.Left = this.noteDisplay.Left + e.X;
				}
				else if (cutSecond < 0)
				{
					cutSecond = ((double)e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
					this.cutBarSecond.Visible = true;
					this.cutBarSecond.Left = this.noteDisplay.Left + e.X;
				}
			}
		}

		private void NoteDisplayMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (f == null) return;
			int b = e.X * zoomScroll.Value / noteDisplay.Width + offsetScroll.Value + 1;
			int n = ClosestNote(e.X, e.Y);
			if (n >= 0)
			{
				toolTip1.SetToolTip(noteDisplay, "bar " + b.ToString() + "\n" + KeyList.NoteName(n));
			}
			else
			{
				toolTip1.SetToolTip(noteDisplay, "bar " + b.ToString());
			}
			if ((e.Button == MouseButtons.Left) && (play_start >= 0))
			{
				play_stop = ((double)e.X * zoomScroll.Value) / noteDisplay.Width + offsetScroll.Value;
				redraw_notes();
				if (play_stop != play_start)
				{
					menuItemAdd.Enabled = true;
				}
				else
				{
					menuItemAdd.Enabled = false;
				}
			}
			noteDisplay.Refresh();

			this.hoverBar.Visible = true;
			this.hoverBar.Left = this.noteDisplay.Left + e.X;
		}

		/***** Chord Display Event Handlers Begin *****/
		private void ChordDisplayMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (f == null) return;
			int b = e.X * zoomScroll.Value / chordDisplay.Width + offsetScroll.Value + 1;
			toolTip1.SetToolTip(chordDisplay, "bar " + b.ToString());
		}

		/***** Cut Panel Event Handlers Begin *****/
		private void cutRow_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				//this will be the point where we start out dragging
				cutRowDragX = e.X;
			}
		}

		private void cutRow_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			PictureBox p = sender as PictureBox;
			if (p != null && e.Button == MouseButtons.Left && cutRowDragX > 0)
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
			return openMidFileDialog.FileName;
		}

		private bool IsNote(Bitmap bm, int x, int y)
		{
			switch (unchecked((uint)bm.GetPixel(x, y).ToArgb()))
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
			Bitmap bm = (Bitmap)noteDisplay.Image;
			if (x < 0 || x >= bm.Width || y < 0 || y >= bm.Height)
				return -1;
			if (IsNote(bm, x, y))
			{
				Color c = bm.GetPixel(x, y);
				if (y + 2 < bm.Height && bm.GetPixel(x, y + 2) == c)
					return f.max_note - (y + 2) / 2;
				else if (y > 1 && bm.GetPixel(x, y - 2) == c)
					return f.max_note - (y) / 2;
				else return f.max_note - (y + 1) / 2;
			}
			if (y + 1 < bm.Height && IsNote(bm, x, y + 1))
			{
				Color c = bm.GetPixel(x, y + 1);
				if (y + 3 < bm.Height && bm.GetPixel(x, y + 3) == c)
					return f.max_note - (y + 4) / 2;
				else return f.max_note - (y + 2) / 2;
			}
			if (y > 0 && IsNote(bm, x, y - 1))
			{
				Color c = bm.GetPixel(x, y - 1);
				if (y > 2 && bm.GetPixel(x, y - 3) == c)
					return f.max_note - (y - 2) / 2;
				else return f.max_note - (y) / 2;
			}
			if (y + 2 < bm.Height && IsNote(bm, x, y + 2))
			{
				Color c = bm.GetPixel(x, y + 2);
				if (y + 4 < bm.Height && bm.GetPixel(x, y + 4) == c)
					return f.max_note - (y + 5) / 2;
				else return f.max_note - (y + 3) / 2;
			}
			if (y > 1 && IsNote(bm, x, y - 2))
			{
				Color c = bm.GetPixel(x, y - 2);
				if (y > 3 && bm.GetPixel(x, y - 4) == c)
					return f.max_note - (y - 3) / 2;
				else return f.max_note - (y - 1) / 2;
			}
			return -1;
		}

		void update_tuning_avg()
		{
			if (chords == null) return;
			for (int i = 0; i < tunings.Length; i++)
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
			draw_notes(Graphics.FromImage(noteDisplay.Image), offsetScroll.Value, 0, 2);
		}

		void redraw_chords()
		{
			Graphics.FromImage(chordDisplay.Image).Clear(Color.White);
			draw_chords(Graphics.FromImage(chordDisplay.Image), offsetScroll.Value, 0);
			Graphics.FromImage(chordNameDisplay.Image).Clear(Color.White);
			draw_chordnames(Graphics.FromImage(chordNameDisplay.Image), offsetScroll.Value, 0);
		}

		// draw piano roll, starting at bar offset
		void draw_notes(Graphics gr, int offset, int y0, int vscale)
		{
			draw_notes(gr, offset, y0, vscale, zoomScroll.Value);
		}

		void draw_notes(Graphics gr, int offset, int y0, int vscale, int zoomValue)
		{
			int grw = (int)(gr.VisibleClipBounds.Width);
			int grh = vscale * (f.max_note - f.min_note);
			// draw bar markers & bar numbers
			if (zoomValue < 100)
				for (int i = 0; i < zoomValue; i++)
				{
					if (i > 0) gr.DrawLine(barpen, i * grw / zoomValue, y0, i * grw / zoomValue, y0 + grh);
					if ((offset + i) % zoomValue == 0) gr.DrawString((offset + i + 1).ToString(), smallFont, drawBrush, i * grw / zoomValue, y0);
				}
			// draw horizontal orientation lines at each D,F and A
			int y;
			for (int a = 0; a < 10; a++)
			{
				int b = a * 12 + 2;
				if (b < f.max_note && b > f.min_note)
				{
					y = vscale * (f.max_note - b) + y0;
					gr.DrawLine(barpen, 0, y, gr.VisibleClipBounds.Width, y);
				}
				b = a * 12 + 5;
				if (b < f.max_note && b > f.min_note)
				{
					y = vscale * (f.max_note - b) + y0;
					gr.DrawLine(orientpen, 0, y, gr.VisibleClipBounds.Width, y);
				}
				b = a * 12 + 9;
				if (b < f.max_note && b > f.min_note)
				{
					y = vscale * (f.max_note - b) + y0;
					gr.DrawLine(orientpen, 0, y, gr.VisibleClipBounds.Width, y);
				}
			}
			//
			// draw notes

			if (trackDisplay != null)
			{
				trackDisplay.Draw(gr, grw, y0, f.max_note, offset,
								  f.timing, zoomValue, vscale, rf);
			}

			// draw selection
			if (play_start >= 0)
			{
				Brush sel_brush = new SolidBrush(selectColor);
				int x = (int)(grw * (Math.Min(play_start, play_stop) - offset) / zoomValue);
				int w = (int)(grw * Math.Abs(play_stop - play_start) / zoomValue);
				gr.FillRectangle(sel_brush, x, 0, w, grh);
			}
			noteDisplay.Refresh();
		}

		void draw_chords(Graphics gr, int offset, int y0)
		{
			if (!chordDisplay.Visible) return;
			int grw = (int)(gr.VisibleClipBounds.Width);
			int grh = chordDisplay.Height;
			int mintime = offset * 4 * f.timing;
			int maxtime = (offset + zoomScroll.Value + 1) * 4 * f.timing;
			int x1, x2, y;
			// draw bar markers for chord display
			if (zoomScroll.Value < 100)
				for (int i = 1; i < zoomScroll.Value; i++)
					gr.DrawLine(barpen, i * grw / zoomScroll.Value, y0, i * grw / zoomScroll.Value, y0 + grh);
			// draw chords
			int q;
			for (int i = 0; i < tunings.Length; i++)
				if (tunings[i].enabled)
				{
					pen.Color = colors[i];
					thinpen.Color = colors[i];
					foreach (TimeInfo c in chords)
					{
						if (c.Time > maxtime) break;
						if (c.Time >= mintime && qualityWeights.enabled(c))
						{
							x1 = grw * (c.Time - 4 * offset * f.timing) / f.timing / 4 / zoomScroll.Value;
							x2 = grw * (c.Time + c.Duration - 4 * offset * f.timing) / f.timing / 4 / zoomScroll.Value;
							q = (int)tunings[i].Quality(c, qualityWeights);
							y = y0 + grh - 1 - 2 * q;
							if (c.IsChord) gr.DrawLine(pen, x1, y, x2, y);
							else gr.DrawLine(thinpen, x1, y, x2, y);
						}
					}
				}
			chordDisplay.Refresh();
		}

		void draw_chordnames(Graphics gr, int offset, int y0)
		{
			if (!chordNameDisplay.Visible) return;
			int grw = (int)(gr.VisibleClipBounds.Width);
			int mintime = offset * 4 * f.timing;
			int maxtime = (offset + zoomScroll.Value + 1) * 4 * f.timing;
			int x;
			string s;
			foreach (TimeInfo c in chords)
			{
				if (c.Time > maxtime) break;
				if (c.Time >= mintime && qualityWeights.enabled(c))
				{
					s = c.Name;
					x = grw * (c.Time - 4 * offset * f.timing) / f.timing / 4 / zoomScroll.Value;
					if (c.IsChord)
					{
						gr.DrawString(s.Substring(0, 1), drawFont, drawBrush, x, y0);
						if (s.Length > 1) gr.DrawString(s.Substring(1, 1), drawFont, drawBrush, x, y0 + drawFont.Size);
					}
					else
					{
						gr.DrawString(s.Substring(0, 1), smallFont, drawBrush, x, y0);
						if (s.Length > 1) gr.DrawString(s.Substring(1, 1), smallFont, drawBrush, x, y0 + smallFont.Size);
						if (s.Length > 2) gr.DrawString(s.Substring(2, 1), smallFont, drawBrush, x, y0 + 2 * smallFont.Size);
					}
				}
			}
			chordNameDisplay.Refresh();
		}

		void StopPlayback()
		{
			pl.Stop();
			playButton.Enabled = true;
			stopButton.Enabled = false;
			pauseButton.Enabled = false;
			outputBox.Enabled = true;
			timer1.Enabled = false;
			cursor.Left = noteDisplay.Left;

			///get rid of the cut row cursor
			this.cutRowCursor.Visible = false;
			foreach(PictureBox p in this.cutPanel.Controls)
			{
				
			}
		}
	}

	class TransparentPanel : Panel
    {
		//from http://stackoverflow.com/questions/547172/pass-through-mouse-events-to-parent-control
		protected override void WndProc(ref Message m)
		{
			const int WM_NCHITTEST = 0x0084;
			const int HTTRANSPARENT = (-1);

			if (m.Msg == WM_NCHITTEST)
			{
				m.Result = (IntPtr)HTTRANSPARENT;
			}
			else
			{
				base.WndProc(ref m);
			}
		}
	}
}



