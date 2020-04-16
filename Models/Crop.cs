using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class Crop
    {
        public Crop()
        {
            CropStatus = new HashSet<CropStatus>();
        }

        public int CropId { get; set; }
        public int PortId { get; set; }
        public int PlantId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ActualYieldOz { get; set; }

        public virtual Plant Plant { get; set; }
        public virtual Port Port { get; set; }
        public virtual ICollection<CropStatus> CropStatus { get; set; }
    }
}
