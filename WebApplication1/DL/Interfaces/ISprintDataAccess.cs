using Jira.DL.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jira.DL.Impl
{
    public interface ISprintDataAccess
    {
        IEnumerable<SprintResult> GetSprintList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows);
    }
}
