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
    public class DrillBitLogic : IDrillBitLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrillBitLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<DrillBit>> GetDrillBitAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var drillBit = _unitOfWork.DrillBit.PaginateGetAsync(
                parameters: parameters,
                d => (d.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || d.Code.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(drillBit, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<DrillBit> AddDrillBitAsync(DrillBit drillBit)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createdDrillBit = _unitOfWork.DrillBit.Create(drillBit);
            await _unitOfWork.Save();

            return drillBit;
        }

        public async Task<DrillBit> UpdateDrillBitAsync(int id, DrillBit drillBit)
        {
            _unitOfWork.DrillBit.Update(drillBit);
            await _unitOfWork.Save();
            return drillBit;
        }

        public async Task<DrillBit> DeleteDrillBitAsync(int id)
        {
            var drillBit = await _unitOfWork.DrillBit.Find(id);

            drillBit.DeletedAt = DateTime.UtcNow;
            _unitOfWork.DrillBit.Update(drillBit);
            await _unitOfWork.Save();
            return drillBit;
        }
    }
}
