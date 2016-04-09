using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Janus.ManagedMIDI;

namespace ChordQuality
{
    public partial class PrintPreviewForm : Form
    {
        private int currentPage;
        private int totalPages;
        private int zoomV;
        private String midiFileName;
        private MidiFile f;
        private float rf;
        private TrackDisplay td;
        private int rowsPerPage;
        private PrintDocument pd;
        private bool jl;

       public PrintPreviewForm(int rpp, int totalP, int zoom, String fileName, MidiFile mf, TrackDisplay t, float r, PrintDocument p)
        {
            InitializeComponent();
            totalPages = totalP;
            currentPage = 0;
            midiFileName = fileName;
            f = mf;
            zoomV = zoom;
            td = t;
            rf = r;
            rowsPerPage = rpp;
            pd = p;
            this.MouseEnter += new EventHandler(PrintPreviewForm_MouseEnter);
            jl = true;
        }

       void PrintPreviewForm_MouseEnter(object sender, EventArgs e)
       {
           if (jl)
           {
               jl = false;
               paintPictureBox(rowsPerPage);
           }
       }

       private void paintPictureBox(int rowsPerPage)
       {
           Graphics g = this.pictureBox1.CreateGraphics();
           Pen framepen = new Pen(Color.Black, 3);
           Font drawFont = new Font("Courier New", 10);
           SolidBrush drawBrush = new SolidBrush(Color.Black);
           g.PageUnit = GraphicsUnit.Pixel;

           string s = midiFileName + " [" + (currentPage + 1).ToString() + "]";
           g.DrawString(s, drawFont, drawBrush, 0, 0);
           int h0 = (int)(drawFont.Height * g.DpiX / 96);
           int vscale = (int)(g.VisibleClipBounds.Height - h0) / rowsPerPage / (f.max_note - f.min_note);
           int h = vscale * (f.max_note - f.min_note);

           for (int i = 0; i < rowsPerPage; i++)
           {
               if ((rowsPerPage * currentPage + i) * zoomV >= f.bars) break;
               draw_notes(g, (rowsPerPage * currentPage + i) * zoomV, h0 + i * h, vscale);
               g.DrawLine(framepen, 0, h0 + i * h, 0, h0 + (i + 1) * h);
               g.DrawLine(framepen, g.VisibleClipBounds.Width - 1, h0 + i * h, g.VisibleClipBounds.Width - 1, h0 + (i + 1) * h);
               g.DrawLine(framepen, 0, h0 + i * h, g.VisibleClipBounds.Width, h0 + i * h);
               g.DrawLine(framepen, 0, h0 + (i + 1) * h, g.VisibleClipBounds.Width, h0 + (i + 1) * h);
               /*if (qualityCheck.Checked)
               {
                   draw_chords(g,(n*currentPage+i)*zoomScroll.Value,h0+i*h+noteDisplay.Height);
                   g.DrawLine(barpen,0,h0+(i+1)*h+noteDisplay.Height,g.VisibleClipBounds.Width,h0+(i+1)*h+noteDisplay.Height);
               }*/
           }
           
          
       }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                this.pictureBox1.Refresh();
               
                paintPictureBox(rowsPerPage);
            }

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages-1)
            {
                currentPage++;
                this.pictureBox1.Refresh();
               
                paintPictureBox(rowsPerPage);
            }

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDialog p = new PrintDialog();
            p.Document = pd;
            if (p.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
                this.Close();
            }
        }

        void draw_notes(Graphics g, int offset, int y0, int vscale)
        {
            Font smallFont = new Font("Courier New", 6);
            Font drawFont = new Font("Courier New", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen barpen = new Pen(Color.LightGray, 1);
            Pen orientpen = new Pen(Color.LightGray, 1);
            int grw = (int)(g.VisibleClipBounds.Width);
            int grh = vscale * (f.max_note - f.min_note);
            // draw bar markers & bar numbers
            if (zoomV < 100)
                for (int i = 0; i < zoomV; i++)
                {
                    if (i > 0) g.DrawLine(barpen, i * grw / zoomV, y0, i * grw / zoomV, y0 + grh);
                    if ((offset + i) % zoomV == 0) g.DrawString((offset + i + 1).ToString(), smallFont, drawBrush, i * grw / zoomV, y0);
                }
            // draw horizontal orientation lines at each D,F and A
            int y;
            for (int a = 0; a < 10; a++)
            {
                int b = a * 12 + 2;
                if (b < f.max_note && b > f.min_note)
                {
                    y = vscale * (f.max_note - b) + y0;
                    g.DrawLine(barpen, 0, y, g.VisibleClipBounds.Width, y);
                }
                b = a * 12 + 5;
                if (b < f.max_note && b > f.min_note)
                {
                    y = vscale * (f.max_note - b) + y0;
                    g.DrawLine(orientpen, 0, y, g.VisibleClipBounds.Width, y);
                }
                b = a * 12 + 9;
                if (b < f.max_note && b > f.min_note)
                {
                    y = vscale * (f.max_note - b) + y0;
                    g.DrawLine(orientpen, 0, y, g.VisibleClipBounds.Width, y);
                }
            }
            //
            // draw notes

           td.Draw(g, grw, y0, f.max_note, offset, f.timing, zoomV, vscale, rf);
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            paintPictureBox(rowsPerPage);
        }


    }
}
