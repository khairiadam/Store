using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store_Client.Services.CategoryService;
using Store_Client.Services.ProductService;
using Store_Shared.Dto;
using Store_Shared.Models;

namespace Store_Client.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategorySer _category;
        private readonly IProductSer _product;

        public ShopController(IProductSer product, ICategorySer category)
        {
            _product = product;
            _category = category;
        }


        [HttpGet("Shop")]
        [HttpGet("Shop/{id}")]
        public IActionResult Index(string id = null)
        {
            ViewBag.Categories = _category.Get();


            IEnumerable<ProductModel> products = null;
            products = id == null ? _product.Get() : _product.GetByCategory(id);

            return View(products);
        }


        [HttpGet("Shop/Details/{id}")]
        public IActionResult Details(string id)
        {
            var product = _product.Get(id);

            return View(product);
        }


        [HttpGet]
        public IActionResult Edit(string id = null)
        {
            if (id == null) return NotFound();
            var product = _product.Get(id);
            if (product == null) return NotFound();

            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
// _product.
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}