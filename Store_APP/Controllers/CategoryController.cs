using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_API.Services.Categories;
using Store_Shared.Models;

namespace Store_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<List<Category>> GetCategories()
        {
            return await _category.GetAll();
        }

        [HttpGet("GetCategory")]
        public async Task<Category> GetCategory(string id)
        {
            var cat = await _category.Get(id);
            return cat;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategories([FromForm] Category category, List<IFormFile> image)
        {
            if (!ModelState.IsValid) return BadRequest();


            await _category.Post(category, image);
            return Ok(category);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _category.Delete(id);
            return Ok();
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Edit(string id, [FromForm] Category category, List<IFormFile> image)
        {
            if (id != category.Id) return BadRequest();

            await _category.Put(category, image);
            return Ok(category);
        }
    }
}