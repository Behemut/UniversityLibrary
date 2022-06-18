using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }


        //Relationship with Model Book (Many-to-many)
        public ICollection<Borrow> Borrows { get; set; }

    }
}
