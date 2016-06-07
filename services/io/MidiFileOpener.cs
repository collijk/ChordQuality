using System.ComponentModel;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.services.io
{
    internal class MidiFileOpener
    {
        // Thread safe singleton pattern for MidiFileOpener construction.
        private static MidiFileOpener _instance;
        private static readonly object Padlock = new object();
        private IEventAggregator _eventAggregator;
        private OpenFileDialog _openMidiFileDialog;

        private MidiFileOpener()
        {
            InitializeServices();
            InitializeDialog();
        }

        public static MidiFileOpener Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new MidiFileOpener();
                    }
                    return _instance;
                }
            }
        }

        private void InitializeServices()
        {
            _eventAggregator = EventAggregator.Instance;
        }

        private void InitializeDialog()
        {
            _openMidiFileDialog = new OpenFileDialog {Filter = "MIDI-Files|*.mid"};
            _openMidiFileDialog.FileOk += OpenFileDialogFileOk;
        }

        private void OpenFileDialogFileOk(object sender, CancelEventArgs e)
        {
            // read midi file
            MidiFileReader fileReader = new MidiFileReader();
            MidiFile file = fileReader.Read(_openMidiFileDialog.FileName);

            var message = new FileOpenedMessage {File = file};
            _eventAggregator.Publish(message);
        }

        public void OpenMidiFile()
        {
            _openMidiFileDialog.ShowDialog();
        }
    }
}