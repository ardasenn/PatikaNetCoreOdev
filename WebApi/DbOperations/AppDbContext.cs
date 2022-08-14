using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db) :base(db)
        {
            
        }      

        public DbSet<Book>Books {get; set;}

    }
}