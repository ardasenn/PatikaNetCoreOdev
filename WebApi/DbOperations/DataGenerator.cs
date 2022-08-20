using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

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
                context.Authors.AddRange(
                   new Author
                   {
                       AuthorId=1,
                       FirstName = "Arda",
                       LastName = "Şen",
                       BirthDate = DateTime.Parse("08-07-1996")
                   },
                    new Author
                    {
                        AuthorId = 2,
                        FirstName = "Nurgül",
                        LastName = "bla bla",
                        BirthDate = DateTime.Parse("10-06-1997"),
                    },
                     new Author
                     {
                         AuthorId = 3,
                         FirstName = "Zikriye",
                         LastName = "Ürkmez",
                         BirthDate = DateTime.Parse("01-01-1995"),
                     }
                   );
                context.Genres.AddRange(
                    new Genre
                    { 
                        Name="Personal Growth"
                    },
                    new Genre
                    { 
                        Name="Science Finction"
                    },
                    new Genre
                    { 
                        Name="Romance"
                    }
                );
                context.Books.AddRange(
                new Book
                    {
                        Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12),
                        AuthorId = 1
                    },
                new Book
                {
                    Id = 2,
                    Title = "Herland",
                    GenreId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23),
                    AuthorId = 2

                },
                new Book
                {
                    Id = 3,
                    Title = "Dune",
                    GenreId = 2,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 21),
                    AuthorId = 3
                });
                               

             context.SaveChanges(); // e bunu tetiklemekiçin  program cs'e gititk
             // Author author = context.Authors.SingleOrDefault(a => a.AuthorId == 1);
             // author.Books = context.Books.Where(a => a.AuthorId == author.AuthorId).ToList();
             //context.SaveChanges();
            }
        }
    }
}