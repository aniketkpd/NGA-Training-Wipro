using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions();

            // set expiration time for the cookie
            options.Expires = DateTime.Now.AddMinutes(30);

            //set the cookie
            Response.Cookies.Append("Username", "Aniket", options);

            return Content("Cookie Created");
        }

        public IActionResult GetCookie()
        {
            //get the cookie value
            string? value = Request.Cookies["Username"];

            return Content("Cookie Value = " + value);
        }

        public IActionResult DeleteCookie()
        {
            //delete the cookie
            Response.Cookies.Delete("Username");

            return Content("Cookie Deleted");
        }
    }
}