using System.Drawing;
using System.Drawing.Printing;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.services
{
    internal class PrintDocumentProvider
    {
        // Thread safe singleton pattern for EventAggregator construction.
        private static PrintDocumentProvider _instance;
        private static readonly object Padlock = new object();
        private readonly SolidBrush _drawBrush = new SolidBrush(Color.Black);
        private readonly Font _drawFont = new Font("Courier New", 10);
        private readonly Pen _framepen = new Pen(Color.Black, 3);
        private readonly int _pages;
        private PianoRollArtist _artist;
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;
        private int _pagesPrinted;
        private PrintDocument _printDoc;
        private int _rowsPerPage;
        private ISubscription<RowsPerPageChangedMessage> _rowsPerPageSubscription;
        private int _zoomScrollValue;
        private ISubscription<ZoomScrollChangedMessage> _zoomValueSubscription;

        private PrintDocumentProvider()
        {
            InitializeSubscriptions();
            _pagesPrinted = 0;
            _pages = 0;
            _rowsPerPage = 5;
        }

        public static PrintDocumentProvider Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new PrintDocumentProvider());
                }
            }
        }

        public void SetArtist(PianoRollArtist artist)
        {
            _artist = artist;
        }


        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
            _zoomValueSubscription =
                _eventAggregator.Subscribe<ZoomScrollChangedMessage>(message => { _zoomScrollValue = message.ZoomValue; });
            _rowsPerPageSubscription =
                _eventAggregator.Subscribe<RowsPerPageChangedMessage>(message => { _rowsPerPage = message.RowsPerPage; });
        }

        public PrintDocument GetPrintDoc()
        {
            _printDoc = new PrintDocument {DefaultPageSettings = {Landscape = true}};
            _printDoc.PrintPage += PrintPage;
            _printDoc.PrinterSettings.FromPage = 1;
            _printDoc.PrinterSettings.MaximumPage = _pages;
            _printDoc.PrinterSettings.ToPage = _printDoc.PrinterSettings.MaximumPage;
            _pagesPrinted = 0;

            return _printDoc;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.PageUnit = GraphicsUnit.Pixel;

            var s = _currentFile.name + " [" + (_pagesPrinted + 1) + "]";
            ev.Graphics.DrawString(s, _drawFont, _drawBrush, 0, 0);
            var h0 = (int) (_drawFont.Height*ev.Graphics.DpiX/96);
            var vscale = (int) (ev.Graphics.VisibleClipBounds.Height - h0)/_rowsPerPage/
                         (_currentFile.max_note - _currentFile.min_note);
            var h = vscale*(_currentFile.max_note - _currentFile.min_note);
            if (_printDoc.PrinterSettings.PrintRange == PrintRange.SomePages &&
                _pagesPrinted < _printDoc.PrinterSettings.FromPage - 1)
                _pagesPrinted = _printDoc.PrinterSettings.FromPage - 1;

            for (var i = 0; i < _rowsPerPage; i++)
            {
                if ((_rowsPerPage*_pagesPrinted + i)*_zoomScrollValue >= _currentFile.bars)
                    break;
                _artist.draw_notes(ev.Graphics, (_rowsPerPage*_pagesPrinted + i)*_zoomScrollValue, h0 + i*h, vscale);
                ev.Graphics.DrawLine(_framepen, 0, h0 + i*h, 0, h0 + (i + 1)*h);
                ev.Graphics.DrawLine(_framepen, ev.Graphics.VisibleClipBounds.Width - 1, h0 + i*h,
                    ev.Graphics.VisibleClipBounds.Width - 1, h0 + (i + 1)*h);
                ev.Graphics.DrawLine(_framepen, 0, h0 + i*h, ev.Graphics.VisibleClipBounds.Width, h0 + i*h);
                ev.Graphics.DrawLine(_framepen, 0, h0 + (i + 1)*h, ev.Graphics.VisibleClipBounds.Width, h0 + (i + 1)*h);
                /*if (qualityCheck.Checked)
				{
					draw_chords(ev.Graphics,(n*pages_printed+i)*zoomScroll.Value,h0+i*h+noteDisplay.Height);
					ev.Graphics.DrawLine(barpen,0,h0+(i+1)*h+noteDisplay.Height,ev.Graphics.VisibleClipBounds.Width,h0+(i+1)*h+noteDisplay.Height);
				}*/
            }
            _pagesPrinted++;
            if (_printDoc.PrinterSettings.PrintRange == PrintRange.SomePages)
            {
                ev.HasMorePages = _pagesPrinted < _printDoc.PrinterSettings.ToPage;
            }
            else
            {
                ev.HasMorePages = _pagesPrinted*_rowsPerPage*_zoomScrollValue < _currentFile.bars;
            }
        }
    }
}