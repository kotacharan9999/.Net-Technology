
using System.ComponentModel.DataAnnotations;

namespace Practical6.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter product name")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Name must contain 2 to 50 characters")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Enter product category")]
        public string Category { get; set; } = "";

        [Range(1, 1000000,
            ErrorMessage = "Price must be between 1 and 1000000")]
        public decimal Price { get; set; }

        [Range(0, 10000,
            ErrorMessage = "Stock must be between 0 and 10000")]
        public int Stock { get; set; }

        [StringLength(200,
            ErrorMessage = "Description cannot exceed 200 characters")]
        public string Description { get; set; } = "";
    }
}