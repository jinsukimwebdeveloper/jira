using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.BL.Interface
{
    public interface IissueHandler
    {
        IEnumerable<IssueListTableModel> GetIssueListMoel(DateTime startTime, DateTime endTime, int pageNumber, int pageRows);

        IEnumerable<UserResult> GetUsers();

        IEnumerable<PriorityResult> GetPriority();

        IEnumerable<ComponentResult> GetComponent();

        int CreateIssue(CreateIssueModel model);
    }
}