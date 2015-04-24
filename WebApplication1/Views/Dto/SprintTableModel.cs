using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.Views.Dto
{
    public class SprintTableModel
    {
        public int Id { get; set; }
        public string Reporter { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public static int TotalRows { get; set; }
    }
}