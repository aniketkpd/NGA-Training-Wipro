using OnlineBookStoreApp.Filters;
using OnlineBookStoreApp.Services;

namespace OnlineBookStoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            builder.Services.AddRazorPages();

            builder.Services.AddSession();

            builder.Services.AddSingleton<BookRepository>();

            builder.Services.AddScoped<SessionCheckFilter>();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "bookdetails",
                pattern: "book/{id:int}",
                defaults: new { controller = "Book", action = "Details" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}