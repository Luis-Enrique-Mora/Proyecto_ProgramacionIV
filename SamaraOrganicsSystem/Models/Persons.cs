using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Phones = new HashSet<Phones>();
            Users = new HashSet<Users>();
            Vendors = new HashSet<Vendors>();
        }

        public int IdPerson { get; set; }
        public string PersonName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Phones> Phones { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<Vendors> Vendors { get; set; }
    }
}
