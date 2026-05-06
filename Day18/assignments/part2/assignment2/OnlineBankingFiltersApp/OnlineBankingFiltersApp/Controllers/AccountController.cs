using Microsoft.AspNetCore.Mvc;
using OnlineBankingFiltersApp.Filters;

namespace OnlineBankingFiltersApp.Controllers;

[ServiceFilter(typeof(AuthenticationFilter))]
[ServiceFilter(typeof(LoggingFilter))]
public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ServiceFilter(typeof(AuthorizationFilter))]
    public IActionResult Admin()
    {
        return View();
    }

    public IActionResult ErrorTest()
    {
        throw new Exception("Test Exception");
    }
}