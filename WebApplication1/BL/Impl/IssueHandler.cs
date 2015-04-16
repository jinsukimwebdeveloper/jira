using Jira.BL.Interface;
using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.BL.Impl
{
    public class IssueHandler : IissueHandler
    {
        private readonly IissueDataAccess _issueDataAccess;

        public IssueHandler(IissueDataAccess issueDataAccess)
        {
            _issueDataAccess = issueDataAccess;
        }

        public IEnumerable<IssueListTableModel> GetIssueListMoel(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            List<IssueListTableModel> result = new List<IssueListTableModel>();
            IEnumerable<IssueListResult> issueListResult = _issueDataAccess.GetIssueList(startTime, endTime, pageNumber, pageRows);
            IssueListTableModel.TotalRows = IssueListResult.TotalCount;
            foreach (IssueListResult item in issueListResult)
            {
                IssueListTableModel model = new IssueListTableModel();
                model.Id = item.Id;
                model.Subject = item.Subject;
                model.Status = item.Status;
                model.Priority = item.Priority;
                model.FixVersion = item.FixVersion;
                model.Assignee = item.Assignee;
                model.Estimate = item.Estimate;
                model.CompletedTimeStamp = (item.CompletedTimeStamp.Year == 1900) ? "open" : item.CompletedTimeStamp.ToShortDateString();
                model.Repoter = item.Repoter;
                model.CreatedTimeStamp = item.CreatedTimeStamp.ToShortDateString();
                result.Add(model);
            }
            return result;
        }

        public int CreateIssue(CreateIssueModel model)
        {
            CreateIssueResult result = new CreateIssueResult();
            result.Subject = model.Subject;
            result.FixVersion = model.FixVersion;
            result.Estimate = model.Estimate;
            result.Description = model.Description;
            result.Priority = model.Priority;
            result.Owner = model.Owner;
            result.Repoter = GetLoginUser();
            result.Component = model.Component;

            return _issueDataAccess.CreateIssue(result);
        }

        public IssueListTableModel FindIssues(int id)
        {
            IssueListTableModel model = new IssueListTableModel();
            IssueListResult result = _issueDataAccess.FindIssue(id);
            model.Id = result.Id;
            model.Subject = result.Subject;
            model.Status = result.Status;
            model.Priority = result.Priority;
            model.FixVersion = result.FixVersion;
            model.Assignee = result.Assignee;
            model.Estimate = result.Estimate;
            model.Description = result.Description;
            model.CompletedTimeStamp = result.CompletedTimeStamp.ToShortDateString();
            model.Repoter = result.Repoter;
            model.CreatedTimeStamp = result.CreatedTimeStamp.ToShortDateString();

            return model;
        }

        private int GetLoginUser()
        {
            // TODO
            return 1;
        }

        public IEnumerable<UserResult> GetUsers()
        {
            return _issueDataAccess.GetUsers();
        }

        public IEnumerable<PriorityResult> GetPriority()
        {
            return _issueDataAccess.GetPriority();
        }

        public IEnumerable<ComponentResult> GetComponent()
        {
            return _issueDataAccess.GetComponent();
        }
    }
}