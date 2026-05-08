using Microsoft.AspNetCore.Mvc;

namespace OnlineExamPortal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("User", username);

            Response.Cookies.Append("Theme", "Dark");

            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");

            var theme = Request.Cookies["Theme"];

            return Content("Welcome " + user + " | Theme: " + theme);
        }
    }
}