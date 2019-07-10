using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InjectCore.Extensions;
using InjectCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace InjectCore.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IFoobar _foobar;
        public DefaultController(IFoobar foobar) => _foobar = foobar;

        [HttpGet("/")]
        public Task Index(string source)
        {
            HttpContext.SetInvocationSource(source);
            var features = HttpContext.Features;
            foreach (var item in features)
            {

            }
            return _foobar.InvokeAsync(HttpContext) ?? Task.CompletedTask;
        }
    }
}