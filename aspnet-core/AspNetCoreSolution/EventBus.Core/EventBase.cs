using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Core
{
    public abstract class EventBase : IEventBase
    {
        public DateTimeOffset EventAt { get; private set; }
        public string EventId { get; private set; }
        protected EventBase()
        {
            EventId = Guid.NewGuid().ToString();
            EventAt = DateTimeOffset.UtcNow;
        }
        public EventBase(string eventId, DateTimeOffset eventAt)
        {
            EventId = eventId;
            EventAt = eventAt;
        }
    }
}
