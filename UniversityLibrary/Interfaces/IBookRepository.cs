using UniversityLibrary.Models;
namespace UniversityLibrary.Interfaces
{
    public interface IBookRepository
    {
        Task <List<Book>> GetBooks();
        Task  CreateBook(Book book, int? authorId);
        Task <Book> GetBookByIdAsync(int? id);
        Task UpdateBook(Book book);
        Task DeleteBook(int? id);

    }
}
