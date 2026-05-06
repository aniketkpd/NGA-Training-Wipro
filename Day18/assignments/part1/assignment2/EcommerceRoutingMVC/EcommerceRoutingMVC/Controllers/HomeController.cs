using Microsoft.AspNetCore.Mvc;

namespace EcommerceRoutingMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}