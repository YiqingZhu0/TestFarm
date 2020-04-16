using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public interface IPlantRepository
    {
        Plant GetPlant(int Id);
        IEnumerable<Plant> GetPlants();
        Plant Add(Plant plant);
        Plant Update(Plant plantChanges);
        Plant Delete(int Id);
    }
}
