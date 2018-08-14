using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPBFramework.Logger;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Controllers
{
    public class ManagementController : ControllerExtention
    {
        public ManagementController(ILoggingService loggingService, ICommonService commonService) : base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
        }

        // GET: Office
        public ActionResult OfficeInfo()
        {
            return View();
        }

        // GET: Office
        public ActionResult OffDate()
        {
            return View();
        }
    }
}