﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.Views.Dto
{
    public class IssueListModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string FixVersion { get; set; }
        public string Assignee { get; set; }
        public string Estimate { get; set; }
        public DateTime CompletedTimeStamp { get; set; }
        public string Repoter { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public static int TotalRows { get; set; }
    }
}