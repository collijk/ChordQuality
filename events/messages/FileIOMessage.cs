using Janus.ManagedMIDI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.events.messages
{
    public class FileIOMessage : IMessage
    {
    }

    public class FileOpenedMessage : FileIOMessage
    {
        public MidiFile file
        {
            get; set;
        }

        public MidiFilePlayer player
        {
            get; set;
        }
    }
}
