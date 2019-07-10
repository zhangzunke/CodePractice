using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using InjectCore.Attributes;
using InjectCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace InjectCore.Services
{
    public class FoobarSelector : IFoobar
    {
        private static ConcurrentDictionary<Type, string> _sources = new ConcurrentDictionary<Type, string>();
        public Task InvokeAsync(HttpContext context)
        {
            return context.RequestServices.GetServices<IFoobar>()
                .FirstOrDefault(it => it != this && GetInvocationSource(it) == context.GetInvocationSource())?.InvokeAsync(context);

            string GetInvocationSource(object service)
            {
                var type = service.GetType();
                return _sources.GetOrAdd(type, _ => type.GetCustomAttribute<InvocationSourceAttribute>()?.Source);
            }
        }
    }
}
