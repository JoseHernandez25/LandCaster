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
    public interface IJoineryTypeLogic
    {
        Task<PaginationResponse<JoineryType>> GetJoineryTypeAsync(PaginationDTO parameters);
        Task<JoineryType> AddJoineryTypeAsync(AddJoineryTypeDTO addjoineryTypeDTO);

        Task<JoineryType> UpdateJoineryTypeAsync(int id, JoineryType joineryType);
        Task<JoineryType> DeleteJoineryTypeAsync(int id);
    }
}
