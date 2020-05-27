using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class MoneyAccounts
    {
        public MoneyAccounts()
        {
            Invoices = new HashSet<Invoices>();
            MoneyAccountsHistory = new HashSet<MoneyAccountsHistory>();
            PaidIn = new HashSet<PaidIn>();
        }

        public int MoneyAccountId { get; set; }
        public string NameMoneyAccount { get; set; }
        public string DescriptionMoneyAccount { get; set; }
        public decimal? GlobalAmount { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<MoneyAccountsHistory> MoneyAccountsHistory { get; set; }
        public virtual ICollection<PaidIn> PaidIn { get; set; }
    }
}
