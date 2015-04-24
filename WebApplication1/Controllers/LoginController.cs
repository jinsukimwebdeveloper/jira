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
    public class LoginController : Controller
    {
        // GET: Login
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
    }
}