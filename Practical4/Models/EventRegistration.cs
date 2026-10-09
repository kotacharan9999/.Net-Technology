
using System.ComponentModel.DataAnnotations;

namespace Practical4.Models
{
    public class EventRegistration
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "Enter a valid name")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Enter exactly 10 digits")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Please select an event")]
        public string EventName { get; set; } = "";

        [Required(ErrorMessage = "Please select a date")]
        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage = "Please enter the number of participants")]
        [Range(1, 10, ErrorMessage = "Participants must be between 1 and 10")]
        public int? Participants { get; set; }
    }
}