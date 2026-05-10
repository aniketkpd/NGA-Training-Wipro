using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication7.Filters
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = "Exception Handled Successfully"
            };
            context.ExceptionHandled = true;
        }
    }
}
