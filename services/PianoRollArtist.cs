using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChordQuality.services
{
    // Temporary class to aid in MainForm Refactor.
    // Drawing methods will be moved to the display classes that need them
    // once they are separated from the MainForm and most of the message passing
    // will disappear.
    class PianoRollArtist
    {
        Color[] colors = new Color[19] {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black };
        Font smallFont = new Font("Courier New", 6);
        Pen barpen = new Pen(Color.LightGray, 1);
        Pen pen = new Pen(Color.Black, 2);
        Pen thinpen = new Pen(Color.Black, 1);
        Color selectColor = Color.FromArgb(32, 0, 0, 255);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        Font drawFont = new Font("Courier New", 10);
        Pen orientpen = new Pen(Color.LightGray, 1);
        private int zoomScrollValue = 0;
        private float relThickness = 0.5f;
        private double playStart = -1;
        private double playStop = -1;
        private MidiFile currentFile = null;
        private TrackDisplay trackDisplay = null;
        private PictureBox noteDisplay;
        private PictureBox chordDisplay;
        private TuningScheme[] tunings;
        private QualityWeights qualityWeights;
        private PictureBox chordNameDisplay;

        private IEventAggregator eventAggregator;
        private ISubscription<ZoomScrollChangedMessage> zoomScrollSubscription;
        private ISubscription<FileOpenedMessage> fileSubscription;
        private ISubscription<TrackDisplayChangedMessage> trackDisplaySubscription;
        private ISubscription<RelThicknessChangedMessage> relThicknessSubscription;
        private ISubscription<PlaySelectionChangedMessage> playSelectionSubscription;

        public PianoRollArtist(PictureBox noteDisplay, PictureBox chordDisplay, TuningScheme[] tunings, 
            QualityWeights qualityWeights, PictureBox chordNameDisplay)
        {
            initializeSubscriptions();
            this.noteDisplay = noteDisplay;
            this.chordDisplay = chordDisplay;
            this.tunings = tunings;
            this.qualityWeights = qualityWeights;
            this.chordNameDisplay = chordNameDisplay;
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            zoomScrollSubscription = eventAggregator.Subscribe<ZoomScrollChangedMessage>(Message =>
            {
                zoomScrollValue = Message.zoomValue;
            });
            fileSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                currentFile = Message.file;
            });
            trackDisplaySubscription = eventAggregator.Subscribe<TrackDisplayChangedMessage>(Message =>
            {
                trackDisplay = Message.trackDisplay;
            });
            relThicknessSubscription = eventAggregator.Subscribe<RelThicknessChangedMessage>(Message =>
            {
                relThickness = Message.relThickness;
            });
            playSelectionSubscription = eventAggregator.Subscribe<PlaySelectionChangedMessage>(Message =>
            {
                playStart = Message.playStart;
                playStop = Message.playStop;
            });
        }

        // draw piano roll, starting at bar offset
        public void draw_notes(Graphics gr, int offset, int y0, int vscale)
        {
            draw_notes(gr, offset, y0, vscale, zoomScrollValue);
        }

        public void draw_notes(Graphics gr, int offset, int y0, int vscale, int zoomValue)
        {
            int grw = (int) (gr.VisibleClipBounds.Width);
            int grh = vscale * (currentFile.max_note - currentFile.min_note);
            // draw bar markers & bar numbers
            if(zoomValue < 100)
                for(int i = 0; i < zoomValue; i++)
                {
                    if(i > 0)
                        gr.DrawLine(barpen, i * grw / zoomValue, y0, i * grw / zoomValue, y0 + grh);
                    if((offset + i) % zoomValue == 0)
                        gr.DrawString((offset + i + 1).ToString(), smallFont, drawBrush, i * grw / zoomValue, y0);
                }
            // draw horizontal orientation lines at each D,F and A
            int y;
            for(int a = 0; a < 10; a++)
            {
                int b = a * 12 + 2;
                if(b < currentFile.max_note && b > currentFile.min_note)
                {
                    y = vscale * (currentFile.max_note - b) + y0;
                    gr.DrawLine(barpen, 0, y, gr.VisibleClipBounds.Width, y);
                }
                b = a * 12 + 5;
                if(b < currentFile.max_note && b > currentFile.min_note)
                {
                    y = vscale * (currentFile.max_note - b) + y0;
                    gr.DrawLine(orientpen, 0, y, gr.VisibleClipBounds.Width, y);
                }
                b = a * 12 + 9;
                if(b < currentFile.max_note && b > currentFile.min_note)
                {
                    y = vscale * (currentFile.max_note - b) + y0;
                    gr.DrawLine(orientpen, 0, y, gr.VisibleClipBounds.Width, y);
                }
            }
            //
            // draw notes

            if(trackDisplay != null)
            {
                trackDisplay.Draw(gr, grw, y0, currentFile.max_note, offset,
                                  currentFile.timing, zoomValue, vscale, relThickness);
            }

            // draw selection
            if(playStart >= 0)
            {
                Brush sel_brush = new SolidBrush(selectColor);
                int x = (int) (grw * (Math.Min(playStart, playStop) - offset) / zoomValue);
                int w = (int) (grw * Math.Abs(playStop - playStart) / zoomValue);
                gr.FillRectangle(sel_brush, x, 0, w, grh);
            }
            noteDisplay.Refresh();
        }

        public void draw_chords(Graphics gr, int offset, int y0)
        {
            if(!chordDisplay.Visible)
                return;
            int grw = (int) (gr.VisibleClipBounds.Width);
            int grh = chordDisplay.Height;
            int mintime = offset * 4 * currentFile.timing;
            int maxtime = (offset + zoomScrollValue + 1) * 4 * currentFile.timing;
            int x1, x2, y;
            // draw bar markers for chord display
            if(zoomScrollValue < 100)
                for(int i = 1; i < zoomScrollValue; i++)
                    gr.DrawLine(barpen, i * grw / zoomScrollValue, y0, i * grw / zoomScrollValue, y0 + grh);
            // draw chords
            int q;
            for(int i = 0; i < tunings.Length; i++)
                if(tunings[i].enabled)
                {
                    pen.Color = colors[i];
                    thinpen.Color = colors[i];
                    foreach(TimeInfo c in currentFile.FindChords())
                    {
                        if(c.Time > maxtime)
                            break;
                        if(c.Time >= mintime && qualityWeights.enabled(c))
                        {
                            x1 = grw * (c.Time - 4 * offset * currentFile.timing) / currentFile.timing / 4 / zoomScrollValue;
                            x2 = grw * (c.Time + c.Duration - 4 * offset * currentFile.timing) / currentFile.timing / 4 / zoomScrollValue;
                            q = (int) tunings[i].Quality(c, qualityWeights);
                            y = y0 + grh - 1 - 2 * q;
                            if(c.IsChord)
                                gr.DrawLine(pen, x1, y, x2, y);
                            else
                                gr.DrawLine(thinpen, x1, y, x2, y);
                        }
                    }
                }
            chordDisplay.Refresh();
        }

        public void draw_chordnames(Graphics gr, int offset, int y0)
        {
            if(!chordNameDisplay.Visible)
                return;
            int grw = (int) (gr.VisibleClipBounds.Width);
            int mintime = offset * 4 * currentFile.timing;
            int maxtime = (offset + zoomScrollValue + 1) * 4 * currentFile.timing;
            int x;
            string s;
            foreach(TimeInfo c in currentFile.FindChords())
            {
                if(c.Time > maxtime)
                    break;
                if(c.Time >= mintime && qualityWeights.enabled(c))
                {
                    s = c.Name;
                    x = grw * (c.Time - 4 * offset * currentFile.timing) / currentFile.timing / 4 / zoomScrollValue;
                    if(c.IsChord)
                    {
                        gr.DrawString(s.Substring(0, 1), drawFont, drawBrush, x, y0);
                        if(s.Length > 1)
                            gr.DrawString(s.Substring(1, 1), drawFont, drawBrush, x, y0 + drawFont.Size);
                    } else
                    {
                        gr.DrawString(s.Substring(0, 1), smallFont, drawBrush, x, y0);
                        if(s.Length > 1)
                            gr.DrawString(s.Substring(1, 1), smallFont, drawBrush, x, y0 + smallFont.Size);
                        if(s.Length > 2)
                            gr.DrawString(s.Substring(2, 1), smallFont, drawBrush, x, y0 + 2 * smallFont.Size);
                    }
                }
            }
            chordNameDisplay.Refresh();
        }
    }
}

