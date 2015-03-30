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
            IEnumerable<IssueListModel> model = handler.GetIssueListMoel(DateTime.Parse("2015-01-01"), DateTime.Parse("2015-12-31"), 1, 10);
            return View(model);
        }

        [HttpGet]
        public ActionResult GetIssueList(int pageNumber, int pageRows)
        {
            IissueHandler handler = new IssueHandler(new IssueDataAccess());
            IEnumerable<IssueListModel> model = handler.GetIssueListMoel(DateTime.Parse("2015-01-01"), DateTime.Parse("2015-12-31"), pageNumber, pageRows);
            return PartialView("_IssueListTable", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}