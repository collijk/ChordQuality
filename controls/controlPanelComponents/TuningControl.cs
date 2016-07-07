using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class TuningControl : UserControl
    {
        private CheckBox[] _tuningChecks;
        private RadioButton[] _tuningRadios;

        private readonly Color[] _colors = new Color[]
        {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black
        };

        private MidiTuningModel _tuningModel;

        public MidiTuningModel TuningModel
        {
            get { return _tuningModel; }
            set
            {
                if (value == _tuningModel)
                    return;

                _tuningModel = value;
                EnableControls();
            }
        }


        public TuningControl()
        {
            InitializeComponent();
        }

        private void EnableControls()
        {
            _tuningChecks = new CheckBox[TuningModel.Tunings.Length];
            _tuningRadios = new RadioButton[TuningModel.Tunings.Length];

            for (var n = 0; n < TuningModel.Tunings.Length; n++)
            {
                _tuningChecks[n] = new CheckBox
                {
                    Location = new Point(4, 4 + n*16),
                    Size = new Size(152, 16),
                    ForeColor = _colors[n],
                    Text = TuningModel.Tunings[n].Name
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
            for (var i = 0; i < _tuningRadios.Length; i++)
            {
                if (_tuningRadios[i].Checked)
                {
                    TuningModel.CurrentTuning = TuningModel.Tunings[i];
                }
            }
        }

        private void TuningCheckedChanged(object sender, EventArgs e)
        {
            OnTuningEnabled();
        }

        private void OnTuningEnabled()
        {
            
                for (var i = 0; i < _tunings.Length; i++)
                    _tunings[i].enabled = _tuningChecks[i].Checked;
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
                _tuningChecks[i].Text = _tunings[i].Name + @" (" + q + @")";
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