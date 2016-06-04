using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ChordQuality.events.messages;
using ChordQuality.events;

namespace ChordQuality.services.io
{
    class MidiFileOpener
    {
        private IEventAggregator eventAggregator;
        private OpenFileDialog openMidiFileDialog;

        // Thread safe singleton pattern for MidiFileOpener construction.
        private static MidiFileOpener instance = null;
        private static readonly object padlock = new object();
               
        public static MidiFileOpener Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new MidiFileOpener();
                    }
                    return instance;
                }
            }
        }

        private MidiFileOpener()
        {
            initializeServices();
            initializeDialog();            
        }

        private void initializeServices()
        {
            eventAggregator = EventAggregator.Instance;            
        }

        private void initializeDialog()
        {
            openMidiFileDialog = new OpenFileDialog();
            openMidiFileDialog.Filter = "MIDI-Files|*.mid";
            openMidiFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogFileOk);
        }

        private void OpenFileDialogFileOk(object sender, CancelEventArgs e)
        {
            // read midi file
            MidiFileReader fileReader = new MidiFileReader();
            MidiFile file = fileReader.Read(openMidiFileDialog.FileName);

            FileOpenedMessage message = new FileOpenedMessage();
            message.file = file;
            eventAggregator.Publish(message);           
        }

        public void openMidiFile()
        {
            openMidiFileDialog.ShowDialog();
        }
    }
}
