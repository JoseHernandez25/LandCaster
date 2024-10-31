using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IProfileLogic
    {
        Task<PaginationResponse<Profile>> GetProfileAsync(PaginationDTO parameters);
        Task<Profile> AddProfileAsync(Profile doorType);
        Task<Profile> UpdateProfileAsync(int id, Profile doorType);
        Task<Profile> DeleteProfileAsync(int id);
    }
}
