var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//configure conventional routing for the application. This line maps the controller actions to the appropriate routes based on the attributes defined in the controllers. It allows the application to handle incoming HTTP requests and route them to the correct controller actions.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // This line defines a default route pattern for the application. It specifies that if no specific route is provided in the URL, it will default to the Home controller and the Index action. The {id?} part indicates that an optional id parameter can be included in the URL.

app.Run();
