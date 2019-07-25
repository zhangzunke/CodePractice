using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Core
{
    public interface IEventBus
    {
        bool Subscribe<TEvent, TEventHandler>() 
            where TEventHandler : IEventHandler<TEvent> 
            where TEvent : IEventBase;
        bool Unsubscribe<TEvent, TEventHanlder>()
            where TEventHanlder : IEventHandler<TEvent>
            where TEvent : IEventBase;
        bool Publish<TEvent>(TEvent @event) where TEvent : IEventBase;
    }
}
