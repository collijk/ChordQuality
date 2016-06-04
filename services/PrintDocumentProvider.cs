using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.services
{
    class PrintDocumentProvider
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileOpenedMessage> midiFileSubscription;
        private ISubscription<ZoomScrollChangedMessage> zoomValueSubscription;
        private ISubscription<RowsPerPageChangedMessage> rowsPerPageSubscription;
        private MidiFile currentFile;
        private int pages_printed, Pages, RowsPerPage;
        private PrintDocument printDoc;
        private PianoRollArtist artist;
        private int zoomScrollValue = 0;
        Font drawFont = new Font("Courier New", 10);
        Pen framepen = new Pen(Color.Black, 3);
        SolidBrush drawBrush = new SolidBrush(Color.Black);

        
        // Thread safe singleton pattern for EventAggregator construction.
        private static PrintDocumentProvider instance = null;
        private static readonly object padlock = new object();

        public static PrintDocumentProvider Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new PrintDocumentProvider();
                    }
                    return instance;
                }
            }
        }

        private PrintDocumentProvider()
        {
            initializeSubscriptions();            
            pages_printed = 0;
            Pages = 0;
            RowsPerPage = 5;
        }

        public void setArtist(PianoRollArtist artist)
        {
            this.artist = artist;            
        }

        

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                currentFile = Message.file;
            });
            zoomValueSubscription = eventAggregator.Subscribe<ZoomScrollChangedMessage>(Message =>
            {
                zoomScrollValue = Message.zoomValue;
            });
            rowsPerPageSubscription = eventAggregator.Subscribe<RowsPerPageChangedMessage>(Message =>
            {
                RowsPerPage = Message.RowsPerPage;
            });
        }

        public PrintDocument getPrintDoc()
        {
            printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.PrinterSettings.FromPage = 1;
            printDoc.PrinterSettings.MaximumPage = Pages;
            printDoc.PrinterSettings.ToPage = printDoc.PrinterSettings.MaximumPage;
            pages_printed = 0;
            
            return printDoc;
        }

        void PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.PageUnit = GraphicsUnit.Pixel;
            
            string s = currentFile.name + " [" + (pages_printed + 1).ToString() + "]";
            ev.Graphics.DrawString(s, drawFont, drawBrush, 0, 0);
            int h0 = (int) (drawFont.Height * ev.Graphics.DpiX / 96);
            int vscale = (int) (ev.Graphics.VisibleClipBounds.Height - h0) / RowsPerPage / (currentFile.max_note - currentFile.min_note);
            int h = vscale * (currentFile.max_note - currentFile.min_note);
            if(printDoc.PrinterSettings.PrintRange == PrintRange.SomePages && pages_printed < printDoc.PrinterSettings.FromPage - 1)
                pages_printed = printDoc.PrinterSettings.FromPage - 1;

            for(int i = 0; i < RowsPerPage; i++)
            {
                if((RowsPerPage * pages_printed + i) * zoomScrollValue >= currentFile.bars)
                    break;
                artist.draw_notes(ev.Graphics, (RowsPerPage * pages_printed + i) * zoomScrollValue, h0 + i * h, vscale);
                ev.Graphics.DrawLine(framepen, 0, h0 + i * h, 0, h0 + (i + 1) * h);
                ev.Graphics.DrawLine(framepen, ev.Graphics.VisibleClipBounds.Width - 1, h0 + i * h, ev.Graphics.VisibleClipBounds.Width - 1, h0 + (i + 1) * h);
                ev.Graphics.DrawLine(framepen, 0, h0 + i * h, ev.Graphics.VisibleClipBounds.Width, h0 + i * h);
                ev.Graphics.DrawLine(framepen, 0, h0 + (i + 1) * h, ev.Graphics.VisibleClipBounds.Width, h0 + (i + 1) * h);
                /*if (qualityCheck.Checked)
				{
					draw_chords(ev.Graphics,(n*pages_printed+i)*zoomScroll.Value,h0+i*h+noteDisplay.Height);
					ev.Graphics.DrawLine(barpen,0,h0+(i+1)*h+noteDisplay.Height,ev.Graphics.VisibleClipBounds.Width,h0+(i+1)*h+noteDisplay.Height);
				}*/
            }
            pages_printed++;
            if(printDoc.PrinterSettings.PrintRange == PrintRange.SomePages)
            {
                if(pages_printed < printDoc.PrinterSettings.ToPage)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            } else
            {
                if(pages_printed * RowsPerPage * zoomScrollValue < currentFile.bars)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
        }
    }
}
