using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Dto
{
    public class BookDto
    {
     
        public int Id { get; set; }
        [Required, Display(Name = "Título")]
        public string Title { get; set; }
        [Required, Display(Name = "Fecha de publicacion")]
        public DateTime PublishedDate { get; set; }
        [Required, Display(Name = "Cantidad")]
        public int Stock { get; set; }

    }
}
