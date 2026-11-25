using System.ComponentModel.DataAnnotations;

namespace Practical10.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Department { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [StringLength(80)]
    public string Company { get; set; } = string.Empty;

    [Range(0, 100)]
    public decimal Package { get; set; }
}
