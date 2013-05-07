using DomainModel;
using DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;
using System.Data;

namespace DataAccess
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public void ChangeUserRole(int userId, int roleId)
        {
            var user = GetById(userId);
            user.RoleId = roleId;
            Update(user);

        }
    }
}
