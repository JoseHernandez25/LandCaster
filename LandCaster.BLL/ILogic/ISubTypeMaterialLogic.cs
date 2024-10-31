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
    public interface ISubTypeMaterialLogic
    {
        Task<PaginationResponse<SubTypeMaterial>> GetSubTypeMaterialAsync(PaginationDTO parameters);
        Task<SubTypeMaterial> AddSubTypeMaterialAsync(AddSubTypeMaterialDTO addSubTypeMaterialDTO);
        Task<SubTypeMaterial> UpdateSubTypeMaterialAsync(int id, SubTypeMaterial subTypeMaterial);
        Task<SubTypeMaterial> DeleteSubTypeMaterialAsync(int id);

        Task<SubTypeMaterial> GetSubTypeMaterialByFinish(int id);
        Task<IEnumerable<SubTypeMaterial>> GetSubTypeMaterial();
        Task AddFinishToSubTypeMaterialAsync(AddFinishToSubTypeDTO addFinishToSubTypeDTO);
        Task RemoveFinishFromSubTypeMaterialAsync(AddFinishToSubTypeDTO addFinishToSubTypeDTO);

        



    }
}
