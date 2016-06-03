using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System.Windows.Forms;
using System;

namespace ChordQuality.controls
{
    public partial class FileTransposeControl : UserControl
    {

        private IEventAggregator eventAggregator;
        private ISubscription<FileOpenedMessage> fileOpenedSubscription;
        private ISubscription<BarOffsetChangedMessage> barOffsetSubscription;
        private MidiFile file;

        public FileTransposeControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            fileOpenedSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                onFileOpened(Message.file);
            });
            barOffsetSubscription = eventAggregator.Subscribe<BarOffsetChangedMessage>(Message =>
            {
                offsetValueLabel.Text = Message.offsetValue + " Bars";
            });
        }

        private void onFileOpened(MidiFile file)
        {
            this.file = file;
            fileTransposeUpDown.Maximum = 127 - file.max_note;
            fileTransposeUpDown.Minimum = 0 - file.min_note;
            fileTransposeUpDown.Value = 0;
            offsetValueLabel.Text = "0 Bars";
        }

        private void fileTransposeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(file != null)
            {
                file.Transpose((int) fileTransposeUpDown.Value);
                FileTransposedMessage message = new FileTransposedMessage();
                message.chords = file.FindChords();
                eventAggregator.Publish(message);                
            }
        }
    }
}
