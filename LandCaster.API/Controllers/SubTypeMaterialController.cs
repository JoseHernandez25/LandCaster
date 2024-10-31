using LandCaster.BLL;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/subtypematerials")]
    [ApiController]
    public class SubTypeMaterialController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public SubTypeMaterialController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<SubTypeMaterialController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<SubTypeMaterial> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.SubTypeMaterial.GetSubTypeMaterialAsync(parameters);
        }

        // GET api/<SubTypeMaterialController>/5
        [HttpGet("{id}"), Authorize]
        public async Task<SubTypeMaterial> Get(int id)
        {
            return await _manageLogic.SubTypeMaterial.GetSubTypeMaterialByFinish(id);

        }

        // POST api/<SubTypeMaterialController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddSubTypeMaterialDTO addSubTypeMaterialDTO)
        {
            if (addSubTypeMaterialDTO.SubTypeMaterial == null)
            {
                return BadRequest("El Objeto SubtypeMaterial es Nulo");
            }

            // Puedes realizar lógica adicional aquí, como validaciones, antes de agregar el color.
            // Por ejemplo, podrías verificar si el color ya existe, etc.

            var createdSubTypeMaterial = await _manageLogic.SubTypeMaterial.AddSubTypeMaterialAsync(addSubTypeMaterialDTO);

            return CreatedAtAction("Get", new { id = createdSubTypeMaterial.Id }, createdSubTypeMaterial);
        }

        // PUT api/<SubTypeMaterialController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, SubTypeMaterial subTypeMaterial)
        {
            if (subTypeMaterial == null)
            {
                return BadRequest("El Objeto SubClase Material es Nulo");
            }
            var createdSubTypeMaterial = await _manageLogic.SubTypeMaterial.UpdateSubTypeMaterialAsync(id, subTypeMaterial);

            return CreatedAtAction("Get", new { id = createdSubTypeMaterial.Id }, createdSubTypeMaterial);

        }

        // DELETE api/<SubTypeMaterialController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdSubTypeMaterial = await _manageLogic.SubTypeMaterial.DeleteSubTypeMaterialAsync(id);

            return CreatedAtAction("Get", new { id = createdSubTypeMaterial.Id }, createdSubTypeMaterial);

        }

        [HttpGet("get-subTypeMaterial"), Authorize]
        public async Task<IEnumerable<SubTypeMaterial>> GetSubtypeMaterial()
        {
            return await _manageLogic.SubTypeMaterial.GetSubTypeMaterial();
        }

        [HttpPost("add-finish")]
        public async Task<IActionResult> AddFinishToSubTypeMaterial([FromBody] AddFinishToSubTypeDTO addFinishToSubTypeMaterialDTO)
        {
            try
            {
                await _manageLogic.SubTypeMaterial.AddFinishToSubTypeMaterialAsync(addFinishToSubTypeMaterialDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("remove-finish/{subTypeMaterialId}/{finishId}"), Authorize]
        public async Task<IActionResult> RemoveFinishFromSubTypeMaterial(int subTypeMaterialId, int finishId)
        {
            try
            {
                var dto = new AddFinishToSubTypeDTO
                {
                    SubTypeMaterialId = subTypeMaterialId,
                    FinishId = finishId
                };

                await _manageLogic.SubTypeMaterial.RemoveFinishFromSubTypeMaterialAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
