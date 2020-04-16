using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class LstLocations
    {
        public LstLocations()
        {
            Tower = new HashSet<Tower>();
        }

        public int LocationId { get; set; }
        public int Aisle { get; set; }
        public int AisleSection { get; set; }

        public virtual ICollection<Tower> Tower { get; set; }
    }
}
