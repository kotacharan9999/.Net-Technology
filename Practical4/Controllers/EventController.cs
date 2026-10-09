
using Microsoft.AspNetCore.Mvc;
using Practical4.Models;

namespace Practical4.Controllers
{
    public class EventController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EventRegistration registration)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message =
                    "Registration successful! Thank you for registering.";

                ModelState.Clear();
                return View(new EventRegistration());
            }

            return View(registration);
        }
    }
}