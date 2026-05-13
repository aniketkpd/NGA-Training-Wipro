using LibraryManagementSystem.Data;
using LibraryManagementSystem.DatabaseFirst;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("LibraryDatabase")
        ?? "Data Source=library.db"));
builder.Services.AddDbContext<ExistingLibraryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ExistingLibraryDatabase")
        ?? "Data Source=existing-library.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
