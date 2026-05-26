using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new
            {
                Id = 1,
                Name = "Laptop",
                Price = 50000
            },
            new
            {
                Id = 2,
                Name = "Mouse",
                Price = 1000
            }
        });
    }
}