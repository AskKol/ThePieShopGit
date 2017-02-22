using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ThePieShopGit.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContent;
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContent = appDbContext;
        }

        public IEnumerable<Pie> Pies => _appDbContent.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => _appDbContent.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);

        public Pie GetPieById(int pieId)
        {
            return _appDbContent.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}