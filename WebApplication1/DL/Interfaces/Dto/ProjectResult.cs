using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces.Dto
{
    public class ProjectResult
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string SourceRespository { get; set; }
        public string ReleasedVersion { get; set; }
        public string RecentSprint { get; set; }
        public string LastUpdatedBy { get; set; }
        public string[] Members { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}