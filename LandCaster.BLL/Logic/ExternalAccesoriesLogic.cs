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
    public class ExternalAccesoriesLogic : IExternalAccesoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExternalAccesoriesLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PaginationResponse<ExternalAccesory> GetExternalAccesoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var ExternalAccesory = _unitOfWork.ExternalAccesory.PaginateGet(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "",
                isTracking: false
            );

            var currentPage = parameters.PageNumber;
            var totalPages = ExternalAccesory.MetaData.TotalPages;

            var prevDisabled = currentPage <= 1 ? new { status = "disabled", pageNumber = 1 } : new { status = "enabled", pageNumber = currentPage - 1 };
            var nextDisabled = currentPage >= totalPages ? new { status = "disabled", pageNumber = totalPages } : new { status = "enabled", pageNumber = currentPage + 1 };

            var result = new PaginationResponse<ExternalAccesory>
            {
                TotalPages = totalPages,
                TotalCount = ExternalAccesory.MetaData.TotalCount,
                PageSize = ExternalAccesory.MetaData.PageSize,
                PageNumber = currentPage,
                Prev = prevDisabled,
                Next = nextDisabled,
                Data = ExternalAccesory
            };

            return result;
        }


        public async Task<ExternalAccesory> AddExternalAccesoryAsync(ExternalAccesory ExternalAccesory)
        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var createExternalAccesory = _unitOfWork.ExternalAccesory.Create(ExternalAccesory);
            await _unitOfWork.Save();

            return ExternalAccesory;
        }

        public async Task<ExternalAccesory> UpdateExternalAccesoryAsync(int id, ExternalAccesory ExternalAccesory)
        {
            _unitOfWork.ExternalAccesory.Update(ExternalAccesory);
            await _unitOfWork.Save();
            return ExternalAccesory;
        }

        public async Task<ExternalAccesory> DeleteExternalAccesoryAsync(int id)
        {
            var ExternalAccesory = await _unitOfWork.ExternalAccesory.Find(id);

            ExternalAccesory.DeletedAt = DateTime.UtcNow;
            _unitOfWork.ExternalAccesory.Update(ExternalAccesory);
            await _unitOfWork.Save();
            return ExternalAccesory;
        }
        public async Task<List<Brand>> GetBrands()
        {
            //var brands = _unitOfWork.Color.GetBrands();
            var subCategory = await _unitOfWork.SubCategory.Get(
                c => (c.Id == 1),
                orderBy: null,
                properties: "Brands",
                isTracking: false);

            // Seleccionar y aplanar las marcas de todas las subcategorías
            var brands = subCategory.SelectMany(sc => sc.Brands).ToList();

            return brands;
        }
    }
}


