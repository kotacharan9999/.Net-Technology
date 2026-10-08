using Microsoft.AspNetCore.Mvc;
using Practical7.Models;

namespace Practical7.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message =
                    "✓ Feedback submitted successfully! Thank you for your response.";

                ModelState.Clear();
            }

            return View(feedback);
        }
    }
}