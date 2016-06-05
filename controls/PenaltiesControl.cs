using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System.Windows.Forms;
using System;

namespace ChordQuality.controls
{
    public partial class PenaltiesControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<QualityWeightsUpdatedMessage> qualityWeightsSubscription;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;
        private MidiFile currentFile;
        private QualityWeights qualityWeights;

        public PenaltiesControl()
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
                currentFile = Message.file;
                enableControls();
            });
        }

        private void enableControls()
        {
            thresholdUpDown.Enabled = true;
            penaltyAddVScroll.Enabled = true;
            penaltyShortVScroll.Enabled = true;
        }

        private void thresholdUpDown_SelectedItemChanged(object sender, System.EventArgs e)
        {
            if(currentFile != null)
            {
                switch(thresholdUpDown.SelectedIndex)
                {
                    case 0:
                        qualityWeights.Threshold = 4 * currentFile.timing;
                        break;
                    case 1:
                        qualityWeights.Threshold = 4 * currentFile.timing / 2.0;
                        break;
                    case 2:
                        qualityWeights.Threshold = 4 * currentFile.timing / 4.0;
                        break;
                    case 3:
                        qualityWeights.Threshold = 4 * currentFile.timing / 8.0;
                        break;
                    case 4:
                        qualityWeights.Threshold = 4 * currentFile.timing / 16.0;
                        break;
                    case 5:
                        qualityWeights.Threshold = 4 * currentFile.timing / 32.0;
                        break;
                    case 6:
                        qualityWeights.Threshold = 4 * currentFile.timing / 64.0;
                        break;
                }
                PenaltiesChangedMessage pMessage = new PenaltiesChangedMessage();
                pMessage.penalties = thresholdUpDown.Text;
                eventAggregator.Publish(new PenaltiesChangedMessage());
            }
        }

        private void penaltyAddVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.Add = (10 - penaltyAddVScroll.Value) / 10.0;
            
        }

        private void penaltyShortVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            qualityWeights.Short = (10 - penaltyShortVScroll.Value) / 10.0;
            eventAggregator.Publish(new PenaltyScrollChangedMessage());
        }
    }
}
