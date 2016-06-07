using System.Collections;
using Janus.ManagedMIDI;

namespace ChordQuality.events.messages
{
    public class MidiInfoMessage : IMessage
    {
    }

    public class MidiPlayerUpdatedMessage : MidiInfoMessage
    {
        public MidiFilePlayer Player { get; set; }
    }

    public class FileTransposedMessage : MidiInfoMessage
    {
        public ArrayList Chords { get; set; }
    }

    public class PlaySelectionChangedMessage : MidiInfoMessage
    {
        public double PlayStart { get; set; }

        public double PlayStop { get; set; }
    }

    public class MarkersChangedMessage : MidiInfoMessage
    {
    }

    public class FindBestTuningsMessage : MidiInfoMessage
    {
    }

    public class TuningsUpdatedMessage : MidiInfoMessage
    {
        public TuningScheme[] Tunings { get; set; }
    }

    public class TuningEnabledMessage : MidiInfoMessage
    {
    }

    public class TuningsTransposedMessage : MidiInfoMessage
    {
        public int TransposeValue { get; set; }
    }

    public class QualityWeightsUpdatedMessage : MidiInfoMessage
    {
        public QualityWeights QualityWeights { get; set; }
    }

    public class QualityWeightScrollChangedMessage : MidiInfoMessage
    {
    }

    public class PenaltiesChangedMessage : MidiInfoMessage
    {
        public string Penalties { get; set; }
    }

    public class PenaltyScrollChangedMessage : MidiInfoMessage
    {
    }

    public class TracksChangedMessage : MidiInfoMessage
    {
    }
}