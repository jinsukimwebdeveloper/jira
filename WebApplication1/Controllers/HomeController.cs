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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestLogin(LoginModel login)
        {
            LoginHandler loginHandler = new LoginHandler(new LoginDataAccess());
            LoginResult result = loginHandler.RequestLogin(login);
            return Json(result);
        }

        public ActionResult IssuesList()
        {
            IissueHandler handler = new IssueHandler(new IssueDataAccess());

            // Retrieve the issue list for the past 6 months only
            DateTime to = DateTime.Now.AddDays(1);
            DateTime from = DateTime.Now.AddMonths(-6);
            IEnumerable<IssueListTableModel> model = handler.GetIssueListMoel(from, to, 1, 10);
            CreateIssueModel createIssueModel = new CreateIssueModel();

            // Priority dropdown list
            List<SelectListItem> priorityList = new List<SelectListItem>();
            IEnumerable<PriorityResult> priorityResult = handler.GetPriority();
            foreach (PriorityResult priority in priorityResult)
            {
                priorityList.Add(new SelectListItem { Text = priority.Name, Value = priority.Id.ToString() });
            }
            createIssueModel.PriorityList = priorityList;

            // Owner dropdown list
            List<SelectListItem> ownerList = new List<SelectListItem>();
            IEnumerable<UserResult> userResult = handler.GetUsers();
            foreach (UserResult user in userResult)
            {
                ownerList.Add(new SelectListItem { Text = user.Name, Value = user.Id.ToString() });
            }
            createIssueModel.OwnerList = ownerList;

            // Component list
            List<SelectListItem> componentList = new List<SelectListItem>();
            IEnumerable<ComponentResult> componentResult = handler.GetComponent();
            foreach (ComponentResult component in componentResult)
            {
                componentList.Add(new SelectListItem { Text = component.Name, Value = component.Id.ToString() });
            }
            createIssueModel.ComponentList = componentList;

            // Estimate list
            List<SelectListItem> estimateList = new List<SelectListItem>();
            for(int i = 1; i < 5; i++)
            {
                estimateList.Add(new SelectListItem { Text = i + "MD", Value = i.ToString() });
            }
            createIssueModel.EstimateList = estimateList;

            ViewData["CreateIssueModel"] = createIssueModel;
            return View(model);
        }

        [HttpGet]
        public ActionResult GetIssueList(int pageNumber, int pageRows)
        {
            IissueHandler handler = new IssueHandler(new IssueDataAccess());
            IEnumerable<IssueListTableModel> model = handler.GetIssueListMoel(DateTime.Parse("2015-01-01"), DateTime.Parse("2015-12-31"), pageNumber, pageRows);
            return PartialView("_IssueListTable", model);
        }

        [HttpPost]
        public int CreateIssue(CreateIssueModel model)
        {
            IissueHandler handler = new IssueHandler(new IssueDataAccess());
            return handler.CreateIssue(model);
        }
    }
}