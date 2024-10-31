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
    public class TongueGrooveLogic : ITongueGrooveLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public TongueGrooveLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<TongueGroove>> GetTongueGrooveAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var tongueGroove = _unitOfWork.TongueGroove.PaginateGetAsync(
                parameters: parameters,
                d => (d.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || d.Code.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(tongueGroove, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<TongueGroove> AddTongueGrooveAsync(TongueGroove tongueGroove)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createdTongueGroove = _unitOfWork.TongueGroove.Create(tongueGroove);
            await _unitOfWork.Save();

            return tongueGroove;
        }

        public async Task<TongueGroove> UpdateTongueGrooveAsync(int id, TongueGroove tongueGroove)
        {
            _unitOfWork.TongueGroove.Update(tongueGroove);
            await _unitOfWork.Save();
            return tongueGroove;
        }

        public async Task<TongueGroove> DeleteTongueGrooveAsync(int id)
        {
            var tongueGroove = await _unitOfWork.TongueGroove.Find(id);

            tongueGroove.DeletedAt = DateTime.UtcNow;
            _unitOfWork.TongueGroove.Update(tongueGroove);
            await _unitOfWork.Save();
            return tongueGroove;
        }
    }
}
