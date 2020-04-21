using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFarm.Models.PageModels
{
    public class PlantTypePageModel : PageModel
    {
        public SelectList PlantTypeSL { get; set; }

        public void PopulatePlantTypesDropDownList(VerticalFarmingContext _context,
            object selectedPlantType = null)
        {
            var plantTypesQuery = from t in _context.LstPlantType
                                  orderby t.Name
                                  select t;

            PlantTypeSL = new SelectList(plantTypesQuery.AsNoTracking(),
                "Id", "Name", selectedPlantType);
        }
    }
}
