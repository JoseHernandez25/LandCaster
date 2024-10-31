using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public CategoryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<CategoryController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Category>> Get(
            int pageNumber,
            int pageSize,
            string? term = null,
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

            return await _manageLogic.Category.GetCategoryAsync(parameters);
        }




        // GET api/<CategoryController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Category category)
        {
            if (category == null)
            {
                return BadRequest("El Objeto Category es Nulo");
            }
            var createdCategory = await _manageLogic.Category.AddCategoryAsync(category);

            return CreatedAtAction("Get", new { id = createdCategory.Id }, createdCategory);
        }
        

        // PUT api/<CategoryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Category category)
        {
            if (category == null)
            {
                return BadRequest("El Objeto Category es Nulo");
            }
            var createdCategory = await _manageLogic.Category.UpdateCategoryAsync(id, category);

            return CreatedAtAction("Get", new { id = createdCategory.Id }, createdCategory);

         }

    // DELETE api/<CategoryController>/5
         [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdCategory = await _manageLogic.Category.DeleteCategoryAsync(id);

            return CreatedAtAction("Get", new { id = createdCategory.Id }, createdCategory);

        }
        
 
    }
}
