using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var regDefault = new
            {
                controller = "Registration",
                action = "Index"
            };

            routes.MapRoute(
                name: "Registration Courses",
                url: "Registration/Courses",
                defaults: regDefault
            );

            routes.MapRoute(
                name: "Registration Instructors",
                url: "Registration/Instructors",
                defaults: regDefault
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
