using UniversityLibrary.Data;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Models;

namespace UniversityLibrary.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public bool CreateAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Author> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
