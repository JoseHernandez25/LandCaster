using LandCaster.BLL;
using LandCaster.DAL.Repository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/drawer-slide-components")]
    [ApiController]
    public class DrawerSlideComponentController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public DrawerSlideComponentController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        [HttpGet, Authorize]
        public async Task<PaginationResponse<DrawerSlideComponent> >Get(
            int pageNumber,
            int PageSize,
            string? term = null,
            string? brandId = null,
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

            if (orderByAsc != null)
                parameters.Parameters.Add("orderByAsc", orderByAsc);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            return await _manageLogic.DrawerSlideComponent.GetDrawerSlideComponentAsync(parameters);
        }

        // GET api/<DrawerSlideComponentController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DrawerSlideComponentController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(DrawerSlideComponent drawerSlideComponent)
        {
            if (drawerSlideComponent == null)
            {
                return BadRequest("El objeto componente deslizante de cajón es nulo");
            }
            var createdDrawerSlideComponent = await _manageLogic.DrawerSlideComponent.AddDrawerSlideComponentAsync(drawerSlideComponent);

            return CreatedAtAction("Get", new { id = createdDrawerSlideComponent.Id }, createdDrawerSlideComponent);
        }

        // PUT api/<DrawerSlideComponentController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, DrawerSlideComponent drawerSlideComponent)
        {
            if (drawerSlideComponent == null)
            {
                return BadRequest("El objeto componente deslizante de cajón es nulo");
            }
            var updatedDrawerSlideComponent = await _manageLogic.DrawerSlideComponent.UpdateDrawerSlideComponentAsync(id, drawerSlideComponent);

            return CreatedAtAction("Get", new { id = updatedDrawerSlideComponent.Id }, updatedDrawerSlideComponent);
        }

        // DELETE api/<DrawerSlideComponentController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedDrawerSlideComponent = await _manageLogic.DrawerSlideComponent.DeleteDrawerSlideComponentAsync(id);

            return CreatedAtAction("Get", new { id = deletedDrawerSlideComponent.Id }, deletedDrawerSlideComponent);
        }

        // Obtener marcas
        [HttpGet("get-brands-drawer-slide-components"), Authorize]
        public async Task<List<Brand>> GetBrands()
        {
            return await _manageLogic.DrawerSlideComponent.GetBrands();
        }


        // get components by a
        [HttpGet("get-draweslide-components"), Authorize]
        public async Task<List<DrawerSlideComponent>> GetDrawerSlideComponents()
        {
            return await _manageLogic.DrawerSlideComponent.GetDrawerSlideComponents();
        }

        // PUT api/<DrawerSlideComponentController>/5
        [HttpPut("drawer-slide-drws-component/{id}"), Authorize]
        public async Task<IActionResult> PutDrawerDwrSlideComponent(int id, DrawerSlideDrwsComponent drawerSlideDrwsComponent)
        {
            if (drawerSlideDrwsComponent == null)
            {
                return BadRequest("El objeto componente deslizante de cajón es nulo");
            }
            var drawerSDrwsSlideComponents = await _manageLogic.DrawerSlideComponent.UpdatDrawerSlideDrwsComponentAsync(id, drawerSlideDrwsComponent);

            return CreatedAtAction("Get", new { drawerSDrwsSlideComponents });
        }
    }

}


