using Janus.ManagedMIDI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.events.messages
{
    public class MidiInfoMessage : IMessage
    {
    }

    public class MidiPlayerUpdatedMessage : MidiInfoMessage
    {
        public MidiFilePlayer player
        {
            get; set;
        }
    }

    public class FileTransposedMessage : MidiInfoMessage
    {
        public ArrayList chords
        {
            get; set;
        }
    }

    public class PlaySelectionChangedMessage : MidiInfoMessage
    {
        public double playStart
        {
            get; set;
        }

        public double playStop
        {
            get; set;
        }
    }

    public class MarkersChangedMessage : MidiInfoMessage
    {
    }

    public class FindBestTuningsMessage : MidiInfoMessage
    {
    }

    public class TuningsUpdatedMessage : MidiInfoMessage
    {
        public TuningScheme[] tunings
        {
            get; set;
        }
    }

    public class TuningsTransposedMessage : MidiInfoMessage
    {
        public int transposeValue
        {
            get; set;
        }
    }

    public class QualityWeightsUpdatedMessage : MidiInfoMessage
    {
        public QualityWeights qualityWeights
        {
            get; set;
        }
    }

    public class QualityWeightScrollChangedMessage : MidiInfoMessage
    {
        public String source
        {
            get; set;
        }
        public int scrollValue
        {
            get; set;
        }
    }

    public class PenaltiesChangedMessage : MidiInfoMessage
    {
        public String penalties
        {
            get; set;
        }

        public int penaltiesIndex
        {
            get; set;
        }
    }

    public class PenaltyScrollChangedMessage : MidiInfoMessage
    {
        public String source
        {
            get; set;
        }

        public int scrollValue
        {
            get; set;
        }
    }
    public class TracksChangedMessage : MidiInfoMessage
    {
    }

}
