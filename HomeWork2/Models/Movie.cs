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

        [Required(ErrorMessage = $"Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Poster is required.")]
        public string PosterUrl { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        //[RegularExpression(@"\d+(\.\d{1})?", ErrorMessage = "Invalid rating format.")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}
