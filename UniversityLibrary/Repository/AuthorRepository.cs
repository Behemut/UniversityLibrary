using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Data;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Models;

namespace UniversityLibrary.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAuthor(Author author) { 
            _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAuthor(int? id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Remove(author);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(author));
            }
        }

        public async Task<Author> GetAuthor(int? id)
        {
            return await _context.Authors.FindAsync(id);            
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public Task<List<Book>> GetBooksByAuthor(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAuthor(Author author)
        {
            _context.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
