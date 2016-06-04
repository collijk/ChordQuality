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
   
}
