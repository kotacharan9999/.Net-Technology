
using Microsoft.AspNetCore.Mvc;
using Practical9.Models;
using System.Collections.Generic;
using System.Linq;

namespace Practical9.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                StudentID = 1,
                StudentName = "Rahul",
                Department = "CSE",
                Company = "TCS",
                Package = 4.5m,
                PlacementStatus = "Placed"
            },

            new Student
            {
                StudentID = 2,
                StudentName = "Priya",
                Department = "AIML",
                Company = "Infosys",
                Package = 5.5m,
                PlacementStatus = "Placed"
            },

            new Student
            {
                StudentID = 3,
                StudentName = "Kiran",
                Department = "ECE",
                Company = "Wipro",
                Package = 3.8m,
                PlacementStatus = "Placed"
            },

            new Student
            {
                StudentID = 4,
                StudentName = "Arjun",
                Department = "IT",
                Company = "Not Selected",
                Package = 0,
                PlacementStatus = "Not Placed"
            },

            new Student
            {
                StudentID = 5,
                StudentName = "Sneha",
                Department = "CSE",
                Company = "Accenture",
                Package = 6.0m,
                PlacementStatus = "Placed"
            }
        };

        public IActionResult Index(string department)
        {
            var result = students.AsEnumerable();

            if (!string.IsNullOrEmpty(department))
            {
                result = result.Where(s =>
                    s.Department == department);
            }

            ViewBag.Departments = students
                .Select(s => s.Department)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            ViewBag.SelectedDepartment = department;

            return View(result.ToList());
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(
                s => s.StudentID == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            student.StudentID = students.Count == 0
                ? 1
                : students.Max(s => s.StudentID) + 1;

            students.Add(student);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(
                s => s.StudentID == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var oldStudent = students.FirstOrDefault(
                s => s.StudentID == student.StudentID);

            if (oldStudent == null)
                return NotFound();

            oldStudent.StudentName = student.StudentName;
            oldStudent.Department = student.Department;
            oldStudent.Company = student.Company;
            oldStudent.Package = student.Package;
            oldStudent.PlacementStatus = student.PlacementStatus;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(
                s => s.StudentID == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(
                s => s.StudentID == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}
