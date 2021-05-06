using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_APP.Services.Categories;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        [HttpGet("Categories")]
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
        public async Task<IActionResult> AddCategories(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _category.Post(category);
            return NoContent();
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _category.Delete(id);
            return Ok();
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> Edit(string id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await _category.Put(category);
            return Ok(category);
        }
    }
}
