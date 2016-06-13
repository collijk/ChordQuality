using System;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.views
{
    public partial class ChordDisplay : PictureBox
    {
        private MidiDisplayModel _displayModel;
        private MidiTuningModel _tuningModel;
        private MidiQualityModel _qualityModel;
        private MidiDataModel _dataModel;
        private const int Ystart = 0;

        private Graphics _graphics;
        private readonly Pen _barpen = new Pen(Color.LightGray, 1);
        private readonly Pen _pen = new Pen(Color.Black, 2);
        private readonly Pen _thinpen = new Pen(Color.Black, 1);
        private readonly Color[] _colors = new Color[]
        {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black
        };

        public MidiDisplayModel DisplayModel
        {
            get
            {
                return _displayModel;
            }
            set
            {
                _displayModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public MidiTuningModel TuningModel
        {
            get
            {
                return _tuningModel;
            }
            set
            {
                _tuningModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public MidiQualityModel QualityModel
        {
            get
            {
                return _qualityModel;
            }
            set
            {
                _qualityModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public MidiDataModel DataModel
        {
            get
            {
                return _dataModel;
            }
            set
            {
                _dataModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public ChordDisplay()
        {
            InitializeComponent();
            Image = new Bitmap(Width, Height);
            _graphics = Graphics.FromImage(Image);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Image = new Bitmap(Width, Height);
            _graphics = Graphics.FromImage(Image);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (!Visible)
                return;

            base.OnPaint(pe);
            _graphics.Clear(Color.White);

            if(_displayModel != null && _tuningModel != null && _dataModel != null && _qualityModel != null)
            {
                DrawBars();
                DrawChords();
                Refresh();
            }
        }

        private void DrawChords()
        {
            var displayWidth = _graphics.VisibleClipBounds.Width;
            var displayHeight = _graphics.VisibleClipBounds.Height;
            var timeWidth = 4 * _dataModel.Timing * _displayModel.NumberOfBars;
            var scaleFactor = displayWidth / timeWidth;

            var minTime = 4 * (_displayModel.FirstBar - 1) * _dataModel.Timing;
            var maxTime = minTime + timeWidth;

            for(var i = 0; i < _tuningModel.Tunings.Length; i++)
            {
                if(_tuningModel.Tunings[i].enabled)
                {
                    _pen.Color = _colors[i];
                    _thinpen.Color = _colors[i];

                    /* TODO: 
                     * I'm pretty sure this leaves chords that are contained in the
                     * currently displayed selection but run before or after the selection
                     * ends undisplayed. Needs to be tested and potentially fixed. */
                    foreach(TimeInfo c in _dataModel.Chords)
                    {
                        if(c.Time > maxTime)
                            break;
                        if(c.Time >= minTime && _qualityModel.QualityWeights.enabled(c))
                        {
                            var startTime = c.Time - minTime;
                            var endTime = startTime + c.Duration;

                            var xStart = scaleFactor * startTime;
                            var xEnd = scaleFactor * endTime;
                            var q = (int) _tuningModel.Tunings[i].Quality(c, _qualityModel.QualityWeights);
                            var y = Ystart + displayHeight - 1 - 2 * q;
                            _graphics.DrawLine(c.IsChord ? _pen : _thinpen, xStart, y, xEnd, y);
                        }
                    }
                }
            }
        }

        private void DrawBars()
        {
            var displayWidth = _graphics.VisibleClipBounds.Width;
            var displayHeight = _graphics.VisibleClipBounds.Height;

            if(_displayModel.NumberOfBars < 100)
                for(var i = 1; i < _displayModel.NumberOfBars; i++)
                {
                    var xPosition = i * displayWidth / _displayModel.NumberOfBars;
                    _graphics.DrawLine(_barpen, xPosition, Ystart, xPosition, Ystart + displayHeight);
                }
        }
    }
}

