using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication7.Filters
{
    public class MyResultFilter : ResultFilterAttribute
    {

        //this method will be excecuted before the return of action method
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Before Result Executes");
        }



        //this method will be excecuted after the return of action method
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("After Result Executes");
        }

    }
}
