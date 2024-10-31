using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IPermissionRepository :IRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetAllPermissionAsync();
    }
}
