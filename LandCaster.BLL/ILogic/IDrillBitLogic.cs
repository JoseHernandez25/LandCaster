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
    public interface IDrillBitLogic
    {
        Task<PaginationResponse<DrillBit>> GetDrillBitAsync(PaginationDTO parameters);
        Task<DrillBit> AddDrillBitAsync(DrillBit drillBit);
        Task<DrillBit> UpdateDrillBitAsync(int id, DrillBit drillBit);
        Task<DrillBit> DeleteDrillBitAsync(int id);
    }
}
