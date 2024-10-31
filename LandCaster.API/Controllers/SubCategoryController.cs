using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/sub-categories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public SubCategoryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<SubCategoryController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<SubCategory> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? categoryId = null,
            string? subsubcategoryId = null,
            string? orderByAsc = null,
            string? orderBy = null

            )
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.SubCategory.GetSubCategoryAsync(parameters);
        }

        // GET api/<SubCategoryController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubCategoryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddSubCategoryDTO addSubCategoryDTO)
        {
            if (addSubCategoryDTO.SubCategory == null)
            {
                return BadRequest("El Objeto SubCategory es Nulo");
            }

            var createdSubCategory = await _manageLogic.SubCategory.AddSubCategoryAsync(addSubCategoryDTO);

            return CreatedAtAction("Get", new { id = createdSubCategory.Id }, createdSubCategory);
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, SubCategory subcategory)
        {
            if (subcategory == null)
            {
                return BadRequest("El Objeto Subcategory es Nulo");
            }
            var createdSubCategory = await _manageLogic.SubCategory.UpdateSubCategoryAsync(id, subcategory);

            return CreatedAtAction("Get", new { id = createdSubCategory.Id }, createdSubCategory);

        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdSubCategory = await _manageLogic.SubCategory.DeleteSubCategoryAsync(id);

            return CreatedAtAction("Get", new { id = createdSubCategory.Id }, createdSubCategory);

        }
        
    }
}
