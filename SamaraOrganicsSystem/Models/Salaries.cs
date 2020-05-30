using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Salaries
    {
        public int SalaryId { get; set; }
        public int EmployeeFk { get; set; }
        public decimal? HoursWorked { get; set; }
        public decimal? InsuranceCost { get; set; }
        public decimal? SalaryAmount { get; set; }
        public int MoneyAccountFk { get; set; }

        public virtual Employee EmployeeFkNavigation { get; set; }
    }
}
