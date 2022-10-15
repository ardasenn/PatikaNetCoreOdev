using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperaitons.GetById
{
    public class GetBookDetailQuery
    {
        public int BookId {get; set;}
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public GetBookDetailQuery(IAppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public BookDetailVM Handle()
        {
            var book= dbContext.Books.Include(a=>a.Genre).Where(a => a.Id == BookId).SingleOrDefault();
            if(book is null) throw new InvalidOperationException("böyle bir kitap zaten yok len");
            BookDetailVM vm= mapper.Map<BookDetailVM>(book); //new BookDetailVM();
            // vm.Title=book.Title;
            // vm.PageCount=book.PageCount;
            // vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy");
            // vm.Genre=((GenreEnum)book.GenreId).ToString();
            return vm;
        }
        public class BookDetailVM
        {           
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount {get; set;}

        public string PublishDate { get; set; }
        }
    }
}