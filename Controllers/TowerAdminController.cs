using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;

namespace TestFarm.Controllers
{
    public class TowerAdminController : Controller
    {
        private readonly ITowerRepository _towerRepo;
        private readonly ILstTowerTypeRepository _towerTypeRepo;
        private readonly ILstLocationsRepository _locationRepo;
        public TowerAdminController(ITowerRepository towerRepo, ILstTowerTypeRepository towerTypeRepo, ILstLocationsRepository locationRepo)
        {
            this._towerRepo = towerRepo;
            this._towerTypeRepo = towerTypeRepo;
            this._locationRepo = locationRepo;
        }

        public ViewResult Index() => View("~/Views/Admin/Towers/Index.cshtml", _towerRepo.GetTowers());

        public ViewResult Add()
        {
            PopulateLocationsDropDownList();
            PopulateTowerTypesDropDownList();
            return View("~/Views/Admin/Towers/Add.cshtml");
        }

        [HttpPost]
        public IActionResult Add(Tower tower)
        {
            if (ModelState.IsValid)
            {
                _towerRepo.Add(tower);
                TempData["message"] = $"{tower.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                //something is wrong
                return View("~/Views/Admin/Towers/Add.cshtml", tower);
            }
        }

        public ViewResult Edit(int towerId)
        {
            //ViewBag.PlantTypes = new SelectList(_repo.GetPlants().Select(t => t.CategoryNavigation.Id, t.CategoryNavigation.Name).Distinct());
            PopulateLocationsDropDownList(_towerRepo.GetTower(towerId).Location);
            PopulateTowerTypesDropDownList(_towerRepo.GetTower(towerId).TowerType);
            return View("~/Views/Admin/Towers/Edit.cshtml", _towerRepo.GetTowers().FirstOrDefault(p => p.TowerId == towerId));
        }


        [HttpPost]
        public IActionResult Edit(Tower tower)
        {
            if (ModelState.IsValid)
            {
                _towerRepo.Update(tower);
                TempData["message"] = $"{tower.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                //something is wrong
                return View("~/Views/Admin/Towers/Edit.cshtml", tower);
            }
        }

        private void PopulateTowerTypesDropDownList(object selectedTowerType = null)
        {
            var towerTypesQuery = from d in _towerTypeRepo.GetTowerTypes()
                                  orderby d.TowerName
                                  select d;
            ViewBag.TowerType = new SelectList(towerTypesQuery.AsNoTracking(), "TowerTypeId", "TowerName", selectedTowerType);
        }

        private void PopulateLocationsDropDownList(object selectedLocation = null)
        {
            var locationsQuery = from d in _locationRepo.GetLocations()
                                  orderby d.Aisle,d.AisleSection
                                  select d;
            ViewBag.Location = new SelectList(locationsQuery.AsNoTracking(), "LocationId", "Aisle", selectedLocation);
        }
    }
}
