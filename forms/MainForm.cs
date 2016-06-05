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
        private Button applyButton;
        private TextBox barsPerPageBox;
        private PrintPreviewControl printPreviewDialog1;
        private Timer timer1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label9;
        private ToolTip toolTip1;
        private PictureBox chordNameDisplay;
        private Panel cursor;
        private TextBox barsEdit;
        private PictureBox noteDisplay;
        private Panel panel2;
        private Panel panel1;
        private TextBox rowsEdit;
        private HScrollBar offsetScroll;
        private TextBox pagesBox;
        private PictureBox chordDisplay;
        private VScrollBar zoomScroll;
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
        private ISubscription<TracksChangedMessage> tracksChangedSubscription;
        private ISubscription<TrackColorChangedMessage> trackColorChangedSubscription;
        private ISubscription<PenaltiesChangedMessage> penaltiesChangedSubscription;
        private ISubscription<PenaltyScrollChangedMessage> penaltyScrollSubscription;
        private ISubscription<QualityWeightScrollChangedMessage> qualityWeightScrollSubscription;
        private ISubscription<TuningsTransposedMessage> tuningTransposeSubscription;
        private ISubscription<TuningEnabledMessage> tuningEnabledSubscription;
        private ISubscription<QualityCheckChangedMessage> qualityCheckSubscription;
        private ISubscription<LabelCheckChangedMessage> labelCheckSubscription;
        private controls.FileTransposeControl fileTransposeControl1;
        private PlaybackControl playbackControl;
        private PianoRollArtist artist;
        private controls.MainMenuControl mainMenuControl1;
        private controls.TrackControl trackControl1;
        private controls.TuningControl tuningControl1;
        private PrintDocumentProvider printDocProvider;



        public MainForm()
        {
            InitializeComponent();
            initializeSubscriptions();
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
            this.zoomScroll = new System.Windows.Forms.VScrollBar();
            this.chordDisplay = new System.Windows.Forms.PictureBox();
            this.pagesBox = new System.Windows.Forms.TextBox();
            this.offsetScroll = new System.Windows.Forms.HScrollBar();
            this.rowsEdit = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tuningControl1 = new ChordQuality.controls.TuningControl();
            this.trackControl1 = new ChordQuality.controls.TrackControl();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cutPanel = new System.Windows.Forms.Panel();
            this.cutBarSecond = new ChordQuality.TransparentPanel();
            this.cutBarFirst = new ChordQuality.TransparentPanel();
            this.chordNameDisplay = new System.Windows.Forms.PictureBox();
            this.cursor = new System.Windows.Forms.Panel();
            this.hoverBar = new ChordQuality.TransparentPanel();
            this.noteDisplay = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewControl();
            this.cutRowCursor = new System.Windows.Forms.Panel();
            this.mainMenuControl1 = new ChordQuality.controls.MainMenuControl();
            ((System.ComponentModel.ISupportInitialize)(this.chordDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.layoutBox.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chordNameDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteDisplay)).BeginInit();
            this.SuspendLayout();
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
            // pagesBox
            // 
            this.pagesBox.Location = new System.Drawing.Point(88, 127);
            this.pagesBox.Name = "pagesBox";
            this.pagesBox.ReadOnly = true;
            this.pagesBox.Size = new System.Drawing.Size(32, 20);
            this.pagesBox.TabIndex = 7;
            this.pagesBox.Text = "0";
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.tuningControl1);
            this.panel1.Controls.Add(this.trackControl1);
            this.panel1.Controls.Add(this.fileTransposeControl1);
            this.panel1.Controls.Add(this.playbackControl);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.layoutBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 457);
            this.panel1.TabIndex = 45;
            // 
            // tuningControl1
            // 
            this.tuningControl1.AutoSize = true;
            this.tuningControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tuningControl1.Location = new System.Drawing.Point(546, 6);
            this.tuningControl1.Name = "tuningControl1";
            this.tuningControl1.Size = new System.Drawing.Size(566, 238);
            this.tuningControl1.TabIndex = 51;
            // 
            // trackControl1
            // 
            this.trackControl1.AutoSize = true;
            this.trackControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trackControl1.Location = new System.Drawing.Point(309, 3);
            this.trackControl1.Name = "trackControl1";
            this.trackControl1.Size = new System.Drawing.Size(231, 179);
            this.trackControl1.TabIndex = 60;
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
            this.panel2.Location = new System.Drawing.Point(0, 487);
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
            this.mainMenuControl1.AutoSize = true;
            this.mainMenuControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainMenuControl1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.mainMenuControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenuControl1.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl1.Name = "mainMenuControl1";
            this.mainMenuControl1.Size = new System.Drawing.Size(1228, 24);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.layoutBox.ResumeLayout(false);
            this.layoutBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chordNameDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
            tracksChangedSubscription = eventAggregator.Subscribe<TracksChangedMessage>(Message =>
            {
                onTracksChanged();
            });
            trackColorChangedSubscription = eventAggregator.Subscribe<TrackColorChangedMessage>(Message =>
            {
                redraw();
            });
            penaltiesChangedSubscription = eventAggregator.Subscribe<PenaltiesChangedMessage>(Message =>
            {
                update_tuning_avg();
                redraw_chords();
            });
            penaltyScrollSubscription = eventAggregator.Subscribe<PenaltyScrollChangedMessage>(Message =>
            {
                update_tuning_avg();
                if(f != null)
                    redraw_chords();
            });
            qualityWeightScrollSubscription = eventAggregator.Subscribe<QualityWeightScrollChangedMessage>(Message =>
            {
                update_tuning_avg();

                if(f != null)
                    redraw_chords();
            });
            tuningTransposeSubscription = eventAggregator.Subscribe<TuningsTransposedMessage>(Message =>
            {
                if(f != null)
                {
                    update_tuning_avg();
                    redraw_chords();
                }
            });
            tuningEnabledSubscription = eventAggregator.Subscribe<TuningEnabledMessage>(Message =>
            {
                redraw_chords();
            });
            qualityCheckSubscription = eventAggregator.Subscribe<QualityCheckChangedMessage>(Message =>
            {
                chordDisplay.Visible = Message.checkStatus;
                updateDisplay();
            });
            labelCheckSubscription = eventAggregator.Subscribe<LabelCheckChangedMessage>(Message =>
            {
                chordNameDisplay.Visible = Message.checkStatus;
                updateDisplay();
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
        
        MidiFilePlayer pl = null;
        ArrayList chords;
        TuningScheme[] tunings;
        double play_start = -1, play_stop = -1;
        
        QualityWeights qualityWeights;

        int RowsPerPage = 5, Pages = 0;
        TrackDisplay trackDisplay = null;

        //the starting and ending bar for each cut row
        ArrayList cutRows = new ArrayList();
        double cutFirst = -1, cutSecond = -1;
        int cutRowDragX = -1;

        void MainFormLoad(object sender, EventArgs e)
        {
            // misc init.'s            
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
            pMessage.playStart = play_start;
            pMessage.playStop = play_stop;
            eventAggregator.Publish(pMessage);

            // load the track display into memory
            trackDisplay = new TrackDisplay(f.tracks, trackColors);
            TrackDisplayChangedMessage tmessage = new TrackDisplayChangedMessage();
            tmessage.trackDisplay = trackDisplay;
            eventAggregator.Publish(tmessage);


            

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
            updateDisplay();
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
                Stop();
            }
        }


       
        private void updateDisplay()
        {
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
            tuningControl1.setTranspose(minj);            
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
        }

        private void Pause()
        {
            pl.Pause();
            timer1.Enabled = false;
        }

        void onTracksChanged()
        {
            chords = f.FindChords();
            update_tuning_avg();

            // update the in memory track display
            trackDisplay = new TrackDisplay(f.tracks, trackColors);
            TrackDisplayChangedMessage tmessage = new TrackDisplayChangedMessage();
            tmessage.trackDisplay = trackDisplay;
            eventAggregator.Publish(tmessage);

            redraw();
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
            if(chords != null)
                tuningControl1.updateTuningAverage(chords, qualityWeights);            
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