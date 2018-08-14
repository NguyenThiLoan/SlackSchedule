using System.Web.Mvc;
using HPBFramework.Logger;
using SlackSchedule.Services.IServices;

namespace SlackSchedule.Controllers
{
    [AllowAnonymous]
    public class ErrorController : ControllerExtention
    {
        public ErrorController(ILoggingService loggingService, ICommonService commonService) : 
            base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
        }

        //
        // GET: /*/Error
        public ActionResult Index(string RequestUrl)
        {
            ViewBag.RequestUrl = RequestUrl;

            return View("Error");
        }

        //
        // GET: /*/NotFound
        public ActionResult NotFound(string RequestUrl)
        {
            return View();
        }

        //
        // GET: /*/AccessDenied
        public ActionResult AccessDenied(string RequestUrl)
        {
            return View();
        }
    }
}
