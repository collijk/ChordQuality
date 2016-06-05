using ChordQuality.events;
using System.Windows.Forms;
using System;
using ChordQuality.events.messages;

namespace ChordQuality.controls
{
    public partial class QualityWeightsControl : UserControl
    {
        private IEventAggregator eventAggregator;

        public QualityWeightsControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
        }

        private void sixthMajorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "6M Interval";
            qMessage.scrollValue = sixthMajorIntervalVScroll.Value;
            eventAggregator.Publish(qMessage);

        }

        private void sixthMinorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "6m Interval";
            qMessage.scrollValue = sixthMinorIntervalVScroll.Value;
            eventAggregator.Publish(qMessage);
        }

        private void fifthIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "5 Interval";
            qMessage.scrollValue = fifthIntervalVScroll.Value;
            eventAggregator.Publish(qMessage);
        }

        private void fourthIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "4 Interval";
            qMessage.scrollValue = fourthIntervalVScroll.Value;
            eventAggregator.Publish(qMessage);
        }

        private void thirdMajorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "3M Interval";
            qMessage.scrollValue = thirdMajorIntervalVScroll.Value;
            eventAggregator.Publish(qMessage);
        }

        private void thirdMinorIntervalVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "3m Interval";
            qMessage.scrollValue = thirdMinorIntervalVScroll.Value;
            eventAggregator.Publish(qMessage);
        }

        private void fifthChordVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "5 Chord";
            qMessage.scrollValue = fifthChordVScroll.Value;
            eventAggregator.Publish(qMessage);
        }

        private void thirdMajorChordVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            QualityWeightScrollChangedMessage qMessage = new QualityWeightScrollChangedMessage();
            qMessage.source = "3M Chord";
            qMessage.scrollValue = thirdMajorChordVScroll.Value;
            eventAggregator.Publish(qMessage);
        }
    }
}
