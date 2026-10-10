
using System;
using System.ComponentModel.DataAnnotations;

namespace Practical5.Models
{
    public class LeaveApplication
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Name must contain 2 to 50 characters")]
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "Name can contain only letters and spaces")]
        public string StudentName { get; set; } = "";

        [Required(ErrorMessage = "Select a leave type")]
        public string LeaveType { get; set; } = "";

        [Required(ErrorMessage = "Select the start date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Select the end date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Enter the reason")]
        [StringLength(200, MinimumLength = 5,
            ErrorMessage = "Reason must contain 5 to 200 characters")]
        public string Reason { get; set; } = "";

        [Required(ErrorMessage = "Select an academic event")]
        public string AcademicEvent { get; set; } = "";
    }
}