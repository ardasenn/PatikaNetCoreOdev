using AutoMapper;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.BookOperaitons.GetBooks;
using WebApi.Entities;
using static WebApi.BookOperaitons.CreateBook.CreateBookCommand;
using static WebApi.BookOperaitons.GetById.GetBookDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile :Profile
    {
      public MappingProfile()
      {
        CreateMap<CreateBookModel,Book>();
        CreateMap<Book,BookDetailVM>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));
        CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src => src.Genre.Name));//BooksViewModel içerisindeki genreyi şu şekilde maple diyoruz. Map from enyden maplicez nasıl yapıcaz :)
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}