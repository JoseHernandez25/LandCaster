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
    public interface IFinishLogic
    {
        Task<PaginationResponse<Finish>> GetFinishAsync(PaginationDTO parameters);
        Task<Finish> AddFinishAsync(Finish finish);
        Task<Finish> UpdateFinishAsync(int id, Finish finish);
        Task<Finish> DeleteFinishAsync(int id);
    }
}
