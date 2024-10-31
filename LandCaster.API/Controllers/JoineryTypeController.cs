using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/joinerytypes")]
    [ApiController]
    public class JoineryTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public JoineryTypeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<JoineryTypeController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<JoineryType> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.JoineryType.GetJoineryTypeAsync(parameters);
        }

        // GET api/<JoineryTypeController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JoineryTypeController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddJoineryTypeDTO addJoineryTypeDTO)
        {
            if (addJoineryTypeDTO.JoineryType == null)
            {
                return BadRequest("El Objeto JoineryType es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdJoineryType = await _manageLogic.JoineryType.AddJoineryTypeAsync(addJoineryTypeDTO);

            return CreatedAtAction("Get", new { id = createdJoineryType.Id }, createdJoineryType);
        }

        // PUT api/<JoineryTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, JoineryType joineryType)
        {
            if (joineryType == null)
            {
                return BadRequest("El Objeto JoineryType es Nulo");
            }
            var createdJoineryType = await _manageLogic.JoineryType.UpdateJoineryTypeAsync(id, joineryType);

            return CreatedAtAction("Get", new { id = createdJoineryType.Id }, createdJoineryType);

        }

        // DELETE api/<JoineryTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdJoineryType = await _manageLogic.JoineryType.DeleteJoineryTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdJoineryType.Id }, createdJoineryType);

        }
    }
}
