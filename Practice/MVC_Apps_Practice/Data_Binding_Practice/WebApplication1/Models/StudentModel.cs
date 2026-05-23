using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentModel
    {

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }
    }
}
