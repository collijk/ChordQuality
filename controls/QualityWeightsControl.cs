using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class QualityWeightsControl : UserControl
    {
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;
        private QualityWeights _qualityWeights;
        private ISubscription<QualityWeightsUpdatedMessage> _qualityWeightsSubscription;

        public QualityWeightsControl()
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
            _fileUpdatedSubscription = _eventAggregator.Subscribe<FileUpdatedMessage>(message => { EnableScrollBars(); });
        }

        private void EnableScrollBars()
        {
            sixthMajorIntervalVScroll.Enabled = true;
            sixthMinorIntervalVScroll.Enabled = true;
            fifthIntervalVScroll.Enabled = true;
            fourthIntervalVScroll.Enabled = true;
            thirdMajorIntervalVScroll.Enabled = true;
            thirdMinorIntervalVScroll.Enabled = true;
            fifthChordVScroll.Enabled = true;
            thirdMajorChordVScroll.Enabled = true;
        }

        private void sixthMajorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.M6 = (20 - sixthMajorIntervalVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void sixthMinorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.m6 = (20 - sixthMinorIntervalVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void fifthIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.fifth = (20 - fifthIntervalVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void fourthIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.fourth = (20 - fifthIntervalVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void thirdMajorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.M3 = (20 - thirdMajorIntervalVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void thirdMinorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.m3 = (20 - thirdMinorIntervalVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void fifthChordVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.Ch5 = (20 - fifthChordVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void thirdMajorChordVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            _qualityWeights.Ch3 = (20 - thirdMajorChordVScroll.Value)/10.0;
            _eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }
    }
}