using System;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class TrackControl : UserControl
    {
        private CheckBox[] _trackChecks;
        private ColorDialog _colorDialog;

        private MidiDataModel _dataModel;
        private MidiDisplayModel _displayModel;

        public MidiDataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                if (value == _dataModel)
                    return;

                _dataModel = value;
                EnableControls();
            }
        }

        public MidiDisplayModel DisplayModel
        {
            get { return _displayModel; }
            set
            {
                if (value == _displayModel)
                    return;

                _displayModel = value;
                EnableControls();
            }
        }

        public TrackControl()
        {
            InitializeComponent();
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            _colorDialog = new ColorDialog();
        }

        private void EnableControls()
        {
            if (DataModel == null || DisplayModel == null)
                return;

            trackPanel.Controls.Clear();
            _trackChecks = new CheckBox[DataModel.Tracks.Length];

            for (var n = 0; n < DataModel.Tracks.Length; n++)
            {
                _trackChecks[n] = new CheckBox
                {
                    Location = new Point(4, 4 + n*16),
                    Size = new Size(192, 16),
                    ForeColor = DisplayModel.TrackColors[n],
                    Text = @"#" + (n + 1) + @": " + DataModel.Tracks[n].name,
                    Checked = true
                };

                _trackChecks[n].CheckedChanged += TrackCheckedChanged;
                _trackChecks[n].ContextMenuStrip = colorContextMenu;
                trackPanel.Controls.Add(_trackChecks[n]);
            }
        }

        private void TrackCheckedChanged(object sender, EventArgs e)
        {
            if (DataModel == null)
                return;

            for (var i = 0; i < DataModel.Tracks.Length; i++)
                DataModel.Tracks[i].enabled = _trackChecks[i].Checked;
        }


        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < DataModel.Tracks.Length; i++)
            {
                if (colorContextMenu.SourceControl == _trackChecks[i])
                {
                    _colorDialog.Color = DisplayModel.TrackColors[i];
                }
            }

            _colorDialog.ShowDialog();

            for (var i = 0; i < DataModel.Tracks.Length; i++)
            {
                if (colorContextMenu.SourceControl != _trackChecks[i])
                    continue;

                DisplayModel.TrackColors[i] = _colorDialog.Color;
                _trackChecks[i].ForeColor = _colorDialog.Color;
            }
        }
    }
}