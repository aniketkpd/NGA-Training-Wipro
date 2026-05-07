using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentModel
    {
        [Required]
        public string? Name { get; set; }

        [Range(18,60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }
    }
}
