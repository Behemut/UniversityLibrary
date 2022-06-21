using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        public int Stock { get; set; }

        //Relationships many-to-many 
        public ICollection<GenreBook> GenreBooks { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public ICollection<Borrow> Borrows { get; set; }



    }
}
