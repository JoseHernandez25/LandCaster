using LandCaster.BLL;
using LandCaster.DAL.Migrations;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.DrawerSlidesTypesDTO;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/hinge-Type")]
    [ApiController]
    public class HingeTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public HingeTypeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        [HttpGet, Authorize]
        public async Task<PaginationResponse<HingeType> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? brandId = null,
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

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            if (withTrashed != null)
                parameters.Parameters.Add("withTrashed", withTrashed);

            return await _manageLogic.HingeType.GetHingeTypeAsync(parameters);
        }

        // GET api/<HingeTypeController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<HingeTypeController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(AddHingeTypeDTO addHingeTypeDTO)
        {
            if (addHingeTypeDTO == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdHingeType = await _manageLogic.HingeType.AddHingeTypeAsync(addHingeTypeDTO);

            return CreatedAtAction("Get", new { id = createdHingeType.Id }, createdHingeType);
        }

        // PUT api/<HingeTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, HingeType HingeType)
        {
            if (HingeType == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdHingesTypes = await _manageLogic.HingeType.UpdateHingeTypeAsync(id, HingeType);

            return CreatedAtAction("Get", new { id = createdHingesTypes.Id }, createdHingesTypes);

        }



        // DELETE api/<HingeTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdHingeType = await _manageLogic.HingeType.DeleteHingeTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdHingeType.Id }, createdHingeType);

        }

        // get brands
        [HttpGet("get-brands-hinges-types"), Authorize]
        public async Task<List<Brand>> getBrands()
        {
            return await _manageLogic.HingeType.GetBrands();

        }

       
    }
}
