using LandCaster.BLL;
using LandCaster.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LandCaster.API.Controllers
{
    [Route("api/financing-parameters")]
    [ApiController]
    public class FinancingParametersController : ControllerBase
    {
        private readonly IManageLogic _manageLogic;

        public FinancingParametersController(IManageLogic manageLogic)
        {
            _manageLogic = manageLogic;

        }
        // GET: api/<FinancingParametersController>
        [HttpGet, Authorize]
        public async Task<List<FinancingParameter>>Get()
        {
            return await _manageLogic.FinancingParameter.GetFinancingParameterAsync();
        }

        // GET api/<FinancingParametersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FinancingParametersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FinancingParametersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FinancingParametersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
