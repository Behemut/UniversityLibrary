using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Models;

namespace UniversityLibrary.Data
{
    public class DataContext: DbContext 
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Creating Tables for each Model
        public DbSet<Author> Authors { get; set; }



    }
}
