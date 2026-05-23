using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication7.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {

        // this code block will execute before the action method executes
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Before Action Executes");
        }



        //this code block will execute after the action method executes
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("After Action Executes");
        }

    }
}
