using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GraphQLWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<HelloWorldQuery>();
            services.AddSingleton<ISchema, HelloWorldSchema>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseMvc();
            //var schema = new Schema
            //{
            //    Query = new HelloWorldQuery()
            //};

            //app.Run(async (context) =>
            //{
            //    var result = await new DocumentExecuter()
            //    .ExecuteAsync(doc => 
            //    {
            //        doc.Schema = schema;
            //        doc.Query = @"
            //            query {
            //               hello
            //               howdy
            //            }
            //        ";
            //    }).ConfigureAwait(false);

            //    var json = new DocumentWriter(indent: true)
            //               .Write(result);
            //    await context.Response.WriteAsync(json);
            //});

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMiddleware<GraphQLMiddleware>();

            /*
            app.Run(async (context) => 
            {
                if (context.Request.Path.StartsWithSegments("/api/graphql")
                && string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
                {
                    string body;
                    using (var streamReader = new StreamReader(context.Request.Body))
                    {
                        body = await streamReader.ReadToEndAsync();

                        var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);
                        var schema = new Schema { Query = new HelloWorldQuery() };

                        var result = await new DocumentExecuter()
                        .ExecuteAsync(doc => 
                        {
                            doc.Schema = schema;
                            doc.Query = request.Query;
                        }).ConfigureAwait(false);

                        var json = new DocumentWriter(indent: true)
                        .Write(result);

                        await context.Response.WriteAsync(json);
                    }
                }
            });
            */
        }
    }
}
