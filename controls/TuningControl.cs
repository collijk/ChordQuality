using ChordQuality.events;
using ChordQuality.events.messages;
using System.Windows.Forms;

namespace ChordQuality.controls
{
    public partial class TuningControl : UserControl
    {
        private IEventAggregator eventAggregator;

        public TuningControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
        }
        private void tuningTransposeUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            TuningsTransposedMessage tMessage = new TuningsTransposedMessage();
            tMessage.transposeValue = (int) tuningTransposeUpDown.Value;
            eventAggregator.Publish(tMessage);
        }

        public void setTranspose(int transposeValue)
        {
            tuningTransposeUpDown.Value = transposeValue;
        }
    }
}
