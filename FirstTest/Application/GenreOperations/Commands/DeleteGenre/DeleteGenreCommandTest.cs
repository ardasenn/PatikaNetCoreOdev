using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.BookOperaitons.DeleteBook;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext context;

        public DeleteGenreCommandTest(CommonTextFixture textFixture)
        {
            context = textFixture.Context;
        }
        [Theory]
        [InlineData(5)]
        [InlineData(100)]
        public void WhenGenreIfNotExist_InvalidOperationException_ShouldBeReturn(int id)

        {
            DeleteGenreCommand cmd = new DeleteGenreCommand(context);
            cmd.GenreId = id;
            FluentActions.Invoking(() => cmd.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenInputIsValid_Genre_ShouldBeDelete(int id)

        {
            DeleteGenreCommand cmd = new DeleteGenreCommand(context);
            cmd.GenreId = id;
            FluentActions.Invoking(() => cmd.Handle()).Invoke();

            var book = context.Books.SingleOrDefault(a => a.Id == cmd.GenreId);
            book.Should().BeNull();
        }
    }
}
