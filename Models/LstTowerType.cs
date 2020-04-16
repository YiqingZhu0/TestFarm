using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class LstTowerType
    {
        public LstTowerType()
        {
            Tower = new HashSet<Tower>();
        }

        public int TowerTypeId { get; set; }
        public string TowerName { get; set; }
        public string TowerDesc { get; set; }
        public int Size { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Tower> Tower { get; set; }
    }
}
