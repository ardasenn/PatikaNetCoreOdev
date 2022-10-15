using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public GetGenresQuery(IAppDbContext appDbContext,IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var gernes = appDbContext.Genres.Where(a => a.IsActive == true).OrderBy(a=>a.Id);
            List<GenresViewModel> genrelist= mapper.Map<List<GenresViewModel>>(gernes);
            return genrelist;
        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
