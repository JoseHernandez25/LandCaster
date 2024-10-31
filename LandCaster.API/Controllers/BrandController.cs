using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public BrandController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<BrandController>
        [HttpGet,Authorize]
        public async Task<PaginationResponse<Brand>> Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Brand.GetBrandAsync(parameters);
        }


        // GET api/<BrandController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BrandController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("El Objeto Marca es Nulo");
            }
            var createdBrand = await _manageLogic.Brand.AddBrandAsync(brand);

            return CreatedAtAction("Get", new { id = createdBrand.Id }, createdBrand);
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("El Objeto Marca es Nulo");
            }
            var createdBrand = await _manageLogic.Brand.UpdateBrandAsync(id, brand);

            return CreatedAtAction("Get", new { id = createdBrand.Id }, createdBrand);

        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var createdBrand = await _manageLogic.Brand.DeleteBrandAsync(id);

            return CreatedAtAction("Get", new { id = createdBrand.Id }, createdBrand);

        }
    }
}
