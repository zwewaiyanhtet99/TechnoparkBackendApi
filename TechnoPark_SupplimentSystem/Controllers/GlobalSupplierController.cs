using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class GlobalSupplierController : Controller
    {
        private GlobalSupplierServices _globalSupplierServices;

        public GlobalSupplierController(GlobalSupplierServices globalSupplierServices)
        {
            _globalSupplierServices = globalSupplierServices;
        }

        [Route("api/supplier/global")]
        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] GlobalSupplierModel model)
        {
            var dataResult = await _globalSupplierServices.CreateSupplier(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }

        [Route("api/supplier/global")]
        [HttpGet]
        public async Task<IActionResult> SupplierList()
        {
            var dataResult = await _globalSupplierServices.GlobalSupplierList();
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/supplier/global")]
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] GlobalSupplierModel model)
        {
            var dataResult = await _globalSupplierServices.UpdateGlobalSupplier(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }

        [Route("api/supplier/global")]
        [HttpDelete]
        public async Task<IActionResult> DeletSupplier([FromBody] GlobalSupplierModel model)
        {
            var dataResult = await _globalSupplierServices.DeleteGlobalSupplier(model.NO);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
