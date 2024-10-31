using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IHingeLogic
    {
        Task<PaginationResponse<Hinge>> GetHingeAsync(PaginationDTO parameters);
        Task<Hinge> AddHingeAsync(AddHingeDTO addHingeDTO);
        Task<Hinge> UpdateHingeAsync(int id, UpdateHingeDTO updateHingeDTO);
        Task<Hinge> DeleteHingeAsync(int id);
        Task DeleteHingeComponentAsync(int hingeId, int componentId);
        Task<List<Brand>> GetBrands();
        Task<List<HingeType>> GetHingeTypes();



    }
}
