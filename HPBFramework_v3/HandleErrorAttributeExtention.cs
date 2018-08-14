using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPBFramework
{
    public class HandleErrorAttributeExtention : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Logger.LoggingService.GetLoggingService().Error(filterContext.Exception);
        }
    }
}