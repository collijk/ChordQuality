using System;
using System.ComponentModel;
using System.Drawing;
using ChordQuality.views;

namespace ChordQuality.model
{
    public class MidiDisplayModel : INotifyPropertyChanged
    {
        private int _firstBar;
        private int _lastBar;
        private int _numberOfBars;
        private float _verticalScale;
        private TrackDisplay _tracks;
        private float _relThickness;
        private Color[] _trackColors;
        private const double ComparisonTolerance = 0.001;

        public int FirstBar
        {
            get { return _firstBar; }
            set
            {
                if (value == _firstBar)
                    return;

                _firstBar = value;
                NumberOfBars = _lastBar - _firstBar + 1;
                OnPropertyChanged("FirstBar");
            }
        }

        public int LastBar
        {
            get { return _lastBar; }
            set
            {
                if (value == _lastBar)
                    return;

                _lastBar = value;
                NumberOfBars = _lastBar - _firstBar + 1;
                OnPropertyChanged("LastBar");
            }
        }

        public int NumberOfBars
        {
            get { return _numberOfBars; }
            private set
            {
                if (value == _numberOfBars)
                    return;

                _numberOfBars = value;
                OnPropertyChanged("NumberOfBars");
            }
        }

        public float VerticalScale
        {
            get { return _verticalScale; }
            set
            {
                if (Math.Abs(value - _verticalScale) < ComparisonTolerance)
                    return;

                _verticalScale = value;
                OnPropertyChanged("VerticalScale");
            }
        }

        public TrackDisplay Tracks
        {
            get { return _tracks; }
            set
            {
                if (value == _tracks)
                    return;

                _tracks = value;
                OnPropertyChanged("Tracks");
            }
        }

        public float RelThickness
        {
            get { return _relThickness; }
            set
            {
                if (Math.Abs(value - _relThickness) < ComparisonTolerance)
                    return;

                _relThickness = value;
                OnPropertyChanged("RelThickness");
            }
        }

        public Color[] TrackColors
        {
            get { return _trackColors; }
            set
            {
                if (value == _trackColors)
                    return;

                _trackColors = value;
                OnPropertyChanged("TrackColors");
            }
        }

        public MidiDisplayModel()
        {
            // Default Display Values
            FirstBar = 1;
            LastBar = 1;
            VerticalScale = 2.0f;
            Tracks = null;
            RelThickness = 0.5f;
            TrackColors = new Color[]
            {
                Color.Black,
                Color.Red,
                Color.Green,
                Color.Orange,
                Color.Blue,
                Color.Black,
                Color.Black,
                Color.Black,
                Color.Black,
                Color.Magenta,
                Color.Cyan,
                Color.Pink,
                Color.LightBlue,
                Color.Brown,
                Color.Gold,
                Color.Silver,
                Color.Black,
                Color.Black,
                Color.Black
            };
        }
    

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}