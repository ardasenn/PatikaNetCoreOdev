using FirstTest.TestSetup;
using FluentAssertions;
using WebApi.Applications.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext db;
        
        public DeleteGenreCommandValidatorTest(CommonTextFixture textFixture)
        {
            db = textFixture.Context;           
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            DeleteGenreCommand cmd = new(db);
            cmd.GenreId = id;
            DeleteGenreCommandValidator val = new();
            var result = val.Validate(cmd);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Theory]
        [InlineData(50)]
        [InlineData(1)]

        public void WhenValidInputsAreGiven_Validator_ShouldBeNull(int id)
        {
            DeleteGenreCommand cmd = new(db);
            cmd.GenreId = id;
            DeleteGenreCommandValidator val = new();
            var result = val.Validate(cmd);
            result.Errors.Count.Should().Be(0);

        }
    }
}
