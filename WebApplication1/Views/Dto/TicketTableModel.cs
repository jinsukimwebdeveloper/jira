using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.Views.Dto
{
    public class TicketTableModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string FixVersion { get; set; }
        public string Assignee { get; set; }
        public string Estimate { get; set; }
        public string Description { get; set; }
        public string CompletedTimeStamp { get; set; }
        public string Reporter { get; set; }
        public string CreatedTimeStamp { get; set; }
        public static int TotalRows { get; set; }
    }
}