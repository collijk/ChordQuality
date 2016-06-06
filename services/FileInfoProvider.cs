using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.services
{
    class FileInfoProvider
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileUpdatedMessage> midiFileSubscription;
        private MidiFile currentFile;

        // Thread safe singleton pattern for EventAggregator construction.
        private static FileInfoProvider instance = null;
        private static readonly object padlock = new object();        

        public static FileInfoProvider Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new FileInfoProvider();
                    }
                    return instance;
                }
            }
        }

        private FileInfoProvider()
        {
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;
            });
        }

        internal void showInfo()
        {
            FileInfoForm infoForm = new FileInfoForm(currentFile);
            infoForm.Show();
        }
    }
}
