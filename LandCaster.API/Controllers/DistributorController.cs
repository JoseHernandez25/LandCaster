using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LandCaster.API.Controllers
{
    [Route("api/distributors")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;
        public DistributorController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Distributor> >Get(
               int pageNumber,
               int pageSize,
               string? term,
               string? orderByAsc = null,
               string? orderBy = null,
               string? roleId = null
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

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.Distributor.GetDistributorAsync(parameters);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Distributor distributor)
        {
            if (distributor == null)
            {
                return BadRequest("El Objeto distribuidor es Nulo");
            }

            var createdDistributor = await _manageLogic.Distributor.AddDistributorAsync(distributor);

            return CreatedAtAction("Get", new { id = createdDistributor.Id }, createdDistributor);
        }
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Distributor distributor)
        {
            if (distributor == null)
            {
                return BadRequest("El objeto distribuidor es nulo");
            }
            var createdDistributor = await _manageLogic.Distributor.UpdateDistributorAsync(id, distributor);
            return CreatedAtAction("Get", new { id = createdDistributor.Id }, createdDistributor);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var createdDistributor = await _manageLogic.Distributor.DeleteDistributorAsync(id);
            return CreatedAtAction("Get", new { Id = createdDistributor.Id }, createdDistributor);
        }
    }
}
