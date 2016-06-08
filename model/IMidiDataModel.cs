using Janus.ManagedMIDI;

namespace ChordQuality.model
{
    public interface IMidiDataModel
    {
        TimeInfo[] Chords { get; set; }

        ushort Timing { get; set; }
    }
}
