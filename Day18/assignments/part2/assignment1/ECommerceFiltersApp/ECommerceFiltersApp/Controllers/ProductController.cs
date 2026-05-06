using Microsoft.AspNetCore.Mvc;
using ECommerceFiltersApp.Filters;

namespace ECommerceFiltersApp.Controllers;

[ServiceFilter(typeof(AuthFilter))]
[ServiceFilter(typeof(LoggingFilter))]
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ErrorTest()
    {
        throw new Exception("Test Exception");
    }
}