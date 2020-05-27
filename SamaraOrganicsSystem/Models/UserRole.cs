using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<Users>();
        }

        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
