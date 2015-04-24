using Jira.BL.Interface;
using Jira.DL.Impl;
using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.BL.Impl
{
    public class SprintHandler : ISprintHandler
    {
        private readonly ISprintDataAccess _sprintDataAccess;

        public SprintHandler(ISprintDataAccess sprintDataAccess)
        {
            _sprintDataAccess = sprintDataAccess;
        }

        public IEnumerable<SprintTableModel> GetSprintTableModel(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            List<SprintTableModel> result = new List<SprintTableModel>();
            IEnumerable<SprintResult> sprintListResult = _sprintDataAccess.GetSprintList(startTime, endTime, pageNumber, pageRows);
            SprintTableModel.TotalRows = SprintResult.TotalCount;
            foreach (SprintResult item in sprintListResult)
            {
                SprintTableModel model = new SprintTableModel();
                model.Id = item.Id;
                model.Subject = item.Subject;
                model.Status = item.Status;
                model.Description = item.Description;
                model.Reporter = item.Reporter;
                model.StartTime = item.StartTime.ToShortDateString();
                model.EndTime = item.EndTime.ToShortDateString();
                model.Project = item.Project;
                result.Add(model);
            }
            return result;
        }
    }
}