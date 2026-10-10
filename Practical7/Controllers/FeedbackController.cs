
using Microsoft.AspNetCore.Mvc;
using Practical6.Models;

namespace Practical6.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly string[] categories =
        {
            "Teaching",
            "Infrastructure",
            "Library",
            "Laboratory",
            "Website",
            "Other"
        };

        private void LoadCategories()
        {
            ViewBag.Categories = categories;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoadCategories();
            return View(new Feedback());
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            LoadCategories();

            if (!categories.Contains(feedback.Category))
            {
                ModelState.AddModelError(
                    "Category", "Please select a valid category");
            }

            if (ModelState.IsValid)
            {
                ViewBag.Message =
                    "Thank you! Your feedback was submitted successfully.";

                ViewBag.SubmittedName = feedback.Name;
                ViewBag.SubmittedRating = feedback.Rating;

                ModelState.Clear();
                return View(new Feedback());
            }

            return View(feedback);
        }
    }
}