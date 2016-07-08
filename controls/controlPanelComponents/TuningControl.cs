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
        private MidiDisplayModel _displayModel;

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

        public TuningControl()
        {
            InitializeComponent();
        }

        private void EnableControls()
        {
            if (_displayModel == null || _tuningModel == null)
                return;

            _tuningChecks = new CheckBox[_tuningModel.Tunings.Length];
            _tuningRadios = new RadioButton[_tuningModel.Tunings.Length];
            tuningTransposeUpDown.DataBindings.Add("Value", TuningModel, "Transpose");
            qualityCheckBox.DataBindings.Add("Checked", DisplayModel, "QualityDisplayed");
            labelCheckBox.DataBindings.Add("Checked", DisplayModel, "ChordLabelsDisplayed");

            for (var n = 0; n < _tuningModel.Tunings.Length; n++)
            {
                _tuningChecks[n] = new CheckBox
                {
                    Location = new Point(4, 4 + n*16),
                    Size = new Size(152, 16),
                    ForeColor = _colors[n],
                    Text = _tuningModel.Tunings[n].Name
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
                    TuningModel.CurrentTuning = _tuningModel.Tunings[i];
                }
            }
        }

        private void TuningCheckedChanged(object sender, EventArgs e)
        {
            OnTuningEnabled();
        }

        private void OnTuningEnabled()
        {
            for (var i = 0; i < _tuningModel.Tunings.Length; i++)
                TuningModel.Tunings[i].enabled = _tuningChecks[i].Checked;
        }

        internal void UpdateTuningAverage(ArrayList chords, QualityWeights qualityWeights)
        {
            for (var i = 0; i < _tuningModel.Tunings.Length; i++)
            {
                var q = Math.Round(_tuningModel.Tunings[i].AvgQuality(chords, qualityWeights), 1);
                _tuningChecks[i].Text = _tuningModel.Tunings[i].Name + @" (" + q + @")";
            }
        }
    }
}