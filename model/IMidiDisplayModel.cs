using ChordQuality.views;

namespace ChordQuality.model
{
    public interface IMidiDisplayModel
    {
        int FirstBar { get; set; }

        int LastBar { get; set; }

        int NumberOfBars { get; }

        float VerticalScale { get; set; }

        byte MinNote { get; set; }

        byte MaxNote { get; set; }
        
        TrackDisplay Tracks { get; set; }

        float RelThickness{ get; set; }
    }
}