using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/drawer-slide")]
    [ApiController]
    public class DrawerSlideController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public DrawerSlideController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        [HttpGet, Authorize]
        public async Task<PaginationResponse<DrawerSlide> >Get(
     int pageNumber,
     int PageSize,
     string? term = null,
     string? brandId = null,
     string? DrawerSlideTypeId = null,
     string? orderByAsc = null,
     string? orderBy = null)
        {
            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = PageSize,
                Parameters = new Dictionary<string, object>()
            };

            if (term != null)
                parameters.Parameters.Add("term", term);

            if (brandId != null)
                parameters.Parameters.Add("brandId", brandId);

            if (DrawerSlideTypeId != null)
                parameters.Parameters.Add("DrawerSlideTypeId", DrawerSlideTypeId);

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            //if (isSimple != null)
            //    parameters.Parameters.Add("isSimple", isSimple);

            return await _manageLogic.DrawerSlide.GetDrawerSlideAsync(parameters);
        }

        // GET api/<DrawerSlideController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] AddDrawerSlideDTO addDrawerSlideDTO)
        {
            if (addDrawerSlideDTO.DrawerSlide == null)
            {
                return BadRequest("El Objeto corredera es Nulo");
            }


            var createdDrawerSlide = await _manageLogic.DrawerSlide.AddDrawerSlideAsync(addDrawerSlideDTO);

            return CreatedAtAction("Get", new { id = createdDrawerSlide.Id }, createdDrawerSlide);
        }



        // PUT api/<DrawerSlideController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, UpdateDrawerSlideDTO updateDrawerSlideDTO)
        {
            if (updateDrawerSlideDTO.DrawerSlide == null)
            {
                return BadRequest("El objeto componente deslizante de cajón es nulo");
            }
            var updatedDrawerSlide = await _manageLogic.DrawerSlide.UpdateDrawerSlideAsync(id, updateDrawerSlideDTO);

            return CreatedAtAction("Get", new { id = updatedDrawerSlide.Id }, updatedDrawerSlide);
        }


        [HttpPut("without-modifying-components/{id}"), Authorize]
        public async Task<IActionResult> PutWithoutModifyingComponents(int id, DrawerSlide drawerSlide)
        {
            if (drawerSlide == null)
            {
                return BadRequest("El objeto componente deslizante de cajón es nulo");
            }

            var updatedDrawerSlide = await _manageLogic.DrawerSlide.UpdateDrawerSlideWithoutModifyingComponentsAsync(id, drawerSlide);

            return CreatedAtAction("Get", new { id = updatedDrawerSlide.Id }, updatedDrawerSlide);
        }


        // DELETE api/<DrawerSlideController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedDrawerSlide = await _manageLogic.DrawerSlide.DeleteDrawerSlideAsync(id);

            return CreatedAtAction("Get", new { id = deletedDrawerSlide.Id }, deletedDrawerSlide);
        }

        // Obtener marcas
        [HttpGet("get-brands-drawer-slide"), Authorize]
        public async Task<List<Brand>> GetBrands()
        {
            return await _manageLogic.DrawerSlide.GetBrands();
        }
    }

}
