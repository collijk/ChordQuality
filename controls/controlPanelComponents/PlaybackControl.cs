using System;
using System.IO;
using System.Windows.Forms;
using ChordQuality.model;

namespace ChordQuality.controls
{
    public partial class PlaybackControl : UserControl
    {
        private MidiPlaybackModel _playbackModel;
        private MidiDataModel _dataModel;
        private MidiPlaybackModel.PlaybackState _playState;

        public MidiPlaybackModel PlaybackModel
        {
            get { return _playbackModel; }
            set
            {
                if (value == _playbackModel)
                    return;

                _playbackModel = value;
                EnableControls();
            }
        }

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

        public MidiPlaybackModel.PlaybackState PlayState
        {
            get { return _playState; }
            set
            {
                if (value == _playState)
                    return;

                _playState = value;
                OnPlayStateChanged();
            }
        }

        public PlaybackControl()
        {
            InitializeComponent();
            var bpmBinding = new Binding("Text", tempoTrackBar, "Value");
            bpmBinding.Format += TempoToBpmLabel;
            bpmLabel.DataBindings.Add(bpmBinding);
        }

        private static void TempoToBpmLabel(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(string))
                return;

            e.Value = ((int)e.Value - 1) + " bpm";
        }

        private void EnableControls()
        {
            if (_dataModel == null || _playbackModel == null)
                return;

            InitializeDevices();
            InitializeInstruments();
            this.DataBindings.Add("PlayState", PlaybackModel, "PlayState");
            tempoTrackBar.DataBindings.Add("Value", PlaybackModel, "Tempo");
            volumeTrackBar.DataBindings.Add("Value", PlaybackModel, "Volume");
        }

        private void InitializeDevices()
        {
            for (var i = 0; i < _playbackModel.OutputDevices.NumDevs; i++)
            {
                midiOutComboBox.Items.Add(_playbackModel.OutputDevices.Label(i));
            }
            midiOutComboBox.DataBindings.Add("SelectedIndex", PlaybackModel, "SelectedOutputDevice");
        }
        
        private void InitializeInstruments()
        {
            if (File.Exists("MIDI_PatchMap.txt"))
            {
                var sr = new StreamReader("MIDI_PatchMap.txt");
                // TODO : fix this bit of code to handle input read errors.
                for (var i = 0; i < 128; i++)
                    instrumentComboBox.Items.Add(sr.ReadLine());
                sr.Close();
            }
            else
            {
                for (var i = 1; i < 129; i++)
                    instrumentComboBox.Items.Add(i.ToString().PadLeft(3, '0'));
            }
            instrumentComboBox.DataBindings.Add("SelectedIndex", PlaybackModel, "SelectedInstrument") ;
        }

        private void OnPlayStateChanged()
        {
            switch (_playState)
            {
                case MidiPlaybackModel.PlaybackState.Uninitialized:
                    playButton.Enabled = false;
                    pauseButton.Enabled = false;
                    stopButton.Enabled = false;
                    volumeTrackBar.Enabled = false;
                    tempoTrackBar.Enabled = false;
                    midiOutComboBox.Enabled = false;
                    instrumentComboBox.Enabled = false;
                    break;
                case MidiPlaybackModel.PlaybackState.Play:
                    playButton.Enabled = false;
                    pauseButton.Enabled = true;
                    stopButton.Enabled = true;
                    volumeTrackBar.Enabled = true;
                    tempoTrackBar.Enabled = true;
                    midiOutComboBox.Enabled = true;
                    instrumentComboBox.Enabled = true;
                    break;
                case MidiPlaybackModel.PlaybackState.Pause:
                    playButton.Enabled = true;
                    pauseButton.Enabled = false;
                    stopButton.Enabled = true;
                    volumeTrackBar.Enabled = true;
                    tempoTrackBar.Enabled = true;
                    midiOutComboBox.Enabled = true;
                    instrumentComboBox.Enabled = true;
                    break;
                case MidiPlaybackModel.PlaybackState.Stop:
                    playButton.Enabled = true;
                    pauseButton.Enabled = true;
                    stopButton.Enabled = false;
                    volumeTrackBar.Enabled = true;
                    tempoTrackBar.Enabled = true;
                    midiOutComboBox.Enabled = true;
                    instrumentComboBox.Enabled = true;
                    break;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            PlayState = MidiPlaybackModel.PlaybackState.Play;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            PlayState = MidiPlaybackModel.PlaybackState.Pause;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            PlayState = MidiPlaybackModel.PlaybackState.Stop;
        }
    }
}