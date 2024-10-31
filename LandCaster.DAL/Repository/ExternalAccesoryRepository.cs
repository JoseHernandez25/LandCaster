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
    internal class ExternalAccessoryRepository : Repository<ExternalAccessory>, IExternalAccessoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ExternalAccessoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }


        public List<Brand> GetBrands()
        {
            var brands = _context.SubCategories
                                .Include(sc => sc.Brands)
                                .FirstOrDefault(sc => sc.Id == 1)?
                                .Brands
                                .ToList();
            return brands;
        }
    }
}

