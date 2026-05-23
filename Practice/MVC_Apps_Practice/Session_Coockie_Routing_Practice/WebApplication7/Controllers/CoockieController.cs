using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class CoockieController : Controller
    {
        public IActionResult Index()
        {
            return Content("Cookie Index");
        }



        public IActionResult SetCoockie()
        {
            // Creating an object of CookieOptions to specify the options for the cookie
            CookieOptions options = new CookieOptions();

            // Setting the expiration time for the cookie to 1 day from now
            options.Expires = DateTime.Now.AddDays(1);

            // Setting the cookie with the name "MyCookie" and value "aniket" using the Response.Cookies.Append method
            Response.Cookies.Append("MyCookie", "aniket", options);

            return Content("Cookie has been set.");
        }





        //Get cookie
        public IActionResult GetCookie()
        {
            // Retrieving the value of the cookie named "MyCookie" from the Request.Cookies collection
            string value = Request.Cookies["MyCookie"];
            return Content(value);
        }


        //Delete cookie
        public IActionResult DeleteCookie()
        {
            // Deleting the cookie named "MyCookie" from the Response.Cookies collection
            Response.Cookies.Delete("MyCookie");
            return Content("Cookie has been deleted.");
        }
    
    }
}
