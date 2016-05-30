using System;

namespace ChordQuality.events
{
    class Subscription<TMessage> : ISubscription<TMessage>
        where TMessage : IMessage
    {
        public Action<TMessage> Action
        {
            get;
            private set;
        }

        public IEventAggregator EventAggregator
        {
            get;
            private set;
        }

        public Subscription(IEventAggregator eventAggregator, Action<TMessage> action)
        {
            if(eventAggregator == null)
            {
                throw new ArgumentNullException("eventAggregator");
            }
            if(action == null)
            {
                throw new ArgumentNullException("action");
            }

            EventAggregator = eventAggregator;
            Action = action;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                EventAggregator.Unsubscribe(this);
            }
        }
    }
}
