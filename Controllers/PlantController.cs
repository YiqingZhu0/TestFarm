using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;
using TestFarm.ViewModels;

namespace TestFarm.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantRepository _plantRepository;

        public PlantController(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public ViewResult Index()
        {
            var model = _plantRepository.GetPlants();
            return View("~/Views/Plants/Index.cshtml", model);
        }
        [Route("Plant/Details/{Id?}")]
        public ViewResult Details(int? Id)
        {
            PlantDetailsViewModel plantDetailsViewModel = new PlantDetailsViewModel()
            {
                Plant = _plantRepository.GetPlant(Id??1),
                PageTitle = "Plant Details"
            };

            return View("~/Views/Plants/Details.cshtml", plantDetailsViewModel);
        }
    }
}
