using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechnoPark_SupplimentSystem.Models;
using TechnoPark_SupplimentSystem.Services;

namespace TechnoPark_SupplimentSystem.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryServices _categoryService;

        public CategoryController(CategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("api/category")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel model)
        {
            var dataResult = await _categoryService.CreateCategory(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [Route("api/category")]
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var dataResult = await _categoryService.CategoryList();
            return Content(JsonConvert.SerializeObject(dataResult), "application/json");
        }

        [Route("api/category")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel model)
        {
            var dataResult = await _categoryService.UpdateCategory(model);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }

        [Route("api/category")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] CategoryModel model)
        {
            var dataResult = await _categoryService.DeleteCategory(model.Id);
            return dataResult > 0 ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status409Conflict);
        }
    }
}
