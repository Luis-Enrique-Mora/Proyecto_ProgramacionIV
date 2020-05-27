using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class InvoiceCategory
    {
        public InvoiceCategory()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int InvoiceCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
