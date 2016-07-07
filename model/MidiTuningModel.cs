using System.ComponentModel;
using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public class MidiTuningModel : INotifyPropertyChanged
    {
        private TuningScheme[] _tunings;
        private TuningScheme _currentTuning;
        private int _numberOfAvailableTunings;
        private int _transpose;

        public TuningScheme[] Tunings
        {
            get { return _tunings; }
            set
            {
                if (value == _tunings)
                    return;

                _tunings = value;
                OnPropertyChanged("Tunings");
            }
        }

        public TuningScheme CurrentTuning
        {
            get { return _currentTuning; }
            set
            {
                if (value == CurrentTuning)
                    return;

                _currentTuning = value;
                OnPropertyChanged("CurrentTuning");
            }
        }

        public int NumberOfAvailableTunings
        {
            get { return _numberOfAvailableTunings; }
            set
            {
                if (value == _numberOfAvailableTunings)
                    return;

                _numberOfAvailableTunings = value;
                OnPropertyChanged("NumberOfAvailableTunings");
            }
        }

        public int Transpose
        {
            get { return _transpose; }
            set
            {
                if (value == _transpose)
                    return;

                _transpose = value;

                foreach (var t in _tunings)
                {
                    t.Transpose = _transpose;
                }

                OnPropertyChanged("Transpose");
            }
        }

        public MidiTuningModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}