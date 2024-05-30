using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class CurrencyExchangeRateController : Controller
    {
        private CurrencyExchangeRateServices _service;//constructor

        public CurrencyExchangeRateController(CurrencyExchangeRateServices service)
        {
            _service = service;
        }

        [Route("api/exchangerate")]
        [HttpPost]
        public async Task<IActionResult> SetupExchangeRate([FromBody] CurrencyExchangeRateModel model)
        {
            var dataResult = await _service.SetupExchangeRate(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [Route("api/exchangerate")]
        [HttpGet]
        public async Task<IActionResult> ExchangeRate()
        {
            var dataResult = await _service.GetExchangeRateList();
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/dailyexchangerate")]
        [HttpGet]
        public async Task<IActionResult> ExchangeRate(string currency, DateTime exchangeRateDate)
        {
            var dataResult = await _service.GetDailyExchangeRateByCurrency(currency, exchangeRateDate);
            if (dataResult == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/exchangerate")]
        [HttpPut]
        public async Task<IActionResult> UpdateExchangeRate([FromBody] CurrencyExchangeRateModel model)
        {
            var dataResult = await _service.UpdateExchangeRate(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [Route("api/exchangerate")]
        [HttpDelete]
        public async Task<IActionResult> DeteExchangeRate([FromBody] CurrencyExchangeRateModel model)
        {
            var dataResult = await _service.DeleteExchangeRate(model.Id);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
