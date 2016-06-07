using System;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.services;
using ChordQuality.services.io;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class MainMenuControl : UserControl
    {
        private AnalysisFileWriter _analysisWriter;
        private MidiFile _currentFile;
        private PrintDocumentPrinter _docPrinter;
        private IEventAggregator _eventAggregator;
        private MidiFileOpener _fileOpener;
        private MidiFileSaver _fileSaver;
        private FileInfoProvider _infoProvider;
        private ToolStripMenuItem[] _markersMenuAddMenuItems;
        private ToolStripMenuItem[] _markersMenuRemoveMenuItems;
        private ISubscription<FileUpdatedMessage> _midiFileSubscription;
        private MidiToTextWriter _midiTextWriter;
        private ISubscription<PlaySelectionChangedMessage> _playSelectionSubscription;
        private double _playStart = -1;
        private double _playStop = -1;
        private PrintPreviewProvider _previewProvider;

        public MainMenuControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
            InitializeServices();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _midiFileSubscription = _eventAggregator.Subscribe<FileUpdatedMessage>(message =>
            {
                _currentFile = message.File;
                OnFileUpdated();
            });
            _playSelectionSubscription = _eventAggregator.Subscribe<PlaySelectionChangedMessage>(message =>
            {
                _playStart = message.PlayStart;
                _playStop = message.PlayStop;
                markersMenuAddMenu.Enabled = _playStop != _playStart;
            });
        }

        private void OnFileUpdated()
        {
            fileMenuSaveItem.Enabled = true;
            fileMenuPrintItem.Enabled = true;
            fileMenuMidiToTextItem.Enabled = true;
            fileMenuInfoItem.Enabled = true;
            fileMenuPrintPreviewItem.Enabled = true;
            markersMenu.Enabled = true;
            analysisMenu.Enabled = true;

            _markersMenuAddMenuItems = new ToolStripMenuItem[_currentFile.tracks.Length];
            for (var i = 0; i < _currentFile.tracks.Length; i++)
            {
                _markersMenuAddMenuItems[i] = new ToolStripMenuItem
                {
                    Text = "#" + (i + 1) + ": " + _currentFile.tracks[i].name
                };
                _markersMenuAddMenuItems[i].Click += AddMenuItemClicked;
            }
            markersMenuAddMenu.DropDownItems.Clear();
            markersMenuAddMenu.DropDownItems.AddRange(_markersMenuAddMenuItems);

            // create "markers -> remove" menu
            _markersMenuRemoveMenuItems = new ToolStripMenuItem[_currentFile.tracks.Length];
            for (var i = 0; i < _currentFile.tracks.Length; i++)
            {
                _markersMenuRemoveMenuItems[i] = new ToolStripMenuItem
                {
                    Text = "#" + (i + 1) + ": " + _currentFile.tracks[i].name
                };
                _markersMenuRemoveMenuItems[i].Click += RemoveMenuItemClicked;
            }
            markersMenuRemoveMenu.DropDownItems.Clear();
            markersMenuRemoveMenu.DropDownItems.AddRange(_markersMenuRemoveMenuItems);
        }

        private void RemoveMenuItemClicked(object sender, EventArgs e)
        {
            for (var i = 0; i < _currentFile.tracks.Length; i++)
            {
                if (sender == _markersMenuRemoveMenuItems[i])
                {
                    if (_playStart != _playStop)
                    {
                        _currentFile.RemoveMarkers(
                            i, (int) (_playStart*4*_currentFile.timing), (int) (_playStop*4*_currentFile.timing));
                    }
                    else
                    {
                        _currentFile.RemoveAllMarkers(i);
                    }
                }
            }
            _eventAggregator.Publish(new MarkersChangedMessage());
        }

        private void AddMenuItemClicked(object sender, EventArgs e)
        {
            for (var i = 0; i < _currentFile.tracks.Length; i++)
            {
                if (sender == _markersMenuAddMenuItems[i])
                {
                    _currentFile.InsertMarker(i,
                        (int) (_playStart*4*_currentFile.timing), (int) (_playStop*4*_currentFile.timing));
                }
            }
            _eventAggregator.Publish(new MarkersChangedMessage());
        }

        private void InitializeServices()
        {
            _fileOpener = MidiFileOpener.Instance;
            _fileSaver = MidiFileSaver.Instance;
            _infoProvider = FileInfoProvider.Instance;
            _previewProvider = PrintPreviewProvider.Instance;
            _docPrinter = PrintDocumentPrinter.Instance;
            _midiTextWriter = MidiToTextWriter.Instance;
            _analysisWriter = AnalysisFileWriter.Instance;
        }

        private void fileMenuOpenItem_Click(object sender, EventArgs e)
        {
            _fileOpener.OpenMidiFile();
        }

        private void fileMenuSaveItem_Click(object sender, EventArgs e)
        {
            _fileSaver.SaveMidiFile();
        }

        private void fileMenuInfoItem_Click(object sender, EventArgs e)
        {
            _infoProvider.ShowInfo();
        }

        private void fileMenuPrintPreviewItem_Click(object sender, EventArgs e)
        {
            _previewProvider.ShowPreview();
        }

        private void fileMenuPrintItem_Click(object sender, EventArgs e)
        {
            _docPrinter.Print();
        }

        private void fileMenuMidiToTextItem_Click(object sender, EventArgs e)
        {
            _midiTextWriter.WriteMidiToText();
        }

        private void fileMenuExitItem_Click(object sender, EventArgs e)
        {
            _eventAggregator.Publish(new CloseRequestMessage());
        }

        private void analysisMenuFindBestTuningItem_Click(object sender, EventArgs e)
        {
            _eventAggregator.Publish(new FindBestTuningsMessage());
        }

        private void analysisMenuExportAnalysisItem_Click(object sender, EventArgs e)
        {
            _analysisWriter.WriteAnalysis();
        }
    }
}