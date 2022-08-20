using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly AppDbContext db;

        public int GenreId { get; set; }
        public DeleteGenreCommand(AppDbContext db)
        {
            this.db = db;
        }

        public void Handle()
        {
            var genre = db.Genres.SingleOrDefault(a => a.Id == GenreId);
            if (genre is null) throw new InvalidOperationException("Kitap türü bulunamadı");
            db.Genres.Remove(genre);
            db.SaveChanges();
        }
    }
}
