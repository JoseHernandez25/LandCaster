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
    public class DoorTypeLogic : IDoorTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoorTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<DoorType>> GetDoorTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var doorType = _unitOfWork.DoorType.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(doorType, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<DoorType> AddDoorTypeAsync(DoorType doorType)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createdDoorType = _unitOfWork.DoorType.Create(doorType);
            await _unitOfWork.Save();

            return doorType;
        }

        public async Task<DoorType> UpdateDoorTypeAsync(int id, DoorType doorType)
        {
            _unitOfWork.DoorType.Update(doorType);
            await _unitOfWork.Save();
            return doorType;
        }

        public async Task<DoorType> DeleteDoorTypeAsync(int id)
        {
            var doorType = await _unitOfWork.DoorType.Find(id);

            doorType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.DoorType.Update(doorType);
            await _unitOfWork.Save();
            return doorType;
        }
    }
}
