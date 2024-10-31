using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public SupplierController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;
        }

        // GET: api/<SupplierController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Supplier> >Get(int pageNumber, int pagesSize, string? term)
        {
            if (term is null) term = "";

            var parameters = new PaginationDTO
            {
                PageNumber = pageNumber,
                PageSize = pagesSize,
                OrderBy = "DEC", // ¿Qué es "DEC"? Debes proporcionar la lógica correcta aquí
                Parameters = new Dictionary<string, object> { { "term", term } }
            };

            return await _manageLogic.Supplier.GetSupplierAsync(parameters);
        }

        // GET api/SupplierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
