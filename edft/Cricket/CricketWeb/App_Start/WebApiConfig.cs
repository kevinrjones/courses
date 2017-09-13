using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
//using CricketWeb.Models;
using CricketEF;

namespace CricketWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // OData
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Player>("Players");
            builder.EntitySet<BattingDetail>("BattingDetails");
            builder.EntitySet<BowlingDetail>("BowlingDetails");
            builder.EntitySet<Country>("Countrys");
            builder.EntitySet<Match>("Matches").EntityType.HasKey(m => m.MatchNumber);
            config.AddODataQueryFilter();
            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}

