using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using KelloRepository.Contexts;

namespace Kello
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            string ctor = ConfigurationManager.ConnectionStrings["KelloContext"].ConnectionString;
            var repositoryAssemblies = Assembly.Load("KelloRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies).AsImplementedInterfaces();
            var serviceAssemblies = Assembly.Load("KelloService");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();
            builder.RegisterType<KelloContext>().WithParameter(new NamedParameter("connectionString", ctor)).InstancePerRequest();            
        }

    }
}
