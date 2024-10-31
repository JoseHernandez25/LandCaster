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
    public interface IAreaLogic
    {
        Task<PaginationResponse<Area>> GetAreasAsync(PaginationDTO parameters);
        Task<Area> AddAreaAsync(Area area);
        Task<Area> UpdateAreaAsync(int id, Area area);
        Task<Area> DeleteAreaAsync(int id);
    }
}
