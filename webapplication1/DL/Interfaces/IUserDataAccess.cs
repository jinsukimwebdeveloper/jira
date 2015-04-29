using Jira.DL.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces
{
    public interface IUserDataAccess
    {
        IEnumerable<UserResult> GetUserList();
    }
}