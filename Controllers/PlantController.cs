using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public int PageSize = 10;

        public PlantController(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public ViewResult Index(int plantPage = 1)
            => View("~/Views/Plants/Index.cshtml", new PlantIndexViewModel
            {
                Plants = _plantRepository.GetPlants()
                    .OrderBy(p => p.PlantId)
                    .Skip((plantPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = plantPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _plantRepository.GetPlants().Count()
                }
            });
       // {

            //PlantIndexViewModel plantIndexViewModel = new PlantDetailsViewModel()
            //{
            //    var model = _plantRepository.GetPlants()
            //        .OrderBy(p => p.PlantId)
            //        .Skip((productPage -1) * PageSize)
            //        .Take(PageSize)
            //}; 
                
            //return View("~/Views/Plants/Index.cshtml", model);
       // }

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
