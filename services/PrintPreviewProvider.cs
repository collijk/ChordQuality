using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.views;
using Janus.ManagedMIDI;

namespace ChordQuality.services
{
    internal class PrintPreviewProvider
    {
        // Thread safe singleton pattern for PrintPreviewProvider construction.
        private static PrintPreviewProvider _instance;
        private static readonly object Padlock = new object();
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;
        private PrintDocumentProvider _printDocProvider;
        private float _relThickness = 0.5f;
        private ISubscription<RelThicknessChangedMessage> _relThicknessSubscription;
        private int _rowsPerPage = 5;
        private ISubscription<RowsPerPageChangedMessage> _rowsPerPageSubscription;
        private TrackDisplay _trackDisplay;
        private ISubscription<TrackDisplayChangedMessage> _trackDisplaySubscription;
        private int _zoomScrollValue;
        private ISubscription<ZoomScrollChangedMessage> _zoomValueSubscription;

        private PrintPreviewProvider()
        {
            InitializeSubscriptions();
            InitializeServices();
        }

        public static PrintPreviewProvider Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new PrintPreviewProvider();
                    }
                    return _instance;
                }
            }
        }

        private void InitializeServices()
        {
            _printDocProvider = PrintDocumentProvider.Instance;
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
            _zoomValueSubscription =
                _eventAggregator.Subscribe<ZoomScrollChangedMessage>(message => { _zoomScrollValue = message.ZoomValue; });
            _trackDisplaySubscription =
                _eventAggregator.Subscribe<TrackDisplayChangedMessage>(
                    message => { _trackDisplay = message.TrackDisplay; });
            _relThicknessSubscription =
                _eventAggregator.Subscribe<RelThicknessChangedMessage>(
                    message => { _relThickness = message.RelThickness; });
            _rowsPerPageSubscription =
                _eventAggregator.Subscribe<RowsPerPageChangedMessage>(message => { _rowsPerPage = message.RowsPerPage; });
        }

        public void ShowPreview()
        {
            var printDoc = _printDocProvider.GetPrintDoc();
            var ppf = new PrintPreviewForm(_rowsPerPage, printDoc.DefaultPageSettings.PrinterSettings.ToPage,
                _zoomScrollValue, _currentFile.name, _currentFile, _trackDisplay, _relThickness, printDoc);
            ppf.Show();
        }
    }
}