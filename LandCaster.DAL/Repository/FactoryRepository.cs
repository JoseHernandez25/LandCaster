using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class FactoryRepository : Repository<Factory>, IFactoryRepository
    {
        public FactoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
