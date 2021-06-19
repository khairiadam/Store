using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store_API.Services.OrderProductsServices;
using Store_API.Services.Orders;
using Store_Shared.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        // private readonly IOrderProductsService _orderProducts;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly HttpContext _context;
        private readonly List<CartItem> _cart = new List<CartItem>();


        public OrderController(IOrderService order,
            UserManager<ApplicationUser> userManager)
        {
            _order = order;
            // _orderProducts = orderProducts;
            _userManager = userManager;
            //_context = context;
        }


        
        // GET: api/<OrderController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Orders()
        {
            return Ok(await _order.GetAll());
        }

        
        
        // GET api/<OrderController>/5
        [HttpGet("Detail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrder(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound("Invalid Order Id !");

            var clt = await _order.Get(id);

            if (clt is null) return NotFound("Order was not Found !");

            return Ok(clt);
        }

        

        // POST api/<OrderController>
        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrders(Order order)
        {
            if (!ModelState.IsValid) return BadRequest("Couldn't add the Order");

            return Ok(await _order.Post(order));
        }

        

        // DELETE api/<OrderController>/5
        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            await _order.Delete(id);
            return Ok();
        }

        
        
        // public async Task<IActionResult> PlaceOrder()
        // {
        //     try
        //     {
        //         // return Ok(await _orderProducts.GetCartItems(_cart));
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //         return BadRequest();
        //     }
        // }

        
        
        //[Authorize(Roles = "Admin")]
        //public async Task MarkAsPaid()
        //{
        //    var user = await _userManager.GetUserAsync(_context.User);
        //    var order = await _order.GetOrderByUserId(user.Id);
        //    await _order.ConfirmOrder(order);
        //}

        
        
        // PUT api/<OrderController>/5
        [HttpPut("Edit")]
        [Authorize]
        public async Task<IActionResult> Update(string id, Order order)
        {
            if (string.IsNullOrEmpty(id) && id != order.Id) return BadRequest();
            await _order.Put(order);
            return Ok(order);
        }
    }
}