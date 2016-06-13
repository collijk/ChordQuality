using System;
using System.ComponentModel;
using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public class MidiQualityModel : INotifyPropertyChanged
    {
        private double _sixthMajorInterval;
        private double _sixthMinorInterval;
        private double _fifthInterval;
        private double _fourthInterval;
        private double _thirdMajorInterval;
        private double _thirdMinorInterval;
        private double _fifthChord;
        private double _thirdMajorChord;
        private double _add;
        private double _short;
        private double _threshold;
        private QualityWeights _qualityWeights;
        private const double ComparisonTolerance = 0.001;

        public QualityWeights QualityWeights
        {
            get { return _qualityWeights; }
            set
            {
                if (value == QualityWeights)
                    return;

                _qualityWeights = value;
                OnPropertyChanged("QualityWeights");
            }
        }

        public double SixthMajorInterval
        {
            get { return _sixthMajorInterval; }
            set
            {
                if (Math.Abs(value - _sixthMajorInterval) < ComparisonTolerance)
                    return;

                _sixthMajorInterval = value;
                OnPropertyChanged("SixthMajorInterval");
            }
        }

        public double SixthMinorInterval
        {
            get { return _sixthMinorInterval; }
            set
            {
                if (Math.Abs(value - _sixthMinorInterval) < ComparisonTolerance)
                    return;

                _sixthMinorInterval = value;
                OnPropertyChanged("SixthMinorInterval");
            }
        }

        public double FifthInterval
        {
            get { return _fifthInterval; }
            set
            {
                if (Math.Abs(value - _fifthInterval) < ComparisonTolerance)
                    return;

                _fifthInterval = value;
                OnPropertyChanged("FifthInterval");
            }
        }

        public double FourthInterval
        {
            get { return _fourthInterval; }
            set
            {
                if (Math.Abs(value - _fourthInterval) < ComparisonTolerance)
                    return;

                _fourthInterval = value;
                OnPropertyChanged("FourthInterval");
            }
        }

        public double ThirdMajorInterval
        {
            get { return _thirdMajorInterval; }
            set
            {
                if (Math.Abs(value - _thirdMajorInterval) < ComparisonTolerance)
                    return;

                _thirdMajorInterval = value;
                OnPropertyChanged("ThirdMajorInterval");
            }
        }

        public double ThirdMinorInterval
        {
            get { return _thirdMinorInterval; }
            set
            {
                if (Math.Abs(value - _thirdMinorInterval) < ComparisonTolerance)
                    return;
                
                _thirdMinorInterval = value;
                OnPropertyChanged("ThirdMinorInterval");
            }
        }

        public double FifthChord
        {
            get { return _fifthChord; }
            set
            {
                if (Math.Abs(value - _fifthChord) < ComparisonTolerance)
                    return;

                _fifthChord = value;
                OnPropertyChanged("FifthChord");
            }
        }

        public double ThirdMajorChord
        {
            get { return _thirdMajorChord; }
            set
            {
                if (Math.Abs(value - _thirdMajorChord) < ComparisonTolerance)
                    return;

                _thirdMajorChord = value;
                OnPropertyChanged("ThirdMajorChord");
            }
        }

        public double Add
        {
            get { return _add; }
            set
            {
                if (Math.Abs(value - _add) < ComparisonTolerance)
                    return;

                _add = value;
                OnPropertyChanged("Add");
            }
        }

        public double Short
        {
            get { return _short; }
            set
            {
                if (Math.Abs(value - _short) < ComparisonTolerance)
                    return;

                _short = value;
                OnPropertyChanged("Short");
            }
        }

        public double Threshold
        {
            get { return _threshold; }
            set
            {
                if (Math.Abs(value - _threshold) < ComparisonTolerance)
                    return;

                _threshold = value;
                OnPropertyChanged("Threshold");
            }
        }

        public MidiQualityModel(QualityWeights qualityWeights)
        {
            SixthMajorInterval = qualityWeights.M6;
            SixthMinorInterval = qualityWeights.m6;
            FifthInterval = qualityWeights.fifth;
            FourthInterval = qualityWeights.fourth;
            ThirdMajorInterval = qualityWeights.M3;
            ThirdMinorInterval = qualityWeights.m3;
            FifthChord = qualityWeights.Ch5;
            ThirdMajorChord = qualityWeights.Ch3;
            Add = qualityWeights.Add;
            Short = qualityWeights.Short;
            Threshold = qualityWeights.Threshold;
            QualityWeights = qualityWeights;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}