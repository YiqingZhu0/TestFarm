using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public class DbLstLocationsRepository : ILstLocationsRepository
    {
        private readonly VerticalFarmingContext context;

        public DbLstLocationsRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }

        public LstLocations Add(LstLocations location)
        {
            context.LstLocations.Add(location);
            context.SaveChanges();
            return location;
        }

        public LstLocations Delete(int Id)
        {
            LstLocations location = context.LstLocations.Find(Id);
            if (location != null)
            {
                context.Remove(location);
                context.SaveChanges();
            }
            return location;
        }

        public LstLocations GetLocation(int Id)
        {
            return context.LstLocations.FirstOrDefault(t => t.LocationId == Id);
        }

        public IQueryable<LstLocations> GetLocations()
        {
            return context.LstLocations;
        }

        public LstLocations Update(LstLocations locationChanges)
        {
            var location = context.LstLocations.Attach(locationChanges);
            location.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return locationChanges;
        }
    }
}
