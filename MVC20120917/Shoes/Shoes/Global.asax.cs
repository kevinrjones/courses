using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Shoes.App_Start;

namespace Shoes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error()
        {
        }

        protected void Application_Start()
        {
            BuildAutofacContainer();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteTable.Routes.RegisterRoutes();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            var loadedAssemblies = Assembly.Load("ShoeInMemoryRepository");
            builder.RegisterAssemblyTypes(loadedAssemblies).AsImplementedInterfaces();
            loadedAssemblies = Assembly.Load("InMemoryShoeServices");
            builder.RegisterAssemblyTypes(loadedAssemblies).AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}