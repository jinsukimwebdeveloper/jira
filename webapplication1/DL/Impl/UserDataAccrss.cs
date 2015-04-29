using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Jira.DL.Impl
{
    public class UserDataAccess : IUserDataAccess
    {
        private const int dbTimeout = 600;

        public IEnumerable<UserResult> GetUserList()
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<UserResult> result = new List<UserResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetUserList]"))
            {
                cmd.CommandTimeout = dbTimeout;
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserResult item = new UserResult();
                    item.Id = (int)ds.Tables[0].Rows[i][0];
                    item.Name = DBNull.Value.Equals(ds.Tables[0].Rows[i][1]) ? "" : (string)ds.Tables[0].Rows[i]["Name"];
                    item.Email = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Email"]) ? "" : (string)ds.Tables[0].Rows[i]["Email"];
                    item.Mobile = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Mobile"]) ? "" : (string)ds.Tables[0].Rows[i]["Mobile"];
                    item.Org = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Org"]) ? "" : (string)ds.Tables[0].Rows[i]["Org"];
                    item.ImageUrl = DBNull.Value.Equals(ds.Tables[0].Rows[i]["ImageUrl"]) ? "" : (string)ds.Tables[0].Rows[i]["ImageUrl"];
                    result.Add(item);
                }
            }

            return result;
        }
    }
}