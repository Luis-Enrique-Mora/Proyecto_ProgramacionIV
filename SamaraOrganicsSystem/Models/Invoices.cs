using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Invoices
    {
        public Invoices()
        {
            CloseRegisterInvoices = new HashSet<CloseRegisterInvoices>();
        }

        public int InvoiceId { get; set; }
        public int VendorFk { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public int InvoiceCategoryFk { get; set; }
        public string InvoiceDescription { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int StatusFk { get; set; }
        public int MoneyAccountFk { get; set; }
        public decimal? FinalPayment { get; set; }

        public virtual InvoiceCategory InvoiceCategoryFkNavigation { get; set; }
        public virtual MoneyAccounts MoneyAccountFkNavigation { get; set; }
        public virtual InvoiceStatus StatusFkNavigation { get; set; }
        public virtual Vendors VendorFkNavigation { get; set; }
        public virtual ICollection<CloseRegisterInvoices> CloseRegisterInvoices { get; set; }
    }
}
