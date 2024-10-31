using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/materials")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public MaterialController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<MaterialController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Material> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO();

            parameters.PageNumber = pageNumber;
            parameters.PageSize = pageSize;
            parameters.OrderBy = "DEC";
            parameters.Parameters = new Dictionary<string, object> { { "term", term } };

            return await _manageLogic.Material.GetMaterialAsync(parameters);
        }

        // GET api/<MaterialController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MaterialController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Material material)
        {
            if (material == null)
            {
                return BadRequest("El Objeto Material es Nulo");
            }


            var createdMaterial = await _manageLogic.Material.AddMaterialAsync(material);

            return CreatedAtAction("Get", new { id = createdMaterial.Id }, createdMaterial);
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Material material)
        {
            if (material == null)
            {
                return BadRequest("El Objeto Material es Nulo");
            }
            var createdMaterial = await _manageLogic.Material.UpdateMaterialAsync(id, material);

            return CreatedAtAction("Get", new { id = createdMaterial.Id }, createdMaterial);

        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdMaterial = await _manageLogic.Material.DeleteMaterialAsync(id);

            return CreatedAtAction("Get", new { id = createdMaterial.Id }, createdMaterial);

        }

        [HttpGet("get-doormodel-material-materialtype"), Authorize]
        public async Task<List<MaterialType>> GetMaterialType()
        {
            return await _manageLogic.Material.GetMaterialType();
        }

        [HttpGet("get-material-by-materialtype/{materialtypeId}"), Authorize]
        public async Task<List<Material>> GetComponentsByBrand(int materialtypeId)
        {
            return await _manageLogic.Material.GetMaterialByMaterialType(materialtypeId);
        }
    }
}
