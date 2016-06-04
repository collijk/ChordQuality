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
using ChordQuality.services.io;
using ChordQuality.events.messages;
using ChordQuality.services;

namespace ChordQuality.controls
{
    public partial class MainMenuControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileOpenedMessage> midiFileSubscription;
        private MidiFileOpener fileOpener;
        private MidiFileSaver fileSaver;
        private FileInfoProvider infoProvider;
        private PrintPreviewProvider previewProvider;

        public MainMenuControl()
        {
            InitializeComponent();
            initializeSubscriptions();
            initializeServices();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                onFileOpened();
            });
        }

        private void onFileOpened()
        {
            fileMenuSaveItem.Enabled = true;
            fileMenuPrintItem.Enabled = true;
            fileMenuMidiToTextItem.Enabled = true;
            markersMenu.Enabled = true;
            analysisMenu.Enabled = true;
            fileMenuInfoItem.Enabled = true;
            fileMenuPrintPreviewItem.Enabled = true;
        }

        private void initializeServices()
        {
            fileOpener = new MidiFileOpener();
            fileSaver = new MidiFileSaver();
            infoProvider = new FileInfoProvider();
        }

        private void fileMenuOpenItem_Click(object sender, EventArgs e)
        {
            fileOpener.openMidiFile();
        }

        private void fileMenuSaveItem_Click(object sender, EventArgs e)
        {
            fileSaver.saveMidiFile();
        }

        private void fileMenuInfoItem_Click(object sender, EventArgs e)
        {
            infoProvider.showInfo();
        }

        private void fileMenuPrintPreviewItem_Click(object sender, EventArgs e)
        {

        }
    }
}
