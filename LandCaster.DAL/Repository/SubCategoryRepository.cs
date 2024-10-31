using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public SubCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<SubCategory> AddSubCategoryAsync(AddSubCategoryDTO addSubCategoryDTO)
        {
            var brands = _context.Brands.Where(b => addSubCategoryDTO.BrandIds.Contains(b.Id)).ToList();

            var subCategorySaved = await _context.SubCategories.AddAsync(addSubCategoryDTO.SubCategory);
 
            foreach (var brand in brands)
            {
                subCategorySaved.Entity.Brands.Add(brand);
            }

            await _context.SaveChangesAsync();

            return subCategorySaved.Entity;
        }
    }
}
