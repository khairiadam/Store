using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_APP.Services.Products;
using Store_Shared.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
    


        private readonly IProductService _iProductService;

        public ProductsController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }


        [HttpGet("products")]
        public async Task<IActionResult> Get()
        {


            return Ok(await _iProductService.GetAll());




        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> Getproduct(string id)
        {
            var result = await _iProductService.Get(id);

            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);



        }


        [HttpPost("Post")]

        public async Task<IActionResult> Post([FromForm] Product model, List<IFormFile> image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }






            await _iProductService.Post(model, image);


            return Ok(model);



        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {

            if (ModelState.IsValid)
            {
                await _iProductService.Delete(id);
            }


            else
            {
                return BadRequest();

            }



            return NoContent();





        }






        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(string id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _iProductService.Update(product);
            return Ok(product);
        }

    }
}
