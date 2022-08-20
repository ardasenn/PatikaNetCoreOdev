using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db) :base(db)
        {
            
        }      

        public DbSet<Book>Books {get; set;}
        public DbSet<Genre> Genres {get; set;}

    }
}