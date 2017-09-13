using System.Web.Mvc;
using System.Web.Routing;

namespace Shoes.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(this RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Shoe-Time",
                url: "shoe/time",
                defaults: new { controller = "Shoe", action = "Time" },
                constraints: new { httpConstraint = new HttpMethodConstraint("Get") }
            );

            routes.MapRoute(
                name: "Shoe-New",
                url: "shoe/new",
                defaults: new { controller = "Shoe", action = "New" },
                constraints: new { httpConstraint = new HttpMethodConstraint("Get") }
            );

            
            routes.MapRoute(
                name: "Shoe-Create",
                url: "shoe",
                defaults: new { controller = "Shoe", action = "Create" },
                constraints: new { httpConstraint = new HttpMethodConstraint("Post") }
            );

            routes.MapRoute(
                            name: "Shoe-Get",
                            url: "shoe/{id}",
                            defaults: new { controller = "Shoe", action = "Show" },
                            constraints: new { httpConstraint = new HttpMethodConstraint("Get") }

                        );

            routes.MapRoute(
                    name: "error",
                    url: "error/show",
                    defaults: new {controller = "Error", action = "Show"}
                );

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Shoe", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}