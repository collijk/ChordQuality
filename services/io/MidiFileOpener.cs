using System.ComponentModel;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.services.io
{
    internal class MidiFileOpener
    {
        private OpenFileDialog _openMidiFileDialog;
        // Thread safe singleton pattern for MidiFileOpener construction.
        private static MidiFileOpener _instance;
        private static readonly object Padlock = new object();
        
        public MidiDataModel DataModel { get; set; }

        private MidiFileOpener()
        {
            InitializeDialog();
        }

        public static MidiFileOpener Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new MidiFileOpener());
                }
            }
        }

        private void InitializeDialog()
        {
            _openMidiFileDialog = new OpenFileDialog {Filter = @"MIDI-Files|*.mid"};
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