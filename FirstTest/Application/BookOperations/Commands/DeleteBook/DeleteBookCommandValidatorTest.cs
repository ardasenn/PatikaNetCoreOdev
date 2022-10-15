using FirstTest.TestSetup;
using FluentAssertions;
using System;

using System.Linq;
using WebApi.Applications.BookOperaitons.Commands.DeleteBook;
using WebApi.BookOperaitons.DeleteBook;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext context;

        public DeleteBookCommandValidatorTest(CommonTextFixture textFixture)
        {
            context = textFixture.Context;
        }
        
        [Theory]
        [InlineData(0)]        
        [InlineData(-10)]
        
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteBookCommand cmd = new(context);
            cmd.Id=id;
            DeleteBookCommandValidator val=new();
            var result=val.Validate(cmd);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Theory]
        [InlineData(50)]        
        [InlineData(1)]
        
        public void WhenValidInputsAreGiven_Validator_ShouldBeNull(int id)
        {
            DeleteBookCommand cmd = new(context);
            cmd.Id=id;
            DeleteBookCommandValidator val=new();
            var result=val.Validate(cmd);
            result.Errors.Count.Should().Be(0);

        }
    }
}
