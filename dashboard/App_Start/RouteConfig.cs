using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace dashboard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login/",
                defaults: new { Controller = "Login", action = "Index" }
            );

            routes.MapRoute(
                name: "Tes",
                url: "Login/Tes/",
                defaults: new { Controller = "Login", action = "Tes" }
            );

            routes.MapRoute(
                name: "Validasi",
                url: "Login/Validasi/",
                defaults: new { Controller = "Login", action = "Validasi" }
            );

            routes.MapRoute(
                name: "Dashboard",
                url: "Dashboard/{action}/",
                defaults: new { Controller = "Dashboard", action = "Index" }
            );

            routes.MapRoute(
                name: "Simper",
                url: "Simper/{action}/",
                defaults: new { Controller = "Simper", action = "Index" }
            );
        }
    }
}
