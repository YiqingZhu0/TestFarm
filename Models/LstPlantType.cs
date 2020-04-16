using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class LstPlantType
    {
        public LstPlantType()
        {
            Plant = new HashSet<Plant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }

        public virtual ICollection<Plant> Plant { get; set; }
    }
}
