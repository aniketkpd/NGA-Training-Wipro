using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters;

public class AuthFilter : IActionFilter
{
    private readonly IAuthService _authService;

    public AuthFilter(IAuthService authService)
    {
        _authService = authService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!_authService.IsLoggedIn())
        {
            context.Result = new ContentResult
            {
                Content = "User not logged in"
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}