using Microsoft.AspNetCore.Mvc;

namespace Store_Client.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}