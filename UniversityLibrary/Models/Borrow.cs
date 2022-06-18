namespace UniversityLibrary.Models
{
    public class Borrow
    {
    
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string CurrentStatus { get; set; }


    }
}
