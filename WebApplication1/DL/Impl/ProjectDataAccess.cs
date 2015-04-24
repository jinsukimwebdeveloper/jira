using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Impl
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        public IEnumerable<ProjectResult> GetSProjectList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            return null;
        }
    }
}