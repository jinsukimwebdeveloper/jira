using Jira.DL.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces
{
    interface IissueDataAccess
    {
        IssueListResult GetIssueList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows);
    }
}