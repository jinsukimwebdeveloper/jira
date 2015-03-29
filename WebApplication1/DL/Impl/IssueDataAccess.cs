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

        public IssueListResult GetIssueList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            IssueListResult result = new IssueListResult();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[[GetIssueList]]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime2, startTime);
                db.AddInParameter(cmd, "@EndDate", DbType.DateTime2, endTime);
                db.AddInParameter(cmd, "@PageNumber", DbType.Int32, pageNumber);
                db.AddInParameter(cmd, "@PageRows", DbType.Int32, pageRows);
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result.Id = (int)ds.Tables[0].Rows[i]["SeqNo"];
                    result.Subject = (string)ds.Tables[0].Rows[i]["Subject"];
                    result.Status = (string)ds.Tables[0].Rows[i]["Status"];
                    result.Priority = (string)ds.Tables[0].Rows[i]["Priority"];
                    result.FixVersion = (string)ds.Tables[0].Rows[i]["FixVersion"];
                    result.Estimate = (string)ds.Tables[0].Rows[i]["Estimate"];
                    result.CompletedTimeStamp = (DateTime)ds.Tables[0].Rows[i]["CompletedTimeStamp"];
                    result.Repoter = (string)ds.Tables[0].Rows[i]["Repoter"];
                    result.CompletedTimeStamp = (DateTime)ds.Tables[0].Rows[i]["CreatedTimeStamp"];
                }
                IssueListResult.TotalCount = (int) ds.Tables[1].Rows[0]["TotalCount"];

            }

            return result;
        }
    }
}