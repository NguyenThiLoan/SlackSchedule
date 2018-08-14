using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPBFramework.Logger;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Controllers
{
    public class ProjectController : ControllerExtention
    {
        private readonly IProjectService _projectService;
        public ProjectController(ILoggingService loggingService, ICommonService commonService, IProjectService projectService) 
            : base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
            _projectService = projectService;
        }

        // GET: Project
        public ActionResult Index()
        {
            ViewData["message"] = getTempMessage();

            var projects = _projectService.GetProjectIndexDto();

            return View(projects);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}