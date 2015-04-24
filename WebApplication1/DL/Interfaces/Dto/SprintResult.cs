using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces.Dto
{
    public class SprintResult
    {
        public int Id { get; set; }
        public string Reporter { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public static int TotalCount { get; set; }
    }
}