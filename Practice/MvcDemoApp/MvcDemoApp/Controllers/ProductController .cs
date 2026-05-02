using Microsoft.AspNetCore.Mvc;
using MvcDemoApp.Models;

namespace MvcDemoApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50000
            };

            return View(product);
        }
    }
}