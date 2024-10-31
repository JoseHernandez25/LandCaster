using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class DrawerSlideRepository : Repository<DrawerSlide>, IDrawerSlideRepository
    {
        private readonly ApplicationDbContext _context;

        public DrawerSlideRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }

}
