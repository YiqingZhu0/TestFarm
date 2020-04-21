using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public class DbLstPlantTypeRepository : ILstPlantTypeRepository
    {
        private readonly VerticalFarmingContext context;

        public DbLstPlantTypeRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }

        public LstPlantType Add(LstPlantType type)
        {
            context.LstPlantType.Add(type);
            context.SaveChanges();
            return type;
        }

        public LstPlantType Delete(int Id)
        {
            LstPlantType type = context.LstPlantType.Find(Id);
            if (type != null)
            {
                context.Remove(type);
                context.SaveChanges();
            }
            return type;
        }

        public LstPlantType GetPlantType(int Id)
        {
            return context.LstPlantType.FirstOrDefault(t => t.Id == Id);
        }

        public IQueryable<LstPlantType> GetPlantTypes()
        {
            return context.LstPlantType;
        }

        public LstPlantType Update(LstPlantType typeChanges)
        {
            var type = context.LstPlantType.Attach(typeChanges);
            type.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return typeChanges;
        }
    }
}
