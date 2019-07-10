using InjectCore.Infrastructures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjectCore.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetInvocationSource(this HttpContext context) => context.Features.Get<IInvocationSourceFeature>()?.Source;
        public static void SetInvocationSource(this HttpContext context, string source) => context.Features.Set<IInvocationSourceFeature>(new InvocationSourceFeature(source));
    }
}
