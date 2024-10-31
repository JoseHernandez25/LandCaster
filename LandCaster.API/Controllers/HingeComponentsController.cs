using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/hinge-components")]
    [ApiController]
    public class HingeComponentController : ControllerBase
    {

        private readonly IManageLogic _manageLogic;

        public HingeComponentController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<HingeComponentsController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<HingeComponent> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? brandId = null,
            string? orderByAsc = null,
            string? orderBy = null

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

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.HingeComponent.GetHingeComponentAsync(parameters);
        }


        // GET api/<HingeComponentsController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HingeComponentsController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(HingeComponent hingeComponent)
        {
            if (hingeComponent == null)
            {
                return BadRequest("El Objeto componente bisagra es Nulo");
            }
            var createdHingeComponent = await _manageLogic.HingeComponent.AddHingeComponentAsync(hingeComponent);

            return CreatedAtAction("Get", new { id = createdHingeComponent.Id }, createdHingeComponent);
        }

        // PUT api/<HingeComponentsController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, HingeComponent hingeComponent)
        {
            if (hingeComponent == null)
            {
                return BadRequest("El Objeto Objeto componente bisagra es Nulo");
            }
            var updatedHingeComponent = await _manageLogic.HingeComponent.UpdateHingeComponentAsync(id, hingeComponent);

            return CreatedAtAction("Get", new { id = updatedHingeComponent.Id }, updatedHingeComponent);
        }

        // DELETE api/<HingeComponentsController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedHingeComponent = await _manageLogic.HingeComponent.DeleteHingeComponentAsync(id);

            return CreatedAtAction("Get", new { id = deletedHingeComponent.Id }, deletedHingeComponent);
        }

        // get brands
        [HttpGet("get-hinge-component-brands"), Authorize]
        public async Task<List<Brand>> GetBrands()
        {
            return await _manageLogic.HingeComponent.GetBrands();
        }


        // get components by a
        [HttpGet("get-components-by-brand/{brandId}"), Authorize]
        public async Task<List<HingeComponent>> GetComponentsByBrand(int brandId)
        {
            return await _manageLogic.HingeComponent.GetComponentsByBrand(brandId);
        }
    }
}
 