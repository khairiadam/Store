using Microsoft.AspNetCore.Mvc;
using Store_Client.Services.CategoryService;
using Store_Client.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store_Shared.Dto;
using Store_Shared.Models;

namespace Store_Client.Controllers
{

    public class ShopController : Controller
    {
        private IProductSer _product;
        private ICategorySer _category;

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
            if (id == null)
            {
                products = _product.Get();

            }
            else
            {
                products = _product.GetByCategory(id);

            }

            return View(products);
        }



        public IActionResult Details(string id)
        {
            var product = _product.Get(id);

            return View(product);
        }
    }
}
