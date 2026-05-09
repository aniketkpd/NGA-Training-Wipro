using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(string name)
        {
            HttpContext.Session.SetString("UserName", name);


            // this will execute the Welcome()
            return RedirectToAction("Welcome");
        }

        public IActionResult Welcome()
        {
            string? name = HttpContext.Session.GetString("UserName");

            ViewBag.Name = name;

            return View();
        }

        public IActionResult Logout()
        {
            //both of these will work, but Clear() is more efficient as it removes all session data in one call
            //HttpContext.Session.Remove("UserName");
            HttpContext.Session.Clear();

            // this will excute the Index()
            return RedirectToAction("Index");
        }
    }
}