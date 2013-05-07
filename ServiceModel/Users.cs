using ServiceModel.Types;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceModel
{
    [Route("/users", "GET")]
    public class GetUsers : IReturn<List<UserDTO>> { }
    [Route("/users/{Id}", "GET")]
    public class GetUser : IReturn<UserDTO>
    {
        public int Id { get; set; }
    }
    [Route("/users", "POST")]
    public class CreateUser : IReturn<int>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
    }
    [Route("/users/{Id}", "PUT")]
    public class UpdateUser : IReturnVoid
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }

    [Route("/users/{UserId}/role/{RoleId}", "PUT")]
    public class UpdateUserRole : IReturnVoid
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
