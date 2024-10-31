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
    public interface IAccesorieTypeLogic
    {
        Task<PaginationResponse<AccessoryType>> GetAccessoryTypeAsync(PaginationDTO parameters);
        Task<AccessoryType> AddAccessoryTypeAsync(AccessoryType AccessoryType);
        Task<AccessoryType> UpdateAccessoryTypeAsync(int id, AccessoryType AccessoryType);
        Task<AccessoryType> DeleteAccessoryTypeAsync(int id);
    }
}
