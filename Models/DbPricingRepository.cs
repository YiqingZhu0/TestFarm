using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestFarm.Models
{
    public class DbPricingRepository : IPricingRepository
    {
        private readonly VerticalFarmingContext context;

        public DbPricingRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }

        public Pricing Add(Pricing price)
        {
            context.Pricings.Add(price);
            context.SaveChanges();
            return price;
        }

        public Pricing Delete(int Id)
        {
            Pricing price = context.Pricings.Find(Id);
            if (price != null)
            {
                context.Remove(price);
                context.SaveChanges();
            }
            return price;
        }

        public IQueryable<Pricing> GetAllPrices()
        {
            return context.Pricings
                .Include(p => p.Plant);
        }

        public Pricing GetPrice(int Id)
        {
            return context.Pricings
                .Include(p => p.Plant).FirstOrDefault(p => p.PricingId == Id);
        }

        public Pricing Update(Pricing priceChanges)
        {
            var price = context.Pricings.Attach(priceChanges);
            price.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return priceChanges;
        }
    }
}
