using Jira.BL.Interface;
using Jira.DL.Interfaces;
using Jira.DL.Interfaces.Dto;
using Jira.Views.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jira.BL.Impl
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public IEnumerable<UserTableModel> GetUserTableModel()
        {
            List<UserTableModel> result = new List<UserTableModel>();
            IEnumerable<UserResult> userListResult = _userDataAccess.GetUserList();
            TicketTableModel.TotalRows = TicketResult.TotalCount;
            foreach (UserResult item in userListResult)
            {
                UserTableModel model = new UserTableModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Email = item.Email;
                model.Mobile = item.Mobile;
                model.Org = item.Org;
                model.Dept = item.Dept;
                model.ImageUrl = item.ImageUrl;
                result.Add(model);
            }
            return result;
        }
    }
}