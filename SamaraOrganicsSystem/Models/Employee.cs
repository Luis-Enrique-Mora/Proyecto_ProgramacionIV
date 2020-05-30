using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CloseRegister = new HashSet<CloseRegister>();
            Salaries = new HashSet<Salaries>();
        }

        public int EmployeeId { get; set; }
        public int PersonFk { get; set; }
        public string LastName2 { get; set; }
        public string Cedula { get; set; }
        public decimal SalaryPerHour { get; set; }

        public virtual Persons PersonFkNavigation { get; set; }
        public virtual ICollection<CloseRegister> CloseRegister { get; set; }
        public virtual ICollection<Salaries> Salaries { get; set; }
    }
}
