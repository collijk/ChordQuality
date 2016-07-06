using System;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.views
{
    public partial class ChordNameDisplay : PictureBox
    {
        private MidiDisplayModel _displayModel;
        private MidiQualityModel _qualityModel;
        private MidiDataModel _dataModel;
        private const int YStart = 0;

        private Graphics _graphics;
        private readonly SolidBrush _drawBrush = new SolidBrush(Color.Black);
        private readonly Font _drawFont = new Font("Courier New", 10);
        private readonly Font _smallFont = new Font("Courier New", 6);

        public MidiDisplayModel DisplayModel
        {
            get { return _displayModel; }
            set
            {
                _displayModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public MidiQualityModel QualityModel
        {
            get { return _qualityModel; }
            set
            {
                _qualityModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public MidiDataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                if(value != null)
                    Refresh();
            }
        }

        public ChordNameDisplay()
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

            if(_displayModel != null  && _dataModel != null && _qualityModel != null)
            {
                var displayWidth = _graphics.VisibleClipBounds.Width;
                var timeWidth = 4 * _dataModel.Timing * _displayModel.NumberOfBars;
                var scaleFactor = timeWidth / displayWidth;

                var minTime = 4 * (_displayModel.FirstBar - 1) * _dataModel.Timing;
                var maxTime = minTime + timeWidth;

                foreach(TimeInfo c in _dataModel.Chords)
                {
                    if(c.Time > maxTime)
                        break;
                    if(c.Time >= minTime && _qualityModel.QualityWeights.enabled(c))
                    {
                        var chordName = c.Name;
                        var x = scaleFactor * (c.Time - minTime);
                        if(c.IsChord)
                        {
                            _graphics.DrawString(chordName.Substring(0, 1), _drawFont, _drawBrush, x, YStart);
                            if(chordName.Length > 1)
                                _graphics.DrawString(chordName.Substring(1, 1), _drawFont, _drawBrush, x, YStart + _drawFont.Size);
                        } else
                        {
                            _graphics.DrawString(chordName.Substring(0, 1), _smallFont, _drawBrush, x, YStart);
                            if(chordName.Length > 1)
                                _graphics.DrawString(chordName.Substring(1, 1), _smallFont, _drawBrush, x, YStart + _smallFont.Size);
                            if(chordName.Length > 2)
                                _graphics.DrawString(chordName.Substring(2, 1), _smallFont, _drawBrush, x, YStart + 2 * _smallFont.Size);
                        }
                    }
                }
                Refresh();
            }
        }
    }
}
