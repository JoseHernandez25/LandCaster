using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/external-Accessory")]
    [ApiController]
    public class ExternalAccessoryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public ExternalAccessoryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        [HttpGet, Authorize]
        public async Task<PaginationResponse<ExternalAccessory>> Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? brandId = null,
            string? AccesorieTypeId = null,
            string? supplierId = null,
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

            if (brandId != null)
                parameters.Parameters.Add("brandId", brandId);

            if (AccesorieTypeId != null)
                parameters.Parameters.Add("AccesorieTypeId", AccesorieTypeId);


            if (supplierId != null)
                parameters.Parameters.Add("supplierId", supplierId);

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            if (withTrashed != null)
                parameters.Parameters.Add("withTrashed", withTrashed);

            return await _manageLogic.ExternalAccessory.GetExternalAccessoryAsync(parameters);
        }

        // GET api/<ExternalAccessoryController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExternalAccessoryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(ExternalAccessory ExternalAccessory)
        {
            if (ExternalAccessory == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdExternalAccessory = await _manageLogic.ExternalAccessory.AddExternalAccessoryAsync(ExternalAccessory);

            return CreatedAtAction("Get", new { id = createdExternalAccessory.Id }, createdExternalAccessory);
        }

        // PUT api/<ExternalAccessoryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, ExternalAccessory ExternalAccessory)
        {
            if (ExternalAccessory == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdExternalAccessory = await _manageLogic.ExternalAccessory.UpdateExternalAccessoryAsync(id, ExternalAccessory);

            return CreatedAtAction("Get", new { id = createdExternalAccessory.Id }, createdExternalAccessory);

        }

        // DELETE api/<ExternalAccessoryController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdExternalAccessory = await _manageLogic.ExternalAccessory.DeleteExternalAccessoryAsync(id);

            return CreatedAtAction("Get", new { id = createdExternalAccessory.Id }, createdExternalAccessory);

        }

        // get brands
        [HttpGet("get-brands-external-Accessory"), Authorize]
        public Task<List<Brand>> getBrands()
        {
            return _manageLogic.ExternalAccessory.GetBrands();

        }

        [HttpGet("get-accesories-external-Accessory"), Authorize]
        public Task<List<AccessoryType>> GetAccesorieTypes()
        {
            return _manageLogic.ExternalAccessory.GetAccesorieType();

        }

        [HttpGet("get-supplier-external-Accessory"), Authorize]
        public Task<List<Supplier>> getSuppliers()
        {
            return _manageLogic.ExternalAccessory.GetSuppliers();

        }
    }
}
