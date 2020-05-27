using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Users
    {
        public Users()
        {
            UserEmployee = new HashSet<UserEmployee>();
        }

        public int IdUser { get; set; }
        public int PersonFk { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int UserRoleFk { get; set; }

        public virtual Persons PersonFkNavigation { get; set; }
        public virtual UserRole UserRoleFkNavigation { get; set; }
        public virtual ICollection<UserEmployee> UserEmployee { get; set; }
    }
}
