using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<PaginationResponse<Category>> GetCategoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<Category>, IOrderedQueryable<Category>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };

            orderBy = value;
            var categories = _unitOfWork.Category.PaginateGetAsync(
                parameters: parameters,
                filter: c =>
                    (string.IsNullOrEmpty(term) || c.Name.Contains(term)) ,
                orderBy: orderBy,
                relationships: "SubCategories",
                isTracking: false
            );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(categories, parameters.PageNumber);

            return   paginationResponse;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {

            var createCategory = _unitOfWork.Category.Create(category);
            await _unitOfWork.Save();

            return category;
        }
        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            _unitOfWork.Category.Update(category);
            await _unitOfWork.Save();
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await _unitOfWork.Category.Find(id);

            category.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Category.Update(category);
            await _unitOfWork.Save();
            return category;
        }



    }
}
