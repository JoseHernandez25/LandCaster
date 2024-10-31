using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
                private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
        public async Task<Product?> GetByCodeWithInventoriesAsync(string code)
        {
            return await _context.Products
                .Include(p => p.Inventories)
                .FirstOrDefaultAsync(p => p.Code == code);
        }
    }
}

