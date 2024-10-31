using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/product-events")]
    [ApiController]
    public class ProductEventController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public ProductEventController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<ProductEventController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<ProductEvent>> Get(
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

            if (withTrashed != null)
                parameters.Parameters.Add("withTrashed", withTrashed);

            return await _manageLogic.ProductEvent.GetProductEventAsync(parameters);
        }



        // GET api/<ProductEventController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductEventController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(ProductEvent productevent)
        {
            if (productevent == null)
            {
                return BadRequest("El Objeto productevent es Nulo");
            }

            try
            {
                var createdProductEvent = await _manageLogic.ProductEvent.AddProductEventAsync(productevent);
                return CreatedAtAction("Get", new { id = createdProductEvent.Id }, createdProductEvent);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<ProductEventController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, ProductEvent productevent)
        {
            if (productevent == null)
            {
                return BadRequest("El Objeto productevent es Nulo");
            }

            try
            {
                var updatedProductEvent = await _manageLogic.ProductEvent.UpdateProductEventAsync(id, productevent);
                return CreatedAtAction("Get", new { id = updatedProductEvent.Id }, updatedProductEvent);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<ProductEventController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdProductEvent = await _manageLogic.ProductEvent.DeleteProductEventAsync(id);

            return CreatedAtAction("Get", new { id = createdProductEvent.Id }, createdProductEvent);

        }

    }
}
