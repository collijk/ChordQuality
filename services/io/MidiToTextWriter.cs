using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using Janus.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace ChordQuality.services.io
{
    class MidiToTextWriter
    {
        private IEventAggregator eventAggregator;
        private SaveFileDialog saveMidiToTextDialog;
        private ISubscription<FileUpdatedMessage> midiFileSubscription;
        private MidiFile currentFile;

        // Thread safe singleton pattern for MidiToTextWriter construction.
        private static MidiToTextWriter instance = null;
        private static readonly object padlock = new object();

        public static MidiToTextWriter Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new MidiToTextWriter();
                    }
                    return instance;
                }
            }
        }

        private MidiToTextWriter()
        {
            initializeSubscriptions();
            initializeDialog();
        }

        private void initializeDialog()
        {
            saveMidiToTextDialog = new SaveFileDialog();
            saveMidiToTextDialog.DefaultExt = "txt";
            saveMidiToTextDialog.Filter = "TXT-Files|*.txt";
            saveMidiToTextDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialogFileOk);
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
            StreamWriter streamWriter = new StreamWriter(saveMidiToTextDialog.FileName);
            foreach(MidiTrack track in currentFile.tracks)
            {
                streamWriter.WriteLine("######## TRACK " + (Array.IndexOf(currentFile.tracks, track) + 1).ToString() + " ########################");
                for(int i = 0; i < track.events.Count; i++)
                    streamWriter.WriteLine(track.events[i].ToString());
            }
            streamWriter.Close();
            Shell.Execute(saveMidiToTextDialog.FileName);
        }

        public void writeMidiToText()
        {
            saveMidiToTextDialog.ShowDialog();
        }      
    }
}
