using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class PaidIn
    {
        public PaidIn()
        {
            PaidInCloseRegister = new HashSet<PaidInCloseRegister>();
        }

        public int PaidInId { get; set; }
        public DateTime PaidInDate { get; set; }
        public string PaidInDescription { get; set; }
        public decimal PaidInAmount { get; set; }
        public int MoneyAccountFk { get; set; }

        public virtual MoneyAccounts MoneyAccountFkNavigation { get; set; }
        public virtual ICollection<PaidInCloseRegister> PaidInCloseRegister { get; set; }
    }
}
