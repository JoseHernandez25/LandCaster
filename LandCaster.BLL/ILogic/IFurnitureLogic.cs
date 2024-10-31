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
    public interface IFurnitureLogic
    {
        Task<PaginationResponse<Furniture>> GetFurnituresAsync(PaginationDTO parameters);
        Task<Furniture> AddtFurnitureAsync(Furniture furniture);
        Task<Furniture> UpdatetFurnitureAsync(int id, Furniture furniture);
        Task<Furniture> DelettFurnitureAsync(int id);
    }
}
