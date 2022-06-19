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

        public Task DeleteAuthor(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthor(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        public Task<List<Book>> GetBooksByAuthor(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
