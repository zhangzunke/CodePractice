using EventBus.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBus.Web.Event
{
    public class BlogViewEventHandler : IEventHandler<NoticeViewEvent>
    {
        private readonly ILogger<BlogViewEventHandler> _logger;
        public BlogViewEventHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BlogViewEventHandler>();
        }
        public async Task Handle(NoticeViewEvent @event)
        {
            _logger.LogWarning($"Blog View Notice : {@event.NoticeId.ToString()}");
            await Task.Delay(1000);
        }
    }
}
