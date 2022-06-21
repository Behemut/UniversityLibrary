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
        public async Task CreateBook(Book book, int[]? SelectedAuthors, int[]? SelectedGenres)
        {
            foreach (var item in SelectedGenres)
            {
                var genre = await _context.Genres.FindAsync(item);
                var genreBooks = new GenreBook()
                {
                    Book = book,
                    Genre = genre

                };
                _context.AddAsync(genreBooks);

            }
            foreach (var item in SelectedAuthors)
            {
                var author = await _context.Authors.FindAsync(item);
                var authorBooks = new AuthorBook()
                {
                    Author = author,
                    Book = book
                };
                _context.AddAsync(authorBooks);

            }
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
        public async Task UpdateBook(Book book, int[]? SelectedAuthors, int[]? SelectedGenres)
        {
            _context.Update(book);
            foreach (var item in SelectedGenres)
            {
                var genre= await _context.Genres.FindAsync(item);
                var genreBooks = new GenreBook()
                {
                    Book = book,
                    Genre = genre
                   
                };
                _context.AddAsync(genreBooks);
                
            }
            foreach (var item in SelectedAuthors)
            {
                var author = await _context.Authors.FindAsync(item);
                var authorBooks = new AuthorBook()
                {
                    Author = author,
                    Book = book
                };
                _context.AddAsync(authorBooks);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAuthorsByBook(int? bookId)
        {
            return await _context.Authors.Where(a => a.AuthorBooks.Any(ab => ab.BookId == bookId)).ToListAsync();
        }

        public async Task<List<Genre>> GetGenresByBook(int? bookId)
        {
            return await _context.Genres.Where(g => g.GenreBooks.Any(gb => gb.BookId == bookId)).ToListAsync();
        }
    }
}
