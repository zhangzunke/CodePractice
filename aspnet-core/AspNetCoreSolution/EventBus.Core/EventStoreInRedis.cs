using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Core
{
    public class EventStoreInRedis : IEventStore
    {
        protected readonly string EventsCacheKey;
        protected readonly ILogger Logger;
        public bool AddSubscription<TEvent, TEventHandler>()
            where TEvent : IEventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }

        public bool Clear()
        {
            throw new NotImplementedException();
        }

        public ICollection<Type> GetEventHandlerTypes<TEvent>() where TEvent : IEventBase
        {
            throw new NotImplementedException();
        }

        public string GetEventKey<TEvent>()
        {
            throw new NotImplementedException();
        }

        public bool HasSubscriptionForEvent<TEvent>() where TEvent : IEventBase
        {
            throw new NotImplementedException();
        }

        public bool RemoveSubscription<TEvent, TEventHandler>()
            where TEvent : IEventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new NotImplementedException();
        }
    }
}
