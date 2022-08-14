using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        //bu yapı in memory kullanmamız için gerekliydi o yüzden ekledik
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Books.Any()) return;
                context.Books.AddRange(new Book
                {
                    Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,//Personal Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
            new Book
            {
                Id = 2,
                Title = "Herland",
                GenreId = 2,//Personal Growth
                PageCount = 250,
                PublishDate = new DateTime(2010, 05, 23)
            },
            new Book
            {
                Id = 3,
                Title = "Dune",
                GenreId = 2,//Personal Growth
                PageCount = 540,
                PublishDate = new DateTime(2001, 12, 21)
            }
             );
             context.SaveChanges(); // e bunu tetiklemekiçin  program cs'e gititk
            }
        }
    }
}