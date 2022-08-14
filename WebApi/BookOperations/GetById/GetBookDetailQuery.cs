using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperaitons.GetById
{
    public class GetBookDetailQuery
    {
        public int BookId {get; set;}
        private readonly AppDbContext dbContext;

        public GetBookDetailQuery(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public BookDetailVM Handle()
        {
            var book= dbContext.Books.Where(a => a.Id == BookId).SingleOrDefault();
            if(book is null) throw new InvalidOperationException("böyle bir kitap zaten yok len");
            BookDetailVM vm=new BookDetailVM();
            vm.Title=book.Title;
            vm.PageCount=book.PageCount;
            vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy");
            vm.Genre=((GenreEnum)book.GenreId).ToString();
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