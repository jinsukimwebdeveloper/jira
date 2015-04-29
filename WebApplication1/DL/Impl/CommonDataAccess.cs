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
    public class CommonDataAccess
    {
        private const int dbTimeout = 600;

        public IEnumerable<PriorityResult> GetProjectSelectionList()
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<PriorityResult> result = new List<PriorityResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetProjectSelectList]"))
            {
                cmd.CommandTimeout = dbTimeout;
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PriorityResult priority = new PriorityResult();
                    priority.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    priority.Name = (string)ds.Tables[0].Rows[i]["Name"];
                    result.Add(priority);
                }
            }
            return result;
        }

        public IEnumerable<PriorityResult> GetPriority()
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<PriorityResult> result = new List<PriorityResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetPriority]"))
            {
                cmd.CommandTimeout = dbTimeout;
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PriorityResult priority = new PriorityResult();
                    priority.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    priority.Name = (string)ds.Tables[0].Rows[i]["Name"];
                    result.Add(priority);
                }
            }
            return result;
        }
    }
}