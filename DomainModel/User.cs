using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }

        #region FK's
        public int RoleId { get; set; }
        #endregion
    }
}
