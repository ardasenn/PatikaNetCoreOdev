using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperaitons.GetBooks;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQueryTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public GetBooksQueryTest(CommonTextFixture textFixture)
        {
            db = textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Fact]
        public void WhenWeWantToGet_Books_ShouldBeReturns()
        {
            GetBooksQuery query = new(db, mapper);
            FluentActions.Invoking(()=>query.Handle()).Should().NotBeNull();
        }
    }
}
