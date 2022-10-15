using AutoMapper;
using FirstTest.TestSetup;
using FluentAssertions;
using System;
using WebApi.Applications.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;
using Xunit;

namespace FirstTest.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTest : IClassFixture<CommonTextFixture>
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public UpdateGenreCommandTest(CommonTextFixture textFixture)
        {
            db = textFixture.Context;
            mapper = textFixture.Mapper;
        }
        [Theory]
        [InlineData( 4)]
        [InlineData( 5)]        
        public void WhenNotExistGenresAreGiven_InvalidOperation_ShouldBeReturnError( int genreId)
        {
            UpdateGenreCommand cmd = new(db, genreId) { Model = new UpdateGenreModel() { Name = "bir şeyler", IsActive = true } };
            FluentActions.Invoking(() => cmd.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap türü yok");
        }

        [Theory]
        [InlineData(1, "Romance")]
        [InlineData(2, "Personal Growth")]
        [InlineData(3, "Science Finction")]
        public void WhenExistGenreNamesAreGiven_InvalidOperation_ShouldBeReturnError(int genreId,string name)
        {
            UpdateGenreCommand cmd = new(db, genreId) { Model = new UpdateGenreModel() { Name = name, IsActive = true } };
            FluentActions.Invoking(() => cmd.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Aynı isimli bir kitap türü zaten mevcut");
        }
    }
}
