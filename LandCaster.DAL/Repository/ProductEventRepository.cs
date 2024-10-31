using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class ProductEventRepository : Repository<ProductEvent>, IProductEventRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductEventRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductEvent>> GetAllAsync(Expression<Func<ProductEvent, bool>> filter = null)
        {
            IQueryable<ProductEvent> query = _context.Set<ProductEvent>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }
    }
}
