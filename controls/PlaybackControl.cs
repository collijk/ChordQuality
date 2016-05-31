using ChordQuality.events;
using ChordQuality.events.messages;
using System;
using System.Windows.Forms;

namespace ChordQuality
{
    public partial class PlaybackControl : UserControl
    {
        private EventAggregator eventAggregator;

        public PlaybackControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            this.eventAggregator = EventAggregator.Instance;
        }

        private void playButton_Click(object sender, System.EventArgs e)
        {
            this.playButton.Enabled = false;
            this.pauseButton.Enabled = true;
            this.stopButton.Enabled = true;
            this.eventAggregator.Publish(new PlayMessage());
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            this.playButton.Enabled = true;
            this.pauseButton.Enabled = false;
            this.stopButton.Enabled = true;
            this.eventAggregator.Publish(new PauseMessage());
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.playButton.Enabled = true;
            this.pauseButton.Enabled = false;
            this.stopButton.Enabled = false;
            this.eventAggregator.Publish(new StopMessage());
        }

        //Currently a hacky fix for testing
        internal bool isStopEnabled()
        {
            return this.stopButton.Enabled;
        }
    }



}
