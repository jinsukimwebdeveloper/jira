using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Jira.DL
{
    public class LoginDataAccess : ILoginDataAccess
    {
        private const int dbTimeout = 600;

        public LoginResult RequestLogin(LoginModel login)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            LoginResult result = new LoginResult();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[RequestLogin]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Email", DbType.String, login.Email);
                db.AddInParameter(cmd, "@Password", DbType.String, login.Password);
                DataSet ds = db.ExecuteDataSet(cmd);
                result.Result = (int)ds.Tables[0].Rows[0]["RESULT"];
                result.Description = (string)ds.Tables[0].Rows[0]["DESC"];
            }

            return result;
        }
    }
}