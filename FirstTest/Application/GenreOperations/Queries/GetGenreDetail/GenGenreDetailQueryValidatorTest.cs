using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GenGenreDetailQueryValidatorTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        public GenGenreDetailQueryValidatorTest(CommonTextFixture textFixture)
        {
            dbContext = textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GenGenreDetailQuery query = new(dbContext, mapper);
            query.GenreId = id;
            GenGenreDetailQueryValidator val = new();
            var result = val.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNull(int id)
        {
            GenGenreDetailQuery query = new(dbContext, mapper);
            query.GenreId = id;
            GenGenreDetailQueryValidator val = new();
            var result = val.Validate(query);
            result.Errors.Count.Should().Be(0);
        }
    }
}
