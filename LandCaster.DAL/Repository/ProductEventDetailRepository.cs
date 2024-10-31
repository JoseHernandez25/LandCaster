using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class ProductEventDetailRepository : Repository<ProductEventDetail>, IProductEventDetailRepository
    {
        public ProductEventDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
