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
    public interface IMoldingLogic
    {
        Task<PaginationResponse<Molding>> GetMoldingAsync(PaginationDTO parameters);
        Task<Molding> AddMoldingAsync(Molding molding);
        Task<Molding> UpdateMoldingAsync(int id, Molding molding);
        Task<Molding> DeleteMoldingAsync(int id);
    }
}
