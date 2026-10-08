using System.ComponentModel.DataAnnotations;

namespace Practical7.Models
{
    public class Feedback
    {
        // Required + only letters and spaces
        [Required(ErrorMessage = "Student name is required")]
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "Name can contain only letters and spaces")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Display(Name = "Student Name")]
        public string Name { get; set; } = "";


        // Required + must end with @gmail.com
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Please enter a valid Gmail address")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";


        // Optional + exactly 10 digits if entered
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Phone number must contain exactly 10 digits")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }


        // Optional + letters and spaces
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "Department can contain only letters and spaces")]
        [StringLength(50,
            ErrorMessage = "Department cannot exceed 50 characters")]
        [Display(Name = "Department")]
        public string? Department { get; set; }


        // Required
        // Allows values such as B.Tech, B.Sc, M.Sc
        [Required(ErrorMessage = "Please select a course")]
        [RegularExpression(@"^[A-Za-z. ]+$",
            ErrorMessage = "Course can contain only letters, dots and spaces")]
        [StringLength(50,
            ErrorMessage = "Course cannot exceed 50 characters")]
        [Display(Name = "Course")]
        public string Course { get; set; } = "";


        // Required + 1 to 8
        [Required(ErrorMessage = "Please select a semester")]
        [Range(1, 8,
            ErrorMessage = "Semester must be between 1 and 8")]
        [Display(Name = "Semester")]
        public int? Semester { get; set; }


        // Required
        // Allows .NET, ASP.NET, C#, Java, Data Mining, etc.
        [Required(ErrorMessage = "Subject is required")]
        [RegularExpression(@"^[A-Za-z0-9.# +\-]+$",
            ErrorMessage = "Subject contains invalid characters")]
        [StringLength(60,
            ErrorMessage = "Subject cannot exceed 60 characters")]
        [Display(Name = "Subject")]
        public string Subject { get; set; } = "";


        // Required
        [Required(ErrorMessage = "Please select an overall rating")]
        [Range(1, 5,
            ErrorMessage = "Please select an overall rating")]
        [Display(Name = "Overall Rating")]
        public int? Rating { get; set; }


        // Required
        [Required(ErrorMessage = "Please select teaching quality")]
        [Display(Name = "Teaching Quality")]
        public string? TeachingQuality { get; set; }


        // Optional
        [Display(Name = "Would you recommend this subject?")]
        public string? Recommend { get; set; }


        // Optional checkboxes
        [Display(Name = "Teaching")]
        public bool Teaching { get; set; }

        [Display(Name = "Course Content")]
        public bool CourseContent { get; set; }
        
        [Display(Name = "Practical Work")]
        public bool PracticalWork { get; set; }


        // Required + maximum 500 characters
        [Required(ErrorMessage = "Please enter your feedback")]
        [StringLength(500,
            MinimumLength = 5,
            ErrorMessage = "Feedback must be between 5 and 500 characters")]
        [Display(Name = "Your Feedback")]
        public string FeedbackText { get; set; } = "";


        // Optional + maximum 300 characters
        [StringLength(300,
            ErrorMessage = "Suggestions cannot exceed 300 characters")]
        [Display(Name = "Suggestions")]
        public string? Suggestions { get; set; }
    }
}