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
        private readonly IRoleRepository _roleRepo;

        public UserRepository(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public void ChangeUserRole(int userId, int roleId)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var user = GetById(userId);
                user.RoleId = roleId;
                Update(user);
            }
        }
    }
}
