using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaskList
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(this RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Create",
                url: "{controller}/Create/{id}",
                defaults: new { controller = "List", action = "Create", id = UrlParameter.Optional },
                constraints: new {httpMethod = new HttpMethodConstraint("POST")}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "List", action = "Index", id = UrlParameter.Optional },
                constraints: new { httpMethod = new HttpMethodConstraint("GET") }
            );
        }
    }
}