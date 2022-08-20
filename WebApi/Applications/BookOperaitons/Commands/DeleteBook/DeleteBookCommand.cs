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
        private readonly AppDbContext dbContext;

        public DeleteBookCommand(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Handle(int id)
        {
              var book = dbContext.Books.SingleOrDefault(a=>a.Id == id);
             if(book is  null) throw new InvalidOperationException("Böyle bir kitap yok zaten eşşek");
             dbContext.Books.Remove(book); 
             dbContext.SaveChanges();
        }
    }
}