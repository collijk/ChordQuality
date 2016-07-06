using System.ComponentModel;
using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public class MidiPlaybackModel : INotifyPropertyChanged
    {
        private PlaybackState _playbackState;
        private MidiOutDevs _outputDevices;
        private int _selectedInstrument;
        private int _selectedOutputDevice;
        private int _tempo;
        private int _volume;

        public enum PlaybackState
        {
            Play, Pause, Stop, Uninitialized
        }

        public PlaybackState PlayState
        {
            get { return _playbackState; }
            set
            {
                if (value == _playbackState)
                    return;

                _playbackState = value;
                OnPropertyChanged("PlayState");
            }
        }

        public MidiOutDevs OutputDevices
        {
            get { return _outputDevices; }
            set
            {
                if (value == _outputDevices)
                    return;

                _outputDevices = value;
                OnPropertyChanged("OutputDevices");
            }
        }

        public int SelectedOutputDevice
        {
            get { return _selectedOutputDevice; }
            set
            {
                if (value == _selectedOutputDevice)
                    return;

                _selectedOutputDevice = value;
                OnPropertyChanged("SelectedOutputDevice");
            }
        }

        public int SelectedInstrument
        {
            get { return _selectedInstrument; }
            set
            {
                if (value == _selectedInstrument)
                    return;

                _selectedInstrument = value;
                OnPropertyChanged("SelectedInstrument");
            }
        }

        public int Tempo
        {
            get { return _tempo; }
            set
            {
                if (value == _tempo)
                    return;

                _tempo = value;
                OnPropertyChanged("Tempo");
            }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value == _volume)
                    return;

                _volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public MidiPlaybackModel()
        {
            PlayState = PlaybackState.Uninitialized;
            OutputDevices = new MidiOutDevs();
            SelectedOutputDevice = 0;
            SelectedInstrument = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
