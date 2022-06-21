using UniversityLibrary.Models;
namespace UniversityLibrary.Interfaces
{
    public interface IBookRepository
    {
        Task <List<Book>> GetBooks();
        Task  CreateBook(Book book, int[]? SelectedAuthors, int[]? SelectedGenres);
        Task <Book> GetBookByIdAsync(int? id);

        Task<List<Genre>> GetGenresByBook(int? bookId);
        Task<List<Author>> GetAuthorsByBook(int? bookId);
        Task UpdateBook(Book book, int[]? SelectedAuthors, int[]? SelectedGenres);
        Task DeleteBook(int? id);

    }
}
