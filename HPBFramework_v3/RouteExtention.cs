using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace HPBFramework
{
    public class RouteExtention : Route
    {
        public RouteExtention(string url, IRouteHandler routeHandler) : base(url, routeHandler)
        {
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            //Custom GetVirtualPath
            //Code here

            return base.GetVirtualPath(requestContext, values);
        }
    }
}