using HPBFramework.Logger;
using SlackSchedule.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SlackSchedule.Controllers
{
    public class HomeController : ControllerExtention
    {
        public HomeController(ILoggingService loggingService, ICommonService commonService) : base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
