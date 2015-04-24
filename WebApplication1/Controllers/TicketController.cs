using Jira.BL.Impl;
using Jira.BL.Interface;
using Jira.DL;
using Jira.DL.Impl;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Jira.Controllers
{
    public class TicketController : Controller
    {

        public ActionResult Index()
        {
            TicketHandler handler = new TicketHandler(new TicketDataAccess());

            // Retrieve the tickets list for the past 6 months only
            DateTime to = DateTime.Now.AddDays(1);
            DateTime from = DateTime.Now.AddMonths(-6);
            IEnumerable<TicketTableModel> model = handler.GetTicketTableModel(from, to, 1, 10);
            CreateTicketModel createTicketModel = new CreateTicketModel();

            // Priority dropdown list
            List<SelectListItem> priorityList = new List<SelectListItem>();
            IEnumerable<PriorityResult> priorityResult = handler.GetPriority();
            foreach (PriorityResult priority in priorityResult)
            {
                priorityList.Add(new SelectListItem { Text = priority.Name, Value = priority.Id.ToString() });
            }
            createTicketModel.PriorityList = priorityList;

            // Owner dropdown list
            List<SelectListItem> ownerList = new List<SelectListItem>();
            IEnumerable<UserResult> userResult = handler.GetUsers();
            foreach (UserResult user in userResult)
            {
                ownerList.Add(new SelectListItem { Text = user.Name, Value = user.Id.ToString() });
            }
            createTicketModel.OwnerList = ownerList;

            // Component list
            List<SelectListItem> componentList = new List<SelectListItem>();
            IEnumerable<ComponentResult> componentResult = handler.GetComponent();
            foreach (ComponentResult component in componentResult)
            {
                componentList.Add(new SelectListItem { Text = component.Name, Value = component.Id.ToString() });
            }
            createTicketModel.ComponentList = componentList;

            // Estimate list
            List<SelectListItem> estimateList = new List<SelectListItem>();
            for(int i = 1; i <= 5; i++)
            {
                estimateList.Add(new SelectListItem { Text = i + "MD", Value = i.ToString() });
            }
            createTicketModel.EstimateList = estimateList;

            ViewData["CreateTicketModel"] = createTicketModel;
            return View(model);
        }

        [HttpGet]
        public ActionResult GetTicketList(int pageNumber, int pageRows)
        {
            TicketHandler handler = new TicketHandler(new TicketDataAccess());
            IEnumerable<TicketTableModel> model = handler.GetTicketTableModel(DateTime.Parse("2015-01-01"), DateTime.Parse("2015-12-31"), pageNumber, pageRows);
            return PartialView("_IssueListTable", model);
        }

        [HttpPost]
        public int CreateIssue(CreateTicketModel model)
        {
            TicketHandler handler = new TicketHandler(new TicketDataAccess());
            return handler.CreateIssue(model);
        }

        public ActionResult Detail(int id)
        {
            // Find the issue detail
            TicketHandler handler = new TicketHandler(new TicketDataAccess());
            TicketTableModel model = handler.FindIssues(id);

            return View(model);
        }
    }
}