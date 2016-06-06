using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.services.io;
using ChordQuality.events.messages;
using ChordQuality.services;
using Janus.ManagedMIDI;
using ChordQuality.Services;

namespace ChordQuality.controls
{
    public partial class MainMenuControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileUpdatedMessage> midiFileSubscription;
        private ISubscription<PlaySelectionChangedMessage> playSelectionSubscription;
        private MidiFileOpener fileOpener;
        private MidiFileSaver fileSaver;
        private FileInfoProvider infoProvider;
        private PrintPreviewProvider previewProvider;
        private PrintDocumentPrinter docPrinter;
        private MidiToTextWriter midiTextWriter;
        private AnalysisFileWriter analysisWriter;
        private ToolStripMenuItem[] markersMenuAddMenuItems;
        private ToolStripMenuItem[] markersMenuRemoveMenuItems;
        private MidiFile currentFile;
        private double playStart = -1;
        private double playStop = -1;

        public MainMenuControl()
        {
            InitializeComponent();
            initializeSubscriptions();
            initializeServices();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            midiFileSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;
                onFileUpdated();
            });
            playSelectionSubscription = eventAggregator.Subscribe<PlaySelectionChangedMessage>(Message =>
            {
                playStart = Message.playStart;
                playStop = Message.playStop;
                if(playStop != playStart)
                {
                    markersMenuAddMenu.Enabled = true;
                } else
                {
                    markersMenuAddMenu.Enabled = false;
                }
            });
        }

        private void onFileUpdated()
        {

            fileMenuSaveItem.Enabled = true;
            fileMenuPrintItem.Enabled = true;
            fileMenuMidiToTextItem.Enabled = true;
            fileMenuInfoItem.Enabled = true;
            fileMenuPrintPreviewItem.Enabled = true;
            markersMenu.Enabled = true;
            analysisMenu.Enabled = true;

            markersMenuAddMenuItems = new ToolStripMenuItem[currentFile.tracks.Length];
            for(int i = 0; i < currentFile.tracks.Length; i++)
            {
                markersMenuAddMenuItems[i] = new ToolStripMenuItem();
                markersMenuAddMenuItems[i].Text = "#" + (i + 1).ToString() + ": " + currentFile.tracks[i].name;
                markersMenuAddMenuItems[i].Click += new System.EventHandler(AddMenuItemClicked);
            }
            markersMenuAddMenu.DropDownItems.Clear();
            markersMenuAddMenu.DropDownItems.AddRange(markersMenuAddMenuItems);                

            // create "markers -> remove" menu
            markersMenuRemoveMenuItems = new ToolStripMenuItem[currentFile.tracks.Length];
            for(int i = 0; i < currentFile.tracks.Length; i++)
            {
                markersMenuRemoveMenuItems[i] = new ToolStripMenuItem();
                markersMenuRemoveMenuItems[i].Text = "#" + (i + 1).ToString() + ": " + currentFile.tracks[i].name;
                markersMenuRemoveMenuItems[i].Click += new System.EventHandler(RemoveMenuItemClicked);
            }
            markersMenuRemoveMenu.DropDownItems.Clear();
            markersMenuRemoveMenu.DropDownItems.AddRange(markersMenuRemoveMenuItems);
        }

        private void RemoveMenuItemClicked(object sender, EventArgs e)
        {
            for(int i = 0; i < currentFile.tracks.Length; i++)
            {
                if(sender == markersMenuRemoveMenuItems[i])
                {
                    if(playStart != playStop)
                    {
                        currentFile.RemoveMarkers(
                            i, (int) (playStart * 4 * currentFile.timing), (int) (playStop * 4 * currentFile.timing));
                    } else
                    {
                        currentFile.RemoveAllMarkers(i);
                    }                  
                }
            }
            eventAggregator.Publish(new MarkersChangedMessage());
        }

        private void AddMenuItemClicked(object sender, EventArgs e)
        {
            for(int i = 0; i < currentFile.tracks.Length; i++)
            {
                if(sender == markersMenuAddMenuItems[i])
                {
                    currentFile.InsertMarker(i,
                        (int) (playStart * 4 * currentFile.timing), (int) (playStop * 4 * currentFile.timing));
                    
                }
            }
            eventAggregator.Publish(new MarkersChangedMessage());
        }

        private void initializeServices()
        {
            fileOpener = MidiFileOpener.Instance;
            fileSaver = MidiFileSaver.Instance;
            infoProvider = FileInfoProvider.Instance;
            previewProvider = PrintPreviewProvider.Instance;
            docPrinter = PrintDocumentPrinter.Instance;
            midiTextWriter = MidiToTextWriter.Instance;
            analysisWriter = AnalysisFileWriter.Instance;
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
            previewProvider.showPreview();
        }

        private void fileMenuPrintItem_Click(object sender, EventArgs e)
        {
            docPrinter.print();
        }

        private void fileMenuMidiToTextItem_Click(object sender, EventArgs e)
        {
            midiTextWriter.writeMidiToText();
        }

        private void fileMenuExitItem_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new CloseRequestMessage());
        }

        private void analysisMenuFindBestTuningItem_Click(object sender, EventArgs e)
        {
            eventAggregator.Publish(new FindBestTuningsMessage());
        }

        private void analysisMenuExportAnalysisItem_Click(object sender, EventArgs e)
        {
            analysisWriter.writeAnalysis();
        }
    }
}
