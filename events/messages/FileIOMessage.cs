using Janus.ManagedMIDI;

namespace ChordQuality.events.messages
{
    public class FileIoMessage : IMessage
    {
    }

    public class FileOpenedMessage : FileIoMessage
    {
        public MidiFile File { get; set; }
    }

    public class FileUpdatedMessage : FileIoMessage
    {
        public MidiFile File { get; set; }
    }
}