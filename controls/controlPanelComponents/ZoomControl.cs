using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;

namespace ChordQuality.controls
{
    public partial class ZoomControl : UserControl
    {
        private ISubscription<BarsPerRowChangedMessage> _barsPerRowSubscription;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;

        public ZoomControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _fileUpdatedSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { InitializeZoomTrackBar(message.File.bars); });
            _barsPerRowSubscription = _eventAggregator.Subscribe<BarsPerRowChangedMessage>(message =>
            {
                if (zoomTrackBar.Value != message.BarsPerRow)
                {
                    zoomTrackBar.Value = message.BarsPerRow;
                    UpdateZoom();
                }
            });
        }

        private void InitializeZoomTrackBar(int bars)
        {
            if (bars < zoomTrackBar.Value)
            {
                zoomTrackBar.Value = bars;
                UpdateZoom();
            }
            zoomTrackBar.Maximum = bars;
            zoomTrackBar.Enabled = true;
        }

        private void UpdateZoom()
        {
            var message = new ZoomScrollChangedMessage {ZoomValue = zoomTrackBar.Value};
            _eventAggregator.Publish(message);
        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            UpdateZoom();
        }
    }
}