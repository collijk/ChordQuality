using ChordQuality.forms.customDisplays;
using System;

namespace ChordQuality.events.messages
{
    public class DisplayChangeMessage : IMessage
    {
    }

    public class BarOffsetChangedMessage : DisplayChangeMessage
    {
        public String offsetValue
        {
            get; set;
        }
    }

    public class ZoomScrollChangedMessage : DisplayChangeMessage
    {
        public int zoomValue
        {
            get; set;
        }
    }

    public class TrackDisplayChangedMessage : DisplayChangeMessage
    {
        public TrackDisplay trackDisplay
        {
            get; set;
        }
    }

    public class TrackColorChangedMessage : DisplayChangeMessage
    {
    }

    public class QualityCheckChangedMessage : DisplayChangeMessage
    {
        public bool checkStatus
        {
            get; set;
        }
    }

    public class LabelCheckChangedMessage : DisplayChangeMessage
    {
        public bool checkStatus
        {
            get; set;
        }
    }
      
}
