using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<GenreBook> GenresBook { get; set; }


    }
}
