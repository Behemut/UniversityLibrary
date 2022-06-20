using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Data;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Models;

namespace UniversityLibrary.Repository
{
    public class BookRepository : IBookRepository 
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateBook(Book book, int? authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            var authorBooks = new AuthorBook()
            {
                Author = author,
                Book = book
            };
            _context.AddAsync(authorBooks);
            _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteBook(int? id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(book));
            }
        }

        public async Task<Book> GetBookByIdAsync(int? id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<List<Book>>  GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task UpdateBook (Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
