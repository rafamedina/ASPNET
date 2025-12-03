using System.ComponentModel.DataAnnotations; // <--- NECESARIO PARA [Required]

namespace EjercicioTagHelpers.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }
    }
}