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
                    item.Subject = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Subject"]) ? "" : (string)ds.Tables[0].Rows[i]["Subject"];
                    item.Status = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Status"]) ? "" : (string)ds.Tables[0].Rows[i]["Status"];
                    item.Priority = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Priority"]) ? "" : (string)ds.Tables[0].Rows[i]["Priority"];
                    item.FixVersion = DBNull.Value.Equals(ds.Tables[0].Rows[i]["FixVersion"]) ? "" : (string)ds.Tables[0].Rows[i]["FixVersion"];
                    item.Estimate = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Estimate"]) ? "" : (string)ds.Tables[0].Rows[i]["Estimate"];
                    item.Assignee = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Assignee"]) ? "" : (string)ds.Tables[0].Rows[i]["Assignee"];
                    item.CompletedTimeStamp = (DateTime) ds.Tables[0].Rows[i]["CompletedTimeStamp"];
                    item.Repoter = DBNull.Value.Equals(ds.Tables[0].Rows[i]["Repoter"]) ? "" : (string)ds.Tables[0].Rows[i]["Repoter"];
                    item.CreatedTimeStamp = (DateTime)ds.Tables[0].Rows[i]["CreatedTimeStamp"];
                    result.Add(item);
                }
                IssueListResult.TotalCount = (int)ds.Tables[1].Rows[0]["TotalCount"];
            }

            return result;
        }

        public IEnumerable<UserResult> GetUsers()
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<UserResult> result = new List<UserResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetUsers]"))
            {
                cmd.CommandTimeout = dbTimeout;
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserResult user = new UserResult();
                    user.Id = (int)ds.Tables[0].Rows[i]["UserId"];
                    user.Name = (string)ds.Tables[0].Rows[i]["Name"];
                    result.Add(user);
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

        public IEnumerable<ComponentResult> GetComponent()
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            List<ComponentResult> result = new List<ComponentResult>();
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[GetComponent]"))
            {
                cmd.CommandTimeout = dbTimeout;
                DataSet ds = db.ExecuteDataSet(cmd);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ComponentResult component = new ComponentResult();
                    component.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    component.Name = (string)ds.Tables[0].Rows[i]["Name"];
                    result.Add(component);
                }
            }
            return result;
        }

        public int CreateIssue(CreateIssueResult createIssueResult)
        {
            Database db = new DatabaseProviderFactory().Create("JIRA");
            using (DbCommand cmd = db.GetStoredProcCommand("[dbo].[CreateIssue]"))
            {
                cmd.CommandTimeout = dbTimeout;
                db.AddInParameter(cmd, "@Subject", DbType.String, createIssueResult.Subject);
                db.AddInParameter(cmd, "@FixVersion", DbType.String, createIssueResult.FixVersion);
                db.AddInParameter(cmd, "@Estimate", DbType.String, createIssueResult.Estimate);
                db.AddInParameter(cmd, "@Description", DbType.String, createIssueResult.Description);
                db.AddInParameter(cmd, "@Priority", DbType.Int32, createIssueResult.Priority);
                db.AddInParameter(cmd, "@Owner", DbType.Int32, createIssueResult.Priority);
                db.AddInParameter(cmd, "@Repoter", DbType.Int32, createIssueResult.Priority);
                db.AddInParameter(cmd, "@Component", DbType.Int32, createIssueResult.Priority);
                db.AddOutParameter(cmd, "@Result", DbType.Int32, 4);
                DataSet ds = db.ExecuteDataSet(cmd);

                return (int)db.GetParameterValue(cmd, "@Result");
            }
        }
    }
}