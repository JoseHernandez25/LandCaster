using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class FinishRepository : Repository<Finish>, IFinishRepository
    {
        public FinishRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
