using Jira.BL.Impl;
using Jira.DL;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult RequestLogin(LoginInput login)
        {
            LoginHandler loginHandler = new LoginHandler(new LoginDataAccess());
            LoginResult result = loginHandler.RequestLogin(login);
            return Json(result);
        }

        public ActionResult IssuesList()
        {
            return View();
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