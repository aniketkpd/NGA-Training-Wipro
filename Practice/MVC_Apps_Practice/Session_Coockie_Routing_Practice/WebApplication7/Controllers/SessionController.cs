using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("save/{name}")]
        [HttpGet]
        public IActionResult Save(string name)
        {
            HttpContext.Session.SetString("name", name);
            return Content("Session Saved");
        }


        [Route("get")]
        public IActionResult Get()
        {
            var name = HttpContext.Session.GetString("name");
            return Content("name is " + name);
        }

        [Route("delete")]
        public IActionResult Delete()
        {
            HttpContext.Session.Remove("name");
            return Content("Session Deleted");
        }
    }
}
