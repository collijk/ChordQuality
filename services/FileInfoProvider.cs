using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.views;
using Janus.ManagedMIDI;

namespace ChordQuality.services
{
    internal class FileInfoProvider
    {
        // Thread safe singleton pattern for EventAggregator construction.
        private static FileInfoProvider _instance;
        private static readonly object Padlock = new object();
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;

        private FileInfoProvider()
        {
            InitializeSubscriptions();
        }

        public static FileInfoProvider Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileInfoProvider();
                    }
                    return _instance;
                }
            }
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
        }

        internal void ShowInfo()
        {
            var infoForm = new FileInfoForm(_currentFile);
            infoForm.Show();
        }
    }
}