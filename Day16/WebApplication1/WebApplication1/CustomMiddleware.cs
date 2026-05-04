namespace WebApplication1
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _Next;

        public CustomMiddleware(RequestDelegate next)
        {
            _Next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Request received");
            await _Next(context);
            Console.WriteLine("Response sent");
        }

    }
}
