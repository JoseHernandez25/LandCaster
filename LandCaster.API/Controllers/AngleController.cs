using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/angle")]
    [ApiController]
    public class AngleController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public AngleController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        // GET: api/<AngleController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Angle>> Get(int pageNumber, int pageSize, string? term)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);


            return await _manageLogic.Angle.GetAngleAsync(parameters);
        }

        // GET api/<AngleController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AngleController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Angle Angle)
        {
            if (Angle == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdAngle = await _manageLogic.Angle.AddAngleAsync(Angle);

            return CreatedAtAction("Get", new { id = createdAngle.Id }, createdAngle);
        }

        // PUT api/<AngleController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Angle Angle)
        {
            if (Angle == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdAngle = await _manageLogic.Angle.UpdateAngleAsync(id, Angle);

            return CreatedAtAction("Get", new { id = createdAngle.Id }, createdAngle);

        }

        // DELETE api/<AngleController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdAngle = await _manageLogic.Angle.DeleteAngleAsync(id);

            return CreatedAtAction("Get", new { id = createdAngle.Id }, createdAngle);

        }
    }
}
