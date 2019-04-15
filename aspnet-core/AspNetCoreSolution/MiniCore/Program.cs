using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MiniCore
{
    public class Program
    {
        public static void Main()
        {
            new WebHostBuilder()
                .UseKestrel()
                .Configure(app => app
                      .Use(FooMiddleware)
                      .Use(BarMiddleware)
                      .Use(BazMiddleware))
                .Build()
                .Run();
        }

        public static RequestDelegate FooMiddleware(RequestDelegate next)
            => async context =>
            {
                await context.Response.WriteAsync("Foo=>");
                await next(context);
            };

        public static RequestDelegate BarMiddleware(RequestDelegate next)
            => async context =>
            {
                await context.Response.WriteAsync("Bar=>");
                await next(context);
            };

        public static RequestDelegate BazMiddleware(RequestDelegate next)
            => async context =>
            {
                await context.Response.WriteAsync("Baz=>");
                await next(context);
            };
    }
    //public class Program
    //{
    //    public static void Main() => new WebHostBuilder()
    //        .UseKestrel()
    //        .Configure(app => app.Run(context => context.Response.WriteAsync("Hello World")))
    //        .Build()
    //        .Run();
    //    //public static void Main(string[] args)
    //    //{
    //    //    CreateWebHostBuilder(args).Build().Run();
    //    //}

    //    //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //    //    WebHost.CreateDefaultBuilder(args)
    //    //        .UseStartup<Startup>();
    //}
}
