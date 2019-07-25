using EventBus.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBus.Web.Event
{
    public class NoticeViewEventHandler : IEventHandler<NoticeViewEvent>
    {
        private readonly ILogger<NoticeViewEventHandler> _logger;
        public NoticeViewEventHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NoticeViewEventHandler>();
        }
        public async Task Handle(NoticeViewEvent @event)
        {
            _logger.LogWarning($"Notice View ID: {@event.NoticeId.ToString()}");
            await Task.Delay(1000);
        }
    }
}
