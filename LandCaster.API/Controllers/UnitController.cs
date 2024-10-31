using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public UnitController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        [HttpGet, Authorize]
        public async Task<PaginationResponse<Unit> >Get(int pageNumber, int pageSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                OrderBy = "DEC",
                Parameters = new Dictionary<string, object> { { "term", term } }
            };

            return await _manageLogic.Unit.GetUnitAsync(parameters);
        }


        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("get-all"), Authorize]
        public async Task<List<Unit>> GetAll()
        {          
            return await _manageLogic.Unit.GetAllUnitsAsync();
        }

    }
}
