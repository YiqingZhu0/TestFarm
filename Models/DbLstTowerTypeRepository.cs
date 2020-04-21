using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models
{
    public class DbLstTowerTypeRepository : ILstTowerTypeRepository
    {
        private readonly VerticalFarmingContext context;

        public DbLstTowerTypeRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }

        public LstTowerType Add(LstTowerType type)
        {
            context.LstTowerType.Add(type);
            context.SaveChanges();
            return type;
        }

        public LstTowerType Delete(int Id)
        {
            LstTowerType type = context.LstTowerType.Find(Id);
            if (type != null)
            {
                context.Remove(type);
                context.SaveChanges();
            }
            return type;
        }

        public LstTowerType GetTowerType(int Id)
        {
            return context.LstTowerType.FirstOrDefault(t => t.TowerTypeId == Id);
        }

        public IQueryable<LstTowerType> GetTowerTypes()
        {
            return context.LstTowerType;
        }

        public LstTowerType Update(LstTowerType typeChanges)
        {
            var type = context.LstTowerType.Attach(typeChanges);
            type.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return typeChanges;
        }
    }
}
