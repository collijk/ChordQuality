using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ChordQuality.controls;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.services;
using Janus.ManagedMIDI;
using System.Collections.Generic;

namespace ChordQuality.views
{
    public class MainForm : Form
    {
        //the starting and ending bar for each cut row
        private readonly ArrayList _cutRows = new ArrayList();

        private readonly Color[] _trackColors = new Color[]
        {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black
        };

        private PianoRollArtist _artist;
        private ISubscription<FindBestTuningsMessage> _bestTuningsSubscription;
        private PictureBox _chordDisplay;
        private PictureBox _chordNameDisplay;
        private ArrayList _chords;
        private ISubscription<CloseRequestMessage> _closeRequestSubscription;

        


        private IContainer components;
        private Panel _cursor;
        private TransparentPanel _cutBarFirst;
        private TransparentPanel _cutBarSecond;
        private Button _cutClrBtn;
        private Button _cutCutBtn;
        private double _cutFirst = -1;
        private Panel _cutPanel;
        private Button _cutResetBtn;
        private Panel _cutRowCursor;
        private int _cutRowDragX = -1;
        private double _cutSecond = -1;
        private IEventAggregator _eventAggregator;
        //test
        private MidiFile _currentFile;
        private FileTransposeControl _fileTransposeControl1;
        private ISubscription<FileTransposedMessage> _fileTransposeSubscription;
        private GroupBox _groupBox1;
        private TransparentPanel _hoverBar;
        private ISubscription<LabelCheckChangedMessage> _labelCheckSubscription;
        private MainMenuControl _mainMenuControl1;
        private ISubscription<MarkersChangedMessage> _markersChangedSubscription;
        private ISubscription<FileOpenedMessage> _midiFileSubscription;
        private ISubscription<MidiPlayerUpdatedMessage> _midiPlayerSubscription;
        private PictureBox _noteDisplay;
        private HScrollBar _offsetScroll;
        private Panel _panel1;
        private Panel _panel2;
        private ISubscription<PauseMessage> _pauseSubscription;
        private ISubscription<PenaltiesChangedMessage> _penaltiesChangedSubscription;
        private ISubscription<PenaltyScrollChangedMessage> _penaltyScrollSubscription;

        private MidiFilePlayer _pl;
        private double _playStart;
        private double _playStop;
        private PlaybackControl _playbackControl;
        private ISubscription<PlayMessage> _playSubscription;
        private PrintDocumentProvider _printDocProvider;
        private PrintingControl _printingControl1;
        private PrintPreviewControl _printPreviewDialog1;
        private ISubscription<QualityCheckChangedMessage> _qualityCheckSubscription;
        private QualityWeights _qualityWeights;
        private ISubscription<QualityWeightScrollChangedMessage> _qualityWeightScrollSubscription;
        private ISubscription<StopMessage> _stopSubscription;
        private Timer _timer1;
        private ToolTip _toolTip1;
        private ISubscription<TrackColorChangedMessage> _trackColorChangedSubscription;

        private TrackControl _trackControl1;
        private TrackDisplay _trackDisplay;
        private ISubscription<TracksChangedMessage> _tracksChangedSubscription;
        private TuningControl _tuningControl1;
        private ISubscription<TuningEnabledMessage> _tuningEnabledSubscription;
        private TuningScheme[] _tunings;
        private ISubscription<TuningsTransposedMessage> _tuningTransposeSubscription;
        private ZoomControl _zoomControl1;
        private ISubscription<ZoomScrollChangedMessage> _zoomUpdatedMessage;
        private int _zoomValue = 15;


        public MainForm()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        #region Windows Forms Designer generated code

        /// <summary>
        ///     This method is required for Windows Forms designer support.
        ///     Do not change the method contents inside the source code editor. The Forms designer might
        ///     not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._chordDisplay = new System.Windows.Forms.PictureBox();
            this._offsetScroll = new System.Windows.Forms.HScrollBar();
            this._panel1 = new System.Windows.Forms.Panel();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._cutClrBtn = new System.Windows.Forms.Button();
            this._cutCutBtn = new System.Windows.Forms.Button();
            this._cutResetBtn = new System.Windows.Forms.Button();
            this._panel2 = new System.Windows.Forms.Panel();
            this._cutPanel = new System.Windows.Forms.Panel();
            this._chordNameDisplay = new System.Windows.Forms.PictureBox();
            this._cursor = new System.Windows.Forms.Panel();
            this._noteDisplay = new System.Windows.Forms.PictureBox();
            this._toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._timer1 = new System.Windows.Forms.Timer(this.components);
            this._printPreviewDialog1 = new System.Windows.Forms.PrintPreviewControl();
            this._cutRowCursor = new System.Windows.Forms.Panel();
            this._zoomControl1 = new ChordQuality.controls.ZoomControl();
            this._printingControl1 = new ChordQuality.controls.PrintingControl();
            this._tuningControl1 = new ChordQuality.controls.TuningControl();
            this._trackControl1 = new ChordQuality.controls.TrackControl();
            this._fileTransposeControl1 = new ChordQuality.controls.FileTransposeControl();
            this._playbackControl = new ChordQuality.controls.PlaybackControl();
            this._mainMenuControl1 = new ChordQuality.controls.MainMenuControl();
            this._cutBarSecond = new ChordQuality.views.TransparentPanel();
            this._cutBarFirst = new ChordQuality.views.TransparentPanel();
            this._hoverBar = new ChordQuality.views.TransparentPanel();
            ((System.ComponentModel.ISupportInitialize)(this._chordDisplay)).BeginInit();
            this._panel1.SuspendLayout();
            this._groupBox1.SuspendLayout();
            this._panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chordNameDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._noteDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // _chordDisplay
            // 
            this._chordDisplay.BackColor = System.Drawing.Color.White;
            this._chordDisplay.Location = new System.Drawing.Point(8, 56);
            this._chordDisplay.Name = "_chordDisplay";
            this._chordDisplay.Size = new System.Drawing.Size(960, 48);
            this._chordDisplay.TabIndex = 42;
            this._chordDisplay.TabStop = false;
            // 
            // _offsetScroll
            // 
            this._offsetScroll.LargeChange = 1;
            this._offsetScroll.Location = new System.Drawing.Point(8, 125);
            this._offsetScroll.Maximum = 0;
            this._offsetScroll.Name = "_offsetScroll";
            this._offsetScroll.Size = new System.Drawing.Size(960, 12);
            this._offsetScroll.TabIndex = 41;
            // 
            // _panel1
            // 
            this._panel1.AutoScroll = true;
            this._panel1.AutoSize = true;
            this._panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this._panel1.Controls.Add(this._zoomControl1);
            this._panel1.Controls.Add(this._printingControl1);
            this._panel1.Controls.Add(this._tuningControl1);
            this._panel1.Controls.Add(this._trackControl1);
            this._panel1.Controls.Add(this._fileTransposeControl1);
            this._panel1.Controls.Add(this._playbackControl);
            this._panel1.Controls.Add(this._groupBox1);
            this._panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this._panel1.Location = new System.Drawing.Point(0, 24);
            this._panel1.Name = "_panel1";
            this._panel1.Size = new System.Drawing.Size(1280, 313);
            this._panel1.TabIndex = 45;
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._cutClrBtn);
            this._groupBox1.Controls.Add(this._cutCutBtn);
            this._groupBox1.Controls.Add(this._cutResetBtn);
            this._groupBox1.Location = new System.Drawing.Point(554, 250);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(200, 60);
            this._groupBox1.TabIndex = 55;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Cut";
            // 
            // _cutClrBtn
            // 
            this._cutClrBtn.Location = new System.Drawing.Point(133, 17);
            this._cutClrBtn.Name = "_cutClrBtn";
            this._cutClrBtn.Size = new System.Drawing.Size(56, 37);
            this._cutClrBtn.TabIndex = 2;
            this._cutClrBtn.Text = "Clear\r\nDisplay";
            this._cutClrBtn.UseVisualStyleBackColor = true;
            // 
            // _cutCutBtn
            // 
            this._cutCutBtn.Location = new System.Drawing.Point(70, 17);
            this._cutCutBtn.Name = "_cutCutBtn";
            this._cutCutBtn.Size = new System.Drawing.Size(56, 37);
            this._cutCutBtn.TabIndex = 1;
            this._cutCutBtn.Text = "Cut";
            this._cutCutBtn.UseVisualStyleBackColor = true;
            // 
            // _cutResetBtn
            // 
            this._cutResetBtn.Location = new System.Drawing.Point(8, 17);
            this._cutResetBtn.Name = "_cutResetBtn";
            this._cutResetBtn.Size = new System.Drawing.Size(56, 37);
            this._cutResetBtn.TabIndex = 0;
            this._cutResetBtn.Text = "Reset\r\nMarker";
            this._cutResetBtn.UseVisualStyleBackColor = true;
            // 
            // _panel2
            // 
            this._panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this._panel2.Controls.Add(this._cutPanel);
            this._panel2.Controls.Add(this._cutBarSecond);
            this._panel2.Controls.Add(this._cutBarFirst);
            this._panel2.Controls.Add(this._chordNameDisplay);
            this._panel2.Controls.Add(this._chordDisplay);
            this._panel2.Controls.Add(this._offsetScroll);
            this._panel2.Controls.Add(this._cursor);
            this._panel2.Controls.Add(this._hoverBar);
            this._panel2.Controls.Add(this._noteDisplay);
            this._panel2.Location = new System.Drawing.Point(0, 314);
            this._panel2.Name = "_panel2";
            this._panel2.Size = new System.Drawing.Size(1280, 396);
            this._panel2.TabIndex = 46;
            // 
            // _cutPanel
            // 
            this._cutPanel.AutoScroll = true;
            this._cutPanel.Location = new System.Drawing.Point(8, 140);
            this._cutPanel.Name = "_cutPanel";
            this._cutPanel.Size = new System.Drawing.Size(976, 235);
            this._cutPanel.TabIndex = 47;
            // 
            // _chordNameDisplay
            // 
            this._chordNameDisplay.BackColor = System.Drawing.Color.White;
            this._chordNameDisplay.Location = new System.Drawing.Point(8, 109);
            this._chordNameDisplay.Name = "_chordNameDisplay";
            this._chordNameDisplay.Size = new System.Drawing.Size(960, 25);
            this._chordNameDisplay.TabIndex = 46;
            this._chordNameDisplay.TabStop = false;
            // 
            // _cursor
            // 
            this._cursor.BackColor = System.Drawing.Color.Red;
            this._cursor.Location = new System.Drawing.Point(8, 6);
            this._cursor.Name = "_cursor";
            this._cursor.Size = new System.Drawing.Size(1, 47);
            this._cursor.TabIndex = 30;
            // 
            // _noteDisplay
            // 
            this._noteDisplay.BackColor = System.Drawing.Color.White;
            this._noteDisplay.Location = new System.Drawing.Point(8, 6);
            this._noteDisplay.Name = "_noteDisplay";
            this._noteDisplay.Size = new System.Drawing.Size(960, 47);
            this._noteDisplay.TabIndex = 29;
            this._noteDisplay.TabStop = false;
            // 
            // _timer1
            // 
            this._timer1.Interval = 10;
            // 
            // _printPreviewDialog1
            // 
            this._printPreviewDialog1.Location = new System.Drawing.Point(0, 0);
            this._printPreviewDialog1.Name = "_printPreviewDialog1";
            this._printPreviewDialog1.Size = new System.Drawing.Size(100, 100);
            this._printPreviewDialog1.TabIndex = 0;
            // 
            // _cutRowCursor
            // 
            this._cutRowCursor.BackColor = System.Drawing.Color.Red;
            this._cutRowCursor.Location = new System.Drawing.Point(8, 6);
            this._cutRowCursor.Name = "_cutRowCursor";
            this._cutRowCursor.Size = new System.Drawing.Size(1, 47);
            this._cutRowCursor.TabIndex = 0;
            this._cutRowCursor.Visible = false;
            // 
            // _zoomControl1
            // 
            this._zoomControl1.AutoSize = true;
            this._zoomControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._zoomControl1.Location = new System.Drawing.Point(175, 217);
            this._zoomControl1.Name = "_zoomControl1";
            this._zoomControl1.Size = new System.Drawing.Size(209, 86);
            this._zoomControl1.TabIndex = 0;
            // 
            // _printingControl1
            // 
            this._printingControl1.AutoSize = true;
            this._printingControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._printingControl1.Location = new System.Drawing.Point(1126, 6);
            this._printingControl1.Name = "_printingControl1";
            this._printingControl1.Size = new System.Drawing.Size(127, 195);
            this._printingControl1.TabIndex = 61;
            // 
            // _tuningControl1
            // 
            this._tuningControl1.AutoSize = true;
            this._tuningControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tuningControl1.Location = new System.Drawing.Point(554, 6);
            this._tuningControl1.Name = "_tuningControl1";
            this._tuningControl1.Size = new System.Drawing.Size(566, 238);
            this._tuningControl1.TabIndex = 51;
            // 
            // _trackControl1
            // 
            this._trackControl1.AutoSize = true;
            this._trackControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._trackControl1.Location = new System.Drawing.Point(317, 3);
            this._trackControl1.Name = "_trackControl1";
            this._trackControl1.Size = new System.Drawing.Size(231, 179);
            this._trackControl1.TabIndex = 60;
            // 
            // _fileTransposeControl1
            // 
            this._fileTransposeControl1.AutoSize = true;
            this._fileTransposeControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._fileTransposeControl1.Location = new System.Drawing.Point(8, 217);
            this._fileTransposeControl1.Name = "_fileTransposeControl1";
            this._fileTransposeControl1.Size = new System.Drawing.Size(161, 73);
            this._fileTransposeControl1.TabIndex = 1;
            // 
            // _playbackControl
            // 
            this._playbackControl.AutoSize = true;
            this._playbackControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._playbackControl.Location = new System.Drawing.Point(8, 3);
            this._playbackControl.Name = "_playbackControl";
            this._playbackControl.Size = new System.Drawing.Size(303, 208);
            this._playbackControl.TabIndex = 59;
            // 
            // _mainMenuControl1
            // 
            this._mainMenuControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this._mainMenuControl1.AutoSize = true;
            this._mainMenuControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._mainMenuControl1.BackColor = System.Drawing.SystemColors.MenuBar;
            this._mainMenuControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this._mainMenuControl1.Location = new System.Drawing.Point(0, 0);
            this._mainMenuControl1.Name = "_mainMenuControl1";
            this._mainMenuControl1.Size = new System.Drawing.Size(1280, 24);
            this._mainMenuControl1.TabIndex = 60;
            // 
            // _cutBarSecond
            // 
            this._cutBarSecond.BackColor = System.Drawing.Color.BlueViolet;
            this._cutBarSecond.Location = new System.Drawing.Point(8, 6);
            this._cutBarSecond.Name = "_cutBarSecond";
            this._cutBarSecond.Size = new System.Drawing.Size(1, 47);
            this._cutBarSecond.TabIndex = 31;
            this._cutBarSecond.Visible = false;
            // 
            // _cutBarFirst
            // 
            this._cutBarFirst.BackColor = System.Drawing.Color.BlueViolet;
            this._cutBarFirst.Location = new System.Drawing.Point(8, 6);
            this._cutBarFirst.Name = "_cutBarFirst";
            this._cutBarFirst.Size = new System.Drawing.Size(1, 47);
            this._cutBarFirst.TabIndex = 31;
            this._cutBarFirst.Visible = false;
            // 
            // _hoverBar
            // 
            this._hoverBar.BackColor = System.Drawing.Color.DarkGray;
            this._hoverBar.Location = new System.Drawing.Point(8, 6);
            this._hoverBar.Name = "_hoverBar";
            this._hoverBar.Size = new System.Drawing.Size(1, 47);
            this._hoverBar.TabIndex = 31;
            this._hoverBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1280, 701);
            this.Controls.Add(this._panel1);
            this.Controls.Add(this._mainMenuControl1);
            this.Controls.Add(this._panel2);
            this.Name = "MainForm";
            this.Text = "ChordQuality";
            ((System.ComponentModel.ISupportInitialize)(this._chordDisplay)).EndInit();
            this._panel1.ResumeLayout(false);
            this._panel1.PerformLayout();
            this._groupBox1.ResumeLayout(false);
            this._panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chordNameDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._noteDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void InitializeServices()
        {
            _artist = new PianoRollArtist(_noteDisplay, _chordDisplay, _tunings, _qualityWeights, _chordNameDisplay);
            _printDocProvider = PrintDocumentProvider.Instance;
            _printDocProvider.SetArtist(_artist);
        }

        private void InitializeSubscriptions()
        {
            _chordDisplay.MouseMove += ChordDisplayMouseMove;
            _offsetScroll.ValueChanged += OffsetScrollValueChanged;
            _cutClrBtn.Click += cutClrBtn_Click;
            _cutCutBtn.Click += cutCutBtn_Click;
            _cutResetBtn.Click += cutResetBtn_Click;
            _panel2.Resize += Panel2Resize;
            _noteDisplay.MouseDown += NoteDisplayMouseDown;
            _noteDisplay.MouseLeave += NoteDisplayOnMouseLeave;
            _noteDisplay.MouseMove += NoteDisplayMouseMove;
            _timer1.Tick += Timer1Tick;
            Closed += MainFormClosed;
            Load += MainFormLoad;

            _eventAggregator = EventAggregator.Instance;
            _playSubscription = _eventAggregator.Subscribe<PlayMessage>(message => { Play(message.DeviceIndex); });
            _pauseSubscription = _eventAggregator.Subscribe<PauseMessage>(message => { Pause(); });
            _stopSubscription = _eventAggregator.Subscribe<StopMessage>(message => { Stop(); });
            _midiPlayerSubscription =
                _eventAggregator.Subscribe<MidiPlayerUpdatedMessage>(message => { UpdatePlayer(message.Player); });
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileOpenedMessage>(message => { OnFileOpened(message.File); });
            _fileTransposeSubscription = _eventAggregator.Subscribe<FileTransposedMessage>(message =>
            {
                _chords = message.Chords;
                update_tuning_avg();
                Redraw();
            });
            _closeRequestSubscription = _eventAggregator.Subscribe<CloseRequestMessage>(message => { Close(); });
            _markersChangedSubscription =
                _eventAggregator.Subscribe<MarkersChangedMessage>(message => { OnMarkersChanged(); });
            _bestTuningsSubscription =
                _eventAggregator.Subscribe<FindBestTuningsMessage>(message => { FindBestTunings(); });
            _tracksChangedSubscription =
                _eventAggregator.Subscribe<TracksChangedMessage>(message => { OnTracksChanged(); });
            _trackColorChangedSubscription = _eventAggregator.Subscribe<TrackColorChangedMessage>(message => { Redraw(); });
            _penaltiesChangedSubscription = _eventAggregator.Subscribe<PenaltiesChangedMessage>(message =>
            {
                update_tuning_avg();
                redraw_chords();
            });
            _penaltyScrollSubscription = _eventAggregator.Subscribe<PenaltyScrollChangedMessage>(message =>
            {
                update_tuning_avg();
                if (_currentFile != null)
                    redraw_chords();
            });
            _qualityWeightScrollSubscription = _eventAggregator.Subscribe<QualityWeightScrollChangedMessage>(message =>
            {
                update_tuning_avg();

                if (_currentFile != null)
                    redraw_chords();
            });
            _tuningTransposeSubscription = _eventAggregator.Subscribe<TuningsTransposedMessage>(message =>
            {
                if (_currentFile != null)
                {
                    update_tuning_avg();
                    redraw_chords();
                }
            });
            _tuningEnabledSubscription = _eventAggregator.Subscribe<TuningEnabledMessage>(message => { redraw_chords(); });
            _qualityCheckSubscription = _eventAggregator.Subscribe<QualityCheckChangedMessage>(message =>
            {
                _chordDisplay.Visible = message.CheckStatus;
                UpdateDisplay();
            });
            _labelCheckSubscription = _eventAggregator.Subscribe<LabelCheckChangedMessage>(message =>
            {
                _chordNameDisplay.Visible = message.CheckStatus;
                UpdateDisplay();
            });
            _zoomUpdatedMessage = _eventAggregator.Subscribe<ZoomScrollChangedMessage>(message =>
            {
                _zoomValue = message.ZoomValue;
                if (_currentFile != null)
                {
                    _offsetScroll.Maximum = Math.Max(_currentFile.bars - message.ZoomValue, 0);
                    Redraw();
                }
            });
        }

        private void OnMarkersChanged()
        {
            _trackDisplay = new TrackDisplay(_currentFile.tracks, _trackColors);
            var tmessage = new TrackDisplayChangedMessage();
            tmessage.TrackDisplay = _trackDisplay;
            _eventAggregator.Publish(tmessage);

            Redraw();
        }

        private void UpdatePlayer(MidiFilePlayer player)
        {
            _pl = player;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            // misc init.'s            
            _qualityWeights = new QualityWeights();
            var qMessage = new QualityWeightsUpdatedMessage();
            qMessage.QualityWeights = _qualityWeights;
            _eventAggregator.Publish(qMessage);

            // load tunings from textfiles
            var di = new DirectoryInfo(Environment.CurrentDirectory);
            var fi = di.GetFiles("*.tng");
            _tunings = new TuningScheme[fi.Length + 1];
            _tunings[0] = new TuningScheme();
            for (var n = 0; n < fi.Length; n++)
                _tunings[n + 1] = new TuningScheme(fi[n].Name);
            var tMessage = new TuningsUpdatedMessage();
            tMessage.Tunings = _tunings;
            _eventAggregator.Publish(tMessage);


            // adjust chordDisplay size
            double maxq = 0;
            for (var i = 0; i < _tunings.Length; i++)
            {
                var q = _tunings[i].MaxQuality();
                if (q > maxq)
                    maxq = q;
            }
            _chordDisplay.Top = _noteDisplay.Bottom + 1;
            _chordDisplay.Height = (int) (2*maxq);
            _chordNameDisplay.Top = _chordDisplay.Bottom + 1;
            _offsetScroll.Top = _chordNameDisplay.Bottom;
            InitializeServices();
        }

        private void OnFileOpened(MidiFile file)
        {
            _currentFile = file;

            // Synchronize the file among all services.
            var fMessage = new FileUpdatedMessage();
            fMessage.File = file;
            _eventAggregator.Publish(fMessage);

            _playStart = -1;
            _playStop = -1;
            var pMessage = new PlaySelectionChangedMessage();
            pMessage.PlayStart = _playStart;
            pMessage.PlayStop = _playStop;
            _eventAggregator.Publish(pMessage);

            // load the track display into memory
            _trackDisplay = new TrackDisplay(_currentFile.tracks, _trackColors);
            var tmessage = new TrackDisplayChangedMessage();
            tmessage.TrackDisplay = _trackDisplay;
            _eventAggregator.Publish(tmessage);


            // show file information
            Text = "ChordQuality   ---   " + _currentFile.name;

            // adjust noteDisplay size
            _noteDisplay.Height = (_currentFile.max_note - _currentFile.min_note)*2 + 1;
            _cursor.Height = _noteDisplay.Height;
            _hoverBar.Height = _noteDisplay.Height;
            _cutBarFirst.Height = _noteDisplay.Height;
            _cutBarSecond.Height = _noteDisplay.Height;
            _chordDisplay.Top = _noteDisplay.Bottom + 1;
            _noteDisplay.Image = new Bitmap(_noteDisplay.Width, _noteDisplay.Height);
            _chordDisplay.Image = new Bitmap(_chordDisplay.Width, _chordDisplay.Height);
            _chordNameDisplay.Image = new Bitmap(_chordNameDisplay.Width, _chordNameDisplay.Height);
            //
            _chords = _currentFile.FindChords();
            update_tuning_avg();
            //            
            _offsetScroll.Value = 0;
            //
            UpdateDisplay();
            _printingControl1.UpdatePrintSettings();

            //place cut panel below
            _cutPanel.Top = _offsetScroll.Bottom + 5;
            //redraw();           
        }

        private void Timer1Tick(object sender, EventArgs e)
        {
            double p = _pl.Position;
            if (p < 0)
                return;
            if (p >= _currentFile.bars)
            {
                Stop();
            }
            else
            {
                if (p >= _offsetScroll.Value + _zoomValue)
                {
                    _offsetScroll.Value = Math.Min(_offsetScroll.Value + _zoomValue, _offsetScroll.Maximum);
                }
                else if (p < _offsetScroll.Value)
                {
                    _offsetScroll.Value = (int) p;
                }

                _cursor.Left = _noteDisplay.Left + (int) ((p - _offsetScroll.Value)*_noteDisplay.Width/_zoomValue);
                if ((_playStart != _playStop) &&
                    (_cursor.Left > _noteDisplay.Width*(Math.Max(_playStart, _playStop) - _offsetScroll.Value)/_zoomValue))
                {
                    Stop();
                }

                //place a cursor in the cut rows as well
                _cutRowCursor.Left = _cursor.Left;
            }
        }

        private void OffsetScrollValueChanged(object sender, EventArgs e)
        {
            var message = new BarOffsetChangedMessage();
            message.OffsetValue = _offsetScroll.Value.ToString();
            _eventAggregator.Publish(message);
            Redraw();
        }


        private void MainFormClosed(object sender, EventArgs e)
        {
            if (_pl != null)
            {
                Stop();
            }
        }


        private void UpdateDisplay()
        {
            if (_chordDisplay.Visible)
            {
                _chordNameDisplay.Top = _chordDisplay.Bottom + 1;
            }
            else
                _chordNameDisplay.Top = _noteDisplay.Bottom + 1;
            if (_chordNameDisplay.Visible)
            {
                _offsetScroll.Top = _chordNameDisplay.Bottom;
            }
            else if (_chordDisplay.Visible)
                _offsetScroll.Top = _chordDisplay.Bottom;
            else
                _offsetScroll.Top = _noteDisplay.Bottom;

            if (_currentFile != null)
                Redraw();
        }


        private void Panel2Resize(object sender, EventArgs e)
        {
            if (_panel2.Width > 0)
            {
                _noteDisplay.Width = _panel2.Width - 32;
                _chordDisplay.Width = _noteDisplay.Width;
                _chordNameDisplay.Width = _noteDisplay.Width;
                _offsetScroll.Width = _noteDisplay.Width;
                _noteDisplay.Image = new Bitmap(_noteDisplay.Width, _noteDisplay.Height);
                _chordDisplay.Image = new Bitmap(_chordDisplay.Width, _chordDisplay.Height);
                _chordNameDisplay.Image = new Bitmap(_chordNameDisplay.Width, _chordNameDisplay.Height);
                if (_currentFile != null)
                    Redraw();
            }
        }

        private void FindBestTunings()
        {
            int mini = 0, minj = 0;
            double minq = 100;
            for (var i = 0; i < _tunings.Length; i++)
                for (var j = 0; j < 12; j++)
                {
                    _tunings[i].Transpose = j;
                    var q = _tunings[i].AvgQuality(_chords, _qualityWeights);
                    if (q < minq)
                    {
                        minq = q;
                        mini = i;
                        minj = j;
                    }
                }
            MessageBox.Show(_tunings[mini].Name + " +" + minj + " (" + Math.Round(minq, 5) + ")", "Best Tuning");
            _tuningControl1.SetTranspose(minj);
        }

        /***** Playback Event Handlers Begin *****/

        private void Play(int outputDevice)
        {
            if (_playStart == _playStop)
            {
                _pl.Play(outputDevice);
            }
            else
            {
                var selectionStart = Math.Min(_playStart, _playStop);
                var selectionStop = Math.Max(_playStart, _playStop);
                _pl.Play(outputDevice, selectionStart, selectionStop);
            }
            _timer1.Enabled = true;
        }

        private void Stop()
        {
            _pl.Stop();
            _timer1.Enabled = false;
            _cursor.Left = _noteDisplay.Left;

            //get rid of the cut row cursor
            _cutRowCursor.Visible = false;
        }

        private void Pause()
        {
            _pl.Pause();
            _timer1.Enabled = false;
        }

        private void OnTracksChanged()
        {
            _chords = _currentFile.FindChords();
            update_tuning_avg();

            // update the in memory track display
            _trackDisplay = new TrackDisplay(_currentFile.tracks, _trackColors);
            var tmessage = new TrackDisplayChangedMessage();
            tmessage.TrackDisplay = _trackDisplay;
            _eventAggregator.Publish(tmessage);

            Redraw();
        }

        /***** Cut Event Handlers Begin *****/

        private void cutResetBtn_Click(object sender, EventArgs e)
        {
            _cutBarFirst.Visible = false;
            _cutBarSecond.Visible = false;
            _cutFirst = -1;
            _cutSecond = -1;
        }

        private void cutCutBtn_Click(object sender, EventArgs e)
        {
            var cutStart = Math.Min(_cutFirst, _cutSecond);
            var cutEnd = Math.Max(_cutFirst, _cutSecond);

            //the bar we're starting on and the number of bars we want
            var barStart = (int) Math.Round(cutStart);
            var barDiff = (int) Math.Round(cutEnd - cutStart);
            var barEnd = barStart + barDiff;
            if (barDiff == 0)
            {
                //make sure we have at least one
                barDiff = 1;
            }

            //we're fixing the numer of bars/cut row (=10.0) for now
            var width = barDiff/10.0*_noteDisplay.Width;
            if (cutStart < 0 || cutEnd < 0)
            {
                return;
            }

            //create a new picture box for our cut row
            var cutRow = new PictureBox();
            cutRow.BackColor = Color.White;
            cutRow.Location = new Point(0, _cutRows.Count*_noteDisplay.Height);
            cutRow.Size = new Size((int) Math.Round(width), _noteDisplay.Height);
            cutRow.Cursor = Cursors.SizeWE;
            cutRow.TabStop = false;
            cutRow.Image = new Bitmap(cutRow.Width, cutRow.Height);
            _cutRows.Add(new Tuple<int, int>(barStart, barEnd));

            //we need to listen to these events so we can perform left/right dragging
            cutRow.MouseDown += cutRow_MouseDown;
            cutRow.MouseMove += cutRow_MouseMove;

            //draw note in our cut row
            _artist.draw_notes(Graphics.FromImage(cutRow.Image), barStart, 0, 2, barDiff);

            //add to our cut panel so it can be showed
            _cutPanel.Controls.Add(cutRow);

            //then reset
            cutResetBtn_Click(sender, e);
        }

        private void cutClrBtn_Click(object sender, EventArgs e)
        {
            _cutRows.Clear();
            _cutPanel.Controls.Clear();
        }


        /***** Note Display Event Handlers Begin *****/

        private void NoteDisplayOnMouseLeave(object sender, EventArgs e)
        {
            //hide the hover bar when the mouse is not in range
            _hoverBar.Visible = false;
        }

        private void NoteDisplayMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _playStart = (double) e.X*_zoomValue/_noteDisplay.Width + _offsetScroll.Value;
                _playStop = _playStart;
                var pMessage = new PlaySelectionChangedMessage();
                pMessage.PlayStart = _playStart;
                pMessage.PlayStop = _playStop;
                _eventAggregator.Publish(pMessage);
            }
            else if (e.Button == MouseButtons.Right)
            {
                //save the locations of our cuts
                //we're naming them first and second as opposed to
                //begin and end because first can come after second
                if (_cutFirst < 0)
                {
                    _cutFirst = (double) e.X*_zoomValue/_noteDisplay.Width + _offsetScroll.Value;
                    _cutBarFirst.Visible = true;
                    _cutBarFirst.Left = _noteDisplay.Left + e.X;
                }
                else if (_cutSecond < 0)
                {
                    _cutSecond = (double) e.X*_zoomValue/_noteDisplay.Width + _offsetScroll.Value;
                    _cutBarSecond.Visible = true;
                    _cutBarSecond.Left = _noteDisplay.Left + e.X;
                }
            }
        }

        private void NoteDisplayMouseMove(object sender, MouseEventArgs e)
        {
            if (_currentFile == null)
                return;
            var b = e.X*_zoomValue/_noteDisplay.Width + _offsetScroll.Value + 1;
            var n = ClosestNote(e.X, e.Y);
            if (n >= 0)
            {
                _toolTip1.SetToolTip(_noteDisplay, "bar " + b + "\n" + KeyList.NoteName(n));
            }
            else
            {
                _toolTip1.SetToolTip(_noteDisplay, "bar " + b);
            }
            if ((e.Button == MouseButtons.Left) && (_playStart >= 0))
            {
                _playStop = (double) e.X*_zoomValue/_noteDisplay.Width + _offsetScroll.Value;
                var pMessage = new PlaySelectionChangedMessage();
                pMessage.PlayStart = _playStart;
                pMessage.PlayStop = _playStop;
                _eventAggregator.Publish(pMessage);
                redraw_notes();
            }
            _noteDisplay.Refresh();

            _hoverBar.Visible = true;
            _hoverBar.Left = _noteDisplay.Left + e.X;
        }

        /***** Chord Display Event Handlers Begin *****/

        private void ChordDisplayMouseMove(object sender, MouseEventArgs e)
        {
            if (_currentFile == null)
                return;
            var b = e.X*_zoomValue/_chordDisplay.Width + _offsetScroll.Value + 1;
            _toolTip1.SetToolTip(_chordDisplay, "bar " + b);
        }

        /***** Cut Panel Event Handlers Begin *****/

        private void cutRow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this will be the point where we start out dragging
                _cutRowDragX = e.X;
            }
        }

        private void cutRow_MouseMove(object sender, MouseEventArgs e)
        {
            var p = sender as PictureBox;
            if (p != null && e.Button == MouseButtons.Left && _cutRowDragX > 0)
            {
                //perform the dragging
                var newLeft = p.Left + (e.X - _cutRowDragX);
                if (newLeft > 0 && newLeft + p.Width < p.Parent.Right)
                {
                    p.Left = newLeft;
                }
            }
        }

        private bool IsNote(Bitmap bm, int x, int y)
        {
            switch (unchecked((uint) bm.GetPixel(x, y).ToArgb()))
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
            var bm = (Bitmap) _noteDisplay.Image;
            if (x < 0 || x >= bm.Width || y < 0 || y >= bm.Height)
                return -1;
            if (IsNote(bm, x, y))
            {
                var c = bm.GetPixel(x, y);
                if (y + 2 < bm.Height && bm.GetPixel(x, y + 2) == c)
                    return _currentFile.max_note - (y + 2)/2;
                if (y > 1 && bm.GetPixel(x, y - 2) == c)
                    return _currentFile.max_note - y/2;
                return _currentFile.max_note - (y + 1)/2;
            }
            if (y + 1 < bm.Height && IsNote(bm, x, y + 1))
            {
                var c = bm.GetPixel(x, y + 1);
                if (y + 3 < bm.Height && bm.GetPixel(x, y + 3) == c)
                    return _currentFile.max_note - (y + 4)/2;
                return _currentFile.max_note - (y + 2)/2;
            }
            if (y > 0 && IsNote(bm, x, y - 1))
            {
                var c = bm.GetPixel(x, y - 1);
                if (y > 2 && bm.GetPixel(x, y - 3) == c)
                    return _currentFile.max_note - (y - 2)/2;
                return _currentFile.max_note - y/2;
            }
            if (y + 2 < bm.Height && IsNote(bm, x, y + 2))
            {
                var c = bm.GetPixel(x, y + 2);
                if (y + 4 < bm.Height && bm.GetPixel(x, y + 4) == c)
                    return _currentFile.max_note - (y + 5)/2;
                return _currentFile.max_note - (y + 3)/2;
            }
            if (y > 1 && IsNote(bm, x, y - 2))
            {
                var c = bm.GetPixel(x, y - 2);
                if (y > 3 && bm.GetPixel(x, y - 4) == c)
                    return _currentFile.max_note - (y - 3)/2;
                return _currentFile.max_note - (y - 1)/2;
            }
            return -1;
        }

        private void update_tuning_avg()
        {
            if (_chords != null)
                _tuningControl1.UpdateTuningAverage(_chords, _qualityWeights);
        }

        private void Redraw()
        {
            redraw_notes();
            redraw_chords();
        }

        private void redraw_notes()
        {
            //List<PictureBox> noteBoxes = new List<PictureBox>();
            //noteBoxes.Add(_noteDisplay);

            //// create one row per 16 bars of track
            //int numRows = _currentFile.bars / 16;
            //if (_currentFile.bars % 16 != 0)
            //    numRows++;

            //const int rowWidth = 960;
            //int rowHeight = (_currentFile.max_note - _currentFile.min_note) * 2 + 1;

            //for (int i = 0; i < numRows; i++)
            //{
            //    if (i != 0)
            //    {
            //        // create a new picture box for the row
            //        var noteBox = new PictureBox();
            //        noteBoxes.Add(noteBox);
            //        noteBox.MouseDown += NoteDisplayMouseDown;
            //        noteBox.MouseLeave += NoteDisplayOnMouseLeave;
            //        _noteDisplay.MouseMove += NoteDisplayMouseMove;

            //        // add the picture box to the main form so it can be rendered
            //        _panel2.Controls.Add(noteBox);

            //        noteBox.BackColor = Color.White;
            //        noteBox.Location = new Point(_noteDisplay.Location.X, _noteDisplay.Location.Y + i * rowHeight);
            //        noteBox.Size = new Size(rowWidth, rowHeight);
            //        noteBox.Cursor = Cursors.SizeWE;
            //        noteBox.TabStop = false;
            //        noteBox.Image = new Bitmap(rowWidth, rowHeight);

                    ////draw note in our cut row
                    //_artist.draw_notes(Graphics.FromImage(cutRow.Image), barStart, 0, 2, barDiff);

                    ////add to our cut panel so it can be showed
                    //_cutPanel.Controls.Add(cutRow);
                //}

                //Graphics.FromImage(noteBoxes[i].Image).Clear(Color.White);
                //_artist.draw_notes(Graphics.FromImage(noteBoxes[i].Image), i*16, 0, 2);
                            //}
                
                Graphics.FromImage(_noteDisplay.Image).Clear(Color.White);
                _artist.draw_notes(Graphics.FromImage(_noteDisplay.Image), _offsetScroll.Value, 0, 2);
        }

        private void redraw_chords()
        {
            Graphics.FromImage(_chordDisplay.Image).Clear(Color.White);
            _artist.draw_chords(Graphics.FromImage(_chordDisplay.Image), _offsetScroll.Value, 0);
            Graphics.FromImage(_chordNameDisplay.Image).Clear(Color.White);
            _artist.draw_chordnames(Graphics.FromImage(_chordNameDisplay.Image), _offsetScroll.Value, 0);
        }
    }
}