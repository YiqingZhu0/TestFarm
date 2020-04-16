using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Plant MyProperty { get; set; }
        public String PageTitle { get; set; }
        public Plant Plant { get; internal set; }
    }
}
