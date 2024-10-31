using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        private readonly ApplicationDbContext _context;
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Permission>> GetAllPermissionAsync()
        {
            return await _context.Permissions.ToListAsync();
        }
    }
}
