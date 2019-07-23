using Autofac;
using AutoFac.Repository.IRepository;
using AutoFac.Repository.Repository;
using AutoFac.Service.IService;
using AutoFac.Service.Service;
using System;

namespace Auto.Ioc
{
    public class Container
    {
        public static IContainer Instance;

        public static void Init()
        {
            var builder = new ContainerBuilder();
            Register(builder);
            Instance = builder.Build();
        }

        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<StudentService>().As<IStudentService>();
        }
    }
}
