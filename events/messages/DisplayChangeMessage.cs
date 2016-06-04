using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
      
}
