using ChordQuality.events;
using ChordQuality.events.messages;
using System;
using System.Windows.Forms;

namespace ChordQuality
{
    public partial class PlaybackControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileOpenedMessage> fileOpenedSubscription;

        public PlaybackControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            this.eventAggregator = EventAggregator.Instance;
            this.fileOpenedSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                onFileOpened();
            });
        }

        private void onFileOpened()
        {
            this.playButton.Enabled = true;
            this.pauseButton.Enabled = false;
            this.stopButton.Enabled = false;
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
