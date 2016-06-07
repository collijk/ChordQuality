using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class PenaltiesControl : UserControl
    {
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;
        private QualityWeights _qualityWeights;
        private ISubscription<QualityWeightsUpdatedMessage> _qualityWeightsSubscription;

        public PenaltiesControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _qualityWeightsSubscription =
                _eventAggregator.Subscribe<QualityWeightsUpdatedMessage>(
                    message => { _qualityWeights = message.QualityWeights; });
            _fileUpdatedSubscription = _eventAggregator.Subscribe<FileUpdatedMessage>(message =>
            {
                _currentFile = message.File;
                EnableControls();
            });
        }

        private void EnableControls()
        {
            thresholdUpDown.Enabled = true;
            penaltyAddVScroll.Enabled = true;
            penaltyShortVScroll.Enabled = true;
        }

        private void thresholdUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (_currentFile == null) return;
            _qualityWeights.Threshold = 4*_currentFile.timing/Math.Pow(2.0, thresholdUpDown.SelectedIndex);
            var pMessage = new PenaltiesChangedMessage {Penalties = thresholdUpDown.Text};
            _eventAggregator.Publish(pMessage);
        }

        private void penaltyAddVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.Add = (10 - penaltyAddVScroll.Value)/10.0;
        }

        private void penaltyShortVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.Short = (10 - penaltyShortVScroll.Value)/10.0;
            _eventAggregator.Publish(new PenaltyScrollChangedMessage());
        }
    }
}