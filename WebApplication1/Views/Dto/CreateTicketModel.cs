using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jira.Views.Dto
{
    public class CreateTicketModel
    {
        public string Subject { get; set; }
        public string FixVersion { get; set; }
        public string Estimate { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Owner { get; set; }
        public int Repoter { get; set; }
        public int Component { get; set; }

        public IEnumerable<SelectListItem> PriorityList { get; set; }
        public IEnumerable<SelectListItem> OwnerList { get; set; }
        public IEnumerable<SelectListItem> ComponentList { get; set; }
        public IEnumerable<SelectListItem> EstimateList { get; set; }
    }
}