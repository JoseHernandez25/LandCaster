using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/inventories")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public InventoryController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<InventoryController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Inventory> >Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? orderByAsc = null,
            string? orderBy = null,
            string? code= null
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

            return await _manageLogic.Inventory.GetInventoryAsync(parameters);
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InventoryController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Inventory inventory)
        {
            if (inventory == null)
            {
                return BadRequest("El objeto Inventory es nulo.");
            }

            try
            {
                var createdInventory = await _manageLogic.Inventory.AddInventoryAsync(inventory);
                return CreatedAtAction(nameof(Get), new { id = createdInventory.Id }, createdInventory);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Inventory inventory)
        {
            if (inventory == null)
            {
                return BadRequest("El Objeto Product es Nulo");
            }
            var createdInventory = await _manageLogic.Inventory.UpdateInventoryAsync(id, inventory);

            return CreatedAtAction("Get", new { id = createdInventory.Id }, createdInventory);

        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdInventory = await _manageLogic.Inventory.DeleteInventoryAsync(id);

            return CreatedAtAction("Get", new { id = createdInventory.Id }, createdInventory);

        }

        [HttpGet("verify-code/{code}"), Authorize]
        public async Task<IActionResult> VerifyProduct(string code)
        {
            var product = await _manageLogic.Product.VerifyProduct(code);
            if (product is not null)
            {
                // Retorna el producto encontrado
                return Ok(product);
            }
            // Retorna mensaje indicando que el producto no fue encontrado
            return BadRequest(new { message = "Producto no encontrado" });
        }

        // GET: api/<EmployeeController>
        [HttpGet("get-all-products")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _manageLogic.Inventory.GetProductAsync();
        }

        [HttpGet("get-inventory-product/{code}")]
        public async Task<IActionResult> VerifyProductWithInv(string code)
        {
            var product = await _manageLogic.Inventory.getInvetoryOfProduct(code);
            if (product == null)
            {
                return BadRequest(new { message = "Producto no encontrado" });
            }

            return Ok(product);
        }
    }
}
