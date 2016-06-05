using ChordQuality.events;
using ChordQuality.events.messages;
using System;
using System.Windows.Forms;
using Janus.ManagedMIDI;
using System.IO;

namespace ChordQuality
{
    public partial class PlaybackControl : UserControl
    {
        private IEventAggregator eventAggregator;
        private ISubscription<FileUpdatedMessage> fileUpdatedSubscription;
        private MidiOutDevs devices;        
        private MidiFilePlayer player;

        public PlaybackControl()
        {
            InitializeComponent();
            initializeSubscriptions();
            initializeDevices();
            initializeInstruments();            
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            fileUpdatedSubscription = eventAggregator.Subscribe<FileUpdatedMessage>(Message =>
            {
                onFileUpdated(Message.file);
            });
        }

        private void initializeDevices()
        {
            devices = new MidiOutDevs();
            for(int i = 0; i < devices.NumDevs; i++)
            {
                midiOutComboBox.Items.Add(devices.Label(i));
            }
            midiOutComboBox.SelectedIndex = 0;
        }

        private void initializeInstruments()
        {
            if(File.Exists("MIDI_PatchMap.txt"))
            {
                StreamReader sr = new StreamReader("MIDI_PatchMap.txt");
                for(int i = 0; i < 128; i++)
                    instrumentComboBox.Items.Add(sr.ReadLine());
                sr.Close();
            } else
            {
                for(int i = 1; i < 129; i++)
                    instrumentComboBox.Items.Add(i.ToString().PadLeft(3, '0'));
            }
            instrumentComboBox.SelectedIndex = 0;
        }
             

        private void onFileUpdated(MidiFile file)
        {
            player = new MidiFilePlayer(file);

            if(file.tempo >= tempoTrackBar.Minimum &&
                file.tempo <= tempoTrackBar.Maximum)
            {
                player.Tempo = file.tempo;
                tempoTrackBar.Value = (int) file.tempo;
                bpmLabel.Text = tempoTrackBar.Value.ToString() + " bpm";
            }            
            if(file.instrument >= 0)
            {
                player.Instrument = file.instrument;
                instrumentComboBox.SelectedIndex = file.instrument;
            }
            if(stopButton.Enabled)
            {
                eventAggregator.Publish(new StopMessage());
            }

            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            midiOutComboBox.Enabled = true;

            MidiPlayerUpdatedMessage message = new MidiPlayerUpdatedMessage();
            message.player = player;
            eventAggregator.Publish(message);
        }

        #region Local Event Handlers
        private void playButton_Click(object sender, System.EventArgs e)
        {
            playButton.Enabled = false;
            pauseButton.Enabled = true;
            stopButton.Enabled = true;
            midiOutComboBox.Enabled = false;
            PlayMessage message = new PlayMessage();
            message.deviceIndex = this.midiOutComboBox.SelectedIndex;
            eventAggregator.Publish(message);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = true;
            midiOutComboBox.Enabled = false;
            eventAggregator.Publish(new PauseMessage());
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            midiOutComboBox.Enabled = true;
            eventAggregator.Publish(new StopMessage());
        }

        private void instrumentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(player != null)
            {
                player.Instrument = instrumentComboBox.SelectedIndex;
            }            
        }

        private void tempoTrackBar_Scroll(object sender, EventArgs e)
        {
            player.Tempo = tempoTrackBar.Value;
            bpmLabel.Text = tempoTrackBar.Value.ToString() + " bpm";
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.Volume = volumeTrackBar.Value;
        }
        #endregion
    }
}
