using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Migrations;
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
    public class MaterialLogic : IMaterialLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaterialLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Material>> GetMaterialAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var materials = _unitOfWork.Material.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "MaterialType,SubTypeMaterial,DoorModels",
            isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(materials, parameters.PageNumber);

            return paginationResponse;
        }


        public async Task<Material> AddMaterialAsync(Material material)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createMaterial = _unitOfWork.Material.Create(material);
            await _unitOfWork.Save();

            return material;
        }

        public async Task<Material> UpdateMaterialAsync(int id, Material material)
        {
            _unitOfWork.Material.Update(material);
            await _unitOfWork.Save();
            return material;
        }

        public async Task<Material> DeleteMaterialAsync(int id)
        {
            var material = await _unitOfWork.Material.Find(id);

            material.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Material.Update(material);
            await _unitOfWork.Save();
            return material;
        }

        public async Task<List<MaterialType>> GetMaterialType()
        {
            
            var materialType = await _unitOfWork.MaterialType.Get();

            return materialType;
        }

        public async Task<List<Material>> GetMaterialByMaterialType(int materialTypeId)
        {
            var materials = await _unitOfWork.Material.Get(
                m => m.MaterialTypeId == materialTypeId,
                orderBy: null,
                properties: "MaterialType,DoorModels",
                isTracking: false);

            return materials.ToList();
        }


    }
}

