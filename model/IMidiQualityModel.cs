using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public interface IMidiQualityModel
    {
        QualityWeights QualityWeights
        {
            get; 
        }

        double SixthMajorInterval
        {
            get; set;
        }

        double SixthMinorInterval
        {
            get; set;
        }

        double FifthInterval
        {
            get; set;
        }

        double FourthInterval
        {
            get; set;
        }

        double ThirdMajorInterval
        {
            get; set;
        }

        double ThirdMinorInterval
        {
            get; set;
        }

        double FifthChord
        {
            get; set;
        }

        double ThirdMajorChord
        {
            get; set;
        }

        double Add
        {
            get; set;
        }

        double Short
        {
            get; set;
        }

    }
}
