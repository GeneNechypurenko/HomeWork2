using System.ComponentModel.DataAnnotations;

namespace HomeWork2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [DynamicRange(1900)]
        public int Year { get; set; }

        public string? PosterUrl { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0.0, 10.0, ErrorMessage = "Rating must be between 0.0 and 10.0.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}
