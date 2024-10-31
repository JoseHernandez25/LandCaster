using LandCaster.BLL;
using LandCaster.DAL.Migrations;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.FurnituresDTOS;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{

    [Route("api/furnitures")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public FurnitureController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<FurnitureController>
        [HttpGet]
        public async  Task<PaginationResponse<Furniture>> Get([FromQuery]  GetFurnituresDTO getFurnituresDTO)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = getFurnituresDTO.pageNumber,
                PageSize = getFurnituresDTO.pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (getFurnituresDTO.term != null)
                parameters.Parameters.Add("term", getFurnituresDTO.term);


            if (getFurnituresDTO.withTrashed != null)
                parameters.Parameters.Add("withTrashed", getFurnituresDTO.withTrashed);

            return await _manageLogic.Furniture.GetFurnituresAsync(parameters);
        }

        // GET api/<FurnitureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FurnitureController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FurnitureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FurnitureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
