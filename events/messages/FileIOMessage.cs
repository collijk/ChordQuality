using Janus.ManagedMIDI;

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
    }

    public class FileUpdatedMessage : FileIOMessage
    {
        public MidiFile file
        {
            get; set;
        }
    }

    
}
