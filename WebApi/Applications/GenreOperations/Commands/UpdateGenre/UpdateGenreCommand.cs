using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IAppDbContext db;

        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }
        public UpdateGenreCommand(IAppDbContext db, int genreId)
        {
            this.db = db;
            GenreId = genreId;
        }

        public void Handle()
        {
            var genre = db.Genres.SingleOrDefault(a => a.Id == GenreId);
            if (genre == null) throw new InvalidOperationException("Böyle bir kitap türü yok");
            if (db.Genres.Any(a => a.Name.ToLower() == Model.Name.ToLower() && a.Id != GenreId))
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");
            genre.Name = Model.Name.Trim() == string.Empty ? genre.Name : Model.Name; // boş gelrise var adını yazdır
            genre.IsActive=Model.IsActive;
            db.Genres.Update(genre);
            db.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
