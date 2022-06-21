using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required,Display(Name = "Título")]
        public string Title { get; set; }

        [Required, Display(Name = "Fecha de publicacion")]
        public DateTime PublishedDate { get; set; }

        [Required, Display(Name = "Cantidad")]
        public int Stock { get; set; }

        //Relationships many-to-many 
        [Display(Name = "Generos")]
        public ICollection<GenreBook> GenreBooks { get; set; }
        [Display(Name = "Autores")]
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<Borrow> Borrows { get; set; }



    }
}
