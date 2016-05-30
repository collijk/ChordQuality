using System;

namespace ChordQuality.events
{
    /// <summary>
    /// A token representing a subscription to a particular message type.
    /// </summary>
    /// <typeparam name="TMessage">The message type subscribed to.</typeparam>
    class Subscription<TMessage> : ISubscription<TMessage>
        where TMessage : IMessage
    {
        /// <summary>
        /// The action fired when a messageType is published to its subscribers.
        /// </summary>
        public Action<TMessage> Action
        {
            get;
            private set;
        }

        /// <summary>
        /// The EventAggregator that published the message.
        /// </summary>
        public IEventAggregator EventAggregator
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructs a subscription token to a message type.
        /// </summary>
        /// <param name="eventAggregator">The EventAggregator that publishes the 
        /// messages of interest to the subscriber.</param>
        /// <param name="action">The action fired when the message type is published.</param>
        public Subscription(IEventAggregator eventAggregator, Action<TMessage> action)
        {
            // Check arguments are valid.
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

        /// <summary>
        /// Allows subscribers to easily remove subscriptions they're no longer
        /// interested in.
        /// </summary>
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
