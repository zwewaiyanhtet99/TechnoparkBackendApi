using Microsoft.AspNetCore.Mvc;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class CommissionController : Controller
    {
        private CommissionServices _service;

        public CommissionController(CommissionServices service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/commission")]
        public async Task<IActionResult> GetCommission()
        {
            var dataResult = await _service.GetCommission();
            return Ok(dataResult);
        }

        [HttpPost]
        [Route("api/commission")]
        public async Task<IActionResult> SetupCommission([FromBody] CommissionModel model)
        {
            var dataResult = await _service.CreateCommission(model);
            return dataResult > 0 ? Ok("Success") : BadRequest();
        }

        [HttpPut]
        [Route("api/commission")]
        public async Task<IActionResult> UpdateCommission([FromBody] CommissionModel model)
        {
            var dataResult = await _service.UpdateCommission(model);
            return dataResult > 0 ? Ok("Success") : BadRequest();
        }
    }
}
