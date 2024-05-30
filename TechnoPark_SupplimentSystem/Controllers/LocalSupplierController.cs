using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class LocalSupplierController : Controller
    {
        private LocalSupplierServices _localSupplierServices;

        public LocalSupplierController(LocalSupplierServices localSupplierServices)
        {
            _localSupplierServices = localSupplierServices;
        }

        [Route("api/supplier/local")]
        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] LocalSupplierModel model)
        {
            var dataResult = await _localSupplierServices.CreateSupplier(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }

        [Route("api/supplier/local")]
        [HttpGet]
        public async Task<IActionResult> SupplierList()
        {
            var dataResult = await _localSupplierServices.GlobalSupplierList();
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/supplier/local")]
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] LocalSupplierModel model)
        {
            var dataResult = await _localSupplierServices.UpdateGlobalSupplier(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }

        [Route("api/supplier/local")]
        [HttpDelete]
        public async Task<IActionResult> DeletSupplier([FromBody] LocalSupplierModel model)
        {
            var dataResult = await _localSupplierServices.DeleteGlobalSupplier(model.NO);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
