using UniversityLibrary.Models;

namespace UniversityLibrary.Interfaces
{
    public interface IAuthorRepository
    {
       // IAuthorRepository Authors { get; }
        Task<List<Author>> GetAuthors();
        Task<Author> GetAuthor(int? id);
        Task<List<Book>> GetBooksByAuthor(int? id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int? id);

    }
}
