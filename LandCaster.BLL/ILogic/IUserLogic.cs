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
    public interface IUserLogic
    {
        Task<PaginationResponse<User>> GetUserAsync(PaginationDTO parameters);
        Task<User> AddUserAsync(User user);
        Task<User> DeleteUserAsync(string  id);
        Task<User> UpdateUserAsync(string id, User user);
    }
}
