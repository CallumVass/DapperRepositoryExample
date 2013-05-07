using DomainModel;
using DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
    }
}
