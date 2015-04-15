using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces.Dto
{
    public class CreateIssueResult
    {
        public string Subject { get; set; }
        public string FixVersion { get; set; }
        public string Estimate { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Owner { get; set; }
        public int Repoter { get; set; }
        public int Component { get; set; }
    }
}