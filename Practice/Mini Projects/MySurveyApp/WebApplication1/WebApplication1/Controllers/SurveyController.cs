using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.IO;

namespace WebApplication1.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Index(SurveyModel model)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    //ViewBag.Message = $"Your name {model.Name} and message {model.Message}is submitted successfully.";
        //    ViewBag.Message = "Your name and message is submitted successfully.";
        //    return View(model);
        //}




        //To save message to text file
        [HttpPost]
        public IActionResult Index(SurveyModel model)
        {
            string path = "messages.txt";

            string data = $"{model.Name}: {model.Message}\n";

            System.IO.File.AppendAllText(path, data);

            ViewBag.Message = "Submitted Successfully";

            return View();
        }



        // To display message from text file
        public IActionResult AllMessages()
        {
            string path = "messages.txt";

            string[] messages = System.IO.File.ReadAllLines(path);

            return View(messages);
        }
    }
}
