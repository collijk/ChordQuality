using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public class MidiPlaybackModel : INotifyPropertyChanged
    {
        private PlaybackState _playbackState;

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

        public MidiPlaybackModel()
        {
            PlayState = PlaybackState.Uninitialized;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
