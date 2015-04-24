using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.Views.Dto
{
    public class ProjectDetailModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string SourceRespository { get; set; }
        public string ReleasedVersion { get; set; }
        public string RecentSprint { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}