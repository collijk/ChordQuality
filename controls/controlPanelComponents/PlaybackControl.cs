using System;
using System.IO;
using System.Windows.Forms;
using ChordQuality.events;
using ChordQuality.events.messages;
using ChordQuality.model;
using Janus.ManagedMIDI;

namespace ChordQuality.controls
{
    public partial class PlaybackControl : UserControl
    {
        private MidiPlaybackModel _playbackModel;
        
        private MidiOutDevs _devices;
        private IEventAggregator _eventAggregator;
        private ISubscription<FileUpdatedMessage> _fileUpdatedSubscription;
        private MidiFilePlayer _player;
        private MidiDataModel _dataModel;


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

        public PlaybackControl()
        {
            InitializeComponent();
            InitializeSubscriptions();
            InitializeDevices();
            InitializeInstruments();
        }

        private void InitializeSubscriptions()
        {
            _eventAggregator = EventAggregator.Instance;
            _fileUpdatedSubscription =
                _eventAggregator.Subscribe<FileUpdatedMessage>(message => { OnFileUpdated(message.File); });
        }

        private void InitializeDevices()
        {
            _devices = new MidiOutDevs();
            for (var i = 0; i < _devices.NumDevs; i++)
            {
                midiOutComboBox.Items.Add(_devices.Label(i));
            }
            midiOutComboBox.SelectedIndex = 0;
        }

        private void EnableControls()
        {

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
            instrumentComboBox.SelectedIndex = 0;
        }


        private void OnFileUpdated(MidiFile file)
        {
            _player = new MidiFilePlayer(file);

            if (file.tempo >= tempoTrackBar.Minimum &&
                file.tempo <= tempoTrackBar.Maximum)
            {
                _player.Tempo = file.tempo;
                tempoTrackBar.Value = (int) file.tempo;
                bpmLabel.Text = tempoTrackBar.Value + @" bpm";
            }
            if (file.instrument >= 0)
            {
                _player.Instrument = file.instrument;
                instrumentComboBox.SelectedIndex = file.instrument;
            }
            if (stopButton.Enabled)
            {
                _eventAggregator.Publish(new StopMessage());
            }

            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            volumeTrackBar.Enabled = true;
            tempoTrackBar.Enabled = true;
            midiOutComboBox.Enabled = true;
            instrumentComboBox.Enabled = true;

            var message = new MidiPlayerUpdatedMessage {Player = _player};
            _eventAggregator.Publish(message);
        }

        #region Local Event Handlers

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Enabled = false;
            pauseButton.Enabled = true;
            stopButton.Enabled = true;
            midiOutComboBox.Enabled = false;
            var message = new PlayMessage {DeviceIndex = midiOutComboBox.SelectedIndex};
            _eventAggregator.Publish(message);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = true;
            midiOutComboBox.Enabled = false;
            _eventAggregator.Publish(new PauseMessage());
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            midiOutComboBox.Enabled = true;
            _eventAggregator.Publish(new StopMessage());
        }

        private void instrumentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.Instrument = instrumentComboBox.SelectedIndex;
            }
        }

        private void tempoTrackBar_Scroll(object sender, EventArgs e)
        {
            _player.Tempo = tempoTrackBar.Value;
            bpmLabel.Text = tempoTrackBar.Value + @" bpm";
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            _player.Volume = volumeTrackBar.Value;
        }

        #endregion

        private void midiOutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO : Enable user to select midi out devices.
        }
    }
}