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
    public interface IHingeTypeLogic
    {
        Task<PaginationResponse<HingeType>> GetHingeTypeAsync(PaginationDTO parameters);
        Task<HingeType> AddHingeTypeAsync(AddHingeTypeDTO addHingeTypeDTO);
        Task<HingeType> UpdateHingeTypeAsync(int id, HingeType HingeType);
        Task<HingeType> DeleteHingeTypeAsync(int id);
        Task<List<Brand>> GetBrands();

    }
}
