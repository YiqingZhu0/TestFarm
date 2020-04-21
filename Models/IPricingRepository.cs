using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    interface IPricingRepository
    {
        Pricing GetPrice(int Id);
        IQueryable<Pricing> GetAllPrices();
        Pricing Add(Pricing price);
        Pricing Update(Pricing priceChanges);
        Pricing Delete(int Id);
    }
}
