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
    public interface IDoorTypeLogic
    {
        Task<PaginationResponse<DoorType>> GetDoorTypeAsync(PaginationDTO parameters);
        Task<DoorType> AddDoorTypeAsync(DoorType doorType);
        Task<DoorType> UpdateDoorTypeAsync(int id, DoorType doorType);
        Task<DoorType> DeleteDoorTypeAsync(int id);
    }
}
