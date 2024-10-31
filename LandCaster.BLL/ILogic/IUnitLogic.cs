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
    public interface IUnitLogic
    {
        Task<PaginationResponse<Unit>> GetUnitAsync(PaginationDTO parameters);
        Task<List<Unit>> GetAllUnitsAsync();

        Task<Unit> AddUnitAsync(Unit unit);
    }

}
