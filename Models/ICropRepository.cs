using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.Models
{
    interface ICropRepository
    {
        Crop GetCrop(int Id);
        IEnumerable<Crop> GetCrops();
        Crop Add(Crop crop);
        Crop Update(Crop cropChanges);
        Crop Delete(int Id);

    }
}
