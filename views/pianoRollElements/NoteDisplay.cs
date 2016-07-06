using System;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.model;

namespace ChordQuality.views
{
    public partial class NoteDisplay : PictureBox
    {
        private MidiDisplayModel _displayModel;
        private MidiDataModel _dataModel;

        private Graphics _graphics;
        private readonly Pen _barpen = new Pen(Color.LightGray, 1);
        private readonly SolidBrush _drawBrush = new SolidBrush(Color.Black);
        private readonly Font _smallFont = new Font("Courier New", 6);
        private const int YStart = 0;
        private const int XStart = 0;


        public MidiDisplayModel DisplayModel
        {
            get { return _displayModel; }
            set
            {
                _displayModel = value;
                if(value != null)
                {
                    Height = (_dataModel.MaxNote - _dataModel.MinNote) * 2 + 1;
                    Image = new Bitmap(Width, Height);
                    _graphics = Graphics.FromImage(Image);
                    Refresh();
                }
            }
        }

        public MidiDataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                if (value != null)
                    Refresh();
            }
        }

        public NoteDisplay()
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
            base.OnPaint(pe);
            // Clear current noteDisplay contents
            _graphics.Clear(Color.White);

            if(_displayModel != null && _dataModel != null)
            {
                DrawBars();
                DrawScale();
                DrawNotes();
            }
        }

        private void DrawBars()
        {
            var displayWidth = _graphics.VisibleClipBounds.Width;
            var displayHeight = _displayModel.VerticalScale * (_dataModel.MaxNote - _dataModel.MinNote);

            var barWidth = displayWidth / _displayModel.NumberOfBars;
            var currentBar = _displayModel.FirstBar;

            var yLabelPosition = displayHeight / 8;
            var xLabelPosition = displayWidth / 10;

            // Label every fourth bar
            if(currentBar % 4 == 1)
            {
                _graphics.DrawString(currentBar.ToString(), _smallFont, _drawBrush, xLabelPosition, yLabelPosition);
            }
            currentBar++;

            for(var i = 1; i < _displayModel.NumberOfBars; i++)
            {
                var xPosition = i * barWidth;
                _graphics.DrawLine(_barpen, xPosition, YStart, xPosition, YStart + displayHeight);
                if(currentBar % 4 == 1)
                {
                    _graphics.DrawString(currentBar.ToString(), _smallFont, _drawBrush, xLabelPosition, yLabelPosition);
                }
                currentBar++;
            }
        }

        private void DrawScale()
        {

            for(var a = 0; a < 10; a++)
            {
                var b = a * 12 + 2;
                DrawScaleLine(b);
                b = a * 12 + 5;
                DrawScaleLine(b);
                b = a * 12 + 9;
                DrawScaleLine(b);
            }
        }

        private void DrawScaleLine(int b)
        {
            var displayWidth = _graphics.VisibleClipBounds.Width;
            if(b < _dataModel.MaxNote && b > _dataModel.MinNote)
            {
                var y = _displayModel.VerticalScale * (_dataModel.MaxNote - b) + YStart;
                _graphics.DrawLine(_barpen, XStart, y, displayWidth, y);
            }
        }

        private void DrawNotes()
        {
            _displayModel.Tracks?.Draw(_graphics, _dataModel.MaxNote, _displayModel.FirstBar,
                _dataModel.Timing, _displayModel.NumberOfBars, _displayModel.VerticalScale, _displayModel.RelThickness);
        }
    }
}