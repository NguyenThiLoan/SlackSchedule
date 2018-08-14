using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SlackSchedule.Models.Dto
{
    [NotMapped]
    public class ProjectIndexDto: Project
    { 
        public String CustomerName { get; set; }
        public String LeaderName { get; set; }
        public String StateName { get; set; }
        public String CoderName { get; set; }
        public String TesterName { get; set; }
    }
}