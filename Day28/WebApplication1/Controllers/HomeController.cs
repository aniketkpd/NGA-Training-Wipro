using Microsoft.AspNetCore.Mvc;

namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetMessage()
        {
            return Json(new { message = "AJAX Call Successful" });
        }
    }
}