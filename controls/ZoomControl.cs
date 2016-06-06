using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;

namespace ChordQuality.controls
{
    public partial class ZoomControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;
        private ISubscription<BarsPerRowChangedMessage> barsPerRowSubscription;

        public ZoomControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            fileUpdatedSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                initializeZoomTrackBar(Message.file.bars);
                
            });
            barsPerRowSubscription = eventAggregator.Subscribe<BarsPerRowChangedMessage>(Message =>
            {
                if(zoomTrackBar.Value != Message.BarsPerRow)
                {
                    zoomTrackBar.Value = Message.BarsPerRow;
                    updateZoom();
                }
            });
        }

        private void initializeZoomTrackBar(int bars)
        {
            if(bars < zoomTrackBar.Value)
            {
                zoomTrackBar.Value = bars;
                updateZoom();
            }
            zoomTrackBar.Maximum = bars;
            zoomTrackBar.Enabled = true;
        }

        private void updateZoom()
        {
            ZoomScrollChangedMessage message = new ZoomScrollChangedMessage();
            message.zoomValue = zoomTrackBar.Value;
            eventAggregator.Publish(message);
        }

        private void zoomTrackBar_Scroll(object sender, EventArgs e)
        {
            updateZoom();
        }
    }
}
