using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public interface ILstTowerTypeRepository
    {
        LstTowerType GetTowerType(int id);
        IQueryable<LstTowerType> GetTowerTypes();
        LstTowerType Add(LstTowerType type);
        LstTowerType Update(LstTowerType typeChanges);
        LstTowerType Delete(int Id);
    }
}
