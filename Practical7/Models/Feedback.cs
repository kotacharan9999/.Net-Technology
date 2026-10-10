
using System.ComponentModel.DataAnnotations;

namespace Practical6.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Enter your name")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Name must contain 2 to 50 characters")]
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "Name can contain only letters and spaces")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(100)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Enter your department")]
        [StringLength(50, MinimumLength = 2)]
        public string Department { get; set; } = "";

        [Required(ErrorMessage = "Select a feedback category")]
        public string Category { get; set; } = "";

        [Required(ErrorMessage = "Select a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Enter your feedback")]
        [StringLength(300, MinimumLength = 5,
            ErrorMessage = "Feedback must contain 5 to 300 characters")]
        public string Comments { get; set; } = "";

        public bool Recommend { get; set; }

        [StringLength(200,
            ErrorMessage = "Suggestions cannot exceed 200 characters")]
        public string Suggestions { get; set; } = "";
    }
}