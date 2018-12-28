﻿using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDocumentWriter _writer;
        private readonly IDocumentExecuter _executor;
        public GraphQLMiddleware(RequestDelegate next,
            IDocumentWriter writer,
            IDocumentExecuter executor)
        {
            _next = next;
            _writer = writer;
            _executor = executor;
        }

        public async Task InvokeAsync(HttpContext httpContext, ISchema schema)
        {
            if (httpContext.Request.Path.StartsWithSegments("/api/graphql")
                && string.Equals(httpContext.Request.Method,
                "POST",
                StringComparison.OrdinalIgnoreCase))
            {
                string body;
                using (var streamReader = new StreamReader(httpContext.Request.Body))
                {
                    body = await streamReader.ReadToEndAsync();
                    var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

                    var result = await _executor.ExecuteAsync(doc =>
                    {
                        doc.Schema = schema;
                        doc.Query = request.Query;
                        doc.Inputs = request.Variables.ToInputs();
                    }).ConfigureAwait(false);

                    var json = await _writer.WriteToStringAsync(result);
                    await httpContext.Response.WriteAsync(json);
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
