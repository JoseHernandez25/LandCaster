using LandCaster.Entities.DTOs;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IRoleLogic
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        //Task<Role> AddRoleAsync(Role role);
        //Task<Role> UpdateUserAsync(int id, Role role);
        //Task<Role> DeleteUserAsync(int id);
    }
}
