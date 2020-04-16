using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class Port
    {
        public Port()
        {
            Crop = new HashSet<Crop>();
        }

        public int PortId { get; set; }
        public int TowerId { get; set; }
        public int PortNumber { get; set; }
        public int PortStatus { get; set; }

        public virtual Tower Tower { get; set; }
        public virtual ICollection<Crop> Crop { get; set; }
    }
}
