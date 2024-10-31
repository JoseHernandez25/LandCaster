using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/TypesBoxJournies")]
    [ApiController]
    public class TypesBoxJourneyController : ControllerBase
    {

        private readonly IManageLogic _manageLogic;

        public TypesBoxJourneyController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<TypesBoxJourneyController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<TypesBoxJourney> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.TypesBoxJourney.GetTypesBoxJourneyAsync(parameters);
        }

        // GET api/<TypesBoxJourneyController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypesBoxJourneyController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddTypesBoxJourneyDTO addTypesBoxJourneyDTO)
        {
            if (addTypesBoxJourneyDTO.TypesBoxJourney == null)
            {
                return BadRequest("El Objeto TypesBoxJourney es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdTypesBoxJourney = await _manageLogic.TypesBoxJourney.AddTypesBoxJourneyAsync(addTypesBoxJourneyDTO);

            return CreatedAtAction("Get", new { id = createdTypesBoxJourney.Id }, createdTypesBoxJourney);
        }

        // PUT api/<TypesBoxJourneyController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, TypesBoxJourney typesBoxJourney)
        {
            if (typesBoxJourney == null)
            {
                return BadRequest("El Objeto TypesBoxJourney es Nulo");
            }
            var createdTypesJournery = await _manageLogic.TypesBoxJourney.UpdateTypesBoxJourneyAsync(id, typesBoxJourney);

            return CreatedAtAction("Get", new { id = createdTypesJournery.Id }, createdTypesJournery);

        }

        // DELETE api/<TypesBoxJourneyController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdTypesJournery = await _manageLogic.TypesBoxJourney.DeleteTypesBoxJourneyAsync(id);

            return CreatedAtAction("Get", new { id = createdTypesJournery.Id }, createdTypesJournery);

        }
    }
}
