using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Models;

namespace UniversityLibrary.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {   
        }
        //Creating Tables for each Model
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationship Many-to-Many Authors -> Books 
            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });
            modelBuilder.Entity<AuthorBook>()
                .HasOne(a => a.Author)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Book)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(b => b.BookId);
            //Relationship Many-to-Many Genres -> Books 
            modelBuilder.Entity<GenreBook>()
                .HasKey(gb => new { gb.BookId, gb.GenreId });
            modelBuilder.Entity<GenreBook>()
                .HasOne(b => b.Book)
                .WithMany(gb => gb.GenreBooks)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<GenreBook>()
                .HasOne(g => g.Genre)
                .WithMany(gb => gb.GenreBooks)
                .HasForeignKey(g => g.GenreId);
            //Relationship Many-to-Many Users -> Books 
            modelBuilder.Entity<Borrow>()
                .HasKey(br => new { br.UserId, br.BookId });
            modelBuilder.Entity<Borrow>()
                .HasOne(u => u.User)
                .WithMany(br => br.Borrows)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<Borrow>()
                .HasOne(bk => bk.Book)
                .WithMany(br => br.Borrows)
                .HasForeignKey(bk => bk.BookId);
        }
    }
}
