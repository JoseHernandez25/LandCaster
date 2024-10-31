using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/colors")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public ColorsController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Color> >Get(
            int pageNumber,
            int pageSize, 
            string? term = null,
            string? brandId = null, 
            string? materialTypeId = null,
            string? orderByAsc = null,
            string? orderBy = null,
            string? withTrashed = null
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

            if (brandId != null)
                parameters.Parameters.Add("brandId", brandId);

            if (materialTypeId != null)
                parameters.Parameters.Add("materialTypeId", materialTypeId);

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);   
            
            if (orderBy != null) 
                parameters.Parameters.Add("orderBy", orderBy);

            if (withTrashed != null) 
                parameters.Parameters.Add("withTrashed", withTrashed);

            return await _manageLogic.Color.GetColorAsync(parameters);
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ColorsController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Color color)
        {
            if (color == null)
            {
                return BadRequest("El Objeto Color es Nulo");
            }
            var createdColor = await _manageLogic.Color.AddColorAsync(color);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);
        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Color color)
        {
         if (color == null)
            {
                return BadRequest("El Objeto Color es Nulo");
            }
            var createdColor = await _manageLogic.Color.UpdateColorAsync(id, color);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);

        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdColor = await _manageLogic.Color.DeleteColorAsync(id);

            return CreatedAtAction("Get", new { id = createdColor.Id }, createdColor);

        }

        // get brands
        [HttpGet("get-brands"), Authorize]
        public async Task<List<Brand>> getBrands()
        {
            return await _manageLogic.Color.GetBrands();

        }
    }
}
