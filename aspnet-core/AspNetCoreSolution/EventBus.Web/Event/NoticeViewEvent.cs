using EventBus.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBus.Web.Event
{
    public class NoticeViewEvent : EventBase
    {
        public Guid NoticeId { get; set; } 
    }
}
