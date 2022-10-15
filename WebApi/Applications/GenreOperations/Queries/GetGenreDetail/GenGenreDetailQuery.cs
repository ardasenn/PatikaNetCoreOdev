using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenreDetail
{
    public class GenGenreDetailQuery
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        public int GenreId { get; set; }

        public GenGenreDetailQuery(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = appDbContext.Genres.SingleOrDefault(a => a.Id == GenreId && a.IsActive == true);
            if (genre == null) throw new InvalidOperationException("Kitap türü bulunamadı");
            return mapper.Map<GenreDetailViewModel>(genre);
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
