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
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            ProjectHandler handler = new ProjectHandler(new ProjectDataAccess());

            // Retrieve the project list for the past 6 months only
            DateTime to = DateTime.Now.AddDays(1);
            DateTime from = DateTime.Now.AddMonths(-6);
            IEnumerable<ProjectTableModel> model = handler.GetProjectTableModel(from, to, 1, 10);
            ViewData["CreateProjectModel"] = new CreateProjectModel();
            return View(model);
        }

        public ActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        public int CreateProject(CreateProjectModel model)
        {
            ProjectHandler handler = new ProjectHandler(new ProjectDataAccess());
            return handler.CreateProject(model);
        }

        [HttpGet]
        public ActionResult GetProjectList(int pageNumber, int pageRows)
        {
            ProjectHandler handler = new ProjectHandler(new ProjectDataAccess());
            IEnumerable<ProjectTableModel> model = handler.GetProjectTableModel(DateTime.Parse("2015-01-01"), DateTime.Parse("2015-12-31"), pageNumber, pageRows);
            return PartialView("_TableList", model);
        }
    }
}