using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.events.messages
{
    public class MidiInfoMessage : IMessage
    {
    }

    public class InstrumentChangedMessage : MidiInfoMessage
    {
        public int instrument
        {
            get; set;
        }
    }

    public class TempoChangedMessage : MidiInfoMessage
    {
        public int tempo
        {
            get; set;
        }
    }

    public class VolumeChangedMessage : MidiInfoMessage
    {
        public int volume
        {
            get; set;
        }
    }
}
