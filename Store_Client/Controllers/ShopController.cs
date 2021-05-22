using Microsoft.AspNetCore.Mvc;
using Store_Client.Services.CategoryService;
using Store_Client.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            var products = _product.Get();

            return View(products);
        }

        public IActionResult Details(string id)
        {
            var product = _product.Get(id);

            return View(product);
        }
    }
}
