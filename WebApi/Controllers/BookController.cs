using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperaitons.CreateBook;
using WebApi.BookOperaitons.DeleteBook;
using WebApi.BookOperaitons.GetBooks;
using WebApi.BookOperaitons.GetById;
using WebApi.BookOperaitons.UpdateBook;
using WebApi.DbOperations;
using static WebApi.BookOperaitons.CreateBook.CreateBookCommand;
using static WebApi.BookOperaitons.GetById.GetBookDetailQuery;
using static WebApi.BookOperaitons.UpdateBook.UpdateBookCommand;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        // private static List<Book> Booklist = new List<Book>()
        // {
        //     new Book{
        //         Id=1,
        //         Title="Lean Startup",
        //         GenreId=1,//Personal Growth
        //         PageCount=200,
        //         PublishDate = new DateTime(2001,06,12)
        //     },
        //     new Book{
        //         Id=2,
        //         Title="Herland",
        //         GenreId=2,//Personal Growth
        //         PageCount=250,
        //         PublishDate = new DateTime(2010,05,23)
        //     },
        //     new Book{
        //         Id=3,
        //         Title="Dune",
        //         GenreId=2,//Personal Growth
        //         PageCount=540,
        //         PublishDate = new DateTime(2001,12,21)
        //     }
        // };
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(appDbContext);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailVM result;
           GetBookDetailQuery query= new GetBookDetailQuery(appDbContext);
            try
            {
                
           query.BookId=id;
           result=query.Handle();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(appDbContext);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(appDbContext);
            try
            {
                command.Model = updatedBook;
                command.Handle(id);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(appDbContext);
            try
            {

                command.Handle(id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}