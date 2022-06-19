namespace UniversityLibrary.Dto
{
    public class BorrowDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string CurrentStatus { get; set; }
    }
}
