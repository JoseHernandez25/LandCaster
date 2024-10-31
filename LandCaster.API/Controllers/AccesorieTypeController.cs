using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/accesorie-type")]
    [ApiController]
    public class AccesorieTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public AccesorieTypeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        // GET: api/<AccessoryTypeController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<AccessoryType>> Get(int pageNumber, int pageSize, string? term)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);


            return await _manageLogic.AccesorieType.GetAccessoryTypeAsync(parameters);
        }

        // GET api/<AccessoryTypeController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccessoryTypeController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(AccessoryType AccessoryType)
        {
            if (AccessoryType == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdAccessoryType = await _manageLogic.AccesorieType.AddAccessoryTypeAsync(AccessoryType);

            return CreatedAtAction("Get", new { id = createdAccessoryType.Id }, createdAccessoryType);
        }

        // PUT api/<AccessoryTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, AccessoryType AccessoryType)
        {
            if (AccessoryType == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdAccessoryType = await _manageLogic.AccesorieType.UpdateAccessoryTypeAsync(id, AccessoryType);

            return CreatedAtAction("Get", new { id = createdAccessoryType.Id }, createdAccessoryType);

        }

        // DELETE api/<AccessoryTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdAccessoryType = await _manageLogic.AccesorieType.DeleteAccessoryTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdAccessoryType.Id }, createdAccessoryType);

        }
    }
}
