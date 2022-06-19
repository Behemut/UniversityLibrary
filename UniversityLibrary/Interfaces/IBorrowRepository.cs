using UniversityLibrary.Models;

namespace UniversityLibrary.Interfaces
{
    public interface IBorrowRepository
    {

        ICollection<Borrow> GetBorrows();
        Borrow GetBorrow(int id);

        ICollection<Book> GetBooksOfAUser(int UserId);

        bool AddBorrow(Borrow borrow);
        bool UpdateBorrow(Borrow borrow);
        bool DeleteBorrow(int id);

        bool DeleteBooks(List<Book> books);
        bool Save();

    }
}
