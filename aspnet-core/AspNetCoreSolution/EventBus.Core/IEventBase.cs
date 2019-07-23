using System;

namespace EventBus.Core
{
    public interface IEventBase
    {
        DateTimeOffset EventAt { get; }
        string EventId { get; }
    }
}
