using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class FileTransposeControl : UserControl
    {
        private ISubscription<BarOffsetChangedMessage> _barOffsetSubscription;
        private IEventAggregator _eventAggregator;
        private MidiFile _file;
        private ISubscription<FileUpdatedMessage> _fileOpenedSubscription;

        public FileTransposeControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _fileOpenedSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { OnFileUpdated(message.File); });
            _barOffsetSubscription =_eventAggregator.Subscribe<BarOffsetChangedMessage>(
                    message => { offsetValueLabel.Text = message.OffsetValue + @" Bars"; });
        }

        private void OnFileUpdated(MidiFile file)
        {
            _file = file;
            fileTransposeUpDown.Maximum = 127 - file.max_note;
            fileTransposeUpDown.Minimum = 0 - file.min_note;
            fileTransposeUpDown.Value = 0;
            offsetValueLabel.Text = @"0 Bars";
            fileTransposeUpDown.Enabled = true;
        }

        private void fileTransposeUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_file == null) return;
            _file.Transpose((int) fileTransposeUpDown.Value);
            var message = new FileTransposedMessage {Chords = _file.FindChords()};
            _eventAggregator.Publish(message);
        }
    }
}