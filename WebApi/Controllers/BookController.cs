using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IMapper mapper;

        public BookController(AppDbContext appDbContext,IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
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
            GetBooksQuery query = new GetBooksQuery(appDbContext,mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailVM result;
           GetBookDetailQuery query= new GetBookDetailQuery(appDbContext,mapper);
           
                
           query.BookId=id;
           GetBookDetailQueryValidator val= new GetBookDetailQueryValidator();
           val.ValidateAndThrow(query);
           result=query.Handle();           
            return Ok(result);
        }
        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(appDbContext,mapper);
           
            
                command.Model = newBook;
                CreateBookCommandValidator validator=new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);//buradaki olası hatayı yazdığımı kod yakalıyor.
                // if(!result.IsValid){
                //     foreach (var item in result.Errors)
                //     {
                //         Console.WriteLine("ÖZellik" + item.PropertyName+" - error Message: "+item.ErrorMessage);
                //     }
                    
                // }
                // else
                command.Handle();

            
            // catch (System.Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(appDbContext);
            
            
                UpdateBookCommandValidator val= new UpdateBookCommandValidator();
                command.Model = updatedBook;
                val.ValidateAndThrow(command);
                command.Handle(id);            
            
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(appDbContext);
                command.Handle(id);         
            
            return Ok();
        }
    }
}