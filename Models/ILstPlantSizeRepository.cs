using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public interface ILstPlantSizeRepository
    {
        LstPlantSize GetPlantSize(int id);
        IQueryable<LstPlantSize> GetPlantSizes();
        LstPlantSize Add(LstPlantSize size);
        LstPlantSize Update(LstPlantSize sizeChanges);
        LstPlantSize Delete(int Id);
    }
}
