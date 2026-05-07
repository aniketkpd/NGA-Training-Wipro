using OnlineBookStoreApp.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN must be 13 digits")]
        public string ISBN { get; set; }

        [ValidPrice]
        public double Price { get; set; }
    }
}