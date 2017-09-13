using System.Web.Mvc;
using System.Web.Routing;

namespace TodoWeb.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(this RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapHubs();

            routes.MapRoute(
                name: "Create",
                url: "{controller}/create",
                defaults: new { controller = "Todo", action = "create" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
            );

            routes.MapRoute(
                name: "InvalidCreate",
                url: "{controller}/create",
                defaults: new { controller = "Error", action = "NotFound" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Todo", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}