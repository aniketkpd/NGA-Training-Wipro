using Microsoft.AspNetCore.Mvc;

namespace EcommerceRoutingMVC.Controllers
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

        [Route("Products/Filter/{category:validcategory}/{priceRange}")]
        public IActionResult Filter(string category, string priceRange)
        {
            ViewBag.Category = category;
            ViewBag.PriceRange = priceRange;

            return View();
        }
    }
}