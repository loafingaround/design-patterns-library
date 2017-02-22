using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EventAggregatorPattern
{
    // several different approaches to event aggregator pattern exist
    // this is one of them (apparently advocated by Jeremy Miller, author of StructureMap)

    class SimpleEventAggregator : IEventAggregator
    {
        // collection of WeakReference objects for each type of message:
        // WeakReference references an object while also letting garbage collector reclaim it
        // using WeakReference allows managing of references (garbage collection) such that subscribers are not held onto
        // simply because of the fact that they listen to a particular event - this reduces memory leaks as there is no
        // *strong* link b/w either the publisher or event aggregator and the subscriber so subscriber does not have to
        // worry about manually unsubscribing itself  - see Publish method below
        private readonly Dictionary<Type,  List<WeakReference>> eventSubscriberLists = new Dictionary<Type, List<WeakReference>>();

        private readonly object lockObj = new object();

        public void Subscribe(object subscriber)
        {
            // we are modifying the subscribers collection, and in multi-threaded environment might
            // be multiple subscribers trying to subscribe simultaneously
            lock (lockObj)
            {
                // get all ISubscriber<> interfaces implemented by subscriber
                IEnumerable<Type> subscriberTypes = subscriber.GetType()
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                WeakReference weakRef = new WeakReference(subscriber);

                foreach (Type subscriberType in subscriberTypes)
                {
                    // get collection of subscribers for ISubscriber<> type (e.g. ISubscriber<MessageSentEvent>)
                    IList<WeakReference> subscribers = GetSubscribers(subscriberType);
                    // and add (WeakReference to) subscriber
                    subscribers.Add(weakRef);
                }
            }
        }
        
        // gets current list of subscribers for type (empty list if none)
        private IList<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;

            lock (lockObj)
            {
                bool found = eventSubscriberLists.TryGetValue(subscriberType, out subscribers);
                if (!found)
                {
                    subscribers = new List<WeakReference>();
                    eventSubscriberLists.Add(subscriberType, subscribers);
                }
            }

            return subscribers;
        }

        public void Publish<TEvent>(TEvent eventToPublish)
        {
            // MakeGenericType constructs an instance of Type by taking the generic type it is called on
            // and using Type argument(s) passed to it as the type parameters of that generic type
            // - here it will create a Type instance for ISubscriber<TEvent>
            Type subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));

            IList<WeakReference> subscribers = GetSubscribers(subscriberType);

            IList<WeakReference> subscribersToRemove = new List<WeakReference>();

            foreach (WeakReference weakSubscriber in subscribers)
            {
                // if subscriber has not been garbage collected (which is fine) 
                if (weakSubscriber.IsAlive)
                {
                    // cast to specific subscriber interface for current event
                    ISubscriber<TEvent> subscriber = (ISubscriber<TEvent>)weakSubscriber.Target;

                    // use SynchronizationContext in case publisher and subscriber are on different threads
                    // e.g. subscriber on UI thread, publisher not
                    var syncContext = SynchronizationContext.Current;

                    if (syncContext == null)
                        syncContext = new SynchronizationContext();

                    syncContext.Post(s => subscriber.OnEvent(eventToPublish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }

                // garbage collected subscribers are automatically unsubscribed:
                if (subscribersToRemove.Any())
                {
                    lock (lockObj)
                    {
                        foreach (WeakReference toRemove in subscribersToRemove)
                            subscribers.Remove(toRemove);
                    }
                }
            }
        }
    }
}
