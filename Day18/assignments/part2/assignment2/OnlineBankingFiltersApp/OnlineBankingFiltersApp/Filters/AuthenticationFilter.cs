using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingFiltersApp.Services;

namespace OnlineBankingFiltersApp.Filters;

public class AuthenticationFilter : IActionFilter
{
    private readonly IAuthService _authService;

    public AuthenticationFilter(IAuthService authService)
    {
        _authService = authService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!_authService.IsLoggedIn())
        {
            context.Result = new ContentResult
            {
                Content = "User not authenticated"
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}