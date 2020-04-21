using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace TestFarm.Models
{
    
    public class DbPlantRepository : IPlantRepository
    {
        private readonly VerticalFarmingContext context;

        public DbPlantRepository(VerticalFarmingContext context)
        {
            this.context = context;
        }

        public Plant Add(Plant plant)
        {
            context.Plants.Add(plant);
            context.SaveChanges();
            return plant;
        }

        public Plant Delete(int Id)
        {
            Plant plant = context.Plants.Find(Id);
            if (plant != null)
            {
                context.Remove(plant);
                context.SaveChanges();
            }
            return plant;
        }

        public Plant GetPlant(int Id)
        {
            return context.Plants
                .Include(p => p.SizeNavigation)
                .Include(p => p.CategoryNavigation)
                .Include(p => p.Pricing).FirstOrDefault(p => p.PlantId == Id);
        }

        public IQueryable<Plant> GetPlants()
        {
            return context.Plants
                .Include(p => p.SizeNavigation)
                .Include(p => p.CategoryNavigation)
                .Include(p => p.Pricing);
        }

        public Plant Update(Plant plantChanges)
        {
            var plant = context.Plants.Attach(plantChanges);
            plant.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return plantChanges;
        }
    }
}
