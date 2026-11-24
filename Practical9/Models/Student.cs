
using System.ComponentModel.DataAnnotations;

namespace Practical9.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        public string StudentName { get; set; } = "";

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; } = "";

        [Required(ErrorMessage = "Company name is required")]
        public string Company { get; set; } = "";

        [Range(0, 100, ErrorMessage = "Enter a valid package")]
        public decimal Package { get; set; }

        [Required]
        public string PlacementStatus { get; set; } = "Not Placed";
    }
}
