using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store_Client.Models;
using Store_Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace Store_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client;
        IEnumerable<Product> products = null;
        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            this.client = client;
            this.client.BaseAddress = new Uri("http://localhost:4000/api/");
        }

        public IActionResult Index()
        {

            //HTTP GET
            var responseTask = client.GetAsync("Product");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Product>>();
                readTask.Wait();

                products = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                products = Enumerable.Empty<Product>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

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
