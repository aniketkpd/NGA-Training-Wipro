using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new
            {
                Id = 101,
                Product = "Laptop",
                Quantity = 1
            },
            new
            {
                Id = 102,
                Product = "Mouse",
                Quantity = 2
            }
        });
    }
}