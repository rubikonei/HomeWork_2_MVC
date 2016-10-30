using System.Web.Mvc;
using System.Web.Routing;

namespace SmartHouseMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddDevice",
                url: "Devices/Add/{deviceType}",
                defaults: new { controller = "Devices", action = "Add" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Devices", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

