using System.ComponentModel.DataAnnotations;

namespace BookStoreADOApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Author")]
        [StringLength(100)]
        public string AuthorName { get; set; } = string.Empty;

        [Range(1, 999999.99)]
        public decimal Price { get; set; }
    }
}
