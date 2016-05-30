using System;

namespace ChordQuality.events
{
    /// <summary>
    /// Interface for message subscriptions.
    /// </summary>
    /// <typeparam name="TMessage">The message type subscribed to.</typeparam>
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
