using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
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
    public class SubCategoryLogic : ISubCategoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<SubCategory>> GetSubCategoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<SubCategory>, IOrderedQueryable<SubCategory>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<SubCategory>, IOrderedQueryable<SubCategory>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "category" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Category.Name) : query.OrderByDescending(c => c.Category.Name),
                _ => null
            };

            orderBy = value;
            var subcategories = _unitOfWork.SubCategory.PaginateGetAsync(
                parameters: parameters,
                filter: c =>
                    (string.IsNullOrEmpty(term) || c.Name.Contains(term)),
                orderBy: orderBy,
                relationships: "Category,SubSubCategories",
                isTracking: false
            );

            var paginationResponse =await PaginationHelper.CreatePaginationResponse(subcategories, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<SubCategory> AddSubCategoryAsync(AddSubCategoryDTO addSubCategoryDTO)

        {
            // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

            var created = await _unitOfWork.SubCategory.AddSubCategoryAsync(addSubCategoryDTO);
            await _unitOfWork.Save();

            return created;
        }

            public async Task<SubCategory> UpdateSubCategoryAsync(int id, SubCategory subcategory)
        {
            _unitOfWork.SubCategory.Update(subcategory);
            await _unitOfWork.Save();
            return subcategory;
        }

        public async Task<SubCategory> DeleteSubCategoryAsync(int id)
        {
            var subcategory = await _unitOfWork.SubCategory.Find(id);

            subcategory.DeletedAt = DateTime.UtcNow;
            _unitOfWork.SubCategory.Update(subcategory);
            await _unitOfWork.Save();
            return subcategory;
        }

    }
}
