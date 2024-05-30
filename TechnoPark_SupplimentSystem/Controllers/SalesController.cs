using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class SalesController : Controller
    {
        private SalesServices _service;

        public SalesController(SalesServices service)
        {
            _service = service;
        }

        [Route("api/sale")]
        [HttpPost]
        public async Task<IActionResult> AddSale([FromBody] SalesModel model)
        {
            var dataResult = await _service.AddSale(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [Route("api/salelist")]
        [HttpPost]
        public async Task<IActionResult> SaleList([FromBody] SaleListRequestModel model)
        {
            var dataResult = await _service.SaleList(model);
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/sale")]
        [HttpPut]
        public async Task<IActionResult> UpdateSale([FromBody] SalesModel model)
        {
            var dataResult = await _service.UpdateSale(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [HttpDelete]
        [Route("api/sale")]
        public async Task<IActionResult> DeleteSale(int Id, int deletedBy)
        {
            var dataResult = await _service.DeleteSaleRecord(Id, deletedBy);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
