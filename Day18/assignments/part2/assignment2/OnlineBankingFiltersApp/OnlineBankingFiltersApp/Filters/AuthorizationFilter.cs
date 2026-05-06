using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineBankingFiltersApp.Services;

namespace OnlineBankingFiltersApp.Filters;

public class AuthorizationFilter : IActionFilter
{
    private readonly IRoleService _roleService;

    public AuthorizationFilter(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!_roleService.IsAdmin())
        {
            context.Result = new ContentResult
            {
                Content = "Access Denied"
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}