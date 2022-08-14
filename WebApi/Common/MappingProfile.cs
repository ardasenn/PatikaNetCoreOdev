using AutoMapper;
using WebApi.BookOperaitons.GetBooks;
using static WebApi.BookOperaitons.CreateBook.CreateBookCommand;
using static WebApi.BookOperaitons.GetById.GetBookDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile :Profile
    {
      public MappingProfile()
      {
        CreateMap<CreateBookModel,Book>();
        CreateMap<Book,BookDetailVM>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));//BooksViewModel içerisindeki genreyi şu şekilde maple diyoruz. Map from enyden maplicez nasıl yapıcaz :)
      }
    }
}