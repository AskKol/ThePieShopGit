﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePieShopGit.Models;
using ThePieShopGit.ViewModel;

namespace ThePieShopGit.Controllers
{
    [Route("api/[controller]")]
    public class PieDataController:Controller
    {

        private readonly IPieRepository _pieRepository;

        public PieDataController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        public IEnumerable<PieViewModel> LoadMorePies()
        {
            IEnumerable<Pie> dbPies = null;

            dbPies = _pieRepository.Pies.OrderBy(p => p.PieId).Take(10);

            List<PieViewModel> pies = new List<PieViewModel>();

            foreach (var dbPie in dbPies)
            {
                pies.Add(MapDbPieToPieViewModel(dbPie));
            }
            return pies;
        }

        private PieViewModel MapDbPieToPieViewModel(Pie dbPie)
        {
            return new PieViewModel()
            {
                PieId = dbPie.PieId,
                Name = dbPie.Name,
                Price = dbPie.Price,
                ShortDescription = dbPie.ShortDescription,
                ImageThumbnailUrl = dbPie.ImageThumbnailUrl
            };
        }
    }
}
