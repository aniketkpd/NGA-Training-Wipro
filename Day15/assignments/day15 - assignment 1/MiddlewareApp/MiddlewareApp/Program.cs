using MiddlewareApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.UseStaticFiles();

app.Use(async (context, next) =>
{
    context.Response.Headers["Content-Security-Policy"] =
        "default-src 'self'; script-src 'self'; style-src 'self';";
    await next();
});

app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.Run();