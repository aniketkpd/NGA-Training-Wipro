using Microsoft.AspNetCore.Mvc;
namespace FilterDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return Content("Please Login First");
        }
    }
}
