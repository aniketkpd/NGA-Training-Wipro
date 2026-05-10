using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Before Action Executes");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("After Action Executes");
        }
    }
}