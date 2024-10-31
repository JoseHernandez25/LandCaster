using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.DrawerSlidesTypesDTO;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/drawer-slide-type")]
    [ApiController]
    public class DrawerSlideTypeController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public DrawerSlideTypeController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        [HttpGet, Authorize]
        public async Task<PaginationResponse<DrawerSlideType>> Get([FromQuery] GetDrawerSlideTypesDTO getDrawerSlideTypesDTO)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = getDrawerSlideTypesDTO.pageNumber,
                PageSize = getDrawerSlideTypesDTO.pageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (getDrawerSlideTypesDTO.term != null)
                parameters.Parameters.Add("term", getDrawerSlideTypesDTO.term);


            if (getDrawerSlideTypesDTO.orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", getDrawerSlideTypesDTO.orderByAsc);

            if (getDrawerSlideTypesDTO.orderBy != null)
                parameters.Parameters.Add("orderBy", getDrawerSlideTypesDTO.orderBy);

            if (getDrawerSlideTypesDTO.withTrashed != null)
                parameters.Parameters.Add("withTrashed", getDrawerSlideTypesDTO.withTrashed);
            if (getDrawerSlideTypesDTO.isSimple != null)
                parameters.Parameters.Add("isSimple", getDrawerSlideTypesDTO.isSimple);

            return await _manageLogic.DrawerSlideType.GetDrawerSlideTypeAsync(parameters);
        }

        // GET api/<DrawerSlideTypeController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("get-all"), Authorize]
        public async Task<List<DrawerSlideType>> GetAllDrawerSlideTypes()
        {
            return await _manageLogic.DrawerSlideType.GetAllDrawerSlideTypesAsync();
        }


        [HttpPost, Authorize]
        public async Task<IActionResult> Post(AddDrawerSlideTypeDTO addDrawerSlideTypeDTO)
        {
            if (addDrawerSlideTypeDTO == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdDrawerSlideType = await _manageLogic.DrawerSlideType.AddDrawerSlideTypeAsync(addDrawerSlideTypeDTO);

            return CreatedAtAction("Get", new { id = createdDrawerSlideType.Id }, createdDrawerSlideType);
        }
        // PUT api/<DrawerSlideTypeController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, DrawerSlideType DrawerSlideType)
        {
            if (DrawerSlideType == null)
            {
                return BadRequest("El Objeto otro accesorio es Nulo");
            }
            var createdDrawerSlideType = await _manageLogic.DrawerSlideType.UpdateDrawerSlideTypeAsync(id, DrawerSlideType);

            return CreatedAtAction("Get", new { id = createdDrawerSlideType.Id }, createdDrawerSlideType);

        }

        // DELETE api/<DrawerSlideTypeController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdDrawerSlideType = await _manageLogic.DrawerSlideType.DeleteDrawerSlideTypeAsync(id);

            return CreatedAtAction("Get", new { id = createdDrawerSlideType.Id }, createdDrawerSlideType);

        }
    }
}
