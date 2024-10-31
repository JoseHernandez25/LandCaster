using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
    }
}
