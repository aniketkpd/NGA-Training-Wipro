using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApp.Models;

namespace OnlineBookStoreApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Summary()
        {
            Order order = new Order()
            {
                OrderId = 101,
                CustomerName = "Aniket",
                TotalAmount = 2000
            };

            return View(order);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}