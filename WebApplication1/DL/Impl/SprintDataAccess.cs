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
    public class SprintDataAccess : ISprintDataAccess
    {
        private const int dbTimeout = 600;

        public IEnumerable<SprintResult> GetSprintList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<SprintResult> result = new List<SprintResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetSprintList]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime2, startTime);
                db.AddInParameter(cmd, "@EndDate", DbType.DateTime2, endTime);
                db.AddInParameter(cmd, "@PageNumber", DbType.Int32, pageNumber);
                db.AddInParameter(cmd, "@PageRows", DbType.Int32, pageRows);
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SprintResult item = new SprintResult();
                    item.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    item.Subject = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Subject"]) ? "" : (string)ds.Tables[0].Rows[i]["Subject"];
                    item.Status = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Status"]) ? "" : (string)ds.Tables[0].Rows[i]["Status"];
                    item.Description = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Description"]) ? "" : (string)ds.Tables[0].Rows[i]["Description"];
                    item.Reporter = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Reporter"]) ? "" : (string)ds.Tables[0].Rows[i]["Reporter"];
                    item.Project = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Project"]) ? "" : (string)ds.Tables[0].Rows[i]["Project"];
                    item.StartTime = DBNull.Value.Equals(ds.Tables[0].Rows[i]["StartTime"]) ? DateTime.MinValue : (DateTime)ds.Tables[0].Rows[i]["StartTime"];
                    item.EndTime = DBNull.Value.Equals(ds.Tables[0].Rows[i]["EndTime"]) ? DateTime.MinValue : (DateTime)ds.Tables[0].Rows[i]["EndTime"];
                    result.Add(item);
                }
                SprintResult.TotalCount = (int)ds.Tables[1].Rows[0]["TotalCount"];
            }

            return result;
        }
    }
}