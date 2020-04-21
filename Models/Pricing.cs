using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public partial class Pricing
    {
        public int PricingId { get; set; }
        public int PlantId { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal PricePerItem { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Plant Plant { get; set; }
    }
}
