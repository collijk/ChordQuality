using ChordQuality.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.services.io
{
    class MidiFileSaver
    {
        private IEventAggregator eventAggregator;
        private SaveFileDialog saveMidiFileDialog;
        private ISubscription<FileUpdatedMessage> midiFileSubscription;
        private MidiFile currentFile;

        // Thread safe singleton pattern for EventAggregator construction.
        private static MidiFileSaver instance = null;
        private static readonly object padlock = new object();        

        public static MidiFileSaver Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new MidiFileSaver();
                    }
                    return instance;
                }
            }
        }

        private MidiFileSaver()
        {
            initializeSubscriptions();
            initializeDialog();
        }

        public void saveMidiFile()
        {
            saveMidiFileDialog.ShowDialog();
        }

        private void initializeDialog()
        {
            saveMidiFileDialog = new SaveFileDialog();
            saveMidiFileDialog.DefaultExt = "mid";
            saveMidiFileDialog.Filter = "MIDI-Files|*.mid";
            saveMidiFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogFileOk);            
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;
            });
        }

        private void SaveFileDialogFileOk(object sender, CancelEventArgs e)
        {
            MidiFileWriter fileWriter = new MidiFileWriter();
            fileWriter.Write(currentFile, saveMidiFileDialog.FileName);
        }
    }
}
