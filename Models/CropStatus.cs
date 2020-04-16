using System;
using System.Collections.Generic;

namespace TestFarm.Models
{
    public partial class CropStatus
    {
        public int CropStatusId { get; set; }
        public int CropId { get; set; }
        public int Status { get; set; }
        public int StatusDate { get; set; }

        public virtual Crop Crop { get; set; }
        public virtual LstCropStatus StatusNavigation { get; set; }
    }
}
