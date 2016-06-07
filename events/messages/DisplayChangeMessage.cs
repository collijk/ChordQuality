using ChordQuality.views;

namespace ChordQuality.events.messages
{
    public class DisplayChangeMessage : IMessage
    {
    }

    public class BarOffsetChangedMessage : DisplayChangeMessage
    {
        public string OffsetValue { get; set; }
    }

    public class ZoomScrollChangedMessage : DisplayChangeMessage
    {
        public int ZoomValue { get; set; }
    }

    public class TrackDisplayChangedMessage : DisplayChangeMessage
    {
        public TrackDisplay TrackDisplay { get; set; }
    }

    public class TrackColorChangedMessage : DisplayChangeMessage
    {
    }

    public class QualityCheckChangedMessage : DisplayChangeMessage
    {
        public bool CheckStatus { get; set; }
    }

    public class LabelCheckChangedMessage : DisplayChangeMessage
    {
        public bool CheckStatus { get; set; }
    }
}