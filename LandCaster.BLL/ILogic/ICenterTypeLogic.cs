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
    public interface ICenterTypeLogic
    {
        Task<PaginationResponse<CenterType>> GetCenterTypeAsync(PaginationDTO parameters);
        Task<CenterType> AddCenterTypeAsync(CenterType doorType);
        Task<CenterType> UpdateCenterTypeAsync(int id, CenterType doorType);
        Task<CenterType> DeleteCenterTypeAsync(int id);
    }
}
