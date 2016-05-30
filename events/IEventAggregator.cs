using System;

namespace ChordQuality.events
{   
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
