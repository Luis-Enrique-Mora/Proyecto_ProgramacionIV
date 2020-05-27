using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
