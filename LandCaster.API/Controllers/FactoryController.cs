using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/Factories")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public FactoryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<FactoryController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Factory>> Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Factory.GetFactoryAsync(parameters);
        }

        // GET api/<FactoryController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FactoryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Factory factory)
        {
            if (factory == null)
            {
                return BadRequest("El Objeto Fabrica es Nulo");
            }
            var createdFactory = await _manageLogic.Factory.AddFactoryAsync(factory);

            return CreatedAtAction("Get", new { id = createdFactory.Id }, createdFactory);
        }

        // PUT api/<FactoryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Factory factory)
        {
            if (factory == null)
            {
                return BadRequest("El Objeto fabrica es Nulo");
            }
            var createdFactory = await _manageLogic.Factory.UpdateFactoryAsync(id, factory);

            return CreatedAtAction("Get", new { id = createdFactory.Id }, createdFactory);

        }

        // DELETE api/<FactoryController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdFactory = await _manageLogic.Factory.DeleteFactoryAsync(id);

            return CreatedAtAction("Get", new { id = createdFactory.Id }, createdFactory);

        }
    }
}
