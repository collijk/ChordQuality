using ChordQuality.events;
using System.Windows.Forms;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class QualityWeightsControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<QualityWeightsUpdatedMessage> qualityWeightsSubscription;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;
        private QualityWeights qualityWeights;

        public QualityWeightsControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            qualityWeightsSubscription = eventAggregator.Subscribe<QualityWeightsUpdatedMessage>(Message =>
            {
                qualityWeights = Message.qualityWeights;                
            });
            fileUpdatedSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                enableScrollBars();
            });
        }

        private void enableScrollBars()
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
            qualityWeights.M6 = (20 - sixthMajorIntervalVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void sixthMinorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.m6 = (20 - sixthMinorIntervalVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void fifthIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.fifth = (20 - fifthIntervalVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void fourthIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.fourth = (20 - fifthIntervalVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void thirdMajorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.M3 = (20 - thirdMajorIntervalVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void thirdMinorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.m3 = (20 - thirdMinorIntervalVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void fifthChordVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.Ch5 = (20 - fifthChordVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }

        private void thirdMajorChordVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.Ch3 = (20 - thirdMajorChordVScroll.Value) / 10.0;
            eventAggregator.Publish(new QualityWeightScrollChangedMessage());
        }
    }
}
