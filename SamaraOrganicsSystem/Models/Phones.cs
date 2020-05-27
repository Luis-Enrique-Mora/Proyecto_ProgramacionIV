using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Phones
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonFk { get; set; }

        public virtual Persons PersonFkNavigation { get; set; }
    }
}
