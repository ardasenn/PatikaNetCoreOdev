using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperaitons.DeleteBook
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }
        private readonly IAppDbContext dbContext;

        public DeleteBookCommand(IAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Handle()
        {
              var book = dbContext.Books.SingleOrDefault(a=>a.Id == Id);
             if(book is  null) throw new InvalidOperationException("Böyle bir kitap yok zaten eşşek");
             dbContext.Books.Remove(book); 
             dbContext.SaveChanges();
        }
    }
}