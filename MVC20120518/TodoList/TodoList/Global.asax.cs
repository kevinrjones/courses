using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using Microsoft.Practices.Unity;
using Repository;

namespace TodoList
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "todo-default",
            //    url: "",
            //    defaults: new { controller = "Todo", action = "Index" },
            //    constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            //);

            routes.MapRoute(
                name: "todo-Index",
                url: "Todo",
                defaults: new { controller = "Todo", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "todo-new",
                url: "todo/new",
                defaults: new { controller = "Todo", action = "new" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "todo-create",
                url: "todo/create",
                defaults: new { controller = "Todo", action = "Create" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            routes.MapRoute(
                name: "todo-update",
                url: "todo/update/{id}",
                defaults: new { controller = "Todo", action = "Update" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            routes.MapRoute(
                name: "todo-getfile",
                url: "todo/file/{name}",
                defaults: new { controller = "Todo", action = "GetFile" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "todo-json",
                url: "todo/json",
                defaults: new { controller = "Todo", action = "GetJson" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", Id=UrlParameter.Optional },
                namespaces: new string[] { "TodoList.Controllers" }
            );
        }
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            IUnityContainer container = RegisterUnity();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            BundleTable.Bundles.RegisterTemplateBundles();

            DisplayModeProvider.Instance.Modes.Insert(0,
                // ctor param indicates suffix
                // will locate views/partials like "Index.iPhone.cshtml"
                // and layout templates like "_Layout.iPhone.cshtml"
                new DefaultDisplayMode("iPhone")
                {
                    ContextCondition = ctx =>
                    {
                        // bool return value if request should trigger
                        // this display mode
                        return ctx.Request.UserAgent.Contains("iPhone");
                    }
                });
            

        }

        private IUnityContainer RegisterUnity()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUsersRepository, UsersRepository>();
            return container;
        }
    }
}