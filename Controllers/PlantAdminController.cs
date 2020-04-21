using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.Controllers
{
    public class PlantAdminController : Controller
    {
        private readonly IPlantRepository _plantRepo;
        private readonly ILstPlantTypeRepository _plantTypeRepo;
        private readonly ILstPlantSizeRepository _plantSizeRepo;
        public PlantAdminController(IPlantRepository plantRepo, ILstPlantTypeRepository plantTypeRepo, ILstPlantSizeRepository plantSizeRepo)
        {
            this._plantRepo = plantRepo;
            this._plantTypeRepo = plantTypeRepo;
            this._plantSizeRepo = plantSizeRepo;
        }

        public ViewResult Index() => View("~/Views/Admin/Plants/Index.cshtml", _plantRepo.GetPlants());

        public ViewResult Add()
        {
            PopulatePlantSizesDropDownList();
            PopulatePlantTypesDropDownList();
            return View("~/Views/Admin/Plants/Edit.cshtml", new Plant());
        }

        //[HttpPost]
        //public IActionResult Add(Plant plant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _plantRepo.Add(plant);
        //        TempData["message"] = $"{plant.Name} has been saved";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        //something is wrong
        //        return View("~/Views/Admin/Plants/Add.cshtml", plant);
        //    }
        //}

        public ViewResult Edit(int plantId)
        {
            //ViewBag.PlantTypes = new SelectList(_repo.GetPlants().Select(t => t.CategoryNavigation.Id, t.CategoryNavigation.Name).Distinct());
            PopulatePlantSizesDropDownList(_plantRepo.GetPlant(plantId).Size);
            PopulatePlantTypesDropDownList(_plantRepo.GetPlant(plantId).Category);
            return View("~/Views/Admin/Plants/Edit.cshtml", _plantRepo.GetPlants().FirstOrDefault(p => p.PlantId == plantId));
        }
            

        [HttpPost]
        public IActionResult Edit(Plant plant)
        {
            if (ModelState.IsValid)
            {
                if (plant.PlantId == 0)
                {
                    _plantRepo.Add(plant);
                }
                else
                {
                    _plantRepo.Update(plant);
                }
                TempData["message"] = $"{plant.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                //something is wrong
                return View("~/Views/Admin/Plants/Edit.cshtml", plant);
            }
        }

        private void PopulatePlantTypesDropDownList(object selectedPlantType = null)
        {
            var plantTypesQuery = from d in _plantTypeRepo.GetPlantTypes()
                                   orderby d.Name
                                   select d;
            ViewBag.Category = new SelectList(plantTypesQuery.AsNoTracking(), "Id", "Name", selectedPlantType);
        }

        private void PopulatePlantSizesDropDownList(object selectedPlantSize = null)
        {
            var plantSizesQuery = from d in _plantSizeRepo.GetPlantSizes()
                                  orderby d.Name
                                  select d;
            ViewBag.Size = new SelectList(plantSizesQuery.AsNoTracking(), "Id", "Name", selectedPlantSize);
        }
    }
}
