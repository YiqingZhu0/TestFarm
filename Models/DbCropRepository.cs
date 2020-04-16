using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.Models
{
    public class DbCropRepository : ICropRepository
    {
        private readonly VerticalFarmingContext context;

        public DbCropRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }
        public Crop Add(Crop crop)
        {
            context.Crops.Add(crop);
            context.SaveChanges();
            return crop;
        }

        public Crop Delete(int Id)
        {
            Crop crop = context.Crops.Find(Id);
            if (crop != null)
            {
                context.Remove(crop);
                context.SaveChanges();
            }
            return crop;
        }

        public Crop GetCrop(int Id)
        {
            return context.Crops.Find(Id);
        }

        public IEnumerable<Crop> GetCrops()
        {
            return context.Crops;
        }

        public Crop Update(Crop cropChanges)
        {
            var crop = context.Crops.Attach(cropChanges);
            crop.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return cropChanges;
        }
    }
}
