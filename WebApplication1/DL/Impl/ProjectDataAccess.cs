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

namespace Jira.DL.Impl
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        private const int dbTimeout = 600;

        public IEnumerable<ProjectResult> GetSProjectList(DateTime startTime, DateTime endTime, int pageNumber, int pageRows)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<ProjectResult> result = new List<ProjectResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetProjectList]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime2, startTime);
                db.AddInParameter(cmd, "@EndDate", DbType.DateTime2, endTime);
                db.AddInParameter(cmd, "@PageNumber", DbType.Int32, pageNumber);
                db.AddInParameter(cmd, "@PageRows", DbType.Int32, pageRows);
                DataSet ds = db.ExecuteDataSet(cmd);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ProjectResult item = new ProjectResult();
                    item.SeqNo = (int)ds.Tables[0].Rows[i]["SeqNo"];
                    item.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    item.Subject = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Subject"]) ? "" : (string)ds.Tables[0].Rows[i]["Subject"];
                    item.Status = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Status"]) ? "" : (string)ds.Tables[0].Rows[i]["Status"];
                    item.StartTime = DBNull.Value.Equals(ds.Tables[0].Rows[i]["StartTime"]) ? DateTime.MinValue : (DateTime)ds.Tables[0].Rows[i]["StartTime"];
                    item.EndTime = DBNull.Value.Equals(ds.Tables[0].Rows[i]["EndTime"]) ? DateTime.MinValue : (DateTime)ds.Tables[0].Rows[i]["EndTime"];
                    result.Add(item);
                }
                ProjectResult.TotalCount = (int)ds.Tables[1].Rows[0]["TotalCount"];
            }

            return result;
        }

        public int CreateProject(CreateProjectResult createProjectResult)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[CreateProject]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Subject", DbType.String, createProjectResult.Subject);
                db.AddInParameter(cmd, "@Description", DbType.String, createProjectResult.Description);
                db.AddInParameter(cmd, "@StartTime", DbType.DateTime2, createProjectResult.StartTime);
                db.AddInParameter(cmd, "@EndTime", DbType.DateTime2, createProjectResult.EndTime);
                db.AddOutParameter(cmd, "@Result", DbType.Int32, 4);
                DataSet ds = db.ExecuteDataSet(cmd);

                return (int)db.GetParameterValue(cmd, "@Result");
            }
        }
    }
}