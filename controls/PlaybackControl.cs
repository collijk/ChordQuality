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
        private ISubscription<FileOpenedMessage> fileOpenedSubscription;

        public PlaybackControl()
        {
            InitializeComponent();
            initializeSubscriptions();
            initializeInstruments();
        }

        private void initializeSubscriptions()
        {
            eventAggregator = EventAggregator.Instance;
            fileOpenedSubscription = eventAggregator.Subscribe<FileOpenedMessage>(Message =>
            {
                onFileOpened();
            });
        }

        private void onFileOpened()
        {
            playButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = false;
            midiOutComboBox.Enabled = true;
        }

        private void playButton_Click(object sender, System.EventArgs e)
        {
            playButton.Enabled = false;
            pauseButton.Enabled = true;
            stopButton.Enabled = true;
            midiOutComboBox.Enabled = false;
            eventAggregator.Publish(new PlayMessage());
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

        // Currently a hacky fix for testing
        internal bool isStopEnabled()
        {
            return this.stopButton.Enabled;
        }

        // Currently a hacky fix for testing
        internal int getMidiOutIndex()
        {
            return this.midiOutComboBox.SelectedIndex;
        }

        // Currently a hacky fix for testing
        internal double getVolume()
        {
            return ((double) this.volumeTrackBar.Value)/this.volumeTrackBar.Maximum;
        }

        // TODO: Fix this with dependency injection, probably.
        internal void initializeMidiOutBox(MidiOutDevs mout)
        {
            for(int i = 0; i < mout.NumDevs; i++)
                this.midiOutComboBox.Items.Add(mout.Label(i));
            this.midiOutComboBox.SelectedIndex = 0;
        }

        internal void initializeInstruments()
        {
            if(File.Exists("MIDI_PatchMap.txt"))
            {
                StreamReader sr = new StreamReader("MIDI_PatchMap.txt");
                for(int i = 0; i < 128; i++)
                    this.instrumentComboBox.Items.Add(sr.ReadLine());
                sr.Close();
            } else
            {
                for(int i = 1; i < 129; i++)
                    this.instrumentComboBox.Items.Add(i.ToString().PadLeft(3, '0'));
            }
            this.instrumentComboBox.SelectedIndex = 0;
        }

        internal void setInstrument(int instrument)
        {
            if(instrument >= 0)
            {
                this.instrumentComboBox.SelectedIndex = instrument;
            }            
        }

        private void instrumentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstrumentChangedMessage message = new InstrumentChangedMessage();
            message.instrument = instrumentComboBox.SelectedIndex;
            eventAggregator.Publish(message);
        }

        private void tempoTrackBar_Scroll(object sender, EventArgs e)
        {
            TempoChangedMessage message = new TempoChangedMessage();
            message.tempo = tempoTrackBar.Value;
            eventAggregator.Publish(message);
            this.bpmLabel.Text = tempoTrackBar.Value.ToString() + " bpm";
        }

        internal void setTempo(double tempo)
        {
            if(tempo >= this.tempoTrackBar.Minimum && 
                tempo <= this.tempoTrackBar.Maximum)
            {
                this.tempoTrackBar.Value = (int) tempo;
            }
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            VolumeChangedMessage message = new VolumeChangedMessage();
            message.volume = volumeTrackBar.Value;
            eventAggregator.Publish(message);
        }

        
    }



}
