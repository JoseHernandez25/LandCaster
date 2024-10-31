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
    public class SubTypeMaterialLogic : ISubTypeMaterialLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubTypeMaterialLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<SubTypeMaterial>> GetSubTypeMaterialAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var subTypeMaterials = _unitOfWork.SubTypeMaterial.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "Colors,Finishes,MaterialTypes,Materials,InternalAccesories",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(subTypeMaterials, parameters.PageNumber);

            return paginationResponse;
        }
        public async Task<SubTypeMaterial> AddSubTypeMaterialAsync(AddSubTypeMaterialDTO addSubTypeMaterialDTO)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

           var  created = await  _unitOfWork.SubTypeMaterial.AddSubTypeMaterialAsync(addSubTypeMaterialDTO);
            await _unitOfWork.Save();

            return created;
        }

        public async Task<SubTypeMaterial> UpdateSubTypeMaterialAsync(int id, SubTypeMaterial subTypeMaterial)
        {
            _unitOfWork.SubTypeMaterial.Update(subTypeMaterial);
            await _unitOfWork.Save();
            return subTypeMaterial;
        }

        public async Task<SubTypeMaterial> DeleteSubTypeMaterialAsync(int id)
        {
            var subTypeMaterial = await _unitOfWork.SubTypeMaterial.Find(id);

            subTypeMaterial.DeletedAt = DateTime.UtcNow;
            _unitOfWork.SubTypeMaterial.Update(subTypeMaterial);
            await _unitOfWork.Save();
            return subTypeMaterial;
        }

        public async Task<SubTypeMaterial> GetSubTypeMaterialByFinish(int id)
        {
            var subTypeMaterial = await _unitOfWork.SubTypeMaterial.Fisrt(
                filter: stm=>stm.Id == id,
                properties: "Finishes",
                isTracking: false
            );
            var allFinishes = await _unitOfWork.Finish.Get(isTracking: false);

            var finishesNotIn = allFinishes
                   .Where(f => !subTypeMaterial.Finishes.Any(fIn => fIn.Id == f.Id))
                   .ToList();
            subTypeMaterial.FinishesNotIn = finishesNotIn;

            return subTypeMaterial;

        }

        public async Task<IEnumerable<SubTypeMaterial>> GetSubTypeMaterial()
        {
            var subTypeMaterial = await _unitOfWork.SubTypeMaterial.Get(
                filter: null,
                orderBy: null,
                properties: "", // Agrega la propiedad Components a las propiedades incluidas
                isTracking: true
            );
            return subTypeMaterial;
        }
        public async Task AddFinishToSubTypeMaterialAsync(AddFinishToSubTypeDTO addFinishToSubTypeMaterialDTO)
        {
            await _unitOfWork.SubTypeMaterial.AddFinishToSubTypeMaterialAsync(addFinishToSubTypeMaterialDTO);
            await _unitOfWork.Save();
        }

        public async Task RemoveFinishFromSubTypeMaterialAsync(AddFinishToSubTypeDTO addFinishToSubTypeMaterialDTO)
        {
            await _unitOfWork.SubTypeMaterial.RemoveFinishFromSubTypeMaterialAsync(addFinishToSubTypeMaterialDTO);
            await _unitOfWork.Save();
        }
    }
}
