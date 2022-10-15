using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperaitons.CreateBook;
using Xunit;

namespace FirstTest.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTest : IClassFixture<CommonTextFixture>
    {
        [Theory]
        [InlineData("Lord Of Thhe Rings",0,0)]
        [InlineData("Lord Of Thhe Rings", 0, 1)]
        [InlineData("", 0, 0)]
        [InlineData("", 10, 0)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 100, 0)]
        [InlineData("Lord", 0, 0)]
        [InlineData(" ", 100, 2)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId)
        {
            //arrange
            CreateBookCommand cmd = new CreateBookCommand(null, null);
            cmd.Model=new CreateBookCommand.CreateBookModel()
            {
                Title=title,PageCount=pageCount,PublishDate=DateTime.Now.Date.AddYears(-1),GenreId=genreId
            };
            //act
            CreateBookCommandValidator val = new CreateBookCommandValidator();
            var result=val.Validate(cmd);
            //aserts
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGıven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateBookCommand cmd = new CreateBookCommand(null, null);
            cmd.Model = new CreateBookCommand.CreateBookModel()
            {
                Title = "Hobbit",
                PageCount = 350,
                PublishDate = DateTime.Now.Date,
                GenreId = 1
            };
            //act
            CreateBookCommandValidator val = new CreateBookCommandValidator();
            var result = val.Validate(cmd);
            //aserts
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGıven_Validator_ShouldBeReturnError()
        {
            //arrange
            CreateBookCommand cmd = new CreateBookCommand(null, null);
            cmd.Model = new CreateBookCommand.CreateBookModel()
            {
                Title = "Hobbit",
                PageCount = 350,
                PublishDate = DateTime.Now.Date.AddYears(-2),
                GenreId = 1
            };
            //act
            CreateBookCommandValidator val = new CreateBookCommandValidator();
            var result = val.Validate(cmd);
            //aserts
            result.Errors.Count.Should().Be(0);
        }
    }
}
