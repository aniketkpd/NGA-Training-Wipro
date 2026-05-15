using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureShop.Data;
using SecureShop.Models;

namespace SecureShop.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;

        if (!_context.Products.Any())
        {
            _context.Products.AddRange(
                new Product
                {
                    Name = "Laptop",
                    Price = 50000,
                    Description = "Gaming Laptop"
                },
                new Product
                {
                    Name = "Phone",
                    Price = 20000,
                    Description = "Android Phone"
                });

            _context.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        return View(_context.Products.ToList());
    }
}