using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingMVC.Controllers
{
    public class DashboardController : Controller
    {
        [Route("Dashboard/{role}")]
        public IActionResult Index(string role)
        {
            if (role.ToLower() == "admin")
            {
                return View("Admin");
            }

            return View("User");
        }
    }
}