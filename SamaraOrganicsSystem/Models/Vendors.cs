using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Vendors
    {
        public Vendors()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int PersonFk { get; set; }
        public string CompanyName { get; set; }

        public virtual Persons PersonFkNavigation { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
