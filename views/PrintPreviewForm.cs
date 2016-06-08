using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Janus.ManagedMIDI;

namespace ChordQuality.views
{
    public partial class PrintPreviewForm : Form
    {
        private readonly MidiFile _currentFile;
        private readonly string _midiFileName;
        private readonly PrintDocument _printDoc;
        private readonly float _relThickness;
        private readonly int _rowsPerPage;
        private readonly TrackDisplay _trackDisplay;
        private readonly int _totalPages;
        private readonly int _zoomValue;
        private int _currentPage;
        private bool _jl;

        public PrintPreviewForm(int rpp, int totalP, int zoom, string fileName, MidiFile mf, TrackDisplay t, float r,
            PrintDocument p)
        {
            InitializeComponent();
            _totalPages = totalP;
            _currentPage = 0;
            _midiFileName = fileName;
            _currentFile = mf;
            _zoomValue = zoom;
            _trackDisplay = t;
            _relThickness = r;
            _rowsPerPage = rpp;
            _printDoc = p;
            MouseEnter += PrintPreviewForm_MouseEnter;
            _jl = true;
        }

        private void PrintPreviewForm_MouseEnter(object sender, EventArgs e)
        {
            if (_jl)
            {
                _jl = false;
                PaintPictureBox(_rowsPerPage);
            }
        }

        private void PaintPictureBox(int rowsPerPage)
        {
            var g = pictureBox1.CreateGraphics();
            var framepen = new Pen(Color.Black, 3);
            var drawFont = new Font("Courier New", 10);
            var drawBrush = new SolidBrush(Color.Black);
            g.PageUnit = GraphicsUnit.Pixel;

            var s = _midiFileName + " [" + (_currentPage + 1) + "]";
            g.DrawString(s, drawFont, drawBrush, 0, 0);
            var h0 = (int) (drawFont.Height*g.DpiX/96);
            var vscale = (int) (g.VisibleClipBounds.Height - h0)/rowsPerPage/(_currentFile.max_note - _currentFile.min_note);
            var h = vscale*(_currentFile.max_note - _currentFile.min_note);

            for (var i = 0; i < rowsPerPage; i++)
            {
                if ((rowsPerPage*_currentPage + i)*_zoomValue >= _currentFile.bars) break;
                draw_notes(g, (rowsPerPage*_currentPage + i)*_zoomValue, h0 + i*h, vscale);
                g.DrawLine(framepen, 0, h0 + i*h, 0, h0 + (i + 1)*h);
                g.DrawLine(framepen, g.VisibleClipBounds.Width - 1, h0 + i*h, g.VisibleClipBounds.Width - 1,
                    h0 + (i + 1)*h);
                g.DrawLine(framepen, 0, h0 + i*h, g.VisibleClipBounds.Width, h0 + i*h);
                g.DrawLine(framepen, 0, h0 + (i + 1)*h, g.VisibleClipBounds.Width, h0 + (i + 1)*h);
                /*if (qualityCheck.Checked)
               {
                   draw_chords(g,(n*currentPage+i)*zoomScroll.Value,h0+i*h+noteDisplay.Height);
                   g.DrawLine(barpen,0,h0+(i+1)*h+noteDisplay.Height,g.VisibleClipBounds.Width,h0+(i+1)*h+noteDisplay.Height);
               }*/
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
                pictureBox1.Refresh();

                PaintPictureBox(_rowsPerPage);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages - 1)
            {
                _currentPage++;
                pictureBox1.Refresh();

                PaintPictureBox(_rowsPerPage);
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            var p = new PrintDialog {Document = _printDoc};
            if (p.ShowDialog() == DialogResult.OK)
            {
                _printDoc.Print();
                Close();
            }
        }

        private void draw_notes(Graphics g, int offset, int y0, int vscale)
        {
            var smallFont = new Font("Courier New", 6);
            var drawBrush = new SolidBrush(Color.Black);
            var barpen = new Pen(Color.LightGray, 1);
            var orientpen = new Pen(Color.LightGray, 1);
            var grw = (int) g.VisibleClipBounds.Width;
            var grh = vscale*(_currentFile.max_note - _currentFile.min_note);
            // draw bar markers & bar numbers
            if (_zoomValue < 100)
                for (var i = 0; i < _zoomValue; i++)
                {
                    if (i > 0) g.DrawLine(barpen, i*grw/_zoomValue, y0, i*grw/_zoomValue, y0 + grh);
                    if ((offset + i)%_zoomValue == 0)
                        g.DrawString((offset + i + 1).ToString(), smallFont, drawBrush, i*(float)grw/_zoomValue, y0);
                }
            // draw horizontal orientation lines at each D,F and A
            for (var a = 0; a < 10; a++)
            {
                var b = a*12 + 2;
                int y;
                if (b < _currentFile.max_note && b > _currentFile.min_note)
                {
                    y = vscale*(_currentFile.max_note - b) + y0;
                    g.DrawLine(barpen, 0, y, g.VisibleClipBounds.Width, y);
                }
                b = a*12 + 5;
                if (b < _currentFile.max_note && b > _currentFile.min_note)
                {
                    y = vscale*(_currentFile.max_note - b) + y0;
                    g.DrawLine(orientpen, 0, y, g.VisibleClipBounds.Width, y);
                }
                b = a*12 + 9;
                if (b < _currentFile.max_note && b > _currentFile.min_note)
                {
                    y = vscale*(_currentFile.max_note - b) + y0;
                    g.DrawLine(orientpen, 0, y, g.VisibleClipBounds.Width, y);
                }
            }
            //
            // draw notes

            _trackDisplay.Draw(g, _currentFile.max_note, offset, _currentFile.timing, _zoomValue, vscale, _relThickness);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PaintPictureBox(_rowsPerPage);
        }
    }
}