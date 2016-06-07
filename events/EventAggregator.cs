using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChordQuality.events.messages;

namespace ChordQuality.events
{
    /// <summary>
    ///     The EventAggregator manages event handling by decoupling
    ///     event sources (Publishers) from event handlers (Subscribers).
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        // Thread safe singleton pattern for EventAggregator construction.
        private static EventAggregator _instance;
        private static readonly object Padlock = new object();

        /// <summary>
        ///     A dictionary maintaining the message types as a set of keys
        ///     and a list of subscriptions to each message type as the associated values.
        /// </summary>
        private readonly IDictionary<Type, IList> _subscriptions =
            new Dictionary<Type, IList>();

        private EventAggregator()
        {
        }

        public static EventAggregator Instance
        {
            get
            {
                lock (Padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new EventAggregator();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        ///     Notifies all subscribers to a particular message that the message
        ///     has been sent.
        /// </summary>
        /// <typeparam name="TMessage">The message type.</typeparam>
        /// <param name="message">The message to be published.</param>
        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            // Check that an actual message has been sent.
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            // Only act if there are subscribers to the message type.
            var messageType = typeof(TMessage);
            if (_subscriptions.ContainsKey(messageType))
            {
                // Get the subscriber list.
                var subscriptionList = new List<ISubscription<TMessage>>(
                    _subscriptions[messageType].Cast<ISubscription<TMessage>>());

                // Notify the appropriate subscribers that the message has been sent.
                foreach (var subscription in subscriptionList)
                {
                    subscription.Action(message);
                }
            }
        }

        /// <summary>
        ///     Allows modules to subscribe to a message. When a module subscribes
        ///     it receives a subscription token that notifies it when the message
        ///     has been published.
        /// </summary>
        /// <typeparam name="TMessage">
        ///     The type of message the subscriber is
        ///     interested in.
        /// </typeparam>
        /// <param name="action">
        ///     The action performed by the subscription token
        ///     when the message of interest is published.
        /// </param>
        /// <returns>
        ///     A subscription token that notifies the subscriber when the
        ///     message of interest is published.
        /// </returns>
        public ISubscription<TMessage> Subscribe<TMessage>(Action<TMessage> action)
            where TMessage : IMessage
        {
            // Create a new subscription token for the message type and action.
            var messageType = typeof(TMessage);
            var subscription = new Subscription<TMessage>(this, action);

            // If the messageType is already a _subscriptions key, add the new
            // subscription to the associated subscription list.
            if (_subscriptions.ContainsKey(messageType))
            {
                _subscriptions[messageType].Add(subscription);
            }
            // Otherwise, create a new subscription list and add it to the 
            // dictionary of subscriptions.
            else
            {
                _subscriptions.Add(
                    messageType, new List<ISubscription<TMessage>> {subscription});
            }

            return subscription;
        }

        /// <summary>
        ///     Unregisters a subscription to a message type.
        /// </summary>
        /// <typeparam name="TMessage">
        ///     The type of message associated with
        ///     the subscription.
        /// </typeparam>
        /// <param name="subscription">The subscription to be removed.</param>
        public void Unsubscribe<TMessage>(ISubscription<TMessage> subscription)
            where TMessage : IMessage
        {
            var messageType = typeof(TMessage);
            // Only act if we have any subscriptions to the messageType.
            if (_subscriptions.ContainsKey(messageType))
            {
                _subscriptions[messageType].Remove(subscription);
            }
        }

        /// <summary>
        ///     Clears all subscriptions from the subscriptions dictionary.
        /// </summary>
        public void ClearAllSubscriptions()
        {
            ClearAllSubscriptions(null);
        }

        /// <summary>
        ///     Removes all subscriptions except those subscribed to messageTypes
        ///     in the exceptMessages array.
        /// </summary>
        /// <param name="exceptMessages">
        ///     An array of messageTypes we do not
        ///     wish to clear the subscriptions from.
        /// </param>
        public void ClearAllSubscriptions(Type[] exceptMessages)
        {
            // Loop over all messageTypes/subscription pairs.
            foreach (var messageSubsciptions in
                new Dictionary<Type, IList>(_subscriptions))
            {
                var canDelete = true;
                // Check that the message type is not excluded.
                if (exceptMessages != null)
                {
                    canDelete = !exceptMessages.Contains(messageSubsciptions.Key);
                }
                // Remove the subscription, if necessary.
                if (canDelete)
                {
                    _subscriptions.Remove(messageSubsciptions);
                }
            }
        }
    }
}