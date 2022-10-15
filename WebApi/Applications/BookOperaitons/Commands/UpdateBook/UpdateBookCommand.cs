using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperaitons.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model {get; set;}
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateBookCommand(IAppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void Handle(int id)
        {
            var book = dbContext.Books.SingleOrDefault(a=>a.Id == id);
            if(book is  null) throw new InvalidOperationException("Böyle bir kitap yok");
            mapper.Map(Model, book);
            dbContext.Books.Update(book);
            dbContext.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title {get; set;}
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }

        }
    }
}