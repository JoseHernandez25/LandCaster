using LandCaster.BLL;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencieController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public CurrencieController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<CurrencieController>
        [HttpGet, Authorize]
        public async Task<List<Currencie>>Get()
        {
            return await _manageLogic.Currencie.GetCurrencieAsync();
        }

        // GET api/<CurrencieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CurrencieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CurrencieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CurrencieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
