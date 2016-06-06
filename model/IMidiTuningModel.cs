using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public interface IMidiTuningModel
    {
        TuningScheme[] Tunings
        {
            get; 
        }

        TuningScheme CurrentTuning
        {
            get; set;
        }

        int NumberOfAvailableTunings
        {
            get; set;
        }
        
    }
}
