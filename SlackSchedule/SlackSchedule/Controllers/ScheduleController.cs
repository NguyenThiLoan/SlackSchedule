using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPBFramework.Logger;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Controllers
{
    public class ScheduleController : ControllerExtention
    {
        public ScheduleController(ILoggingService loggingService, ICommonService commonService) : base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
        }

        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }
    }
}