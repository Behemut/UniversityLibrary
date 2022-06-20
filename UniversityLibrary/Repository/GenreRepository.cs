using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Data;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Models;


namespace UniversityLibrary.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context )
        {
            _context = context;
        }

        public async Task CreateGenre(Genre genre)
        {
            _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenre(int? id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Remove(genre);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(genre));
            }
        }

        public async Task<Genre> GetGenre(int? id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task UpdateGenre(Genre genre)
        {
            _context.Update(genre);
            await _context.SaveChangesAsync();
        }
    }
}
