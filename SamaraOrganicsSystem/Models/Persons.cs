using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SamaraOrganicsSystem.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Employee = new HashSet<Employee>();
            Phones = new HashSet<Phones>();
            Users = new HashSet<Users>();
            Vendors = new HashSet<Vendors>();
        }

        public int IdPerson { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Phones> Phones { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<Vendors> Vendors { get; set; }
    }
}
