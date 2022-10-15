using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using WebApi.Applications.GenreOperations.Queries.GetGenres;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQueryTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public GetGenresQueryTest(CommonTextFixture textFixture)
        {
            context = textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Fact]
        public void WhenWeWantToGet_Books_ShouldBeReturns()
        {
            GetGenresQuery query = new(context, mapper);
            FluentActions.Invoking(() => query.Handle()).Should().NotBeNull();
        }
    }
}
