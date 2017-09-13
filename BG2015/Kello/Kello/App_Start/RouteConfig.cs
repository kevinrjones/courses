using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kello
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "NewList",
                url: "board/list/new",
                defaults: new {controller = "Board", action = "CreateList"}
                );

            routes.MapRoute(
                name: "ShowList",
                url: "Board/Index/{id}",
                defaults: new { controller = "Board", action = "Show" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Boards", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
