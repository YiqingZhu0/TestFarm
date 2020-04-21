using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public interface ILstPlantTypeRepository
    {
        LstPlantType GetPlantType(int id);
        IQueryable<LstPlantType> GetPlantTypes();
        LstPlantType Add(LstPlantType type);
        LstPlantType Update(LstPlantType typeChanges);
        LstPlantType Delete(int Id);
    }
}
