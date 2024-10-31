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
    public class UnitLogic : IUnitLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Unit>> GetUnitAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var units = _unitOfWork.Unit.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(units, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Unit> AddUnitAsync(Unit unit)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createUnit = _unitOfWork.Unit.Create(unit);
            await _unitOfWork.Save();

            return unit;
        }

        public async Task<List<Unit>> GetAllUnitsAsync()
        {
            var units = await _unitOfWork.Unit.Get();;

            return units;
        }


    }
}
