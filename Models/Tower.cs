using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class Tower
    {
        public Tower()
        {
            Port = new HashSet<Port>();
        }

        public int TowerId { get; set; }
        public string Name { get; set; }
        public int TowerType { get; set; }
        public int Location { get; set; }

        public virtual LstLocations LocationNavigation { get; set; }
        public virtual LstTowerType TowerTypeNavigation { get; set; }
        public virtual ICollection<Port> Port { get; set; }
    }
}
