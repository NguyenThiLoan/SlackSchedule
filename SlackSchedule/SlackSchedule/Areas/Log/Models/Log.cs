using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlackSchedule.Areas.Log.Models
{
    public class Log
    {
        public DateTime LogTime { get; set; }
        public string LogLevel { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Url { get; set; }
        public string QueryString{ get; set; }
        public string Message { get; set; }
    }
    public sealed class LogMap : ClassMap<Log>
    {
        public LogMap()
        {
            AutoMap();
            Map(m => m.LogTime).Index(0);
            Map(m => m.LogLevel).Index(1);
            Map(m => m.Controller).Index(2);
            Map(m => m.Action).Index(3);
            Map(m => m.Url).Index(4);
            Map(m => m.QueryString).Index(5);
            Map(m => m.Message).Index(6);
        }
    }
}