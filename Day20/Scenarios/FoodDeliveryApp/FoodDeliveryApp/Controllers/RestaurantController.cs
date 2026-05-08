//Conventional routing + custom route

//using Microsoft.AspNetCore.Mvc;

//public class RestaurantController : Controller
//{
//    public IActionResult Menu()
//    {
//        return Content("Restaurant Menu Page");
//    }

//    public IActionResult Details(int id)
//    {
//        return Content("Restaurant Details ID: " + id);
//    }
//}





// attribute routing + route constraint
// /restaurant/menu
// /restaurant/details/10


using Microsoft.AspNetCore.Mvc;

[Route("restaurant")]
public class RestaurantController : Controller
{
    [Route("menu")]
    public IActionResult Menu()
    {
        return Content("Restaurant Menu");
    }

    [Route("details/{id:int}")]
    public IActionResult Details(int id)
    {
        return Content("Restaurant Details: " + id);
    }
}