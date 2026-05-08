using OnlineExamPortal.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(CustomLogFilter));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();