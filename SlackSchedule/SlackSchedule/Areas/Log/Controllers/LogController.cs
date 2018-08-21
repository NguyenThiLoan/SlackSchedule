using CsvHelper;
using SlackSchedule.Areas.Log.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SlackSchedule.Areas.Log.Controllers
{
    [AllowAnonymous]
    public class LogController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Log/LogDetail/

        public ActionResult Detail(string FolderName, string FileName)
        {
            var path = "~/Areas/Log/Logs/" + FolderName +"/" + FileName;
            List<Models.Log> logs = new List<Models.Log>();
            using (var fileReader = new StreamReader(Server.MapPath(path), Encoding.GetEncoding(932)))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.RegisterClassMap<LogMap>();
                csv.Configuration.IgnoreBlankLines = true;
                while (csv.Read())
                {
                    logs.Add(csv.GetRecord<Models.Log>());
                }
            }
            ViewBag.Logs = logs;
            return View();
        }

    }
}
