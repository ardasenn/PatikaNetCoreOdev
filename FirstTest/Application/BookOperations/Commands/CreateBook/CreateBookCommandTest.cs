using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperaitons.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.BookOperaitons.CreateBook.CreateBookCommand;

namespace FirstTest.Application.BookOperations.Commands.CreateCook
{
    public class CreateBookCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public CreateBookCommandTest(CommonTextFixture textFixture)
        {
            context=textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrange
            var book = new Book()
            {
                Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100,
                PublishDate = new DateTime(1990, 01, 01),
                GenreId = 1
            };
            context.Books.Add(book);
            context.SaveChanges();

            CreateBookCommand cmd = new CreateBookCommand(context, mapper);
            cmd.Model = new CreateBookModel()
            {
                Title = book.Title
            };
            //Act & Assert 
            FluentActions.Invoking(() => cmd.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");

            
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
           
            CreateBookCommand cmd = new CreateBookCommand(context, mapper);
            cmd.Model = new CreateBookModel()
            {
                Title = "Yüzük kardeşliği", PageCount = 100, PublishDate = DateTime.Now.AddYears(-200)
            };
            //Act
            FluentActions.Invoking(() => cmd.Handle()).Invoke();

            //Assert
            var book = context.Books.SingleOrDefault(a => a.Title == cmd.Model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(cmd.Model.PageCount);
            book.PublishDate.Should().Be(cmd.Model.PublishDate);
            book.GenreId.Should().Be(cmd.Model.GenreId);
            

        }
    }
}
