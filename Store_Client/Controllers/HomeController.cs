using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store_Client.Models;
using Store_Client.Services.ProductService;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductSer _product;

        public HomeController(ILogger<HomeController> logger, IProductSer product)
        {
            _logger = logger;
            _product = product;
        }

        public async Task<ActionResult> Index()
        {

            var products = await _product.Get();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
