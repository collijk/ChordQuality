using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordQuality.events.messages
{
    public abstract class PlaybackMessage : IMessage
    {
    }

    public class PlayMessage : PlaybackMessage
    {
    }

    public class PauseMessage : PlaybackMessage
    {
    }

    public class StopMessage : PlaybackMessage
    {
    }
}
