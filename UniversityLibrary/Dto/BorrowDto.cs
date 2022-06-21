using System.ComponentModel.DataAnnotations;

namespace UniversityLibrary.Dto
{
    public class BorrowDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Estado")]
        public string CurrentStatus { get; set; }
    }
}
