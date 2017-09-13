using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using DOCLib;

namespace IoCDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<EFRepository>().As<IRepository>();
            builder.RegisterType<HttpAccountService>().As<IAccountService>();

            IContainer container = builder.Build();

            var service = container.Resolve<IAccountService>();

            service.GetAccount(1);
        }
    }

}
