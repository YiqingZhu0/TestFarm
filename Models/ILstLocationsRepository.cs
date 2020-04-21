using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public interface ILstLocationsRepository
    {
        LstLocations GetLocation(int id);
        IQueryable<LstLocations> GetLocations();
        LstLocations Add(LstLocations location);
        LstLocations Update(LstLocations locationChanges);
        LstLocations Delete(int Id);
    }
}
