using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.BookOperaitons.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBookCommand(IAppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        
        public void Handle(){
            var book = dbContext.Books.SingleOrDefault(a=>a.Title == Model.Title);
            if(book is not null)
             throw new InvalidOperationException("Kitap zaten mevcut");   
            
            book=mapper.Map<Book>(Model); //new Book();
            // book.Title=Model.Title;
            // book.PublishDate=Model.PublishDate;
            // book.PageCount=Model.PageCount;
            // book.GenreId=Model.GenreId;
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

        }
        public class CreateBookModel
        {
            public string Title {get; set;}
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}