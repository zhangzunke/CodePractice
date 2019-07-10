using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InjectCore.Attributes;
using Microsoft.AspNetCore.Http;

namespace InjectCore.Services
{
    [InvocationSource("MiniApp")]
    public class Bar : IFoobar
    {
        public Task InvokeAsync(HttpContext context) => context.Response.WriteAsync("Process for MiniApp");
    }
}
