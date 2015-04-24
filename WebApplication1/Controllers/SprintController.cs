using Jira.BL.Impl;
using Jira.DL.Impl;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jira.Controllers
{
    public class SprintController : Controller
    {

        // GET: Sprint
        public ActionResult Index()
        {
            SprintHandler handler = new SprintHandler(new SprintDataAccess());

            // Retrieve the sprint list for the past 6 months only
            DateTime to = DateTime.Now.AddDays(1);
            DateTime from = DateTime.Now.AddMonths(-6);
            IEnumerable<SprintTableModel> model = handler.GetSprintTableModel(from, to, 1, 10);
            CreateTicketModel createTicketModel = new CreateTicketModel();

            return View(model);
        }

    }
}