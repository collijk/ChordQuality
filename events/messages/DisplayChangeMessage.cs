using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
