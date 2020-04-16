using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.Models
{
    public interface ITowerRepository
    {
        Tower GetTower(int Id);
        IEnumerable<Tower> GetTowers();
        Tower Add(Tower tower);
        Tower Update(Tower towerChanges);
        Tower Delete(int id);
    }
}
