using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class CurrencieRepository : Repository<Currencie>, ICurrencieRepository
    {
        public CurrencieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
