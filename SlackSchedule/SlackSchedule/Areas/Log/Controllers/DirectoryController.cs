
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SlackSchedule.Areas.Log.Controllers
{
    [AllowAnonymous]
    public class DirectoryController : Controller
    {
        //
        // GET: /Log/Directory/

        public ActionResult Index()
        {
            string path =  HostingEnvironment.MapPath("~/Areas/Log/Logs");
            var arrLog = Directory.GetDirectories(path).ToList();
            ViewBag.arrLog = arrLog;
            return View();
        }

        public ActionResult FileLog(string folderName)
        {
            string path =  HostingEnvironment.MapPath("~/Areas/Log/Logs/" + folderName);
            string[] filePaths = Directory.GetFiles(path);
            ViewBag.arrFileName = filePaths;
            ViewBag.FolderName = folderName;
            return View();
        }

    }
}
