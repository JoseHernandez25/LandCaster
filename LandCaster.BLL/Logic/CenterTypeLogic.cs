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
    public class CenterTypeLogic : ICenterTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CenterTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<CenterType>> GetCenterTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var centerType = _unitOfWork.CenterType.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(centerType, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<CenterType> AddCenterTypeAsync(CenterType centerType)

        {

            var createdCenterType = _unitOfWork.CenterType.Create(centerType);
            await _unitOfWork.Save();

            return centerType;
        }

        public async Task<CenterType> UpdateCenterTypeAsync(int id, CenterType centerType)
        {
            _unitOfWork.CenterType.Update(centerType);
            await _unitOfWork.Save();
            return centerType;
        }

        public async Task<CenterType> DeleteCenterTypeAsync(int id)
        {
            var centerType = await _unitOfWork.CenterType.Find(id);

            centerType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.CenterType.Update(centerType);
            await _unitOfWork.Save();
            return centerType;
        }
    }
}
