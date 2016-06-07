using System;
using ChordQuality.events.messages;

namespace ChordQuality.events
{
    /// <summary>
    ///     Interface for Event Aggregator classes.
    /// </summary>
    public interface IEventAggregator
    {
        void Publish<TMessage>(TMessage message) where TMessage : IMessage;

        ISubscription<TMessage> Subscribe<TMessage>(Action<TMessage> action)
            where TMessage : IMessage;

        void Unsubscribe<TMessage>(ISubscription<TMessage> subscription)
            where TMessage : IMessage;

        void ClearAllSubscriptions();

        void ClearAllSubscriptions(Type[] exceptMessages);
    }
}