using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class PrintingControl : UserControl
    {
        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;
        private ISubscription<ZoomScrollChangedMessage> _zoomScrollSubscription;

        public PrintingControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _fileUpdatedSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
            _zoomScrollSubscription =
                _eventAggregator.Subscribe<ZoomScrollChangedMessage>(message => { OnZoomChanged(message.ZoomValue); });
        }

        private void OnZoomChanged(int zoomValue)
        {
            var bars = int.Parse(barsPerRowTextBox.Text);
            if (bars != zoomValue)
            {
                barsPerRowTextBox.Text = zoomValue.ToString();
                UpdatePrintSettings();
            }
        }

        private void applyPrintSettingsButton_Click(object sender, EventArgs e)
        {
            UpdatePrintSettings();
        }

        public void UpdatePrintSettings()
        {
            var bars = int.Parse(barsPerRowTextBox.Text);
            var rowsPerPage = int.Parse(rowsPerPageTextBox.Text);
            var relThickness = (float) double.Parse(relativeThicknessTextBox.Text);
            var barspp = bars*rowsPerPage;
            barsPerPageTextBox.Text = barspp.ToString();

            if (_currentFile != null)
            {
                var pages = (int) Math.Ceiling((double) _currentFile.bars/barspp);
                pagesTextBox.Text = pages.ToString();
            }
            var rppMessage = new RowsPerPageChangedMessage {RowsPerPage = rowsPerPage};
            _eventAggregator.Publish(rppMessage);
            var rMessage = new RelThicknessChangedMessage {RelThickness = relThickness};
            _eventAggregator.Publish(rMessage);
            var bprMessage = new BarsPerRowChangedMessage {BarsPerRow = bars};
            _eventAggregator.Publish(bprMessage);
        }
    }
}