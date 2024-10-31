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
    public  class JoineryTypeLogic : IJoineryTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public JoineryTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<JoineryType>> GetJoineryTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var joineryTypes = _unitOfWork.JoineryType.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "Joineries",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(joineryTypes, parameters.PageNumber);

            return paginationResponse;
        }


        public async Task<JoineryType> AddJoineryTypeAsync(AddJoineryTypeDTO addJoineryTypeDTO)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var created = await _unitOfWork.JoineryType.AddJoineryTypeAsync(addJoineryTypeDTO);
            await _unitOfWork.Save();

            return created;
        }

        public async Task<JoineryType> UpdateJoineryTypeAsync(int id, JoineryType joineryType)
        {
            _unitOfWork.JoineryType.Update(joineryType);
            await _unitOfWork.Save();
            return joineryType;
        }

        public async Task<JoineryType> DeleteJoineryTypeAsync(int id)
        {
            var joineryType = await _unitOfWork.JoineryType.Find(id);

            joineryType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.JoineryType.Update(joineryType);
            await _unitOfWork.Save();
            return joineryType;
        }
    }
}
