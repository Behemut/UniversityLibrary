namespace UniversityLibrary.Models
{
    public class Borrow
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}
