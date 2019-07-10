using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InjectCore.Services
{
    public interface IFoobar
    {
        Task InvokeAsync(HttpContext context);
    }
}
