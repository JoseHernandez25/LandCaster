using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class DrawerSlideTypeRepository : Repository<DrawerSlideType>, IDrawerSlideTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public DrawerSlideTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DrawerSlideType>> GetAllDrawerSlideTypesAsync()
        {
            return await _context.DrawerSlideTypes.ToListAsync();
        }

    }
}
