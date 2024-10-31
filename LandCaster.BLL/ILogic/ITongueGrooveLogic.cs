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
    public interface ITongueGrooveLogic
    {
        Task<PaginationResponse<TongueGroove>> GetTongueGrooveAsync(PaginationDTO parameters);
        Task<TongueGroove> AddTongueGrooveAsync(TongueGroove tongueGroove);
        Task<TongueGroove> UpdateTongueGrooveAsync(int id, TongueGroove tongueGroove);
        Task<TongueGroove> DeleteTongueGrooveAsync(int id);
    }
}
