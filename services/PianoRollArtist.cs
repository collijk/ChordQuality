using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.views;
using Janus.ManagedMIDI;

namespace ChordQuality.services
{
    // Temporary class to aid in MainForm Refactor.
    // Drawing methods will be moved to the display classes that need them
    // once they are separated from the MainForm and most of the message passing
    // will disappear.
    internal class PianoRollArtist
    {
        private readonly Pen _barpen = new Pen(Color.LightGray, 1);
        private readonly PictureBox _chordDisplay;
        private readonly PictureBox _chordNameDisplay;

        private readonly Color[] _colors = new Color[]
        {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black
        };

        private readonly SolidBrush _drawBrush = new SolidBrush(Color.Black);
        private readonly Font _drawFont = new Font("Courier New", 10);
        private readonly PictureBox _noteDisplay;
        private readonly Pen _orientpen = new Pen(Color.LightGray, 1);
        private readonly Pen _pen = new Pen(Color.Black, 2);
        private readonly QualityWeights _qualityWeights;
        private readonly Color _selectColor = Color.FromArgb(32, 0, 0, 255);
        private readonly Font _smallFont = new Font("Courier New", 6);
        private readonly Pen _thinpen = new Pen(Color.Black, 1);
        private readonly TuningScheme[] _tunings;

        private MidiFile _currentFile;

        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileSubscription;
        private ISubscription<PlaySelectionChangedMessage> _playSelectionSubscription;
        private double _playStart = -1;
        private double _playStop = -1;
        private float _relThickness = 0.5f;
        private ISubscription<RelThicknessChangedMessage> _relThicknessSubscription;
        private TrackDisplay _trackDisplay;
        private ISubscription<TrackDisplayChangedMessage> _trackDisplaySubscription;
        private ISubscription<ZoomScrollChangedMessage> _zoomScrollSubscription;

        private int _zoomScrollValue = 15;

        public PianoRollArtist(PictureBox noteDisplay, PictureBox chordDisplay, TuningScheme[] tunings,
            QualityWeights qualityWeights, PictureBox chordNameDisplay)
        {
            InitializeSubscriptions();
            _noteDisplay = noteDisplay;
            _chordDisplay = chordDisplay;
            _tunings = tunings;
            _qualityWeights = qualityWeights;
            _chordNameDisplay = chordNameDisplay;
            _orientpen.DashStyle = DashStyle.Dot;
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _zoomScrollSubscription =
                _eventAggregator.Subscribe<ZoomScrollChangedMessage>(message => { _zoomScrollValue = message.ZoomValue; });
            _fileSubscription = _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
            _trackDisplaySubscription =
                _eventAggregator.Subscribe<TrackDisplayChangedMessage>(
                    message => { _trackDisplay = message.TrackDisplay; });
            _relThicknessSubscription =
                _eventAggregator.Subscribe<RelThicknessChangedMessage>(
                    message => { _relThickness = message.RelThickness; });
            _playSelectionSubscription = _eventAggregator.Subscribe<PlaySelectionChangedMessage>(message =>
            {
                _playStart = message.PlayStart;
                _playStop = message.PlayStop;
            });
        }

        // draw piano roll, starting at bar offset
        public void draw_notes(Graphics gr, int offset, int y0, int vscale)
        {
            draw_notes(gr, offset, y0, vscale, _zoomScrollValue);
        }

        public void draw_notes(Graphics gr, int offset, int y0, int vscale, int zoomValue)
        {
            var grw = (int) gr.VisibleClipBounds.Width;
            var grh = vscale*(_currentFile.max_note - _currentFile.min_note);
            // draw bar markers & bar numbers
            if (zoomValue < 100)
                for (var i = 0; i < zoomValue; i++)
                {
                    if (i > 0)
                        gr.DrawLine(_barpen, i*grw/zoomValue, y0, i*grw/zoomValue, y0 + grh);
                    if ((offset + i)%zoomValue == 0)
                        gr.DrawString((offset + i + 1).ToString(), _smallFont, _drawBrush, i*((float)grw)/zoomValue, y0);
                }
            // draw horizontal orientation lines at each D,F and A
            for (var a = 0; a < 10; a++)
            {
                var b = a*12 + 2;
                int y;
                if (b < _currentFile.max_note && b > _currentFile.min_note)
                {
                    y = vscale*(_currentFile.max_note - b) + y0;
                    gr.DrawLine(_barpen, 0, y, gr.VisibleClipBounds.Width, y);
                }
                b = a*12 + 5;
                if (b < _currentFile.max_note && b > _currentFile.min_note)
                {
                    y = vscale*(_currentFile.max_note - b) + y0;
                    gr.DrawLine(_orientpen, 0, y, gr.VisibleClipBounds.Width, y);
                }
                b = a*12 + 9;
                if (b < _currentFile.max_note && b > _currentFile.min_note)
                {
                    y = vscale*(_currentFile.max_note - b) + y0;
                    gr.DrawLine(_orientpen, 0, y, gr.VisibleClipBounds.Width, y);
                }
            }
            //
            // draw notes
            //
            _trackDisplay?.Draw(gr, _currentFile.max_note, offset,
                _currentFile.timing, zoomValue, vscale, _relThickness);

            // draw selection
            if (_playStart >= 0)
            {
                Brush selectionBrush = new SolidBrush(_selectColor);
                var x = (int) (grw*(Math.Min(_playStart, _playStop) - offset)/zoomValue);
                var w = (int) (grw*Math.Abs(_playStop - _playStart)/zoomValue);
                gr.FillRectangle(selectionBrush, x, 0, w, grh);
            }
            _noteDisplay.Refresh();
        }

        public void draw_chords(Graphics gr, int offset, int y0)
        {
            if (!_chordDisplay.Visible)
                return;
            var grw = (int) gr.VisibleClipBounds.Width;
            var grh = _chordDisplay.Height;
            var mintime = offset*4*_currentFile.timing;
            var maxtime = (offset + _zoomScrollValue + 1)*4*_currentFile.timing;
            // draw bar markers for chord display
            if (_zoomScrollValue < 100)
                for (var i = 1; i < _zoomScrollValue; i++)
                    gr.DrawLine(_barpen, i*grw/_zoomScrollValue, y0, i*grw/_zoomScrollValue, y0 + grh);
            // draw chords
            for (var i = 0; i < _tunings.Length; i++)
                if (_tunings[i].enabled)
                {
                    _pen.Color = _colors[i];
                    _thinpen.Color = _colors[i];
                    foreach (TimeInfo c in _currentFile.FindChords())
                    {
                        if (c.Time > maxtime)
                            break;
                        if (c.Time >= mintime && _qualityWeights.enabled(c))
                        {
                            var x1 = grw*(c.Time - 4*offset*_currentFile.timing)/_currentFile.timing/4/_zoomScrollValue;
                            var x2 = grw*(c.Time + c.Duration - 4*offset*_currentFile.timing)/_currentFile.timing/4/
                                     _zoomScrollValue;
                            var q = (int) _tunings[i].Quality(c, _qualityWeights);
                            var y = y0 + grh - 1 - 2*q;
                            gr.DrawLine(c.IsChord ? _pen : _thinpen, x1, y, x2, y);
                        }
                    }
                }
            _chordDisplay.Refresh();
        }

        public void draw_chordnames(Graphics gr, int offset, int y0)
        {
            if (!_chordNameDisplay.Visible)
                return;
            var grw = (int) gr.VisibleClipBounds.Width;
            var mintime = offset*4*_currentFile.timing;
            var maxtime = (offset + _zoomScrollValue + 1)*4*_currentFile.timing;
            foreach (TimeInfo c in _currentFile.FindChords())
            {
                if (c.Time > maxtime)
                    break;
                if (c.Time >= mintime && _qualityWeights.enabled(c))
                {
                    var s = c.Name;
                    var x = grw*(c.Time - 4*offset*_currentFile.timing)/_currentFile.timing/4/_zoomScrollValue;
                    if (c.IsChord)
                    {
                        gr.DrawString(s.Substring(0, 1), _drawFont, _drawBrush, x, y0);
                        if (s.Length > 1)
                            gr.DrawString(s.Substring(1, 1), _drawFont, _drawBrush, x, y0 + _drawFont.Size);
                    }
                    else
                    {
                        gr.DrawString(s.Substring(0, 1), _smallFont, _drawBrush, x, y0);
                        if (s.Length > 1)
                            gr.DrawString(s.Substring(1, 1), _smallFont, _drawBrush, x, y0 + _smallFont.Size);
                        if (s.Length > 2)
                            gr.DrawString(s.Substring(2, 1), _smallFont, _drawBrush, x, y0 + 2*_smallFont.Size);
                    }
                }
            }
            _chordNameDisplay.Refresh();
        }
    }
}