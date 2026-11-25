using System.ComponentModel.DataAnnotations;

namespace Practical11.Models;

public class CampusServiceRequest
{
    public int Id { get; set; }

    [Required, StringLength(80, MinimumLength = 2)]
    [Display(Name = "Student name")]
    public string StudentName { get; set; } = "";

    [Required, EmailAddress, StringLength(120)]
    public string Email { get; set; } = "";

    [Required, StringLength(80)]
    public string Department { get; set; } = "";

    [Required, StringLength(50)]
    public string Category { get; set; } = "IT Support";

    [Required, StringLength(120, MinimumLength = 4)]
    public string Title { get; set; } = "";

    [Required, StringLength(1000, MinimumLength = 10)]
    public string Description { get; set; } = "";

    [Required]
    public string Priority { get; set; } = "Medium";

    [Required]
    public string Status { get; set; } = "Pending";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
