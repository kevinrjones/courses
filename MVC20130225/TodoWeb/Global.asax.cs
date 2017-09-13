using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.SignalR;
using TodoWeb.App_Start;

namespace TodoWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteTable.Routes.RegisterRoutes();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            string baseDirectory = HttpContext.Current.Server.MapPath("~/App_Data") + ConfigurationManager.AppSettings["dataFolderName"];

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var repositoryAssemblies = Assembly.Load("FileRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies).AsImplementedInterfaces().WithParameter(new NamedParameter("path", baseDirectory));

            var serviceAssemblies = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();

            var configurationManagerWrapperAssembly = Assembly.Load("ConfigurationManagerWrapper");
            builder.RegisterAssemblyTypes(configurationManagerWrapperAssembly).AsImplementedInterfaces();

            var fileAssembly = Assembly.Load("SystemFileAdapter");
            builder.RegisterAssemblyTypes(fileAssembly).AsImplementedInterfaces();

            builder.RegisterFilterProvider();
        }
    }
}