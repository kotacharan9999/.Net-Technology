
using Microsoft.AspNetCore.Mvc;
using Practical5.Models;

namespace Practical5.Controllers
{
    public class LeaveController : Controller
    {
        private readonly string[] eventsList =
        {
            "Semester Exams",
            "Internal Assessment",
            "Annual Day",
            "Sports Day",
            "Technical Fest"
        };

        private readonly string[] leaveTypes =
        {
            "Medical Leave",
            "Personal Leave",
            "Family Function"
        };

        private void LoadData()
        {
            ViewBag.AcademicEvents = eventsList;
            ViewBag.LeaveTypes = leaveTypes;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoadData();

            HttpContext.Session.SetString("StudentName", "Student");
            ViewBag.SavedName = Request.Cookies["StudentName"];

            return View(new LeaveApplication());
        }

        [HttpPost]
        public IActionResult Index(LeaveApplication application)
        {
            LoadData();

            if (!leaveTypes.Contains(application.LeaveType))
            {
                ModelState.AddModelError(
                    "LeaveType", "Please select a valid leave type");
            }

            if (!eventsList.Contains(application.AcademicEvent))
            {
                ModelState.AddModelError(
                    "AcademicEvent", "Please select a valid academic event");
            }

            if (application.StartDate.HasValue &&
                application.EndDate.HasValue)
            {
                if (application.EndDate.Value.Date <
                    application.StartDate.Value.Date)
                {
                    ModelState.AddModelError(
                        "EndDate",
                        "End date must be on or after the start date");
                }
            }

            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString(
                    "StudentName", application.StudentName);

                Response.Cookies.Append(
                    "StudentName",
                    application.StudentName,
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(7),
                        HttpOnly = true,
                        IsEssential = true
                    });

                ViewBag.Message =
                    "Leave application submitted successfully!";

                ViewBag.SavedName = application.StudentName;

                ModelState.Clear();
                return View(new LeaveApplication());
            }

            ViewBag.SavedName = Request.Cookies["StudentName"];

            return View(application);
        }
    }
}