using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using DataModels;
using Logging;
using NlogService;

namespace TodoWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_PostAuthenticateRequest()
        {
            var user = new GenericPrincipal(HttpContext.Current.User.Identity, new []{"admin"});
            Thread.CurrentPrincipal = HttpContext.Current.User = user;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var mvcbuilder = ControllerBuilder.Current;
            mvcbuilder.DefaultNamespaces.Add("TodoWeb.Controllers");


            var builder = new ContainerBuilder();
            builder.RegisterFilterProvider();
            
            RegisterTypes(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var assembly = Assembly.Load("TodoServices");
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            assembly = Assembly.Load("TodoRepository");
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

            builder.RegisterType<TodoEntities>();
            builder.RegisterType<NLogService>().As<ILogger>();
        }

    }
}