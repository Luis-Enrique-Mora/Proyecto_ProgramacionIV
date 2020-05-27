using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class UserEmployee
    {
        public UserEmployee()
        {
            CloseRegister = new HashSet<CloseRegister>();
            Salaries = new HashSet<Salaries>();
        }

        public int EmployeeId { get; set; }
        public int UserFk { get; set; }
        public string LastName2 { get; set; }
        public string Cedula { get; set; }
        public decimal SalaryPerHour { get; set; }

        public virtual Users UserFkNavigation { get; set; }
        public virtual ICollection<CloseRegister> CloseRegister { get; set; }
        public virtual ICollection<Salaries> Salaries { get; set; }
    }
}
