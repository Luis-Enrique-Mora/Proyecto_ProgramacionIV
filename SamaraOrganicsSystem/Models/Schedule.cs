using System;
using System.Collections.Generic;

namespace SamaraOrganicsSystem.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            CloseRegister = new HashSet<CloseRegister>();
        }

        public int ScheduleId { get; set; }
        public string ScheduleName { get; set; }

        public virtual ICollection<CloseRegister> CloseRegister { get; set; }
    }
}
