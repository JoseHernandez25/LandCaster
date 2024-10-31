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
    public interface IMaterialLogic
    {
        Task<PaginationResponse<Material>> GetMaterialAsync(PaginationDTO parameters);
        Task<Material> AddMaterialAsync(Material material);

        Task<Material> UpdateMaterialAsync(int id, Material material);
        Task<Material> DeleteMaterialAsync(int id);

        Task<List<MaterialType>> GetMaterialType();


        Task<List<Material>> GetMaterialByMaterialType(int materialTypeId);
    }
}
