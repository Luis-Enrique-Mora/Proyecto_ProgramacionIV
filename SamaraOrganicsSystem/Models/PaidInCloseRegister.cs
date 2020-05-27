using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class PaidInCloseRegister
    {
        public int PaidInCloseRegisterId { get; set; }
        public int CloseRegisterFk { get; set; }
        public int PaidInFk { get; set; }

        public virtual CloseRegister CloseRegisterFkNavigation { get; set; }
        public virtual PaidIn PaidInFkNavigation { get; set; }
    }
}
