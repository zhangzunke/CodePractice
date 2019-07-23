using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Core
{
    public interface IEventHandler<in TEvent> where TEvent : IEventBase
    {
        Task Handle(TEvent @event);
    }
}
