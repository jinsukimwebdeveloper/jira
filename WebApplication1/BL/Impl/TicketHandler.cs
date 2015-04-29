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
    public class TicketHandler : ITicketHandler
    {
        private readonly ITicketDataAccess _issueDataAccess;

        public TicketHandler(ITicketDataAccess issueDataAccess)
        {
            _issueDataAccess = issueDataAccess;
        }

        public IEnumerable<TicketTableModel> GetTicketTableModel(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            List<TicketTableModel> result = new List<TicketTableModel>();
            IEnumerable<TicketResult> issueListResult = _issueDataAccess.GetTicketList(startTime, endTime, pageNumber, pageRows);
            TicketTableModel.TotalRows = TicketResult.TotalCount;
            foreach (TicketResult item in issueListResult)
            {
                TicketTableModel model = new TicketTableModel();
                model.Id = item.Id;
                model.Subject = item.Subject;
                model.Status = item.Status;
                model.Priority = item.Priority;
                model.FixVersion = item.FixVersion;
                model.Assignee = item.Assignee;
                model.Estimate = item.Estimate;
                model.CompletedTimeStamp = (item.CompletedTimeStamp.Year == 1900) ? "open" : item.CompletedTimeStamp.ToShortDateString();
                model.Reporter = item.Repoter;
                model.CreatedTimeStamp = item.CreatedTimeStamp.ToShortDateString();
                result.Add(model);
            }
            return result;
        }

        public int CreateIssue(CreateTicketModel model)
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

        public TicketTableModel FindIssues(int id)
        {
            TicketTableModel model = new TicketTableModel();
            TicketResult result = _issueDataAccess.FindIssue(id);
            model.Id = result.Id;
            model.Subject = result.Subject;
            model.Status = result.Status;
            model.Priority = result.Priority;
            model.FixVersion = result.FixVersion;
            model.Assignee = result.Assignee;
            model.Estimate = result.Estimate;
            model.Description = result.Description;
            model.CompletedTimeStamp = result.CompletedTimeStamp.ToShortDateString();
            model.Reporter = result.Repoter;
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