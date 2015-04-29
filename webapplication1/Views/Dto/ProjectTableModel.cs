using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.Views.Dto
{
    public class ProjectTableModel
    {
        public int SeqNo { get; set; }
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public static int TotalRows { get; set; }
    }
}