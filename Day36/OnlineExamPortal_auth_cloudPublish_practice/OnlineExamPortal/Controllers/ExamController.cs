using Microsoft.AspNetCore.Mvc;
using OnlineExamPortal.Filters;

namespace OnlineExamPortal.Controllers
{


    [CustomLogFilter]
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return Content("Exam");
        }
    }
}
