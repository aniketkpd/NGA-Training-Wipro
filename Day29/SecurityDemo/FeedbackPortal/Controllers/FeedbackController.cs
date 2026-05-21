using Microsoft.AspNetCore.Mvc;
using FeedbackPortal.Models;

namespace FeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserComment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Protects against Cross-Site Request Forgery (CSRF)
        public IActionResult Create(UserComment submission)
        {
            // Verify that the incoming data passes all Data Annotation constraints
            if (!ModelState.IsValid)
            {
                // Validation failed. Return the view along with the validation errors.
                return View(submission);
            }
            // Validation passed. Safe to process and save to the database here.
            // _dbContext.Comments.Add(submission);
            // _dbContext.SaveChanges();

            return RedirectToAction("Success", submission);
        }

        [HttpGet]
        public IActionResult Success(UserComment submission)
        {
            return View(submission);
        }

    }
}