using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class CloseRegisterInvoices
    {
        public int CloseRegisterInvoicesId { get; set; }
        public int CloseRegisterFk { get; set; }
        public int InvoiceFk { get; set; }

        public virtual CloseRegister CloseRegisterFkNavigation { get; set; }
        public virtual Invoices InvoiceFkNavigation { get; set; }
    }
}
