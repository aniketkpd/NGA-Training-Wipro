using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace WebApplication7.Filters
{
    public class MyAuthorizationFilter : Attribute, IAuthorizationFilter
    {

        //this method will be excecuted at start of pipeline, before the action filter
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // For real usage we use this
            //var user = context.HttpContext.Session.GetString("User");

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
