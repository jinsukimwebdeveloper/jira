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
    public class IssueDataAccess : IissueDataAccess
    {
        private const int dbTimeout = 600;

        public IEnumerable<IssueListResult> GetIssueList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<IssueListResult> result = new List<IssueListResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetIssueList]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime2, startTime);
                db.AddInParameter(cmd, "@EndDate", DbType.DateTime2, endTime);
                db.AddInParameter(cmd, "@PageNumber", DbType.Int32, pageNumber);
                db.AddInParameter(cmd, "@PageRows", DbType.Int32, pageRows);
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    IssueListResult item = new IssueListResult();
                    item.Id = (int)ds.Tables[0].Rows[i]["SeqNo"];
                    item.Subject = (string)ds.Tables[0].Rows[i]["Subject"];
                    item.Status = (string)ds.Tables[0].Rows[i]["Status"];
                    item.Priority = (string)ds.Tables[0].Rows[i]["Priority"];
                    item.FixVersion = (string)ds.Tables[0].Rows[i]["FixVersion"];
                    item.Estimate = (string)ds.Tables[0].Rows[i]["Estimate"];
                    item.Assignee = (string)ds.Tables[0].Rows[i]["Assignee"];
                    item.CompletedTimeStamp = (DateTime)ds.Tables[0].Rows[i]["CompletedTimeStamp"];
                    item.Repoter = (string)ds.Tables[0].Rows[i]["Repoter"];
                    item.CompletedTimeStamp = (DateTime)ds.Tables[0].Rows[i]["CreatedTimeStamp"];
                    result.Add(item);
                }
                IssueListResult.TotalCount = (int) ds.Tables[1].Rows[0]["TotalCount"];
            }

            return result;
        }
    }
}