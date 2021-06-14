using Microsoft.AspNetCore.Mvc;

namespace Store_Client.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}