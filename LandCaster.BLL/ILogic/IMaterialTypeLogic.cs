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
    public interface  IMaterialTypeLogic
    {
        Task<PaginationResponse<MaterialType>> GetMaterialTypeAsync(PaginationDTO parameters);
        Task<MaterialType> AddMaterialTypeAsync(MaterialType materialType);
        Task<MaterialType> UpdateMaterialTypeAsync(int id, MaterialType materialType);
        Task<MaterialType> DeleteMaterialTypeAsync(int id);
    }
}
