using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class MoneyAccountsHistory
    {
        public int HistoryId { get; set; }
        public int AccountFk { get; set; }
        public string HistoryDescription { get; set; }
        public decimal IncomeOutcome { get; set; }
        public decimal? ActualAmount { get; set; }

        public virtual MoneyAccounts AccountFkNavigation { get; set; }
    }
}
