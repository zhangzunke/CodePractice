using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Middleware
{
    public class PlatformAuthenticationOptions : AuthenticationOptions
    {
        public PlatformAuthenticationOptions()
        {
            this.DefaultAuthenticateScheme = "PlatformScheme";
        }
    }
}
