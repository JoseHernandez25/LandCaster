using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/materialtypes")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public MaterialTypeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<MaterialTypeController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<MaterialType> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.MaterialType.GetMaterialTypeAsync(parameters);
        }


        // GET api/<MaterialTypeController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MaterialTypeController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(MaterialType materialType)
        {
            if (materialType == null)
            {
                return BadRequest("El Objeto Clase Material es Nulo");
            }
            var createdMaterialType = await _manageLogic.MaterialType.AddMaterialTypeAsync(materialType);

            return CreatedAtAction("Get", new { id = createdMaterialType.Id }, createdMaterialType);
        }

        // PUT api/<MaterialTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, MaterialType materialType)
        {
            if (materialType == null)
            {
                return BadRequest("El Objeto Clase Material es Nulo");
            }
            var createdMaterialType = await _manageLogic.MaterialType.UpdateMaterialTypeAsync(id, materialType);

            return CreatedAtAction("Get", new { id = createdMaterialType.Id }, createdMaterialType);

        }

        // DELETE api/<MaterialTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdMaterialType = await _manageLogic.MaterialType.DeleteMaterialTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdMaterialType.Id }, createdMaterialType);

        }
    }
}
