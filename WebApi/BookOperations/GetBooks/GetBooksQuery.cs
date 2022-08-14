using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperaitons.GetBooks
{
    public class GetBooksQuery
    {
        private readonly AppDbContext appDbContext;

        public GetBooksQuery(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public List<BooksViewModel>  Handle()
        {
          var booklist= appDbContext.Books.OrderBy(a=>a.Id).ToList();
          List<BooksViewModel>vm=new List<BooksViewModel>();
          foreach (var item in booklist)
          {
            vm.Add(new BooksViewModel(){
                Title=item.Title,
                Genre=((GenreEnum)item.GenreId).ToString(),
                PublishDate=item.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount=item.PageCount
            });
          }
          return vm;
        }

    }
    public class BooksViewModel
    {
        
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount {get; set;}

        public string PublishDate { get; set; }
    }

}
