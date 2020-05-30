using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class CloseRegister
    {
        public CloseRegister()
        {
            CloseRegisterInvoices = new HashSet<CloseRegisterInvoices>();
            PaidInCloseRegister = new HashSet<PaidInCloseRegister>();
        }

        public int CloseRegisterId { get; set; }
        public DateTime CloseRegisterDate { get; set; }
        public int ScheduleFk { get; set; }
        public int UserFk { get; set; }
        public decimal SystemAmount { get; set; }
        public decimal AmountCounted { get; set; }
        public decimal? CashDiffrence { get; set; }
        public decimal? CreditCardSystem { get; set; }
        public decimal? CreditCardMachine { get; set; }
        public decimal? CcDiference { get; set; }
        public decimal? PaidoutAmount { get; set; }
        public decimal? PaidinAmount { get; set; }

        public virtual Schedule ScheduleFkNavigation { get; set; }
        public virtual Employee UserFkNavigation { get; set; }
        public virtual ICollection<CloseRegisterInvoices> CloseRegisterInvoices { get; set; }
        public virtual ICollection<PaidInCloseRegister> PaidInCloseRegister { get; set; }
    }
}
