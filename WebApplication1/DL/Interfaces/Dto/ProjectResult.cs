﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces.Dto
{
    public class ProjectResult
    {
        public int SeqNo { get; set; }
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public static int TotalCount { get; set; }
    }
}