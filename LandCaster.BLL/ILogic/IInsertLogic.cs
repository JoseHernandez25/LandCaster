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
    public interface IInsertLogic
    {
        Task<PaginationResponse<Insert>> GetInsertAsync(PaginationDTO parameters);
        Task<Insert> AddInsertAsync(Insert insert);
        Task<Insert> UpdateInsertAsync(int id, Insert insert);
        Task<Insert> DeleteInsertAsync(int id);
    }
}
