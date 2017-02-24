using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThePieShopGit.Models;
using ThePieShopGit.ViewModel;

namespace ThePieShopGit.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository,ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory = string.Empty;

            if (String.IsNullOrEmpty(category))
            {
                pies = _pieRepository.Pies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.Pies.Where(p => p.Category.CategoryName.ToLower().Contains(category.ToLower())).OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c=>c.CategoryName.ToLower().Contains(category.ToLower())).CategoryName;
            }

            return View(new PiesListViewModel()
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });

            //PiesListViewModel piesListViewModel = new PiesListViewModel();
            //piesListViewModel.Pies = _pieRepository.Pies;
            //piesListViewModel.CurrentCategory = "Cheese cakes";

            //return View(piesListViewModel);
        }

        public IActionResult Details(int Id)
        {
            Pie aPie;
            aPie = _pieRepository.Pies.Where(p => p.PieId == Id).FirstOrDefault();

            if (aPie !=null)
            {
                return View("Details", aPie);
            }
            return NotFound();
        }
    }
}
