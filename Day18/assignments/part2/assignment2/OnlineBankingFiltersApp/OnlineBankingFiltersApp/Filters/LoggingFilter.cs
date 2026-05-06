using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBankingFiltersApp.Filters;

public class LoggingFilter : IActionFilter
{
    private readonly ILogger<LoggingFilter> _logger;

    public LoggingFilter(ILogger<LoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        _logger.LogInformation(
            "User Action: {Method} {Path}",
            request.Method,
            request.Path
        );
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation(
            "Response Status: {StatusCode}",
            context.HttpContext.Response.StatusCode
        );
    }
}