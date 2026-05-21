using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCatalogApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }

        public Director? Director { get; set; }
    }
}