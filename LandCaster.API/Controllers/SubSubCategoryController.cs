using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/sub-subcategories")]
    [ApiController]
    public class SubSubCategoryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public SubSubCategoryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<SubSubCategoryController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<SubSubCategory> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? subcategoryId = null,
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

            return await _manageLogic.SubSubCategory.GetSubSubCategoryAsync(parameters);
        }


        // GET api/<SubSubCategoryController>/5
        [HttpGet("{id}"), Authorize ]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubSubCategoryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(SubSubCategory subsubcategory)
        {
            if (subsubcategory == null)
            {
                return BadRequest("El Objeto Subsubcategory es Nulo");
            }
            var createdSubSubCategory = await _manageLogic.SubSubCategory.AddSubSubCategoryAsync(subsubcategory);

            return CreatedAtAction("Get", new { id = createdSubSubCategory.Id }, createdSubSubCategory);
        }

        // PUT api/<SubSubCategoryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, SubSubCategory subsubcategory)
        {
            if (subsubcategory == null)
            {
                return BadRequest("El Objeto Sub Subcategory es Nulo");
            }
            var createdSubSubCategory = await _manageLogic.SubSubCategory.UpdateSubSubCategoryAsync(id, subsubcategory);

            return CreatedAtAction("Get", new { id = createdSubSubCategory.Id }, createdSubSubCategory);

        }

        // DELETE api/<SubSubCategoryController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdSubSubCategory = await _manageLogic.SubSubCategory.DeleteSubSubCategoryAsync(id);

            return CreatedAtAction("Get", new { id = createdSubSubCategory.Id }, createdSubSubCategory);

        }
    }
}
