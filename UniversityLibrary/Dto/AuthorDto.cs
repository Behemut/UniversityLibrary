using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Dto
{
    public class AuthorDto
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del autor")]
        public string Name { get; set; }
    }
}
