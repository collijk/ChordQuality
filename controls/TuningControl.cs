using ChordQuality.events;
using ChordQuality.events.messages;
using Janus.ManagedMIDI;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections;

namespace ChordQuality.controls
{
    public partial class TuningControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<TuningsUpdatedMessage> tuningsSubscription;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;
        private ISubscription<MidiPlayerUpdatedMessage> midiPlayerSubscription;
        private MidiFile currentFile;
        private MidiFilePlayer midiPlayer;
        private TuningScheme[] tunings;
        private RadioButton[] tuningRadios;
        private CheckBox[] tuningChecks;
        private Color[] colors = new Color[19] {
            Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Blue, Color.Black, Color.Black, Color.Black,
            Color.Black, Color.Magenta, Color.Cyan, Color.Pink,
            Color.LightBlue, Color.Brown, Color.Gold, Color.Silver,
            Color.Black, Color.Black, Color.Black };

        public TuningControl()
        {
            InitializeComponent();
            initializeSubscriptions();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            tuningsSubscription = eventAggregator.Subscribe<TuningsUpdatedMessage>(Message =>
            {
                tunings = Message.tunings;
                onTuningsUpdated();
            });
            fileUpdatedSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                currentFile = Message.file;                
            });
            midiPlayerSubscription = eventAggregator.Subscribe<MidiPlayerUpdatedMessage>(Message =>
            {
                midiPlayer = Message.player;
            });
        }

        private void onTuningsUpdated()
        {
            tuningChecks = new CheckBox[tunings.Length];
            tuningRadios = new RadioButton[tunings.Length];
            for(int n = 0; n < tunings.Length; n++)
            {
                tuningChecks[n] = new CheckBox();
                tuningChecks[n].Location = new Point(4, 4 + n * 16);
                tuningChecks[n].Size = new Size(152, 16);
                tuningChecks[n].ForeColor = colors[n];
                tuningChecks[n].Text = tunings[n].Name;
                tuningChecks[n].CheckedChanged += new System.EventHandler(TuningCheckedChanged);
                tuningsPanel.Controls.Add(tuningChecks[n]);
                tuningRadios[n] = new RadioButton();
                tuningRadios[n].Location = new Point(156, 4 + n * 16);
                tuningRadios[n].Size = new Size(16, 16);
                tuningRadios[n].ForeColor = colors[n];
                tuningRadios[n].CheckedChanged += new System.EventHandler(TuningRadioCheckedChanged);
                tuningsPanel.Controls.Add(tuningRadios[n]);
            }
            tuningChecks[0].Checked = true;
            onTuningEnabled();           
            tuningRadios[0].Checked = true;
            onTuningSelectionChanged();           
        }

        private void TuningRadioCheckedChanged(object sender, EventArgs e)
        {
            onTuningSelectionChanged();
            
        }

        private void onTuningSelectionChanged()
        {
            if(midiPlayer != null)
            {
                for(int i = 0; i < tuningRadios.Length; i++)
                    if(tuningRadios[i].Checked)
                        midiPlayer.Tuning = tunings[i];
            }
        }

        private void TuningCheckedChanged(object sender, EventArgs e)
        {
            onTuningEnabled();            
        }

        private void onTuningEnabled()
        {
            if(currentFile != null)
            {
                for(int i = 0; i < tunings.Length; i++)
                    tunings[i].enabled = tuningChecks[i].Checked;
                eventAggregator.Publish(new TuningEnabledMessage());                
            }
        }

        private void tuningTransposeUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            for(int i = 0; i < tunings.Length; i++)
            {
                tunings[i].Transpose = (int) tuningTransposeUpDown.Value;
            }            
            if(midiPlayer != null)
            {
                for(int i = 0; i < tuningRadios.Length; i++)
                    if(tuningRadios[i].Checked)
                        midiPlayer.Tuning = tunings[i];
            }
            TuningsTransposedMessage tMessage = new TuningsTransposedMessage();
            tMessage.transposeValue = (int) tuningTransposeUpDown.Value;
            eventAggregator.Publish(tMessage);
        }

        public void setTranspose(int transposeValue)
        {
            tuningTransposeUpDown.Value = transposeValue;
        }

        internal void updateTuningAverage(ArrayList chords, QualityWeights qualityWeights)
        {
            for(int i = 0; i < tunings.Length; i++)
            {
                double q = Math.Round(tunings[i].AvgQuality(chords, qualityWeights), 1);
                tuningChecks[i].Text = tunings[i].Name + " (" + q.ToString() + ")";
            }
        }

        private void qualityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            QualityCheckChangedMessage qMessage = new QualityCheckChangedMessage();
            qMessage.checkStatus = qualityCheckBox.Checked;
            eventAggregator.Publish(qMessage);
        }

        private void labelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LabelCheckChangedMessage lMessage = new LabelCheckChangedMessage();
            lMessage.checkStatus = labelCheckBox.Checked;
            eventAggregator.Publish(lMessage);
        }
    }
}
