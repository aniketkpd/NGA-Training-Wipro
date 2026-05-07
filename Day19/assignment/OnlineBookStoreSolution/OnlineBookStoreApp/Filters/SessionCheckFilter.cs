using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineBookStoreApp.Filters
{
    public class SessionCheckFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("User");

            if (session == null)
            {
                context.Result = new RedirectToPageResult("/Account/Login");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}