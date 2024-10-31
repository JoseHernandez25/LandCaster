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
    public interface IAngleLogic
    {
        Task<PaginationResponse<Angle>> GetAngleAsync(PaginationDTO parameters);
        Task<Angle> AddAngleAsync(Angle Angle);
        Task<Angle> UpdateAngleAsync(int id, Angle Angle);
        Task<Angle> DeleteAngleAsync(int id);
    }
}
