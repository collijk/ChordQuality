namespace ChordQuality.events.messages
{
    public class PlaybackMessage : IMessage
    {
    }

    public class PlayMessage : PlaybackMessage
    {
        public int DeviceIndex { get; set; }
    }

    public class PauseMessage : PlaybackMessage
    {
    }

    public class StopMessage : PlaybackMessage
    {
    }
}