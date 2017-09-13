using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace IssueTraq
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            var serviceAssemblies = Assembly.Load("IssueRepository");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();

            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
        }
    }
}
