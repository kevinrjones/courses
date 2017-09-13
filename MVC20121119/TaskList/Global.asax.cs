using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SystemFileAdapter;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Web.WebPages.OAuth;

namespace TaskList
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            OAuthWebSecurity.RegisterGoogleClient();
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            string baseDirectory = HttpContext.Current.Server.MapPath("~/App_Data") + "/" + ConfigurationManager.AppSettings["dataFolderName"];

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var repositoryAssemblies = Assembly.Load("FileRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies).AsImplementedInterfaces().WithParameter(new NamedParameter("path", baseDirectory));

            var configurationManagerWrapperAssembly = Assembly.Load("ConfigurationManagerWrapper");
            builder.RegisterAssemblyTypes(configurationManagerWrapperAssembly).AsImplementedInterfaces();

            var fileAssembly = Assembly.Load("SystemFileAdapter");
            builder.RegisterAssemblyTypes(fileAssembly).AsImplementedInterfaces();
            builder.RegisterType<SystemFileInfoFactory>().As<FileInfoFactory>();
        }

    }
}