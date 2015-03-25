using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.DL.Interfaces
{
    public interface ILoginDataAccess
    {
        LoginResult RequestLogin(LoginModel login);
    }
}