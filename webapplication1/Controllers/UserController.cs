using Jira.BL.Impl;
using Jira.DL.Impl;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jira.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            UserHandler handler = new UserHandler(new UserDataAccess());
            IEnumerable<UserTableModel> model = handler.GetUserTableModel();

            return View(model);
        }

    }
}