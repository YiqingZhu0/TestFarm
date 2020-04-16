using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;
using TestFarm.ViewModels;

namespace TestFarm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlantRepository _plantRepository;

        public HomeController(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public ViewResult Index()
        {
            var model = _plantRepository.GetPlants();
            return View();
        }

        public ViewResult Details(int? Id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Plant = _plantRepository.GetPlant(Id??1),
                PageTitle = "Plant Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}
