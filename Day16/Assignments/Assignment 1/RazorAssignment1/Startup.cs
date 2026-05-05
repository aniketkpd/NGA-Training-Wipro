public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages(options =>
        {
            // Custom routes for product details and category pages.
            options.Conventions.AddPageRoute("/Products/Details", "Products/{id:int}");
            options.Conventions.AddPageRoute("/Products/Category", "Products/Category/{categoryName}");
        });
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapRazorPages();
    }
}
