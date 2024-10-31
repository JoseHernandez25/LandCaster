using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LandCaster.BLL.Logic
{
    public class SubSubCategoryLogic : ISubSubCategoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubSubCategoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<SubSubCategory>> GetSubSubCategoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<SubSubCategory>, IOrderedQueryable<SubSubCategory>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<SubSubCategory>, IOrderedQueryable<SubSubCategory>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "subcategory" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.SubCategory.Name) : query.OrderByDescending(c => c.SubCategory.Name),
                _ => null
            };

            orderBy = value;
            var subsubcategories = _unitOfWork.SubSubCategory.PaginateGetAsync(
                parameters: parameters,
                filter: c =>
                    (string.IsNullOrEmpty(term) || c.Name.Contains(term)),
                orderBy: orderBy,
                relationships: "SubCategory",
                isTracking: false
            );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(subsubcategories, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<SubSubCategory> AddSubSubCategoryAsync(SubSubCategory subsubcategory)
        {

            var createSubSubCategory = _unitOfWork.SubSubCategory.Create(subsubcategory);
            await _unitOfWork.Save();

            return subsubcategory;
        }
        public async Task<SubSubCategory> UpdateSubSubCategoryAsync(int id, SubSubCategory subsubcategory)
        {
            _unitOfWork.SubSubCategory.Update(subsubcategory);
            await _unitOfWork.Save();
            return subsubcategory;
        }

        public async Task<SubSubCategory> DeleteSubSubCategoryAsync(int id)
        {
            var subsubcategory = await _unitOfWork.SubSubCategory.Find(id);

            subsubcategory.DeletedAt = DateTime.UtcNow;
            _unitOfWork.SubSubCategory.Update(subsubcategory);
            await _unitOfWork.Save();
            return subsubcategory;
        }
    }
}
