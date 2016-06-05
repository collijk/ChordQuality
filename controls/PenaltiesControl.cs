using ChordQuality.events;
using ChordQuality.events.messages;
using System.Windows.Forms;

namespace ChordQuality.controls
{
    public partial class PenaltiesControl : UserControl
    {
        private IEventAggregator eventAggregator;

        public PenaltiesControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
        }

        private void thresholdUpDown_SelectedItemChanged(object sender, System.EventArgs e)
        {
            PenaltiesChangedMessage pMessage = new PenaltiesChangedMessage();
            pMessage.penalties = thresholdUpDown.Text;
            pMessage.penaltiesIndex = thresholdUpDown.SelectedIndex;
            eventAggregator.Publish(pMessage);
        }

        private void penaltyAddVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            PenaltyScrollChangedMessage pMessage = new PenaltyScrollChangedMessage();
            pMessage.source = "Add";
            pMessage.scrollValue = penaltyAddVScroll.Value;
            eventAggregator.Publish(pMessage);
        }

        private void penaltyShortVScroll_Scroll(object sender, ScrollEventArgs e)
        {
            PenaltyScrollChangedMessage pMessage = new PenaltyScrollChangedMessage();
            pMessage.source = "Short";
            pMessage.scrollValue = penaltyAddVScroll.Value;
            eventAggregator.Publish(pMessage);
        }
    }
}
