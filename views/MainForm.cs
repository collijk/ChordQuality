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

namespace ChordQuality.views
{
    public class MainForm : Form
    {
        private IEventAggregator _eventAggregator;
        private ISubscription<FindBestTuningsMessage> _bestTuningsSubscription;
        private ISubscription<CloseRequestMessage> _closeRequestSubscription;
        private ISubscription<FileTransposedMessage> _fileTransposeSubscription;
        private ISubscription<LabelCheckChangedMessage> _labelCheckSubscription;
        private ISubscription<MarkersChangedMessage> _markersChangedSubscription;
        private ISubscription<FileOpenedMessage> _midiFileSubscription;
        private ISubscription<MidiPlayerUpdatedMessage> _midiPlayerSubscription;
        private ISubscription<PauseMessage> _pauseSubscription;
        private ISubscription<PenaltiesChangedMessage> _penaltiesChangedSubscription;
        private ISubscription<PenaltyScrollChangedMessage> _penaltyScrollSubscription;
        private ISubscription<PlayMessage> _playSubscription;
        private ISubscription<QualityCheckChangedMessage> _qualityCheckSubscription;
        private ISubscription<QualityWeightScrollChangedMessage> _qualityWeightScrollSubscription;
        private ISubscription<StopMessage> _stopSubscription;
        private ISubscription<TrackColorChangedMessage> _trackColorChangedSubscription;
        private ISubscription<TracksChangedMessage> _tracksChangedSubscription;
        private ISubscription<TuningEnabledMessage> _tuningEnabledSubscription;
        private ISubscription<TuningsTransposedMessage> _tuningTransposeSubscription;
        private ISubscription<ZoomScrollChangedMessage> _zoomUpdatedMessage;


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
        
        private PictureBox _chordDisplay;
        private PictureBox _chordNameDisplay;
        private ArrayList _chords;
        

        


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
        

        private MidiFile _currentFile;
        private FileTransposeControl _fileTransposeControl1;
        
        private GroupBox _groupBox1;
        private TransparentPanel _hoverBar;
        
        private MainMenuControl _mainMenuControl1;
        
        private PictureBox _noteDisplay;
        private HScrollBar _offsetScroll;
        private Panel _panel1;
        private Panel _panel2;
        

        private MidiFilePlayer _pl;
        private double _playStart;
        private double _playStop;
        private PlaybackControl _playbackControl;
        
        private PrintDocumentProvider _printDocProvider;
        private PrintingControl _printingControl1;
        private PrintPreviewControl _printPreviewDialog1;
        
        private QualityWeights _qualityWeights;
        
        private Timer _timer1;
        private ToolTip _toolTip1;
        

        private TrackControl _trackControl1;
        private TrackDisplay _trackDisplay;
        
        private TuningControl _tuningControl1;
        
        private TuningScheme[] _tunings;
        
        private ZoomControl _zoomControl1;
        
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
            components = new Container();
            _chordDisplay = new PictureBox();
            _offsetScroll = new HScrollBar();
            _panel1 = new Panel();
            _zoomControl1 = new ZoomControl();
            _printingControl1 = new PrintingControl();
            _tuningControl1 = new TuningControl();
            _trackControl1 = new TrackControl();
            _fileTransposeControl1 = new FileTransposeControl();
            _playbackControl = new PlaybackControl();
            _groupBox1 = new GroupBox();
            _cutClrBtn = new Button();
            _cutCutBtn = new Button();
            _cutResetBtn = new Button();
            _panel2 = new Panel();
            _cutPanel = new Panel();
            _cutBarSecond = new TransparentPanel();
            _cutBarFirst = new TransparentPanel();
            _chordNameDisplay = new PictureBox();
            _cursor = new Panel();
            _hoverBar = new TransparentPanel();
            _noteDisplay = new PictureBox();
            _toolTip1 = new ToolTip(components);
            _timer1 = new Timer(components);
            _printPreviewDialog1 = new PrintPreviewControl();
            _cutRowCursor = new Panel();
            _mainMenuControl1 = new MainMenuControl();
            ((ISupportInitialize) _chordDisplay).BeginInit();
            _panel1.SuspendLayout();
            _groupBox1.SuspendLayout();
            _panel2.SuspendLayout();
            ((ISupportInitialize) _chordNameDisplay).BeginInit();
            ((ISupportInitialize) _noteDisplay).BeginInit();
            SuspendLayout();
            // 
            // chordDisplay
            // 
            _chordDisplay.BackColor = Color.White;
            _chordDisplay.Location = new Point(8, 56);
            _chordDisplay.Name = "_chordDisplay";
            _chordDisplay.Size = new Size(960, 48);
            _chordDisplay.TabIndex = 42;
            _chordDisplay.TabStop = false;
            _chordDisplay.MouseMove += ChordDisplayMouseMove;
            // 
            // offsetScroll
            // 
            _offsetScroll.LargeChange = 1;
            _offsetScroll.Location = new Point(8, 125);
            _offsetScroll.Maximum = 0;
            _offsetScroll.Name = "_offsetScroll";
            _offsetScroll.Size = new Size(960, 12);
            _offsetScroll.TabIndex = 41;
            _offsetScroll.ValueChanged += OffsetScrollValueChanged;
            // 
            // panel1
            // 
            _panel1.AutoScroll = true;
            _panel1.AutoSize = true;
            _panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _panel1.BackColor = SystemColors.ControlLight;
            _panel1.Controls.Add(_zoomControl1);
            _panel1.Controls.Add(_printingControl1);
            _panel1.Controls.Add(_tuningControl1);
            _panel1.Controls.Add(_trackControl1);
            _panel1.Controls.Add(_fileTransposeControl1);
            _panel1.Controls.Add(_playbackControl);
            _panel1.Controls.Add(_groupBox1);
            _panel1.Dock = DockStyle.Top;
            _panel1.Location = new Point(0, 24);
            _panel1.Name = "_panel1";
            _panel1.Size = new Size(1280, 313);
            _panel1.TabIndex = 45;
            // 
            // zoomControl1
            // 
            _zoomControl1.AutoSize = true;
            _zoomControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _zoomControl1.Location = new Point(175, 217);
            _zoomControl1.Name = "_zoomControl1";
            _zoomControl1.Size = new Size(209, 86);
            _zoomControl1.TabIndex = 0;
            // 
            // printingControl1
            // 
            _printingControl1.AutoSize = true;
            _printingControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _printingControl1.Location = new Point(1126, 6);
            _printingControl1.Name = "_printingControl1";
            _printingControl1.Size = new Size(127, 195);
            _printingControl1.TabIndex = 61;
            // 
            // tuningControl1
            // 
            _tuningControl1.AutoSize = true;
            _tuningControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _tuningControl1.Location = new Point(554, 6);
            _tuningControl1.Name = "_tuningControl1";
            _tuningControl1.Size = new Size(566, 238);
            _tuningControl1.TabIndex = 51;
            // 
            // trackControl1
            // 
            _trackControl1.AutoSize = true;
            _trackControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _trackControl1.Location = new Point(317, 3);
            _trackControl1.Name = "_trackControl1";
            _trackControl1.Size = new Size(231, 179);
            _trackControl1.TabIndex = 60;
            // 
            // fileTransposeControl1
            // 
            _fileTransposeControl1.AutoSize = true;
            _fileTransposeControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _fileTransposeControl1.Location = new Point(8, 217);
            _fileTransposeControl1.Name = "_fileTransposeControl1";
            _fileTransposeControl1.Size = new Size(161, 73);
            _fileTransposeControl1.TabIndex = 1;
            // 
            // playbackControl
            // 
            _playbackControl.AutoSize = true;
            _playbackControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _playbackControl.Location = new Point(8, 3);
            _playbackControl.Name = "_playbackControl";
            _playbackControl.Size = new Size(303, 208);
            _playbackControl.TabIndex = 59;
            // 
            // groupBox1
            // 
            _groupBox1.Controls.Add(_cutClrBtn);
            _groupBox1.Controls.Add(_cutCutBtn);
            _groupBox1.Controls.Add(_cutResetBtn);
            _groupBox1.Location = new Point(554, 250);
            _groupBox1.Name = "_groupBox1";
            _groupBox1.Size = new Size(200, 60);
            _groupBox1.TabIndex = 55;
            _groupBox1.TabStop = false;
            _groupBox1.Text = @"Cut";
            // 
            // cutClrBtn
            // 
            _cutClrBtn.Location = new Point(133, 17);
            _cutClrBtn.Name = "_cutClrBtn";
            _cutClrBtn.Size = new Size(56, 37);
            _cutClrBtn.TabIndex = 2;
            _cutClrBtn.Text = @"Clear
Display";
            _cutClrBtn.UseVisualStyleBackColor = true;
            _cutClrBtn.Click += cutClrBtn_Click;
            // 
            // cutCutBtn
            // 
            _cutCutBtn.Location = new Point(70, 17);
            _cutCutBtn.Name = "_cutCutBtn";
            _cutCutBtn.Size = new Size(56, 37);
            _cutCutBtn.TabIndex = 1;
            _cutCutBtn.Text = @"Cut";
            _cutCutBtn.UseVisualStyleBackColor = true;
            _cutCutBtn.Click += cutCutBtn_Click;
            // 
            // cutResetBtn
            // 
            _cutResetBtn.Location = new Point(8, 17);
            _cutResetBtn.Name = "_cutResetBtn";
            _cutResetBtn.Size = new Size(56, 37);
            _cutResetBtn.TabIndex = 0;
            _cutResetBtn.Text = @"Reset
Marker";
            _cutResetBtn.UseVisualStyleBackColor = true;
            _cutResetBtn.Click += cutResetBtn_Click;
            // 
            // panel2
            // 
            _panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _panel2.BackColor = SystemColors.ControlLight;
            _panel2.Controls.Add(_cutPanel);
            _panel2.Controls.Add(_cutBarSecond);
            _panel2.Controls.Add(_cutBarFirst);
            _panel2.Controls.Add(_chordNameDisplay);
            _panel2.Controls.Add(_chordDisplay);
            _panel2.Controls.Add(_offsetScroll);
            _panel2.Controls.Add(_cursor);
            _panel2.Controls.Add(_hoverBar);
            _panel2.Controls.Add(_noteDisplay);
            _panel2.Location = new Point(0, 314);
            _panel2.Name = "_panel2";
            _panel2.Size = new Size(1280, 396);
            _panel2.TabIndex = 46;
            _panel2.Resize += Panel2Resize;
            // 
            // cutPanel
            // 
            _cutPanel.AutoScroll = true;
            _cutPanel.Location = new Point(8, 140);
            _cutPanel.Name = "_cutPanel";
            _cutPanel.Size = new Size(976, 235);
            _cutPanel.TabIndex = 47;
            // 
            // cutBarSecond
            // 
            _cutBarSecond.BackColor = Color.BlueViolet;
            _cutBarSecond.Location = new Point(8, 6);
            _cutBarSecond.Name = "_cutBarSecond";
            _cutBarSecond.Size = new Size(1, 47);
            _cutBarSecond.TabIndex = 31;
            _cutBarSecond.Visible = false;
            // 
            // cutBarFirst
            // 
            _cutBarFirst.BackColor = Color.BlueViolet;
            _cutBarFirst.Location = new Point(8, 6);
            _cutBarFirst.Name = "_cutBarFirst";
            _cutBarFirst.Size = new Size(1, 47);
            _cutBarFirst.TabIndex = 31;
            _cutBarFirst.Visible = false;
            // 
            // chordNameDisplay
            // 
            _chordNameDisplay.BackColor = Color.White;
            _chordNameDisplay.Location = new Point(8, 109);
            _chordNameDisplay.Name = "_chordNameDisplay";
            _chordNameDisplay.Size = new Size(960, 16);
            _chordNameDisplay.TabIndex = 46;
            _chordNameDisplay.TabStop = false;
            // 
            // cursor
            // 
            _cursor.BackColor = Color.Red;
            _cursor.Location = new Point(8, 6);
            _cursor.Name = "_cursor";
            _cursor.Size = new Size(1, 47);
            _cursor.TabIndex = 30;
            // 
            // hoverBar
            // 
            _hoverBar.BackColor = Color.DarkGray;
            _hoverBar.Location = new Point(8, 6);
            _hoverBar.Name = "_hoverBar";
            _hoverBar.Size = new Size(1, 47);
            _hoverBar.TabIndex = 31;
            _hoverBar.Visible = false;
            // 
            // noteDisplay
            // 
            _noteDisplay.BackColor = Color.White;
            _noteDisplay.Location = new Point(8, 6);
            _noteDisplay.Name = "_noteDisplay";
            _noteDisplay.Size = new Size(960, 47);
            _noteDisplay.TabIndex = 29;
            _noteDisplay.TabStop = false;
            _noteDisplay.MouseDown += NoteDisplayMouseDown;
            _noteDisplay.MouseLeave += NoteDisplayOnMouseLeave;
            _noteDisplay.MouseMove += NoteDisplayMouseMove;
            // 
            // timer1
            // 
            _timer1.Interval = 10;
            _timer1.Tick += Timer1Tick;
            // 
            // printPreviewDialog1
            // 
            _printPreviewDialog1.Location = new Point(0, 0);
            _printPreviewDialog1.Name = "_printPreviewDialog1";
            _printPreviewDialog1.Size = new Size(100, 100);
            _printPreviewDialog1.TabIndex = 0;
            // 
            // cutRowCursor
            // 
            _cutRowCursor.BackColor = Color.Red;
            _cutRowCursor.Location = new Point(8, 6);
            _cutRowCursor.Name = "_cutRowCursor";
            _cutRowCursor.Size = new Size(1, 47);
            _cutRowCursor.TabIndex = 0;
            _cutRowCursor.Visible = false;
            // 
            // mainMenuControl1
            // 
            _mainMenuControl1.AccessibleRole = AccessibleRole.MenuBar;
            _mainMenuControl1.AutoSize = true;
            _mainMenuControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _mainMenuControl1.BackColor = SystemColors.MenuBar;
            _mainMenuControl1.Dock = DockStyle.Top;
            _mainMenuControl1.Location = new Point(0, 0);
            _mainMenuControl1.Name = "_mainMenuControl1";
            _mainMenuControl1.Size = new Size(1280, 24);
            _mainMenuControl1.TabIndex = 60;
            // 
            // MainForm
            // 
            AutoScaleBaseSize = new Size(5, 13);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1280, 701);
            Controls.Add(_panel1);
            Controls.Add(_mainMenuControl1);
            Controls.Add(_panel2);
            Name = "MainForm";
            Text = @"ChordQuality";
            Closed += MainFormClosed;
            Load += MainFormLoad;
            ((ISupportInitialize) _chordDisplay).EndInit();
            _panel1.ResumeLayout(false);
            _panel1.PerformLayout();
            _groupBox1.ResumeLayout(false);
            _panel2.ResumeLayout(false);
            ((ISupportInitialize) _chordNameDisplay).EndInit();
            ((ISupportInitialize) _noteDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
            var tmessage = new TrackDisplayChangedMessage {TrackDisplay = _trackDisplay};
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
            var qMessage = new QualityWeightsUpdatedMessage {QualityWeights = _qualityWeights};
            _eventAggregator.Publish(qMessage);

            // load tunings from textfiles
            var di = new DirectoryInfo(Environment.CurrentDirectory);
            var fi = di.GetFiles("*.tng");
            _tunings = new TuningScheme[fi.Length + 1];
            _tunings[0] = new TuningScheme();
            for (var n = 0; n < fi.Length; n++)
                _tunings[n + 1] = new TuningScheme(fi[n].Name);
            var tMessage = new TuningsUpdatedMessage {Tunings = _tunings};
            _eventAggregator.Publish(tMessage);


            // adjust chordDisplay size
            double maxq = 0;
            foreach (TuningScheme t in _tunings)
            {
                var q = t.MaxQuality();
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
            var fMessage = new FileUpdatedMessage {File = file};
            _eventAggregator.Publish(fMessage);

            _playStart = -1;
            _playStop = -1;
            var pMessage = new PlaySelectionChangedMessage
            {
                PlayStart = _playStart,
                PlayStop = _playStop
            };
            _eventAggregator.Publish(pMessage);

            // load the track display into memory
            _trackDisplay = new TrackDisplay(_currentFile.tracks, _trackColors);
            var tmessage = new TrackDisplayChangedMessage {TrackDisplay = _trackDisplay};
            _eventAggregator.Publish(tmessage);


            // show file information
            Text = @"ChordQuality   ---   " + _currentFile.name;

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
                if ((Math.Abs(_playStart - _playStop) > 0.001) &&
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
            var message = new BarOffsetChangedMessage {OffsetValue = _offsetScroll.Value.ToString()};
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
            if (_panel2.Width <= 0) return;
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
            MessageBox.Show(_tunings[mini].Name + @" +" + minj + @" (" + Math.Round(minq, 5) + @")", @"Best Tuning");
            _tuningControl1.SetTranspose(minj);
        }

        /***** Playback Event Handlers Begin *****/

        private void Play(int outputDevice)
        {
            if (Math.Abs(_playStart - _playStop) < 0.001)
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
            var tmessage = new TrackDisplayChangedMessage {TrackDisplay = _trackDisplay};
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
            var cutRow = new PictureBox
            {
                BackColor = Color.White,
                Location = new Point(0, _cutRows.Count*_noteDisplay.Height),
                Size = new Size((int) Math.Round(width), _noteDisplay.Height),
                Cursor = Cursors.SizeWE,
                TabStop = false
            };
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
                var pMessage = new PlaySelectionChangedMessage
                {
                    PlayStart = _playStart,
                    PlayStop = _playStop
                };
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
                var pMessage = new PlaySelectionChangedMessage
                {
                    PlayStart = _playStart,
                    PlayStop = _playStop
                };
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