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
    public class BrandLogic : IBrandLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<PaginationResponse<Brand>> GetBrandAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var brands = _unitOfWork.Brand.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "Hinges,Colors,DrawerSlides,DrawerSlidesComponents,,hingeTypes",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(brands, parameters.PageNumber);

            return paginationResponse;
        }
        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            var createBrand = _unitOfWork.Brand.Create(brand);
            await _unitOfWork.Save();

            return brand;
        }

        public async Task<Brand> UpdateBrandAsync(int id, Brand brand)
        {
            _unitOfWork.Brand.Update(brand);
            await _unitOfWork.Save();
            return brand;
        }

        public async Task<Brand> DeleteBrandAsync(int id)
        {
            var brand = await _unitOfWork.Brand.Find(id);

            brand.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Brand.Update(brand);
            await _unitOfWork.Save();
            return brand;
        }

    }
}
