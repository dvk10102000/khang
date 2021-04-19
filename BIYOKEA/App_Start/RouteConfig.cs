using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BIYOKEA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
                name: "shop",
                url: "{controller}/{action}/{param1}/{param2}",
                defaults: new { param2 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}"
            );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{id}",
               defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
