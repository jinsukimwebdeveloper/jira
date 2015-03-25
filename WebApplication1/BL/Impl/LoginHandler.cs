using Jira.BL.Interface;
using Jira.DL;
using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.BL.Impl
{
    public class LoginHandler : ILoginHandler 
    {
        private readonly ILoginDataAccess _loginDataAccess;

        public LoginHandler(ILoginDataAccess loginDataAccess)
        {
            _loginDataAccess = loginDataAccess;
        }

        public LoginResult RequestLogin(LoginModel login)
        {
            return _loginDataAccess.RequestLogin(login);
        }
    }
}