using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApplication.IOC;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var container = RegistBasicConventionalRegistart();
            services.AddAuthentication()
                .AddCookie("Cookies");
            services.AddTransient<ITransientTest, TransientTest>();
            services.AddScoped<IScopedTest, ScopedTest>();
            services.AddSingleton<ISingletonTest, SingletonTest>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        private WindsorContainer RegistBasicConventionalRegistart()
        {
            var list = new List<Assembly>();
            list.Add(Assembly.GetExecutingAssembly());
            return new BasicConventionalRegistrar().RegisterAssembly(list);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
