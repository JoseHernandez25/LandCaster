using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/product-event-detail")]
    [ApiController]
    public class ProductEventDetailController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public ProductEventDetailController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<ProductEventDetailController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<ProductEventDetail>> Get(
            int pageNumber,
            int pageSize,
            string? term = null,
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

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            //if (withTrashed != null)
            //    parameters.Parameters.Add("withTrashed", withTrashed);

            return await _manageLogic.ProductEventDetail.GetProductEventDetailAsync(parameters);
        }

        // GET api/<ProductEventDetailController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductEventDetailController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(ProductEventDetail producteventdetail)
        {
            if (producteventdetail == null)
            {
                return BadRequest("El Objeto product event detail es Nulo");
            }
            var createdProductEventDetail = await _manageLogic.ProductEventDetail.AddProductEventDetailAsync(producteventdetail);

            return CreatedAtAction("Get", new { id = createdProductEventDetail.Id }, createdProductEventDetail);
        }

        // PUT api/<ProductEventDetailController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, ProductEventDetail producteventdetail)
        {
            if (producteventdetail == null)
            {
                return BadRequest("El Objeto product event detail es Nulo");
            }
            var createdProductEventDetail = await _manageLogic.ProductEventDetail.UpdateProductEventDetailAsync(id, producteventdetail);

            return CreatedAtAction("Get", new { id = createdProductEventDetail.Id }, createdProductEventDetail);

        }

        // DELETE api/<ProductEventDetailController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdProductEventDetail = await _manageLogic.ProductEventDetail.DeleteProductEventDetailAsync(id);

            return CreatedAtAction("Get", new { id = createdProductEventDetail.Id }, createdProductEventDetail);

        }
    }
}
