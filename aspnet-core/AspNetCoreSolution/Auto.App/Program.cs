using Auto.Ioc;
using System;
using Autofac;
using AutoFac.Service.IService;

namespace Auto.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Container.Init();
            var service = Container.Instance.Resolve<IStudentService>();
            var name = service.GetStudentName(2007);
            Console.ReadLine();
        }
    }
}
