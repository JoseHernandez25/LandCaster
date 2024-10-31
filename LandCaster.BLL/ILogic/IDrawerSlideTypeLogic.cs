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
    public interface IDrawerSlideTypeLogic
    {
        Task<PaginationResponse<DrawerSlideType>> GetDrawerSlideTypeAsync(PaginationDTO parameters);
        Task<DrawerSlideType> AddDrawerSlideTypeAsync(AddDrawerSlideTypeDTO AddDrawerSlideTypeDTO);
        Task<DrawerSlideType> UpdateDrawerSlideTypeAsync(int id, DrawerSlideType DrawerSlideType);
        Task<DrawerSlideType> DeleteDrawerSlideTypeAsync(int id);
        Task<List<DrawerSlideType>> GetAllDrawerSlideTypesAsync(); // Nuevo método

    }
}
