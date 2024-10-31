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
    public interface ILineLogic
    {
        Task<PaginationResponse<Line>> GetLinesAsync(PaginationDTO parameters);
        Task<Line> AddLineAsync(Line Line);
        Task<Line> UpdateLineAsync(int id, Line Line);
        Task<Line> DeleteLineAsync(int id);
    }
}
