using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Dependency;

namespace WebApplication
{
    public class BasicConventionalRegistrar
    {
        private readonly WindsorContainer _container = new WindsorContainer();

        public WindsorContainer RegisterAssembly(List<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                //Transient
                _container.Register(
                    Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
                    .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                    );

                //Singleton
                _container.Register(
                    Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .If(type => !type.IsGenericTypeDefinition)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleSingleton()
                    );
            }

            return _container;
        }
    }
}
