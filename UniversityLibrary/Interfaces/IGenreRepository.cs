using UniversityLibrary.Models;
namespace UniversityLibrary.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenres();
        Task<Genre> GetGenre(int? id);
        //Task<List<Book>> GetBooksByAuthor(int? id);
        Task CreateGenre(Genre genre);
        Task UpdateGenre(Genre genre);
        Task DeleteGenre(int? id);

    }
}
