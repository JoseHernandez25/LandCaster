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
    public class FinancingParamaterRepository : Repository<FinancingParameter>, IFinancingParamaterRepository
    {
        private readonly ApplicationDbContext _context;

        public FinancingParamaterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

    }
}
