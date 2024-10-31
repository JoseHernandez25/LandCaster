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
    public class SupplierLogic : ISupplierLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Supplier>> GetSupplierAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var suppliers = _unitOfWork.Supplier.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(suppliers, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Supplier> AddSupplierAsync(Supplier Supplier)
        {


            var createSupplier = _unitOfWork.Supplier.Create(Supplier);
            await _unitOfWork.Save();

            return Supplier;
        }


    }
}
