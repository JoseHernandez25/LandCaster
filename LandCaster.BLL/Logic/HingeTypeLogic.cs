using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Migrations;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class HingeTypeLogic : IHingeTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public HingeTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<HingeType>> GetHingeTypeAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            var brandId = parameters.Parameters.ContainsKey("brandId") ? Convert.ToInt32(parameters.Parameters["brandId"]) : (int?)null;
            var materialTypeId = parameters.Parameters.ContainsKey("materialTypeId") ? Convert.ToInt32(parameters.Parameters["materialTypeId"]) : (int?)null;
            Func<IQueryable<HingeType>, IOrderedQueryable<HingeType>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<HingeType>, IOrderedQueryable<HingeType>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "brand" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Brand.Name) : query.OrderByDescending(c => c.Brand.Name),
                _ => null
            };

            Expression<Func<HingeType, bool>> filterCondition = c =>
            ((withTrashed == true && c.DeletedAt != null) ||
            (withTrashed == false && c.DeletedAt == null) || withTrashed == null) &&
            ((string.IsNullOrEmpty(term) || c.Name.Contains(term)) ||
             c.Brand.Name.Contains(term));



            orderBy = value;
            var hingestypes = _unitOfWork.HingeType.PaginateGetAsync(
                parameters: parameters,
                filter: filterCondition,
                orderBy: orderBy,
                relationships: "Hinges,Brand",
                isTracking: false,
                 withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(hingestypes, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<HingeType> AddHingeTypeAsync(AddHingeTypeDTO addHingeTypeDTO)
        {
            var existingHingeType = await _unitOfWork.HingeType
                                                     .Fisrt(ht => ht.Name == addHingeTypeDTO.Name);

            if (existingHingeType != null)
            {
                throw new Exception("El nombre del tipo de bisagra ya existe.");
            }

            var hingeType = new HingeType();
            hingeType.BrandId = addHingeTypeDTO.BrandId;
            hingeType.Name = addHingeTypeDTO.Name;
            await _unitOfWork.HingeType.Create(hingeType);
            await _unitOfWork.Save();

            foreach (var hingeDto in addHingeTypeDTO.Hinges)
            {
                var hinge = new Hinge();
                hinge.BrandId = addHingeTypeDTO.BrandId;
                hinge.HingeTypeId = hingeType.Id;
                hinge.Name = hingeDto.Name;
                hinge.Code = hingeDto.Code;
                hinge.AngleId = hingeDto.AngleId;
                hinge.FinancingParameterId = 3;

                await _unitOfWork.Hinge.Create(hinge);

            }

            await _unitOfWork.Save();

            return hingeType;
        }
        public async Task<HingeType> UpdateHingeTypeAsync(int id, HingeType HingeType)
        {
            var existingHingeType = await _unitOfWork.HingeType
                                                     .Fisrt(ht => ht.Name == HingeType.Name && ht.Id != id);

            if (existingHingeType != null)
            {
                throw new Exception("El nombre del tipo de bisagra ya existe.");
            }

            _unitOfWork.HingeType.Update(HingeType);
            await _unitOfWork.Save();
            return HingeType;
        }

        public async Task<HingeType> DeleteHingeTypeAsync(int id)
        {
            var HingeType = await _unitOfWork.HingeType.Find(id);

            HingeType.DeletedAt = DateTime.UtcNow;
            _unitOfWork.HingeType.Update(HingeType);
            await _unitOfWork.Save();
            return HingeType;
        }

        public async Task<List<Brand>> GetBrands()
        {

            var brands = await _unitOfWork.Brand.Get();

            return brands;
        }



    }
}
