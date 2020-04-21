using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class Plant
    {
        public Plant()
        {
            Crop = new HashSet<Crop>();
            Pricing = new HashSet<Pricing>();
        }

        public int PlantId { get; set; }
        public string Name { get; set; }
        public string Abbrev { get; set; }
        public int Size { get; set; }
        public int Category { get; set; }
        public int SoilDays { get; set; }
        public int AeroponicDays { get; set; }
        public int AverageHarvestNumber { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public int AmountOnHand { get; set; }

        public virtual LstPlantType CategoryNavigation { get; set; }
        public virtual LstPlantSize SizeNavigation { get; set; }
        public virtual ICollection<Crop> Crop { get; set; }
        public virtual ICollection<Pricing> Pricing { get; set; }
    }
}
