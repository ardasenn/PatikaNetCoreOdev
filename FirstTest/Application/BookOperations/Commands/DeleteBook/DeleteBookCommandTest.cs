
using FirstTest.TestSetup;
using FluentAssertions;
using System;

using System.Linq;

using WebApi.BookOperaitons.DeleteBook;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext context;

        public DeleteBookCommandTest(CommonTextFixture textFixture)
        {
            context = textFixture.Context;
        }
        [Theory]
        [InlineData(5)]
        [InlineData(100)]
        public void WhenBookIfNotExist_InvalidOperationException_ShouldBeReturn(int id)

        {
            DeleteBookCommand cmd = new DeleteBookCommand(context);
            cmd.Id = id;
            FluentActions.Invoking(() => cmd.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap yok zaten eşşek");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenInputIsValid_Book_ShouldBeDelete(int id)

        {
            DeleteBookCommand cmd = new DeleteBookCommand(context);
            cmd.Id = id;
            FluentActions.Invoking(() => cmd.Handle()).Invoke();

            var book = context.Books.SingleOrDefault(a => a.Id == cmd.Id);
            book.Should().BeNull();
        }

    }
}
