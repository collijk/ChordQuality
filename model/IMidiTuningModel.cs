using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
