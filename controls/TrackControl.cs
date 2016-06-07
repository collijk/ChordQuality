using System;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class TrackControl : UserControl
    {
        private readonly Color[] _trackColors = new Color[]
        {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black
        };

        private ColorDialog _colorDialog;

        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;
        private CheckBox[] _trackChecks;


        public TrackControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            _colorDialog = new ColorDialog();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _fileUpdatedSubscription = _eventAggregator.Subscribe<FileUpdatedMessage>(message =>
            {
                _currentFile = message.File;
                OnFileUpdated();
            });
        }

        private void OnFileUpdated()
        {
            trackPanel.Controls.Clear();
            _trackChecks = new CheckBox[_currentFile.tracks.Length];
            for (var n = 0; n < _currentFile.tracks.Length; n++)
            {
                _trackChecks[n] = new CheckBox
                {
                    Location = new Point(4, 4 + n*16),
                    Size = new Size(192, 16),
                    ForeColor = _trackColors[n],
                    Text = "#" + (n + 1) + ": " + _currentFile.tracks[n].name,
                    Checked = true
                };
                _trackChecks[n].CheckedChanged += TrackCheckedChanged;
                _trackChecks[n].ContextMenuStrip = colorContextMenu;
                trackPanel.Controls.Add(_trackChecks[n]);
            }
        }

        private void TrackCheckedChanged(object sender, EventArgs e)
        {
            if (_currentFile != null)
            {
                for (var i = 0; i < _currentFile.tracks.Length; i++)
                    _currentFile.tracks[i].enabled = _trackChecks[i].Checked;

                _eventAggregator.Publish(new TracksChangedMessage());
            }
        }


        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < _currentFile.tracks.Length; i++)
            {
                if (colorContextMenu.SourceControl == _trackChecks[i])
                {
                    _colorDialog.Color = _trackColors[i];
                }
            }

            _colorDialog.ShowDialog();

            for (var i = 0; i < _currentFile.tracks.Length; i++)
            {
                if (colorContextMenu.SourceControl == _trackChecks[i])
                {
                    _trackColors[i] = _colorDialog.Color;
                    _trackChecks[i].ForeColor = _colorDialog.Color;
                }
            }
            _eventAggregator.Publish(new TrackColorChangedMessage());
        }
    }
}