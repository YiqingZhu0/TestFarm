using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class LstCropStatus
    {
        public LstCropStatus()
        {
            CropStatus = new HashSet<CropStatus>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string StatusAbbrev { get; set; }

        public virtual ICollection<CropStatus> CropStatus { get; set; }
    }
}
