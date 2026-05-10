using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace FilterDemo.Filters
{
    public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isLoggedIn = false;
            if (!isLoggedIn)
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Account",
                    null
                );
            }
        }
    }
}
