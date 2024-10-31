using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class LineRepository : Repository<Line>, ILineRepository
    {
        private readonly ApplicationDbContext _context;

        public LineRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
