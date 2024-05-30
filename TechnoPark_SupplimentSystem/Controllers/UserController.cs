using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class UserController : Controller
    {
        private UserServiecs _userServices;

        public UserController(UserServiecs userServices)
        {
            _userServices = userServices;
        }

        [Route("api/user")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            var dataResult = await _userServices.RegisterUser(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [Route("api/user/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            var dataResult = await _userServices.Login(model.UserName, model.Password);
            return dataResult != null ? StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(dataResult))
                : StatusCode(StatusCodes.Status401Unauthorized);
        }

        [Route("api/user")]
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var dataResult = await _userServices.UserList();
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/user")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel model)
        {
            var dataResult = await _userServices.UpdateUser(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }

        [Route("api/user")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] UserModel model)
        {
            var dataResult = await _userServices.DeleteUser(model.UserID);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
