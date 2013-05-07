using DomainModel;
using DomainModel.Contracts;
using ServiceModel;
using ServiceModel.Types;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceInterface
{
    public class UsersService : Service
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;

        public UsersService(IUserRepository userRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        public object Get(GetUser request)
        {
            var dbUser = _userRepo.GetById(request.Id);
            var dbUserRole = _roleRepo.GetById(dbUser.RoleId);
            return new UserDTO
            {
                FullName = dbUser.FullName,
                Id = dbUser.Id,
                UserName = dbUser.UserName,
                RoleId = dbUser.RoleId,
                RoleName = dbUserRole.RoleName
            };
        }

        public object Get(GetUsers request)
        {
            var dbUsers = _userRepo.GetAll();
            var dbRoles = _roleRepo.GetAll();
            var users = dbUsers.ConvertAll(user =>
            {
                var dbUserRole = dbRoles.FirstOrDefault(x => x.Id == user.RoleId);
                return new UserDTO
                {
                    FullName = user.FullName,
                    Id = user.Id,
                    UserName = user.UserName,
                    RoleId = user.RoleId,
                    RoleName = dbUserRole.RoleName
                };
            });

            return users;
        }

        public object Post(CreateUser request)
        {
            return _userRepo.Add(new User
            {
                FullName = request.FullName,
                UserName = request.UserName,
                RoleId = request.RoleId
            });
        }

        public void Put(UpdateUser request)
        {
            _userRepo.Update(new User
            {
                FullName = request.FullName,
                UserName = request.UserName,
                Id = request.Id,
                RoleId = request.RoleId
            });
        }

        public void Delete(RemoveUser request)
        {
            _userRepo.Remove(request.Id);
        }
    }
}
