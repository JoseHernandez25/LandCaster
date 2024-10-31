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
    public interface IJoineryLogic
    {
        Task<PaginationResponse<Joinery>> GetJoineryAsync(PaginationDTO parameters);
        Task<Joinery> AddJoineryAsync(AddJoineryDTO addJoineryDTO);

        Task<Joinery> UpdateJoineryAsync(int id, Joinery joinery);
        Task<Joinery> DeleteJoineryAsync(int id);
    }
}
