using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class TuningControl : UserControl
    {
        private readonly Color[] _colors = new Color[]
        {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black
        };

        private MidiFile _currentFile;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;
        private MidiFilePlayer _midiPlayer;
        private ISubscription<MidiPlayerUpdatedMessage> _midiPlayerSubscription;
        private CheckBox[] _tuningChecks;
        private RadioButton[] _tuningRadios;
        private TuningScheme[] _tunings;
        private ISubscription<TuningsUpdatedMessage> _tuningsSubscription;

        public TuningControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _tuningsSubscription = _eventAggregator.Subscribe<TuningsUpdatedMessage>(message =>
            {
                _tunings = message.Tunings;
                OnTuningsUpdated();
            });
            _fileUpdatedSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { _currentFile = message.File; });
            _midiPlayerSubscription =
                _eventAggregator.Subscribe<MidiPlayerUpdatedMessage>(message => { _midiPlayer = message.Player; });
        }

        private void OnTuningsUpdated()
        {
            _tuningChecks = new CheckBox[_tunings.Length];
            _tuningRadios = new RadioButton[_tunings.Length];
            for (var n = 0; n < _tunings.Length; n++)
            {
                _tuningChecks[n] = new CheckBox
                {
                    Location = new Point(4, 4 + n*16),
                    Size = new Size(152, 16),
                    ForeColor = _colors[n],
                    Text = _tunings[n].Name
                };
                _tuningChecks[n].CheckedChanged += TuningCheckedChanged;
                tuningsPanel.Controls.Add(_tuningChecks[n]);
                _tuningRadios[n] = new RadioButton
                {
                    Location = new Point(156, 4 + n*16),
                    Size = new Size(16, 16),
                    ForeColor = _colors[n]
                };
                _tuningRadios[n].CheckedChanged += TuningRadioCheckedChanged;
                tuningsPanel.Controls.Add(_tuningRadios[n]);
            }
            _tuningChecks[0].Checked = true;
            OnTuningEnabled();
            _tuningRadios[0].Checked = true;
            OnTuningSelectionChanged();
        }

        private void TuningRadioCheckedChanged(object sender, EventArgs e)
        {
            OnTuningSelectionChanged();
        }

        private void OnTuningSelectionChanged()
        {
            if (_midiPlayer != null)
            {
                for (var i = 0; i < _tuningRadios.Length; i++)
                    if (_tuningRadios[i].Checked)
                        _midiPlayer.Tuning = _tunings[i];
            }
        }

        private void TuningCheckedChanged(object sender, EventArgs e)
        {
            OnTuningEnabled();
        }

        private void OnTuningEnabled()
        {
            if (_currentFile != null)
            {
                for (var i = 0; i < _tunings.Length; i++)
                    _tunings[i].enabled = _tuningChecks[i].Checked;
                _eventAggregator.Publish(new TuningEnabledMessage());
            }
        }

        private void tuningTransposeUpDown_ValueChanged(object sender, EventArgs e)
        {
            foreach (TuningScheme t in _tunings)
            {
                t.Transpose = (int) tuningTransposeUpDown.Value;
            }
            if (_midiPlayer != null)
            {
                for (var i = 0; i < _tuningRadios.Length; i++)
                    if (_tuningRadios[i].Checked)
                        _midiPlayer.Tuning = _tunings[i];
            }
            var tMessage = new TuningsTransposedMessage {TransposeValue = (int) tuningTransposeUpDown.Value};
            _eventAggregator.Publish(tMessage);
        }

        public void SetTranspose(int transposeValue)
        {
            tuningTransposeUpDown.Value = transposeValue;
        }

        internal void UpdateTuningAverage(ArrayList chords, QualityWeights qualityWeights)
        {
            for (var i = 0; i < _tunings.Length; i++)
            {
                double q = Math.Round(_tunings[i].AvgQuality(chords, qualityWeights), 1);
                _tuningChecks[i].Text = _tunings[i].Name + " (" + q + ")";
            }
        }

        private void qualityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var qMessage = new QualityCheckChangedMessage {CheckStatus = qualityCheckBox.Checked};
            _eventAggregator.Publish(qMessage);
        }

        private void labelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var lMessage = new LabelCheckChangedMessage {CheckStatus = labelCheckBox.Checked};
            _eventAggregator.Publish(lMessage);
        }
    }
}