using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly AppDbContext db;

        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(AppDbContext db)
        {
            
            this.db = db;
        }

        public void Handle()
        {
            var genre = db.Genres.SingleOrDefault(a => a.Name == Model.Name);
            if (genre != null) throw new InvalidOperationException("Kitap türü zaten mevcut");

            genre = new Genre();
            genre.Name = Model.Name;
            db.Add(genre);
            db.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
