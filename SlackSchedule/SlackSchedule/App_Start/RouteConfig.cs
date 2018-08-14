using HPBFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SlackSchedule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteExtention route = new RouteExtention("{lang}/{controller}/{action}/{id}", new MvcRouteHandler());

            object defaults = new
            {
                lang = "vi",
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            };
            
            route.Defaults = new RouteValueDictionary(defaults);

            routes.Add("Default", route);
        }
    }
}