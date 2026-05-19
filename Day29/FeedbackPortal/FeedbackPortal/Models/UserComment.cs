using System.ComponentModel.DataAnnotations;

namespace FeedbackPortal.Models
{
    public class UserComment
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please provide your feedback.")]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? CommentText { get; set; }
    }
}