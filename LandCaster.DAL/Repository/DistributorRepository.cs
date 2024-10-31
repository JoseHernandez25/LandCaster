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
    public class DistributorRepository : Repository<Distributor>, IDistributorRepository
    {
        private readonly ApplicationDbContext _context;
        public DistributorRepository(ApplicationDbContext context) : base(context) 
        { 
            _context = context;
        }

       // public async Task<IEnumerable<Distributor>> GetDistributor()
      //  {
       //     var distributors = await _context.Distributors.ToListAsync();
       //     return distributors;
       // }
    }
}
