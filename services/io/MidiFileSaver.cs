using System.ComponentModel;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.services.io
{
    internal class MidiFileSaver
    {
        // Thread safe singleton pattern for EventAggregator construction.
        private static MidiFileSaver _instance;
        private static readonly object Padlock = new object();
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;
        private SaveFileDialog _saveMidiFileDialog;

        private MidiFileSaver()
        {
            InitializeSubscriptions();
            InitializeDialog();
        }

        public static MidiFileSaver Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new MidiFileSaver();
                    }
                    return _instance;
                }
            }
        }

        public void SaveMidiFile()
        {
            _saveMidiFileDialog.ShowDialog();
        }

        private void InitializeDialog()
        {
            _saveMidiFileDialog = new SaveFileDialog
            {
                DefaultExt = "mid",
                Filter = "MIDI-Files|*.mid"
            };
            _saveMidiFileDialog.FileOk += SaveFileDialogFileOk;
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
        }

        private void SaveFileDialogFileOk(object sender, CancelEventArgs e)
        {
            MidiFileWriter fileWriter = new MidiFileWriter();
            fileWriter.Write(_currentFile, _saveMidiFileDialog.FileName);
        }
    }
}