using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System;
using System.Windows.Forms;

namespace ChordQuality.controls
{
    public partial class PrintingControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;
        private ISubscription<ZoomScrollChangedMessage> zoomScrollSubscription;
        private MidiFile currentFile;

        public PrintingControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            fileUpdatedSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;
            });
            zoomScrollSubscription = eventAggregator.Subscribe<ZoomScrollChangedMessage>(Message =>
            {
                onZoomChanged(Message.zoomValue);
            });
        }

        private void onZoomChanged(int zoomValue)
        {
            int bars = Int32.Parse(barsPerRowTextBox.Text);
            if(bars != zoomValue)
            {
                barsPerRowTextBox.Text = zoomValue.ToString();
                updatePrintSettings();
            }
        }

        private void applyPrintSettingsButton_Click(object sender, System.EventArgs e)
        {
            updatePrintSettings(); 
        }

        public void updatePrintSettings()
        {
            int bars = Int32.Parse(barsPerRowTextBox.Text);
            int RowsPerPage = Int32.Parse(rowsPerPageTextBox.Text);
            float relThickness = (float) Double.Parse(relativeThicknessTextBox.Text);
            int barspp = bars * RowsPerPage;
            barsPerPageTextBox.Text = barspp.ToString();

            if(currentFile != null)
            {
                int Pages = (int) Math.Ceiling((double) currentFile.bars / barspp);
                pagesTextBox.Text = Pages.ToString();
            }
            RowsPerPageChangedMessage rppMessage = new RowsPerPageChangedMessage();
            rppMessage.RowsPerPage = RowsPerPage;
            eventAggregator.Publish(rppMessage);
            RelThicknessChangedMessage rMessage = new RelThicknessChangedMessage();
            rMessage.relThickness = relThickness;
            eventAggregator.Publish(rMessage);
            BarsPerRowChangedMessage bprMessage = new BarsPerRowChangedMessage();
            bprMessage.BarsPerRow = bars;
            eventAggregator.Publish(bprMessage);
        }
    }
}
