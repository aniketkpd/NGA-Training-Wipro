using Microsoft.AspNetCore.Mvc;

namespace AdvancedRoutingMVC.Controllers
{
    public class ProductsController : Controller
    {
        [Route("Products/{category}/{id}")]
        public IActionResult Details(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.Id = id;

            return View();
        }

        [Route("Products/Guid/{id:guidcheck}")]
        public IActionResult ProductGuid(Guid id)
        {
            return Content($"Valid GUID: {id}");
        }
    }
}