using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class MaterialTypeLogic : IMaterialTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaterialTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<MaterialType>> GetMaterialTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var materialtypes = _unitOfWork.MaterialType.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "SubTypeMaterials",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(materialtypes, parameters.PageNumber);

            return paginationResponse;
        }
        public async Task<MaterialType> AddMaterialTypeAsync(MaterialType materialType)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createMaterialType = _unitOfWork.MaterialType.Create(materialType);
            await _unitOfWork.Save();

            return materialType;
        }

        public async Task<MaterialType> UpdateMaterialTypeAsync(int id, MaterialType materialType)
        {
            _unitOfWork.MaterialType.Update(materialType);
            await _unitOfWork.Save();
            return materialType;
        }

        public async Task<MaterialType> DeleteMaterialTypeAsync(int id)
        {
            var materialType = await _unitOfWork.MaterialType.Find(id);

            materialType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.MaterialType.Update(materialType);
            await _unitOfWork.Save();
            return materialType;
        }

    }
}
