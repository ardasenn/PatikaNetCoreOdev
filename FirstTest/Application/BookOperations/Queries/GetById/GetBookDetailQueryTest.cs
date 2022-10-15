using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperaitons.GetById;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.BookOperations.Queries.GetById
{
   
    public class GetBookDetailQueryTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        public GetBookDetailQueryTest(CommonTextFixture textFixture)
        {
            dbContext=textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Theory]
        [InlineData(1)]
        public void WhenWeWantToGet_Book_ShouldBeReturnBook(int id)
        {
            GetBookDetailQuery query = new(dbContext, mapper);
            query.BookId = id;
            FluentActions.Invoking(() => query.Handle()).Should().NotBeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void WhenNotExistBookGiven_InvalidOperation_ShouldBeReturnBook(int id)
        {
            GetBookDetailQuery query = new(dbContext, mapper);
            query.BookId = id;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("böyle bir kitap zaten yok len");
        }
    }
}
