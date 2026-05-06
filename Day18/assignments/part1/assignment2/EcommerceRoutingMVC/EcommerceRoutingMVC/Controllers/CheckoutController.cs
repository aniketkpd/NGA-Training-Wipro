using Microsoft.AspNetCore.Mvc;

namespace EcommerceRoutingMVC.Controllers
{
    public class CheckoutController : Controller
    {
        [Route("Checkout/{status}")]
        public IActionResult Index(string status)
        {
            if (status.ToLower() == "guest")
            {
                return View("Login");
            }

            return View("Success");
        }
    }
}