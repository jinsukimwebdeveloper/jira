using Jira.DL.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces
{
    public interface IissueDataAccess
    {
        IEnumerable<IssueListResult> GetIssueList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows);

        IEnumerable<UserResult> GetUsers();

        IEnumerable<PriorityResult> GetPriority();

        IEnumerable<ComponentResult> GetComponent();

        int CreateIssue(CreateIssueResult createIssueResult);
    }
}