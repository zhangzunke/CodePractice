using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EventBus.Core
{
    public class EventBus : IEventBus
    {
        private readonly ILogger<EventBus> _logger;
        private readonly IEventStore _eventStore;
        private readonly IServiceProvider _serviceProvider;
        public EventBus(IEventStore eventStore, IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory)
        {
            _eventStore = eventStore;
            _serviceProvider = serviceProvider;
            _logger = loggerFactory.CreateLogger<EventBus>();
        }
        public bool Publish<TEvent>(TEvent @event) where TEvent : IEventBase
        {
            if (!_eventStore.HasSubscriptionForEvent<TEvent>())
            {
                return false;
            }
            var handlers = _eventStore.GetEventHandlerTypes<TEvent>();
            if (handlers.Count > 0)
            {
                var handlerTasks = new List<Task>();
                foreach (var handlerType in handlers)
                {
                    try
                    {
                        
                        if (_serviceProvider.GetService(handlerType) is IEventHandler<TEvent> handler)
                        {
                            handlerTasks.Add(handler.Handle(@event));
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }
                Task.WhenAll(handlerTasks).ConfigureAwait(false);
                return true;
            }
            return false;
        }

        public bool Subscribe<TEvent, TEventHandler>()
            where TEvent : IEventBase
            where TEventHandler : IEventHandler<TEvent>
        {
            return _eventStore.AddSubscription<TEvent, TEventHandler>();
        }

        public bool Unsubscribe<TEvent, TEventHanlder>()
            where TEvent : IEventBase
            where TEventHanlder : IEventHandler<TEvent>
        {
            return _eventStore.RemoveSubscription<TEvent, TEventHanlder>();
        }
    }
}
