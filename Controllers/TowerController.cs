using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFarm.Models;
using TestFarm.ViewModels;

namespace VerticalFarming.Controllers
{
    public class TowerController : Controller
    {
        private readonly ITowerRepository _towerRepository;

        public TowerController(ITowerRepository towerRepository)
        {
            _towerRepository = towerRepository;
        }

        public ViewResult Index()
        {
            var model = _towerRepository.GetTowers();
            return View("~/Views/Towers/Index.cshtml", model);
        }

        public ViewResult Details(int? Id)
        {
            TowerDetailsViewModel towerDetailsViewModel = new TowerDetailsViewModel()
            {
                Tower = _towerRepository.GetTower(Id ?? 1),
                PageTitle = "Tower Details"
            };

            return View("~/Views/Towers/Details.cshtml", towerDetailsViewModel);
        }
    }
}
