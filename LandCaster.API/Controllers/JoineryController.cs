using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/joineries")]
    [ApiController]
    public class JoineryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public JoineryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<JoineryController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Joinery> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Joinery.GetJoineryAsync(parameters);
        }

        // GET api/<JoineryController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JoineryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddJoineryDTO addJoineryDTO)
        {
            if (addJoineryDTO.Joinery == null)
            {
                return BadRequest("El Objeto Joinery es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdJoinery = await _manageLogic.Joinery.AddJoineryAsync(addJoineryDTO);

            return CreatedAtAction("Get", new { id = createdJoinery.Id }, createdJoinery);
        }

        // PUT api/<JoineryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Joinery joinery)
        {
            if (joinery == null)
            {
                return BadRequest("El Objeto Joinery es Nulo");
            }
            var createdJoinery = await _manageLogic.Joinery.UpdateJoineryAsync(id, joinery);

            return CreatedAtAction("Get", new { id = createdJoinery.Id }, createdJoinery);

        }

        // DELETE api/<JoineryController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdJoinery = await _manageLogic.Joinery.DeleteJoineryAsync(id);

            return CreatedAtAction("Get", new { id = createdJoinery.Id }, createdJoinery);

        }
    }
}
