using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public class DbLstPlantSizeRepository : ILstPlantSizeRepository
    {
        private readonly VerticalFarmingContext context;

        public DbLstPlantSizeRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }

        public LstPlantSize Add(LstPlantSize size)
        {
            context.LstPlantSize.Add(size);
            context.SaveChanges();
            return size;
        }

        public LstPlantSize Delete(int Id)
        {
            LstPlantSize size = context.LstPlantSize.Find(Id);
            if (size != null)
            {
                context.Remove(size);
                context.SaveChanges();
            }
            return size;
        }

        public LstPlantSize GetPlantSize(int Id)
        {
            return context.LstPlantSize.FirstOrDefault(t => t.Id == Id);
        }

        public IQueryable<LstPlantSize> GetPlantSizes()
        {
            return context.LstPlantSize;
        }

        public LstPlantSize Update(LstPlantSize sizeChanges)
        {
            var type = context.LstPlantSize.Attach(sizeChanges);
            type.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return sizeChanges;
        }
    }
}
