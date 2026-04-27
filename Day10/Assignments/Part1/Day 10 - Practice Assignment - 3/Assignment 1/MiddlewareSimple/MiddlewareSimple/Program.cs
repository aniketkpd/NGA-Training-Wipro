using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware: Log Requests & Responses
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

    await next();

    Console.WriteLine($"Response Status: {context.Response.StatusCode}");
});

// Middleware: Error Handling
app.UseExceptionHandler("/error");

app.Map("/error", (HttpContext context) =>
{
    return Results.Content("<h1>Custom Error Page</h1>", "text/html");
});

// Middleware: Enforce HTTPS
app.UseHttpsRedirection();

// Middleware: Content Security Policy
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy",
        "default-src 'self'; script-src 'self'; style-src 'self'");

    await next();
});

// Serve Static Files
app.UseStaticFiles();

// Default route
app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.Run();