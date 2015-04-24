using Jira.DL.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces
{
    public interface IProjectDataAccess
    {
        IEnumerable<ProjectResult> GetSProjectList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows);
    }
}