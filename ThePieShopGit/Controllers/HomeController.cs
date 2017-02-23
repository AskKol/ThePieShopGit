using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePieShopGit.Models;
using ThePieShopGit.ViewModel;

namespace ThePieShopGit.Controllers
{
    public class HomeController:Controller
    {
        private readonly IPieRepository _pieRepository;
     

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                PiesOfTheWeek=_pieRepository.PiesOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
