using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public ProductController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<ProductController>
        [HttpGet, Authorize]
        public async Task<PaginationResponse<Product>>Get(
            int pageNumber,
            int pageSize,
            string? term = null,
            string? orderByAsc = null,
            string? orderBy = null,
            string? brandId = null,
            string? withTrashed = null,
            string? subsubcategoryId = null
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

            if (brandId != null)
                parameters.Parameters.Add("brandId", brandId);

            if (orderBy != null)
                parameters.Parameters.Add("orderBy", orderBy);

            if (withTrashed != null)
                parameters.Parameters.Add("withTrashed", withTrashed);

            if (subsubcategoryId != null)
                parameters.Parameters.Add("subsubcategoryId", subsubcategoryId);

            return await _manageLogic.Product.GetProductAsync(parameters);
        }


        // GET api/<ProductController>/5
        [HttpGet("{id}"), Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest("El Objeto Product es Nulo");
            }
            var existProduct = await _manageLogic.Product.VerifyProduct(product.Code);
            if (existProduct is not null)
            {
                return BadRequest("El producto ya existe");
            }
            var createdProduct = await _manageLogic.Product.AddProductAsync(product);

            return CreatedAtAction("Get", new { id = createdProduct.Id }, createdProduct);
        }


        // PUT api/<ProductController>/5
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, Product product)
        { 
            if (product == null)
            {
                return BadRequest("El Objeto Product es Nulo");
            }
            var createdProduct = await _manageLogic.Product.UpdateProductAsync(id, product);

            return CreatedAtAction("Get", new { id = createdProduct.Id }, createdProduct);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var createdProduct = await _manageLogic.Product.DeleteProductAsync(id);

            return CreatedAtAction("Get", new { id = createdProduct.Id }, createdProduct);

        }

        [HttpGet("get-brands-product"), Authorize]
        public async Task<List<Brand>> GetBrands()
        {
            return await _manageLogic.Product.GetBrands();
        }

        [HttpGet("verify-code/{code}"), Authorize]
        public async Task<IActionResult> VerifyProduct(string code)
        {
            var existProduct = await _manageLogic.Product.VerifyProduct(code);
            if (existProduct is not null)
            {
                return BadRequest(new { message = "El codigo " + code + " ya esta asignado a un producto." });
            }
            return Ok(new { message = "Codigo disponible" });
        }

    }
}
