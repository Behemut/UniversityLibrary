using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }
        [Display(Name = "Genero")]
        public string Name { get; set; }
    }
}
