using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using Janus.Misc;

namespace ChordQuality.services.io
{
    internal class MidiToTextWriter
    {
        // Thread safe singleton pattern for MidiToTextWriter construction.
        private static MidiToTextWriter _instance;
        private static readonly object Padlock = new object();
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;
        private SaveFileDialog _saveMidiToTextDialog;

        private MidiToTextWriter()
        {
            InitializeSubscriptions();
            InitializeDialog();
        }

        public static MidiToTextWriter Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new MidiToTextWriter());
                }
            }
        }

        private void InitializeDialog()
        {
            _saveMidiToTextDialog = new SaveFileDialog
            {
                DefaultExt = "txt",
                Filter = @"TXT-Files|*.txt"
            };
            _saveMidiToTextDialog.FileOk += SaveFileDialogFileOk;
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
        }

        private void SaveFileDialogFileOk(object sender, CancelEventArgs e)
        {
            var streamWriter = new StreamWriter(_saveMidiToTextDialog.FileName);
            foreach (MidiTrack track in _currentFile.tracks)
            {
                streamWriter.WriteLine("######## TRACK " + (Array.IndexOf(_currentFile.tracks, track) + 1) +
                                       " ########################");
                foreach (object t in track.events)
                    streamWriter.WriteLine(t.ToString());
            }
            streamWriter.Close();
            Shell.Execute(_saveMidiToTextDialog.FileName);
        }

        public void WriteMidiToText()
        {
            _saveMidiToTextDialog.ShowDialog();
        }
    }
}