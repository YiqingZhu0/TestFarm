using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.ViewModels
{
    public class PlantIndexViewModel
    {
        public IEnumerable<Plant> Plants { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
