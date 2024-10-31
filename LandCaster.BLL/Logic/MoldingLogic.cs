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
    public class MoldingLogic: IMoldingLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoldingLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Molding>> GetMoldingAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var molding = _unitOfWork.Molding.PaginateGetAsync(
                parameters: parameters,
                d => (d.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || d.Code.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(molding, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Molding> AddMoldingAsync(Molding molding)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createdMolding = _unitOfWork.Molding.Create(molding);
            await _unitOfWork.Save();

            return molding;
        }

        public async Task<Molding> UpdateMoldingAsync(int id, Molding molding)
        {
            _unitOfWork.Molding.Update(molding);
            await _unitOfWork.Save();
            return molding;
        }

        public async Task<Molding> DeleteMoldingAsync(int id)
        {
            var molding = await _unitOfWork.Molding.Find(id);

            molding.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Molding.Update(molding);
            await _unitOfWork.Save();
            return molding;
        }
    }
}
