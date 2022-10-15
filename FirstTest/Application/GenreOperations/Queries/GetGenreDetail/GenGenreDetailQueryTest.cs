using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.BookOperaitons.GetById;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GenGenreDetailQueryTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        public GenGenreDetailQueryTest(CommonTextFixture textFixture)
        {
            dbContext = textFixture.Context;
            mapper = textFixture.Mapper;
        }

        [Theory]
        [InlineData(1)]
        public void WhenWeWantToGet_Genre_ShouldBeReturnBook(int id)
        {
            GenGenreDetailQuery query = new(dbContext, mapper);
            query.GenreId = id;
            FluentActions.Invoking(() => query.Handle()).Should().NotBeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void WhenNotExistGenreGiven_InvalidOperation_ShouldBeReturnBook(int id)
        {
            GenGenreDetailQuery query = new(dbContext, mapper);
            query.GenreId = id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı");
        }
    }
}
