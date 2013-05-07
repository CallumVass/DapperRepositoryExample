using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        void ChangeUserRole(int userId, int roleId);
    }
}
