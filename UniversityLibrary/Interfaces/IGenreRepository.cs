using UniversityLibrary.Models;
namespace UniversityLibrary.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        IEnumerable<Book> GetBooksByGenre(int Genreid);
        bool CreateGenre(Genre genre);
        bool UpdateGenre(Genre genre);
        bool DeleteGenre(int id);
        bool Save();

    }
}
