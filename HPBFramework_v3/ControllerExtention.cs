using HPBFramework.Logger;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HPBFramework
{
    [ValidateInput(false)]
    public class ControllerExtention : Controller
    {
        public ILoggingService _loggingService;

        public ControllerExtention(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        protected override void Initialize(RequestContext filterContext)
        {
            _loggingService.Info("Initialize");
            
            base.Initialize(filterContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

    }
}
