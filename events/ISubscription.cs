using System;

namespace ChordQuality.events
{
    public interface ISubscription<TMessage> : IDisposable 
        where TMessage : IMessage
    {
        Action<TMessage> Action
        {
            get;
        }

        IEventAggregator EventAggregator
        {
            get;
        }
    }
}
